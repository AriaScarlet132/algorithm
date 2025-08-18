from service.app.models.decision_strategy import DecisionStrategy
from service.app.services.register_service import get_pile_map, register_grades, get_grades, get_static_road, get_strategy


def make_decision(params: dict):
    grades = params.get("grades", [])
    if grades:
        register_grades(grades)
    else:
        grades = get_grades()

    if not grades:
        # 如果没有从Redis获取到grades，则返回错误
        raise ValueError("没有相关的养护规定值, 请先向系统注册养护规定值, 或作为参数传入")

    route_info = get_static_road(params.get("线路代码", ""), params.get("路线名称", ""))
    if not route_info:
        # 如果没有从Redis获取到路线信息，则返回错误
        raise ValueError(f"没有找到线路的静态数据, 请先向系统注册线路静态数据")
    
    
    """
    每一段桩号 都要根据ID去静态信息找到对应的{路面类}和{技术等} 添加到动态数据里
    """
    route_no = params.get("线路代码", "")
    route_name = params.get("路线名称", "")
    lanes = params["内容"]

    lane_result_list = [] # 用来存放每个车道的养护策略结果

    # 第一轮遍历 记录所有出现过的{路面类}
    road_type_set = set()
    for lane in lanes:
        lane_no = lane["车道编号"]
        lane_direction = lane["方向"]

        pile_map = get_pile_map(route_no, route_name, lane_no, lane_direction)
        if not pile_map:
            raise ValueError(f"没有找到车道 {lane_no} 的桩号信息, 请先向系统注册线路静态数据")
        
        for pile in lane["桩号构成"]:
            pile_id = pile["ID"]
            if pile_id not in pile_map:
                raise ValueError(f"桩号 {pile_id} 在车道 {lane_no} 中不存在, 请检查静态数据")
            
            static_pile = pile_map[pile_id]
            pile["路面类"] = static_pile.get("路面类", "")
            pile["技术等"] = static_pile.get("技术等", "")
            
            road_type_set.add(static_pile.get("路面类", ""))

    # 然后根据路面类 初始化决策树对象
    strategy_map = {}
    for road_type in road_type_set:
        strategy = get_strategy(road_type)
        if not strategy:
            raise ValueError(f"没有找到路面类型 {road_type} 的养护策略, 请先向系统注册养护策略")
        ds = DecisionStrategy(strategy)
        strategy_map[road_type] = ds

    # 第二轮遍历 进行决策
    for lane in lanes:
        rec_list = [] # 用来存放每个车道的养护策略汇总结果
        pile_result_list = [] # 用来存放每个桩号的养护策略结果
        for pile in lane["桩号构成"]:
            road_type = pile.get("路面类", "")
            ds = strategy_map.get(road_type)
            rec = ds.make_decision(pile, grades)
            pile_result_list.append({
                "ID": pile["ID"],
                "code": int(rec["code"]) if rec else None,
            })
            rec_list.append(int(rec["code"]) if rec else None)
        
        lane_result_list.append({
            "车道编号": lane["车道编号"],
            "方向": lane["方向"],
            "维修策略": rec_list,
            "策略结果": pile_result_list
        })

    return lane_result_list
      


            


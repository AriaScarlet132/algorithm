import json
from service.app.models.static_road import RouteInfo
from service.app.utils.redis_utils import get, save


def register_static_road(road_data: dict) -> None:
    """
    注册静态道路信息到Redis
    :param road_data: 包含线路代码、路线名称和内容的字典
    """
    route_info = RouteInfo(**road_data)
    save(f"{route_info.线路代码}_{route_info.路线名称}", route_info.model_dump_json(), expire=86400 * 365)
    for lane in route_info.内容:
        lane_no = lane.车道编号
        lane_direction = lane.方向
        lane_key = f"{route_info.线路代码}_{route_info.路线名称}_{lane_no}_{lane_direction}"
        pile_map = {item.ID: item.model_dump() for item in lane.桩号构成}
        save(lane_key, json.dumps(pile_map, ensure_ascii=False), expire=86400 * 365)

    
def register_strategy(strategy_data: dict) -> None:
    road_type = strategy_data.get("road_type", "")
    if not road_type:
        raise ValueError("道路类型不能为空")
    save(f"{road_type}", json.dumps(strategy_data), expire=86400 * 365)


def register_grades(grades: list) -> None:
    """
    注册养护规定值到Redis
    :param grades: 养护规定值列表
    """
    save("grades", json.dumps(grades), expire=86400 * 365)


def get_static_road(线路代码: str, 路线名称: str) -> RouteInfo:
    """
    获取静态道路信息
    :param 线路代码: 线路代码
    :param 路线名称: 路线名称
    :return: RouteInfo对象
    """
    route_key = f"{线路代码}_{路线名称}"
    route_info = get(route_key)
    if not route_info:
        return None
    try:
        route_info = json.loads(route_info)
        return RouteInfo(**route_info)
    except json.JSONDecodeError:
        raise ValueError(f"无法解析静态道路信息: {route_key}")


def get_grades() -> list:
    """
    获取养护规定值
    :return: 养护规定值列表
    """
    grades = get("grades")
    return json.loads(grades) if grades else []


def get_strategy(road_type: str) -> dict:
    """
    获取道路类型策略
    :return: 道路类型策略字典
    """
    strategy = get(road_type)
    return json.loads(strategy) if strategy else {}


def get_pile_map(线路代码: str, 路线名称: str, 车道编号: int, 方向: str) -> dict:
    """
    获取指定车道的桩号映射
    :param 线路代码: 线路代码
    :param 路线名称: 路线名称
    :param 车道编号: 车道编号
    :param 方向: 方向
    :return: 桩号映射字典
    """
    lane_key = f"{线路代码}_{路线名称}_{车道编号}_{方向}"
    pile_map_json = get(lane_key)
    return json.loads(pile_map_json) if pile_map_json else {}
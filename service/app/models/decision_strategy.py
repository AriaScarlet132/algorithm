# -*- coding: utf-8 -*-
import uuid

class DecisionStrategy:
    def __init__(self, strategy):
        if not strategy:
            raise ValueError("Strategy cannot be None or empty")
        if 'rules' not in strategy or 'road_type' not in strategy or 'name' not in strategy:
            raise ValueError("Strategy must have rules, name and road_type attributes")
        if not isinstance(strategy['rules'], list):
            raise ValueError("Strategy rules must be a list")
        
        self.rules = strategy['rules']
        self.road_type = strategy['road_type']
        self.name = strategy['name']
        self.id = uuid.uuid4()
        

    def make_decision(self, params: dict, grades: list):
        """
        1. 根据参数匹配情况, 先进行第一层决策
        2. 根据道路等级, 进行第二层决策

        参数匹配情况, 是需要根据rule需要的字段来提取的, 所以要遍历rule的conditions, 通过key来提取params的值再去匹配
        """
        road_level_str = params.get("技术等", "")
        road_level = self._get_road_level(road_level_str)
        for rule in self.rules:
            if self._evaluate_rule(road_level, rule, params, grades):
                # 如果规则匹配成功，返回推荐的养护策略
                recommendations = rule.get("recommendation", [])
                for rec in recommendations:
                    if rec["road_level"] == "all" or rec["road_level"] == "全部":
                        return rec
                    if road_level_str in rec["road_level"]:
                        return rec
        return None
    
    # 根据技术等级获取道路等级
    def _get_road_level(self, tech_level: str) -> int:
        if tech_level == "高速":
            return 0
        elif tech_level == "一级":
            return 1
        elif tech_level == "二级":
            return 2
        elif tech_level == "三级":
            return 3
        elif tech_level == "四级":
            return 4
        else:
            raise ValueError(f"Unknown technical level: {tech_level}")

    # 根据道路等级和指标名称获取对应的阈值  
    def _get_grade_by_indicator(self, road_level, indicator, grades: list) -> float:
        for grade in grades:
            if int(grade["road_level"]) == road_level:
                for key, value in grade.items():
                    if (indicator + "_").lower() in key.lower():
                        try:
                            num = float(value)
                        except ValueError:
                            return None
                        return num
                break
        return None

    # 评估单条规则是否匹配
    def _evaluate_rule(self, road_level, rule, params: dict, grades: list) -> bool:
        conditions = rule.get("conditions", {})
        for indicator, condition in conditions.items():
            if condition == "":
                continue
            # 如果参数里没有该指标 直接返回False
            if indicator not in params:
                return False
            
            # 如果参数里对应指标的值不合法 直接返回False
            value = params[indicator]
            if value == "" or value is None:
                return False
            
            # 如果没有该指标的阈值 不作判断
            threshold = self._get_grade_by_indicator(road_level, indicator, grades)
            if threshold is None:
                continue

            # 判断逻辑
            if condition == "符合":
                if value < threshold:
                    return False
            elif condition == "不符合":
                if value >= threshold:
                    return False
            else:
                return False
        return True
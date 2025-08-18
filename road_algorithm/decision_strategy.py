# -*- coding: utf-8 -*-
import uuid

class DecisionStrategy:
    def __init__(self, strategy, grades: list):
        if not strategy:
            raise ValueError("Strategy cannot be None or empty")
        if not grades or not isinstance(grades, list):
            raise ValueError("Grades must be a non-empty list")
        if 'rules' not in strategy or 'road_type' not in strategy or 'name' not in strategy:
            raise ValueError("Strategy must have rules, name and road_type attributes")
        if not isinstance(strategy['rules'], list):
            raise ValueError("Strategy rules must be a list")
        self.rules = strategy['rules']
        self.road_type = strategy['road_type']
        self.name = strategy['name']
        self.grades = grades
        self.id = uuid.uuid4()

    def make_decision(self, params: dict):
        road_level_str = params.get("技术等", "")
        road_level = self._get_road_level(road_level_str)
        for rule in self.rules:
            if self._evaluate_rule(road_level, rule, params):
                recommendations = rule.get("recommendation", [])
                for rec in recommendations:
                    if rec["road_level"] in ("all", "全部"):
                        return rec
                    if road_level_str in rec["road_level"]:
                        return rec
        return None

    def _get_road_level(self, tech_level: str) -> int:
        mapping = {"高速":0, "一级":1, "二级":2, "三级":3, "四级":4}
        if tech_level not in mapping:
            raise ValueError(f"Unknown technical level: {tech_level}")
        return mapping[tech_level]

    def _get_grade_by_indicator(self, road_level, indicator) -> float:
        for grade in self.grades:
            if int(grade["road_level"]) == road_level:
                for key, value in grade.items():
                    if (indicator + "_").lower() in key.lower():
                        try:
                            return float(value)
                        except ValueError:
                            return None
                break
        return None

    def _evaluate_rule(self, road_level, rule, params: dict) -> bool:
        conditions = rule.get("conditions", {})
        for indicator, condition in conditions.items():
            if condition == "":
                continue
            if indicator not in params:
                return False
            value = params[indicator]
            if value in ("", None):
                return False
            threshold = self._get_grade_by_indicator(road_level, indicator)
            if threshold is None:
                continue
            if condition == "符合":
                if value < threshold:
                    return False
            elif condition == "不符合":
                if value >= threshold:
                    return False
            else:
                return False
        return True

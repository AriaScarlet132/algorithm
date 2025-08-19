# -*- coding: utf-8 -*-
from flask import Blueprint, request, jsonify, Response
import logging
import json

logger = logging.getLogger(__name__)

bp = Blueprint("api", __name__, url_prefix="/api")

@bp.route("/health", methods=["GET"]) 
def health():
    return {"status":"ok"}


@bp.route("/decision", methods=["POST"]) 
def decision():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.decision_service import make_decision
        success = True
        result_list = make_decision(data)
        if not result_list:
            return jsonify({"error": "没有相关的决策结果"}), 400
        for result in result_list:
            if not result.get("维修策略", []) or None in result.get("维修策略"):
                success = False
        resp = {
            "结果": "成功" if success else "失败",
            "线路代码": data.get("线路代码", ""),
            "路线名称": data.get("路线名称", ""),
            "内容": result_list
        }
        logger.info("Decision response: %s", resp)
        logger.info("Decision response JSON: %s", jsonify(resp).get_data(as_text=True))
        
        # 使用自定义 JSON 序列化保持字典顺序
        json_str = json.dumps(resp, ensure_ascii=False, separators=(',', ':'))
        return Response(json_str, content_type='application/json; charset=utf-8'), 200
    except Exception as e:
        logger.error("Decision error: %s", e, exc_info=True)
        error_resp = {"结果": "失败"}
        json_str = json.dumps(error_resp, ensure_ascii=False, separators=(',', ':'))
        return Response(json_str, content_type='application/json; charset=utf-8'), 500


@bp.route("/register/static_road", methods=["POST"])
def register_static_road():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.register_service import register_static_road as reg_static_road
        reg_static_road(data)
        return jsonify({"status": f"道路[{data["线路代码"]}]静态数据注册成功"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@bp.route("/register/strategy", methods=["POST"])
def register_strategy():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.register_service import register_strategy as reg_strategy
        reg_strategy(data)
        return jsonify({"status": "养护工法策略注册成功"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@bp.route("/register/grades", methods=["POST"])
def register_grades():
    data = request.get_json(force=True, silent=True) or {}
    if "road_grades" not in data or not data["road_grades"]:
        return jsonify({"error": "请检查传入的数据里有没有 road_grades !"}) , 400
    try:
        from app.services.register_service import register_grades as reg_grades
        reg_grades(data["road_grades"])
        return jsonify({"status": "养护规定值注册成功"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    

def register_routes(app):
    app.register_blueprint(bp)

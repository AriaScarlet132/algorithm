# -*- coding: utf-8 -*-
from flask import Blueprint, request, jsonify

bp = Blueprint("api", __name__, url_prefix="/api")

@bp.route("/health", methods=["GET"]) 
def health():
    return {"status":"ok"}


@bp.route("/decision", methods=["POST"]) 
def decision():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.decision_service import make_decision
        result = make_decision(data)
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@bp.route("/register/static_road", methods=["POST"])
def register_static_road():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.register_service import register_static_road as reg_static_road
        reg_static_road(data)
        return jsonify({"status": "static road registered successfully"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@bp.route("/register/strategy", methods=["POST"])
def register_strategy():
    data = request.get_json(force=True, silent=True) or {}
    try:
        from app.services.register_service import register_strategy as reg_strategy
        reg_strategy(data)
        return jsonify({"status": "strategy registered successfully"}), 200
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
        return jsonify({"status": "grades registered successfully"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    

def register_routes(app):
    app.register_blueprint(bp)

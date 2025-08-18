# -*- coding: utf-8 -*-
from flask import Flask
from .core.config import get_settings
from .api.routes import register_routes
from .core.redis_client import init_redis


def create_app() -> Flask:
    settings = get_settings()
    app = Flask(__name__)
    app.config.update(
        ENV=settings.env,
        DEBUG=settings.debug,
        JSON_AS_ASCII=False
    )
    # 初始化 Redis (失败不阻塞应用启动)
    try:
        init_redis()
    except Exception as e:
        app.logger.warning(f"Redis init failed: {e}")
    register_routes(app)

    # 全局异常处理，所有 500 错误返回 JSON
    from flask import jsonify
    import traceback

    @app.errorhandler(Exception)
    def handle_exception(e):
        # 生产环境建议只返回 error，不返回详细堆栈
        response = {
            "error": "服务器异常",
            "detail": str(e),
        }
        # if app.config.get("DEBUG"):
            # response["trace"] = traceback.format_exc()
        return jsonify(response), 500

    return app

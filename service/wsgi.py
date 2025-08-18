"""WSGI 入口。支持从 .env.development / 环境变量读取端口。"""
# -*- coding: utf-8 -*-
import os
from app import create_app
from app.core.config import get_settings

app = create_app()

if __name__ == "__main__":
    settings = get_settings()
    host = os.getenv("APP_HOST", "0.0.0.0")
    app.run(host=host, port=settings.port, use_reloader=False)

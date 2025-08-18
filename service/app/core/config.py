"""应用配置加载模块。

支持 .env.development 文件（仅开发环境）来注入环境变量。
优先级: 系统环境变量 > .env.development 文件。
"""
# -*- coding: utf-8 -*-
from dataclasses import dataclass
import os
from pathlib import Path


def _load_env_file():
    """在满足条件时加载 .env.development 文件。

    逻辑:
    1. 如果 APP_ENV 未设置 -> 先尝试读取文件设值。
    2. 如果 APP_ENV 已设置且为 development -> 读取文件补全缺失变量。
    3. 其他环境不读取。
    """
    env_current = os.getenv("APP_ENV")
    need = env_current is None or env_current == "development"
    if not need:
        return
    # 向上查找 .env.development
    for parent in Path(__file__).resolve().parents:
        candidate = parent / ".env.development"
        if candidate.is_file():
            try:
                content = candidate.read_text(encoding="utf-8")
            except Exception:  # pragma: no cover - 容错
                return
            for line in content.splitlines():
                line = line.strip()
                if not line or line.startswith("#") or "=" not in line:
                    continue
                k, v = line.split("=", 1)
                # 不覆盖已存在的系统变量
                if os.getenv(k) is None:
                    os.environ[k] = v
            break


_load_env_file()

@dataclass
class Settings:
    env: str = os.getenv("APP_ENV", "production")
    debug: bool = os.getenv("APP_DEBUG", "false").lower() == "true"
    port: int = int(os.getenv("APP_PORT", "8000"))
    redis_url: str = os.getenv("REDIS_URL", "redis://localhost:6379/0")
    redis_socket_timeout: float = float(os.getenv("REDIS_SOCKET_TIMEOUT", "2"))
    redis_password: str | None = os.getenv("REDIS_PASSWORD") or None


def get_settings() -> Settings:
    return Settings()

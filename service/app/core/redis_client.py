"""Redis 客户端初始化与获取工具。"""
# -*- coding: utf-8 -*-
from __future__ import annotations
from typing import Optional
import redis
from .config import get_settings

_client: Optional[redis.Redis] = None

def init_redis():
    global _client
    if _client is not None:
        return _client
    settings = get_settings()
    _client = redis.from_url(
        settings.redis_url,
        password=settings.redis_password,
        socket_timeout=settings.redis_socket_timeout,
        decode_responses=True,
        health_check_interval=30,
    )
    try:
        _client.ping()
    except Exception as e:
        # 懒连接: 记录异常但不阻塞应用启动
        print(f"[redis] 连接失败: {e}")
    return _client


def get_redis() -> redis.Redis:
    if _client is None:
        return init_redis()
    return _client

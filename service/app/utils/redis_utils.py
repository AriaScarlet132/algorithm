
from service.app.core.redis_client import get_redis


def save(key: str, value: str, expire: int = 3600):
    """
    保存数据到Redis
    :param key: 键
    :param value: 值
    :param expire: 过期时间，单位为秒，默认1小时
    """
    redis_client = get_redis()
    redis_client.set(key, value, ex=expire)

def get(key: str) -> str:
    """
    从Redis获取数据
    :param key: 键
    :return: 值，如果不存在则返回None
    """
    redis_client = get_redis()
    value = redis_client.get(key)
    return value.decode('utf-8') if value else None
#!/bin/bash

# 路面决策系统安装脚本
# 适用于 Linux/macOS

set -e

echo "🚀 开始安装路面决策系统..."

# 检查 Python 版本
echo "📋 检查 Python 版本..."
python_version=$(python3 --version 2>&1 | awk '{print $2}' | cut -d. -f1,2)
required_version="3.10"

if [ "$(echo "$python_version >= $required_version" | bc -l)" -eq 0 ]; then
    echo "❌ 错误: 需要 Python $required_version 或更高版本，当前版本: $python_version"
    exit 1
fi

echo "✅ Python 版本检查通过: $python_version"

# 创建虚拟环境
echo "🔧 创建虚拟环境..."
python3 -m venv .venv

# 激活虚拟环境
echo "🔧 激活虚拟环境..."
source .venv/bin/activate

# 升级 pip
echo "📦 升级 pip..."
pip install --upgrade pip

# 安装依赖
echo "📦 安装项目依赖..."
pip install -e .

# 复制配置文件
echo "⚙️  配置环境..."
if [ ! -f .env.local ]; then
    cp .env.development .env.local
    echo "✅ 已创建 .env.local 配置文件"
    echo "💡 请根据需要编辑 .env.local 中的配置"
fi

# 检查 Redis 连接（可选）
echo "🔍 检查 Redis 连接..."
if command -v redis-cli &> /dev/null; then
    if redis-cli ping &> /dev/null; then
        echo "✅ Redis 连接正常"
    else
        echo "⚠️  警告: Redis 未运行，某些功能可能受限"
        echo "💡 可以运行 'redis-server' 启动 Redis 服务"
    fi
else
    echo "⚠️  警告: 未检测到 Redis，某些功能可能受限"
    echo "💡 可以通过包管理器安装 Redis: apt install redis-server 或 brew install redis"
fi

# 运行测试
echo "🧪 运行测试..."
if pip install pytest > /dev/null 2>&1; then
    if pytest -q; then
        echo "✅ 所有测试通过"
    else
        echo "⚠️  部分测试失败，但不影响基本功能"
    fi
else
    echo "⚠️  跳过测试（pytest 安装失败）"
fi

echo ""
echo "🎉 安装完成！"
echo ""
echo "📚 使用指南:"
echo "  1. 激活虚拟环境: source .venv/bin/activate"
echo "  2. 启动服务: python service/wsgi.py"
echo "  3. 访问健康检查: curl http://localhost:8100/api/health"
echo "  4. 查看完整文档: cat README.md"
echo ""
echo "🔧 配置文件: .env.local"
echo "🌐 默认端口: 8100"
echo ""

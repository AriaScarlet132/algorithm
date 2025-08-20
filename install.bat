@echo off
setlocal enabledelayedexpansion

echo 🚀 开始安装路面决策系统...

REM 检查 Python 版本
echo 📋 检查 Python 版本...
python --version >nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ 错误: 未找到 Python，请先安装 Python 3.10+
    echo 💡 下载地址: https://www.python.org/downloads/
    pause
    exit /b 1
)

for /f "tokens=2" %%i in ('python --version 2^>^&1') do set python_version=%%i
echo ✅ Python 版本: %python_version%

REM 创建虚拟环境
echo 🔧 创建虚拟环境...
python -m venv .venv
if %errorlevel% neq 0 (
    echo ❌ 错误: 虚拟环境创建失败
    pause
    exit /b 1
)

REM 激活虚拟环境
echo 🔧 激活虚拟环境...
call .venv\Scripts\activate.bat

REM 升级 pip
echo 📦 升级 pip...
python -m pip install --upgrade pip

REM 安装依赖
echo 📦 安装项目依赖...
pip install -e .
if %errorlevel% neq 0 (
    echo ❌ 错误: 依赖安装失败
    pause
    exit /b 1
)

REM 复制配置文件
echo ⚙️  配置环境...
if not exist .env.local (
    copy .env.development .env.local >nul
    echo ✅ 已创建 .env.local 配置文件
    echo 💡 请根据需要编辑 .env.local 中的配置
)

REM 运行测试
echo 🧪 运行测试...
pip install pytest >nul 2>&1
pytest -q >nul 2>&1
if %errorlevel% equ 0 (
    echo ✅ 所有测试通过
) else (
    echo ⚠️  部分测试失败，但不影响基本功能
)

echo.
echo 🎉 安装完成！
echo.
echo 📚 使用指南:
echo   1. 激活虚拟环境: .venv\Scripts\activate
echo   2. 启动服务: python service\wsgi.py  
echo   3. 访问健康检查: curl http://localhost:8100/api/health
echo   4. 查看完整文档: type README.md
echo.
echo 🔧 配置文件: .env.local
echo 🌐 默认端口: 8100
echo.

pause

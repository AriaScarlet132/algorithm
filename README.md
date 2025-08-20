# 路面决策系统

路面养护决策算法服务，基于决策树提供路面维修策略建议。

## 功能特性

- 基于动态数据和静态路面信息的智能决策
- 支持多车道、多桩号的批量处理
- Redis 缓存支持，提升性能
- RESTful API 接口，易于集成
- 完整的日志记录和错误处理

## 系统要求

- Python 3.10+
- Redis 服务器 (可选，用于缓存)

## 快速安装

### 1. 克隆项目

```bash
git clone <repository-url>
cd algorithm
```

### 2. 创建虚拟环境

```bash
# Windows
python -m venv .venv
.venv\Scripts\activate

# Linux/macOS
python -m venv .venv
source .venv/bin/activate
```

### 3. 安装依赖

```bash
# 安装基础依赖
pip install -e .

# 或者直接安装依赖包
pip install Flask>=3.0.0 redis>=5.0.0

# 安装开发依赖（可选）
pip install -e .[dev]
```

### 4. 配置环境

复制并编辑环境配置文件：

```bash
# Windows
copy .env.development .env.local

# Linux/macOS  
cp .env.development .env.local
```

编辑 `.env.local` 文件中的配置：

```dotenv
# 应用配置
APP_ENV=production
APP_DEBUG=false
APP_PORT=8100
APP_HOST=0.0.0.0

# Redis 配置（如果使用）
REDIS_URL=redis://localhost:6379/0
REDIS_PASSWORD=your_redis_password
REDIS_SOCKET_TIMEOUT=2
```

### 5. 启动服务

```bash
python service/wsgi.py
```

服务将在 `http://localhost:8100` 启动。

## API 接口

### 健康检查

```http
GET /api/health
```

### 决策接口

```http
POST /api/decision
Content-Type: application/json

{
  "线路代码": "S20",
  "路线名称": "S20外环高速（浦西段）",
  "内容": [
    {
      "车道编号": 1,
      "方向": "上行",
      "桩号构成": [
        {
          "ID": "10001",
          "其他动态数据": "..."
        }
      ]
    }
  ],
  "grades": []
}
```

### 数据注册接口

```http
# 注册静态道路数据
POST /api/register/static_road

# 注册策略数据
POST /api/register/strategy

# 注册养护规定值
POST /api/register/grades
```

## 开发模式

### 运行测试

```bash
# 安装测试依赖
pip install pytest

# 运行测试
pytest
```

### 代码结构

```text
algorithm/
├── service/
│   ├── app/
│   │   ├── api/          # API 路由
│   │   ├── core/         # 核心配置
│   │   ├── models/       # 数据模型
│   │   ├── services/     # 业务逻辑
│   │   └── utils/        # 工具函数
│   └── wsgi.py           # 应用入口
├── tests/                # 测试文件
├── doc/                  # 文档
├── pyproject.toml        # 项目配置
└── README.md
```

## 部署指南

### Docker 部署（推荐）

创建 `Dockerfile`：

```dockerfile
FROM python:3.10-slim

WORKDIR /app
COPY . .
RUN pip install -e .

EXPOSE 8100
CMD ["python", "service/wsgi.py"]
```

构建并运行：

```bash
docker build -t road-algorithm .
docker run -p 8100:8100 road-algorithm
```

### 生产环境部署

使用 Gunicorn 或 uWSGI：

```bash
# 安装 Gunicorn
pip install gunicorn

# 启动服务
gunicorn --bind 0.0.0.0:8100 --workers 4 service.wsgi:app
```

## 故障排除

### 常见问题

1. **Redis 连接失败**
   - 检查 Redis 服务是否运行
   - 验证 REDIS_URL 配置是否正确
   - 确认网络连接和防火墙设置

2. **端口占用**
   - 修改 `.env.local` 中的 `APP_PORT` 配置
   - 或使用环境变量：`APP_PORT=8080 python service/wsgi.py`

3. **依赖安装失败**
   - 升级 pip：`pip install --upgrade pip`
   - 使用国内镜像：`pip install -i https://pypi.tuna.tsinghua.edu.cn/simple/`

### 日志查看

应用日志会输出到控制台，包含详细的错误信息和调试数据。

## 贡献指南

1. Fork 项目
2. 创建功能分支 (`git checkout -b feature/new-feature`)
3. 提交更改 (`git commit -am 'Add new feature'`)
4. 推送到分支 (`git push origin feature/new-feature`)
5. 创建 Pull Request

## 许可证

[添加许可证信息]

## 联系方式

如有问题或建议，请联系项目维护者。
 
# 路面决策系统

## 主要职责

接收决策树参数，并根据实际数据计算养护策略

## 步骤

1. 根据路面等级和动态数据，进行第一轮决策分支，获取对应的策略new Strategy(strategy_code)
2. strategy内部再根据路面等级，进行第二轮决策make_decision()

## 目录结构

```text
decision_strategy.py                 # 核心决策类
examples/demo_decision_strategy.py   # 使用示例
tests/test_decision_strategy.py      # 基础单元测试（需要 pytest）
```

## 快速开始

运行示例：

```bash
python examples/demo_decision_strategy.py
```

安装测试依赖并运行测试：

```bash
pip install -U pytest
pytest -q
```

## 后续规划

- 增加指标方向配置（大于/小于型）
- 增加决策过程可解释信息（返回命中/未命中的原因）
- 与外部策略注册/管理模块集成
 
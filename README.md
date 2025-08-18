# 路面决策系统

## 主要职责

接收决策树参数，并根据实际数据计算养护策略

## 步骤

1. 根据路面等级和动态数据，进行第一轮决策分支，获取对应的策略new Strategy(strategy_code)
2. strategy内部再根据路面等级，进行第二轮决策make_decision()
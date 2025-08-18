import numpy as np


# 病害等级换算扣分分数
def grade_dp(list):  # 主桥病害换算分数
    DP = []
    for i in range(len(list)):
        if int(list[i]) == 5:
            DP.append(100)
        if int(list[i]) == 4:
            DP.append(60)
        if int(list[i]) == 3:
            DP.append(35)
        if int(list[i]) == 2:
            DP.append(15)
        if int(list[i]) == 1:
            DP.append(0)
    return DP


# 计算构件得分
def dp_points(DP):
    DP.sort(reverse=True)  # 扣分值按照降序排列
    U = []
    uy = 0
    for j in range(len(DP)):
        if j == 0:
            U.append(DP[j])
            uy = DP[j]
        else:
            uy = 0
            for k in range(len(U)):  # 计算累加项Uy
                uy = uy + U[k]
            U.append(DP[j])
            U[j] = DP[j] / 100 / np.sqrt(j + 1) * (100 - uy)
            uy = uy + U[j]

    return 100 - uy


# 城市引桥计算构件得分
def csyq_dp_points(DP):
    sum_DP = 0
    for i in range(len(DP)):
        sum_DP += DP[i]
    myu = np.zeros(len(DP))
    if sum_DP != 0:
        for i in range(len(DP)):
            myu[i] = DP[i] / sum_DP
    w = np.zeros(len(DP))
    for i in range(len(DP)):
        w[i] = 3 * myu[i] ** 3 - 5.5 * myu[i] ** 2 + 3.5 * myu[i]
    sum = 0
    for i in range(len(DP)):
        sum += DP[i] * w[i]
    return 100 - sum


# 变权分析法
def bianquan(x):
    if len(x) != 0:
        a = -0.04
        w0 = 1 / len(x)
        xmean = np.mean(x)
        wnew = np.zeros(len(x))
        wtotal = 0
        for i in range(len(x)):
            wtotal = wtotal + w0 * np.exp(a * (x[i] - xmean))

        for i in range(len(x)):
            wnew[i] = w0 * np.exp(a * (x[i] - xmean)) / wtotal

        total = 0
        for i in range(len(x)):
            total = total + wnew[i] * x[i]
    else:
        total = 0.0
    return total


def lishudu(points, w):  # 隶属度计算方法
    # 计算隶属度矩阵
    jz = []
    for i in range(len(points)):
        points[i] = round(points[i], 3)
    for i in range(len(w)):
        w[i] = float(w[i])
    for i in range(len(points)):
        if 90 <= points[i] <= 100:
            u1 = (points[i] - 90) / 10
            u2 = (100 - points[i]) / 10
            u3 = 0.0
            u4 = 0.0
            u5 = 0.0
        elif 70 < points[i] <= 90:
            u1 = 0.0
            u2 = (points[i] - 70) / 20
            u3 = (90 - points[i]) / 20
            u4 = 0.0
            u5 = 0.0
        elif 50 < points[i] <= 70:
            u1 = 0.0
            u2 = 0.0
            u3 = (points[i] - 50) / 20
            u4 = (70 - points[i]) / 20
            u5 = 0.0
        elif 35 < points[i] <= 50:
            u1 = 0.0
            u2 = 0.0
            u3 = 0.0
            u4 = (points[i] - 35) / 15
            u5 = (50 - points[i]) / 15
        else:
            u1 = 0.0
            u2 = 0.0
            u3 = 0.0
            u4 = 0.0
            u5 = 1.0
        u = [u1, u2, u3, u4, u5]
        jz.append(u)
    # 计算模糊集B
    b = []
    for i in range(5):
        data = np.ones(len(points))
        for j in range(len(data)):
            data[j] = w[j] * jz[j][i]
        nb = 0.0
        for k in range(len(data)):
            nb = nb + data[k]
        b.append(nb)
    # 计算隶属度得分
    g = [100.0, 85.0, 70.0, 40.0, 0.0]  # 定义得分集
    g = np.mat(g)
    b = np.mat(b)
    t = g * b.T
    return t[0, 0]


def point_to_grade(point):  # 根据分数换算等级
    grade = 1
    if point >= 95:
        grade = 1
    elif point < 95 and point >= 80:
        grade = 2
    elif point < 80 and point >= 60:
        grade = 3
    elif point < 60 and point >= 40:
        grade = 4
    else:
        grade = 5
    return grade


def yq_grade_dp(grade, maxgrade):  # 公路引桥计算扣分制DP
    DP = 0
    grade = int(grade)
    if maxgrade == 3:
        if grade == 1:
            DP = 0
        elif grade == 2:
            DP = 20
        elif grade == 3:
            DP = 35
    if maxgrade == 4:
        if grade == 1:
            DP = 0
        elif grade == 2:
            DP = 25
        elif grade == 3:
            DP = 40
        elif grade == 4:
            DP = 50
    if maxgrade == 5:
        if grade == 1:
            DP = 0
        elif grade == 2:
            DP = 35
        elif grade == 3:
            DP = 45
        elif grade == 4:
            DP = 60
        elif grade == 5:
            DP = 100
    return DP


def bujian_values(points, t):  # 计算部件得分方法
    return np.mean(points) - (100 - np.min(points)) / t


def weighted_avg(components):  # 计算加权平均
    total = 0
    for i in range(len(components)):
        total = total + components[i].points * float(components[i].weight)
    return total


def huise(test, std):
    x0 = np.zeros(len(test))
    w = np.zeros(len(test))
    for i in range(len(test)):
        if std[i] == 0:
            err = 0
        else:
            err = abs((test[i] - std[i]) / std[i])
        if err < 0.1:
            x0[i] = 100 - err * 100
        elif err < 0.2:
            x0[i] = 90 - (err - 0.1) * 150
        elif err < 0.3:
            x0[i] = 75 - (err - 0.2) * 200
        elif err < 0.4:
            x0[i] = 55 - (err - 0.3) * 200
        elif err > 0.4:
            x0[i] = 35 - (err - 0.4) * 200
            if x0[i] < 0:
                x0[i] = 0.1

    for i in range(int(len(x0) * 0.1 /2)):
        max_value_index = np.argmax(x0)  # 找到最大值的索引
        x0 = np.delete(x0, max_value_index)  # 删除最大值

        min_value_index = np.argmin(x0)  # 找到最大值的索引
        x0 = np.delete(x0, min_value_index)  # 删除最大值
    avg = huise_bianquan(x0, 0.1)
    ita = 0
    if len(x0) ==1:
        ita = 1
    else:
        for i in range(len(x0) - 1):
            k = x0[i + 1] - x0[i]
            ita = ita + 1 / (1 + abs(k / x0[i + 1]))
        ita = ita / (len(x0) - 1)

        """
    for i in range(len(test)-1):
        k0=std[i+1]-std[i]
        ki=test[i+1]-test[i]
        ita=ita+1/(1+abs(k0/std[i+1]-ki/x0[i+1]))
        """
    return avg * ita


def huise_bianquan(x, a):
    w0 = 1 / len(x)
    xnew = np.zeros(len(x))
    wnew = np.zeros(len(x))
    wtotal = 0
    for i in range(len(x)):
        wtotal = wtotal + w0 * x[i] ** (a - 1)

    for i in range(len(x)):
        wnew[i] = w0 * x[i] ** (a - 1) / wtotal

    total = 0
    for i in range(len(x)):
        total = total + wnew[i] * x[i]
    return total


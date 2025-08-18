from pydantic import BaseModel
from typing import List, Optional

# 第三层：桩号构成（Pile Structure）
class PileItem(BaseModel):
    ID: str
    起点桩: float
    止点桩: float
    结构物: str

    特殊桩号头: Optional[str] = None
    特殊桩起点桩: Optional[str] = None
    特殊桩止点桩: Optional[str] = None
    段起点: Optional[str] = None
    段止: Optional[str] = None

    单向车道总: int
    车道编号: int
    车道宽: float

    技术等: str
    路面类: str

    上面层材料: str
    上面层厚: float

    中面层材料: Optional[str] = None
    中面层厚: Optional[float] = None

    下面层材料: Optional[str] = None
    下面层厚: Optional[float] = None

    排序: str


# 第二层：车道信息（Lane Info）
class LaneInfo(BaseModel):
    车道编号: int
    方向: str
    桩号构成: List[PileItem]


# 第一层：主线路信息（Route Info）
class RouteInfo(BaseModel):
    线路代码: str
    路线名称: str
    内容: List[LaneInfo]
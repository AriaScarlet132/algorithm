# -*- coding: utf-8 -*-
"""示例: 使用 DecisionStrategy 进行养护策略决策"""
from road_algorithm import DecisionStrategy

strategy = {
    "name": "沥青路面维修工法",
    "road_type": "沥青",
    "rules": [
      {
        "conditions": {"PCI": "符合", "RQI": "符合", "RDI": "符合", "SRI": "符合", "PSSI": ""},
        "recommendation": [
          {"road_level": "all", "comment": "日常养护", "code": "0"}
        ]
      },
      {
        "conditions": {"PCI": "符合", "RQI": "符合", "RDI": "符合", "SRI": "不符合", "PSSI": ""},
        "recommendation": [
          {"road_level": "all", "comment": "封层", "code": "1"}
        ]
      }
    ]
}

grades = [{
  "road_type": "高速",
  "road_level": "0",
  "pci_threshold": 92,
  "rqi_threshold": 90,
  "rdi_threshold": 90,
  "sri_threshold": 80,
  "pssi_threshold": 80,
  "dbl_threshold": 0.05
}]

params = {
  "技术等": "高速",
  "路面类": "沥青",
  "PCI": 95,
  "RQI": 90,
  "RDI": 95,
  "SRI": 90,
  "PSSI": 81
}

if __name__ == "__main__":
    ds = DecisionStrategy(strategy, grades)
    result = ds.make_decision(params)
    print("决策结果:", result)

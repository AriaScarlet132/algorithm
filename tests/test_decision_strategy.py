# -*- coding: utf-8 -*-
import os, sys

# 确保直接运行该文件时也能找到项目根目录包
PROJECT_ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..'))
if PROJECT_ROOT not in sys.path:
    sys.path.insert(0, PROJECT_ROOT)

import pytest
from decision_strategy import DecisionStrategy

@pytest.fixture
def sample_strategy():
    return {
        "name": "沥青路面维修工法",
        "road_type": "沥青",
        "rules": [
            {
                "conditions": {"PCI": "符合", "RQI": "符合", "RDI": "符合", "SRI": "符合", "PSSI": ""},
                "recommendation": [{"road_level": "all", "comment": "日常养护", "code": "0"}]
            },
            {
                "conditions": {"PCI": "符合", "RQI": "符合", "RDI": "符合", "SRI": "不符合", "PSSI": ""},
                "recommendation": [{"road_level": "all", "comment": "封层", "code": "1"}]
            }
        ]
    }

@pytest.fixture
def grades():
    return [{
        "road_type": "高速",
        "road_level": "0",
        "pci_threshold": 92,
        "rqi_threshold": 90,
        "rdi_threshold": 90,
        "sri_threshold": 80,
        "pssi_threshold": 80,
        "dbl_threshold": 0.05
    }]


def test_match_daily_maintenance(sample_strategy, grades):
    params = {"技术等": "高速", "路面类": "沥青", "PCI": 95, "RQI": 90, "RDI": 95, "SRI": 90, "PSSI": 81}
    ds = DecisionStrategy(sample_strategy)
    rec = ds.make_decision(params, grades)
    assert rec is not None
    assert rec["comment"] == "日常养护"


def test_match_seal(sample_strategy, grades):
    params = {"技术等": "高速", "路面类": "沥青", "PCI": 95, "RQI": 90, "RDI": 95, "SRI": 10, "PSSI": 81}
    ds = DecisionStrategy(sample_strategy)
    rec = ds.make_decision(params, grades)
    assert rec is not None
    assert rec["comment"] == "封层"


def test_no_match(sample_strategy, grades):
    params = {"技术等": "高速", "路面类": "沥青", "PCI": 10, "RQI": 5, "RDI": 5, "SRI": 5, "PSSI": 1}
    ds = DecisionStrategy(sample_strategy)
    rec = ds.make_decision(params, grades)
    assert rec is None

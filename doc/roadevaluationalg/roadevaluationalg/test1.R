# 定义养护对策计算函数
maintenance_measure <- function(PCI, RQI, RDI, SRI, PSSI, DBL, Type, Grade) {
  # 这里只是一个示例，实际的养护决策逻辑要更复杂
  if (PCI < 60 || RQI < 60) {
    return(1)  # 大修
  } else if (PCI < 80 || RQI < 80) {
    return(2)  # 中修
    
  } else {
    return(3)  # 小修保养
  }
}

# 加载必要的包
library(dplyr)
library(purrr)


# 应用函数到数据框
data$初始推荐养护对策 <- pmap_dbl(
  .l = list(PCI = data$PCI, RQI = data$RQI, RDI = data$RDI, 
            SRI = data$SRI, PSSI = data$PSSI, DBL = NA, 
            Type = data$路面类型, Grade = data$技术等级),
  .f = maintenance_measure
)
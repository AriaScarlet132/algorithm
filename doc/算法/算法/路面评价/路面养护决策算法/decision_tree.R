#决策模块
##养护决策树
maintenance_measure <- function(PCI,RQI,RDI,SRI,PSSI,DBL,Type,Grade){#6种指标,路面类型,技术等级
  #缺失值处理
  if(is.na(PCI)){PCI<-100};if(is.na(RQI)){RQI<-100};if(is.na(RDI)){RDI<-100};if(is.na(SRI)){SRI<-100};if(is.na(PSSI)){PSSI<-100};if(is.na(DBL)){DBL<-0}
  #养护规定值(只与技术等级有关,分别对应高速、一级、二级、三级、四级)
  pci_threshold <- c(92,90,90,70,70)
  rqi_threshold <- c(90,90,90,70,70)
  rdi_threshold <- c(90,80,75,0,0)
  sri_threshold <- c(80,80,70,0,0)
  pssi_threshold <- c(80,75,70,65,65)
  dbl_threshold <- c(0.05,0.05,0.1,0.1,0.1)
  #判断养护规定值是否达到
  grade_level <- switch (Grade,
                         "高速" = 1,
                         "一级" = 2,
                         "二级" = 3,
                         "三级" = 4,
                         "四级" = 5,
                         5
  )
  if(PCI>=pci_threshold[grade_level]){pci_ok<-TRUE}else{pci_ok<-FALSE}
  if(RQI>=rqi_threshold[grade_level]){rqi_ok<-TRUE}else{rqi_ok<-FALSE}
  if(RDI>=rdi_threshold[grade_level]){rdi_ok<-TRUE}else{rdi_ok<-FALSE}
  if(SRI>=sri_threshold[grade_level]){sri_ok<-TRUE}else{sri_ok<-FALSE}
  if(PSSI>=pssi_threshold[grade_level]){pssi_ok<-TRUE}else{pssi_ok<-FALSE}
  if(DBL<=dbl_threshold[grade_level]){dbl_ok<-TRUE}else{dbl_ok<-FALSE}#注意此处是小于等于
  #养护决策树(其结构仅与路面类型有关)
  if(Type=="沥青"){#沥青路面:0代表日常养护,1代表封层,2代表一层式铣刨加罩,3代表二层式铣刨加罩,4代表局部补强+二层式铣刨加罩,5代表全面补强+翻修
    if(pci_ok){
      if(rqi_ok){
        if(rdi_ok){
          if(sri_ok){
            0
          }else{
            1
          }
        }else{
          if(Grade=="高速"){
            3
          }else{
            2
          }
        }
      }else{
        if(pssi_ok){
          if(Grade=="高速"){
            3
          }else if(Grade %in% c("一级","二级","三级")){
            2
          }else{
            1
          }
        }else{
          4
        }
      }
    }else{
      if(pssi_ok){
        if(PCI>=70){
          2
        }else{
          3
        }
      }else{
        if(PCI>=70){
          4
        }else{
          5
        }
      }
    }
  }else{#水泥路面:0代表日常养护,1代表刻槽,2代表翻修破损板+板顶研磨,3代表翻修破损板+加铺沥青混凝土,4代表整路段翻修+加铺沥青混凝土,5代表整路段改造为沥青混凝土路面
    if(pci_ok){
      if(rqi_ok){
        if(sri_ok){
          0
        }else{
          1
        }
      }else{
        if(sri_ok){
          2
        }else{
          3
        }
      }
    }else{
      if(dbl_ok){
        4
      }else{
        5
      }
    }
  }
}
data$初始推荐养护对策 <- pmap_dbl(.l=list(PCI=data$PCI,RQI=data$RQI,RDI=data$RDI,SRI=data$SRI,PSSI=data$PSSI,DBL=NA,Type=data$路面类型,Grade=data$技术等级),.f=maintenance_measure)
# tmp <- 
rm(list=ls())
library(readxl)
library(writexl)
library(dplyr)
library(purrr)
library(parallel)
library(foreach)
library(plot3D)
library(ggplot2)
library(reshape2)
library(data.table)
library(iterators)
library(doParallel)
library(plot3D)
t1 <- Sys.time()
#读取数据
static <- read_excel(path = '/Users/zhenghong/Documents/GitHub/roadevaluationalg/data/道路静态数据-运营集团.xlsx',col_types = c(rep("text",2),rep("numeric",2),rep("text",2),rep("numeric",2),rep("text",3),rep("numeric",3),rep("text",2),rep(c("text","numeric"),7),"text","date","numeric"))
dynamic <- read_excel(path = '/Users/zhenghong/Documents/GitHub/roadevaluationalg/data/初始动态数据.xlsx',col_types = c(rep("text",2),rep("numeric",2),rep("text",2),rep("numeric",2),rep("text",3),rep("numeric",15),"date"))
history <- read_excel(path = '/Users/zhenghong/Documents/GitHub/roadevaluationalg/data/外环完整养护历史2011-2024.xlsx')
lane_traffic <- read_excel(path = '/Users/zhenghong/Documents/GitHub/roadevaluationalg/data/外环交通量数据-车道级.xlsx')
section_traffic <- read_excel(path = '/Users/zhenghong/Documents/GitHub/roadevaluationalg/data/外环交通量数据-断面级.xlsx')
##限定到外环北段
section_limits <- function(data,section_code,start){
  tmp1 <- pmin(data$起点桩号,data$止点桩号)
  tmp2 <- pmax(data$起点桩号,data$止点桩号)
  data$起点桩号 <- tmp1;data$止点桩号 <- tmp2
  return(data[which(data$路线代码==section_code & data$起点桩号>=start),])
}
static <- section_limits(static,"S20",79.317)
dynamic <- section_limits(dynamic,"S20",79.317)
#连接动静态数据
head <- unique(c(static$起点桩号,static$止点桩号,dynamic$起点桩号,dynamic$止点桩号))
head <- sort(head)
head <- data.frame(起点桩号=head[1:length(head)-1],止点桩号=head[2:length(head)])#起点桩号、止点桩号
tmp <- NROW(head)
tmp2 <- unique(dynamic$方向)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$方向 <- rep(tmp2,each=tmp)
tmp <- NROW(head)
tmp2 <- unique(dynamic$车道编号)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$车道编号 <- rep(tmp2,each=tmp)#连接表头已准备好
##连接静态数据
head <-left_join(head,static,by=join_by("方向","车道编号",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
head <- head[,c("路线代码","路线名称","起点桩号.x","止点桩号.x","结构物","特殊桩号头","特殊桩起点桩号","特殊桩止点桩号","段起点","段止点","方向","车道编号","单向车道总数","车道宽度","技术等级","路面类型","上面层材料","上面层厚度",
                "中面层材料","中面层厚度","下面层材料","下面层厚度","上基层材料","上基层厚度","中基层材料","中基层厚度","底基层材料","底基层厚度","垫层材料","垫层厚度","土基类型","最后一次建造时间","道路建设总投资")]
tmp <- gsub(".x","",colnames(head),fixed = TRUE)
colnames(head) <- tmp
##连接动态数据
dynamic$数据年份 <- as.numeric(format(dynamic$检测时间,"%Y"))
tmp <- NROW(head)
tmp2 <- unique(dynamic$数据年份)
data <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
data$数据年份 <- rep(tmp2,each=tmp)
data <- left_join(data,dynamic,by=join_by("路线代码","方向","车道编号","数据年份",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
data <- data[,c("路线代码","路线名称.x","起点桩号.x","止点桩号.x","结构物.x","特殊桩号头.x","特殊桩起点桩号.x","特殊桩止点桩号.x","段起点.x","段止点.x","方向","车道编号","单向车道总数","车道宽度","技术等级","路面类型","上面层材料","上面层厚度","中面层材料","中面层厚度",
                "下面层材料","下面层厚度","上基层材料","上基层厚度","中基层材料","中基层厚度","底基层材料","底基层厚度","垫层材料","垫层厚度","土基类型","最后一次建造时间","道路建设总投资","数据年份","PCI","DR","RQI","IRI","RDI","RD","PBI","PWI","SRI","PSSI","BPN","TD","SFC","DEF")]
tmp <- gsub(".x","",colnames(data),fixed = TRUE)
colnames(data) <- tmp
##连接养护历史数据
###先处理改扩建/重建/新建时的数据(无检测数据)
history$养护强度 <- round(history$工程量/history$总面积,3)
tmp <- head
tmp[,c("数据年份","PCI","DR","RQI","IRI","RDI","RD","PBI","PWI","SRI","PSSI","BPN","TD","SFC","DEF")] <-NA
tmp2 <- nrow(tmp)
tmp3 <- unlist(unique(history[history$实施类型 %in% c("改扩建","重建","新建"),"数据年份"]))
tmp <- dplyr::slice(tmp, rep(1:dplyr::n(), times = length(tmp3)))#扩展
tmp$数据年份 <- rep(tmp3,each=tmp2)
tmp <- left_join(tmp,history,by=join_by("路线代码","方向","车道编号","数据年份",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
tmp <- tmp[,c("路线代码","路线名称","起点桩号.x","止点桩号.x","结构物","特殊桩号头","特殊桩起点桩号","特殊桩止点桩号","段起点","段止点","方向","车道编号","单向车道总数","车道宽度","技术等级","路面类型","上面层材料","上面层厚度","中面层材料","中面层厚度","下面层材料","下面层厚度",
              "上基层材料","上基层厚度","中基层材料","中基层厚度","底基层材料","底基层厚度","垫层材料","垫层厚度","土基类型","最后一次建造时间","道路建设总投资","数据年份","PCI","DR","RQI","IRI","RDI","RD","PBI","PWI","SRI","PSSI","BPN","TD","SFC","DEF","实施内容","实施类型","养护强度")]
tmp2 <- gsub(".x","",colnames(tmp),fixed = TRUE)
colnames(tmp) <- tmp2
tmp <- tmp[!is.na(tmp$实施类型),]
tmp[!is.na(tmp$结构物),"实施内容"] <- "拼宽"
tmp[,c("PCI","RQI","RDI","SRI")] <- 100#改扩建后性能指标的初始值置为最大值
###后处理运营时期的数据(有检测数据)
data <- left_join(data,history,by=join_by("路线代码","方向","车道编号","数据年份",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
data <- data[,c("路线代码","路线名称","起点桩号.x","止点桩号.x","结构物","特殊桩号头","特殊桩起点桩号","特殊桩止点桩号","段起点","段止点","方向","车道编号","单向车道总数","车道宽度","技术等级","路面类型","上面层材料","上面层厚度","中面层材料","中面层厚度","下面层材料","下面层厚度",
              "上基层材料","上基层厚度","中基层材料","中基层厚度","底基层材料","底基层厚度","垫层材料","垫层厚度","土基类型","最后一次建造时间","道路建设总投资","数据年份","PCI","DR","RQI","IRI","RDI","RD","PBI","PWI","SRI","PSSI","BPN","TD","SFC","DEF","实施内容","实施类型","养护强度")]
tmp2 <- gsub(".x","",colnames(data),fixed = TRUE)
colnames(data) <- tmp2
###合并数据
data <- rbind(tmp,data)#已获取当前生命周期的完整数据
##连接交通荷载数据
integral_ratio <- round(sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量")])/sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","大型客车数量")]),2)#整体式货车比例
semitrailer_ratio <- round(sum(lane_traffic[,c("特大货车数量","集装箱车数量")])/sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","大型客车数量")]),2)#半挂式货车比例
# round(apply(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","大型客车数量")], 2,sum)/sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","大型客车数量")]),2)#不同TTC分类车辆类型分布系数验证
ttc_type <- function(integral_ratio,semitrailer_ratio){#ttc分类
  distribution_coefficient <- matrix(data = c(6.4,15.3,1.4,0,11.9,3.1,16.3,20.4,25.2,0,22,23.3,2.7,0,8.3,7.5,17.1,8.5,10.6,0,17.8,33.1,3.4,0,12.5,4.4,9.1,10.6,8.5,0.7,
                                              28.9,43.9,5.5,0,9.4,2,4.6,3.4,2.3,0.1,9.9,42.3,14.8,0,22.7,2,2.3,3.2,2.5,0.2),ncol = 10,byrow = TRUE)
  if(integral_ratio<0.4 & semitrailer_ratio>0.5){
    return(distribution_coefficient[1,])
  }else if(integral_ratio<0.4 & semitrailer_ratio<0.5){
    return(distribution_coefficient[2,])
  }else if(integral_ratio>=0.4 & integral_ratio<=0.7 & semitrailer_ratio>0.2){
    return(distribution_coefficient[3,])
  }else if(integral_ratio>=0.4 & integral_ratio<=0.7 & semitrailer_ratio<0.2){
    return(distribution_coefficient[4,])
  }else{
    return(distribution_coefficient[5,])
  }
}
full_load_ratio <- c(0.15,0.1,0.35,0.25,0.45,0.3,0.55,0.4,0.45,0.35)#2-11类车的满载比例
axle_load_coefficient <- matrix(data = c(0.8,0.4,0.7,0.6,1.3,1.4,1.4,1.5,2.4,1.5,2.8,4.1,4.2,6.3,7.9,6,6.7,5.1,7,12.1),ncol=2)#2-11类车的轴载换算系数
count_ratio <- round(sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","大型客车数量")])/sum(lane_traffic[,c("小型货车数量","中型货车数量","大型货车数量","特大货车数量","集装箱车数量","中型客车数量","小型客车数量","大型客车数量")]),2)#忽略小型客车
###计算车道级轴载分布时,小型中型货车按3类车计,大型货车按6类计,特大型货车按10类计,集装箱车按9类计,中型客车大型客车按2类计
tmp <- aggregate(cbind(小型货车数量,中型货车数量,大型货车数量,特大货车数量,集装箱车数量,中型客车数量,大型客车数量)~车道编号,data = lane_traffic,FUN = sum)#按车道汇总
tmp$coefficient <- as.matrix(tmp[,c(2:8)]) %*% matrix(data=c((1-full_load_ratio[c(2,2,5,9,8,1,1)])*axle_load_coefficient[c(2,2,5,9,8,1,1),1]+full_load_ratio[c(2,2,5,9,8,1,1)]*axle_load_coefficient[c(2,2,5,9,8,1,1),2]),ncol=1)/sum(as.matrix(tmp[,c(2:8)]))#注意,2-11类的序号分别为1-10
section_traffic[,c("1","2","3","4")] <- round(matrix(rep(section_traffic$交通流量,4),ncol=4)*count_ratio * matrix(rep(tmp$coefficient,length(section_traffic$交通流量)),byrow = TRUE,ncol = 4),0)
section_traffic <- reshape2::melt(section_traffic,id.vars = c("路线代码","起点桩号","止点桩号","路段范围","方向","交通流量","数据年份"),variable.name = "车道编号",value.name = "ESAL")#车道级每年的ESAL
section_traffic$车道编号 <- as.numeric(section_traffic$车道编号)
###利用养护历史确定累计轴载
esal0 <- history[history$实施类型 %in% c("改扩建","重建","新建"),]#确定累计轴载零点
head <- unique(c(esal0$起点桩号,esal0$止点桩号,section_traffic$起点桩号,section_traffic$止点桩号))#桩号详细切分
head <- sort(head)
head <- data.frame(起点桩号=head[1:length(head)-1],止点桩号=head[2:length(head)])#起点桩号、止点桩号
tmp <- NROW(head)
tmp2 <- unique(section_traffic$路线代码)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$路线代码 <- rep(tmp2,each=tmp)
tmp <- NROW(head)
tmp2 <- unique(section_traffic$方向)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$方向 <- rep(tmp2,each=tmp)
tmp <- NROW(head)
tmp2 <- unique(section_traffic$车道编号)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$车道编号 <- rep(tmp2,each=tmp)
tmp <- NROW(head)
tmp2 <- unique(section_traffic$数据年份)
head <-  dplyr::slice(head, rep(1:dplyr::n(), times = length(tmp2)))#扩展
head$数据年份 <- rep(tmp2,each=tmp)#连接表头已准备好
###先连接交通荷载,再连接改扩建/重建/新建历史,改扩建/重建/新建处ESAL清零
head <-left_join(head,section_traffic,by=join_by("路线代码","方向","数据年份","车道编号",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
head <- head[,c("路线代码","起点桩号.x","止点桩号.x","方向","车道编号","ESAL","数据年份")]
tmp <- gsub(".x","",colnames(head),fixed = TRUE)
colnames(head) <- tmp
###连接
head <-left_join(head,esal0,by=join_by("路线代码","方向","车道编号","数据年份",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
head <- head[,c("路线代码","起点桩号.x","止点桩号.x","方向","车道编号","ESAL","数据年份","实施内容","实施类型")]
tmp <- gsub(".x","",colnames(head),fixed = TRUE)
colnames(head) <- tmp
head <- head[order(head$数据年份),]#按数据年份排序
###计算累计轴载的函数
accumulate_esal <- function(esal,type){
  #esal是每年的esal序列,对应的数据年份必须是逐年+1的;type是改扩建/重建/新建中的一个,type的长度与esal的相同
  tmp <- which.max(type %in% c("改扩建","重建","新建"))
  esal[1:tmp] <- 0
  easl <- cumsum(esal)
}
head <- plyr::ddply(head,c("路线代码","起点桩号","止点桩号","方向","车道编号"),reframe,ESAL=accumulate_esal(ESAL,实施类型),数据年份=数据年份)
###连接
data <- left_join(data,head,by=join_by("路线代码","方向","车道编号","数据年份",x$起点桩号>=y$起点桩号,x$止点桩号<=y$止点桩号))
data <- data[,c("路线代码","路线名称","起点桩号.x","止点桩号.x","结构物","特殊桩号头","特殊桩起点桩号","特殊桩止点桩号","段起点","段止点","方向","车道编号","单向车道总数","车道宽度","技术等级","路面类型","上面层材料","上面层厚度","中面层材料","中面层厚度","下面层材料","下面层厚度",
                "上基层材料","上基层厚度","中基层材料","中基层厚度","底基层材料","底基层厚度","垫层材料","垫层厚度","土基类型","最后一次建造时间","道路建设总投资","数据年份","PCI","DR","RQI","IRI","RDI","RD","PBI","PWI","SRI","PSSI","BPN","TD","SFC","DEF","实施内容","实施类型","养护强度","ESAL")]
tmp2 <- gsub(".x","",colnames(data),fixed = TRUE)
colnames(data) <- tmp2
#设定方向和车道编号组合的顺序
y_s <- unique(data[data$方向=="上行","车道编号"]);y_s <- y_s[order(y_s)]
y_x <- unique(data[data$方向=="下行","车道编号"]);y_x <- y_x[order(y_x)]
data$方向和车道 <- factor(paste(data$方向,data$车道编号,"#",sep = ""),levels = c(paste("下行",y_x[order(y_x,decreasing = TRUE)],"#",sep = ""),paste("上行",y_s,"#",sep = "")))
#道路结构和材料
tmp <- paste(data$上面层材料,' ',data$上面层厚度,"cm+",data$中面层材料,' ',data$中面层厚度,"cm+",data$下面层材料,' ',data$下面层厚度,"cm+",data$上基层材料,' ',data$上基层厚度,"cm+",data$中基层材料,' ',data$中基层厚度,"cm+",data$底基层材料,' ',data$底基层厚度,"cm+",data$垫层材料,' ',data$垫层厚度,"cm+",data$土基类型,sep='')
tmp <- gsub("+NA ","",tmp,fixed = TRUE)
tmp <- gsub("+NA","",tmp,fixed = TRUE)
tmp <- gsub("NAcm","",tmp,fixed = TRUE)
data$道路结构和材料 <- tmp

#当前性能指标热力图
ggplot(data[data$数据年份==2024,], aes(x = 起点桩号, y = 方向和车道)) +
  xlab("公里桩号") +  #x轴标签
  theme_bw() + #设置系统自带主题
  theme(panel.grid.major = element_blank()) +  #设置主项网格
  theme(legend.key=element_blank()) + #去掉背景颜色
  theme(axis.text.x=element_text(angle=45,hjust=1, vjust=1)) +  #设置坐标轴标签
  theme(legend.position="top") +  #设置图例的位置
  geom_tile(aes(fill=PCI)) +  #设置填充的值
  scale_fill_gradient("PCI",low = "red", high = "white") #设置颜色梯度
#全车道性能指标柱状图
tmp <- aggregate(PCI~方向和车道,data = data[data$数据年份==2024,],FUN = mean,na.rm=TRUE)
ggplot(tmp, aes(方向和车道, PCI)) + 
  geom_bar(stat = "identity",fill="pink") + coord_flip() +
  theme_bw() + #设置系统自带主题
  theme(panel.grid.major = element_blank()) +  #设置主项网格
  theme(legend.key=element_blank()) + #去掉背景颜色
  geom_text(aes(label = round(PCI,2)))
# #PPI数据直方图
# hist(data$SRI)
##ppi变化散点图demo
plot_ppi <- function(data,name,direction,lane_no,start,ppi){
  data <- filter(data,路线名称==name & 方向==direction & 车道编号==lane_no & 起点桩号==start)
  eval(parse(text = paste("plot(data$数据年份,data$",ppi,",xlab='',ylab='",ppi,"')",sep = "")))
  eval(parse(text = paste("text(x=data$数据年份,y=data$",ppi,"+2,labels=gsub('NA','',paste(data$实施内容,data$养护强度,sep='\n')),xpd=TRUE,cex=0.7)",sep = "")))
  eval(parse(text = paste("text(x=data$数据年份,y=data$",ppi,"-1,labels=gsub('NA','',data$ESAL),xpd=TRUE,cex=0.5)",sep = "")))
  tmp <- paste(data$上面层材料[1],' ',data$上面层厚度[1],"cm+",data$中面层材料[1],' ',data$中面层厚度[1],"cm+",data$下面层材料[1],' ',data$下面层厚度[1],"cm+",data$上基层材料[1],' ',data$上基层厚度[1],"cm+",data$中基层材料[1],' ',data$中基层厚度[1],"cm+",data$底基层材料[1],' ',data$底基层厚度[1],"cm+",data$垫层材料[1],' ',data$垫层厚度[1],"cm+",data$土基类型[1],sep='')
  tmp <- gsub("+NA ","",tmp,fixed = TRUE)
  tmp <- gsub("+NA","",tmp,fixed = TRUE)
  tmp <- gsub("NAcm","",tmp,fixed = TRUE)
  mtext(tmp, side = 3, line = 1.5,cex=0.8)
  tmp <- paste(name," ",direction," ",lane_no,"# K",start,'-',data$止点桩号[1],sep='')
  mtext(tmp, side = 3, line = 2.5)
  mtext("数据年份", side = 1, line = 2)
  # mtext(paste(data$ESAL,collapse = " "), side = 1, line = 3,cex=0.8)
  # mtext("累计当量轴载", side = 1, line = 4)
}
par(mar=c(3.5,4.5,4,1))
# plot(data$ESAL,data$PCI)#不能直接分析
plot_ppi(data = data,"S20外环高速（浦西段）","上行",2,87.2,"RQI")#输入路名/方向/车道编号/起点桩号/指标名称#标准1
plot_ppi(data = data,"S20外环高速（浦西段）","上行",2,79.5,"PCI")#输入路名/方向/车道编号/起点桩号/指标名称
# plot_ppi(data = data,"S20外环高速（浦西段）","下行",1,90.000,"PCI")#输入路名/方向/车道编号/起点桩号/指标名称#标准1
# plot_ppi(data = data,"S20外环高速（浦西段）","下行",3,90.800,"PCI")#输入路名/方向/车道编号/起点桩号/指标名称
# plot_ppi(data = data,"S20外环高速（浦西段）","上行",2,86.900,"PCI")#输入路名/方向/车道编号/起点桩号/指标名称


# #测试用数据
# ppi <- c(100.00,92.63,91.99,91.84,92.72,NA,NA,89.49,20,89.54,87,NA,83,82,70,74,78,73,70,67,67,63,68,63,62,45,44,90)
# c_ppi <- 100-ppi
# esal <- c(0,4204400,5045280,5704765,6269187,7094899,7920611,8746323,9572035,10397747,11223459,12049171,12874883,13700595,14526307,15352019,16177731,17003443,17829155,18654867,19480579,20306291,21132003,21957715,22783427,23609139,25260563,26911987)
# age <- c(0:27)
# measure <- c(NA,NA,NA,"铣刨加罩",NA,"铣刨加罩",NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA)
# measure_type <- c(NA,NA,NA,"修复养护",NA,"修复养护",NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA)
# measure_intensity <- c(NA,NA,NA,0.139,NA,0.53,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA,NA)
# tmp2 <- data[data$起点桩号==82.500 & data$车道编号==1 & data$方向=="上行",]
# tmp3 <- data[data$起点桩号==80.500 & data$车道编号==2 & data$方向=="下行",]

#阈值区间划分函数
divide_stage <- function(c_ppi,n){
  #c_ppi是累计ppi降低量;n是初步设定的阈值点个数
  ppi_threshold <- quantile(c_ppi,probs = seq(0,1,length.out=n),na.rm = TRUE);#划分成等数据量的n-1个区间
  ppi_threshold <- ppi_threshold[-1];ppi_threshold[length(ppi_threshold)] <- ppi_threshold[length(ppi_threshold)]+1;ppi_threshold <- union(0,ppi_threshold);#标准化区间起点为0,止点为最大值+1
  ppi_threshold <- ppi_threshold[order(ppi_threshold)]#按升序划分区间
}
#判断ppi对应的阶段
judge_stage <- function(c_ppi,ppi_threshold){
  # ppi_threshold是分阶段的ppi值上限
  n <- length(ppi_threshold)#多少个阶段
  tmp <- matrix(data = rep(c_ppi,n),ncol = n)
  tmp2 <- matrix(data = rep(ppi_threshold,length(c_ppi)),ncol = n,byrow = TRUE)
  tmp <- rowSums(tmp2-tmp<=0)#ppi分别在哪个阶段
}
#对于每个基本单元,取历年数据,作分析底图,形成衰变速率分析底表
deterioration_analysis_table <- function(ppi,esal,age){
  tmp <- which(!is.na(ppi))
  if(!identical(tmp,integer(0))){
    tmp2 <- cbind(ppi[tmp],esal[tmp],age[tmp])#移除缺失值
    tmp2 <- tmp2[order(tmp2[,3]),]#按路龄排序
    tmp3 <- diff(tmp2[,1])<0
    if(sum(tmp3)>=1){
      table <- cbind(diff(tmp2[,1])[tmp3],diff(tmp2[,2])[tmp3],diff(tmp2[,3])[tmp3])
      table <- apply(table,2,cumsum)#衰变速率分析底表
      return({matrix(table,ncol = 3)})
    }else{
      return(NA)
    }
  }else{NA}
}

##桩号数据预处理
data$起点桩号  <- sub(".","-",data$起点桩号,fixed = TRUE);data$止点桩号  <- sub(".","-",data$止点桩号,fixed = TRUE)#临时替换
##汇总用于回归的数据
tmp <- plyr::dlply(data,c('路线代码','方向','车道编号','起点桩号','止点桩号','技术等级','路面类型','道路结构和材料'),reframe,x=deterioration_analysis_table(PCI,ESAL,数据年份))#要分析的指标在此选择
tmp <- lapply(tmp,function(x){matrix(x$x,ncol = 3)})
tmp2 <- data.frame(reduce(tmp,rbind));colnames(tmp2) <- c("c_ppi","c_esal","c_age")
##回归数据的表头
tmp3 <- rep(names(tmp),times=lapply(tmp,nrow))
tmp4<- foreach(i=1:length(tmp3),.combine = "rbind") %do%
  {
  tmp5 <- strsplit(tmp3[i],split=".",fixed=TRUE)[[1]]
  }
tmp4 <- data.frame(tmp4)
tmp4$X4 <- sub("-",".",tmp4$X4,fixed = TRUE);tmp4$X5 <- sub("-",".",tmp4$X5,fixed = TRUE);
tmp4[,c("X3","X4","X5")] <- sapply(tmp4[,c("X3","X4","X5")],as.numeric)
colnames(tmp4) <- c("路线代码","方向","车道编号","起点桩号","止点桩号","技术等级","路面类型","道路结构和材料")
##合并表头和数据
data_deterioration <- cbind(tmp4,tmp2);data_deterioration$c_ppi <- -data_deterioration$c_ppi#转换为正值
#删除缺失数据
data_deterioration <- data_deterioration[!is.na(data_deterioration$c_ppi),]
##还原data
data$起点桩号  <- sub("-",".",data$起点桩号,fixed = TRUE);data$止点桩号  <- sub("-",".",data$止点桩号,fixed = TRUE)#替换回来
data[,c("起点桩号","止点桩号")] <- sapply(data[,c("起点桩号","止点桩号")],as.numeric)

#测试
#S20.上行.2.79-5.79-6.高速.沥青.SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm
lapply(tmp, NROW)[203]
tmp2 <- data.frame(tmp[[203]])
tmp2$X1 <- -tmp2$X1
c_ppi <- tmp2$X1;c_esal <- tmp2$X2;c_age <- tmp2$X3
names(tmp2) <- c("c_ppi","c_esal","c_age")

#单阶段回归函数
single_stage_regression <- function(k1_k2_ratio,c_ppi,c_esal,c_age){
  #k1_k2_ratio为多少ESAL可以转换为单位Age的系数
  data <- data.frame(c_ppi,c_esal,c_age)
  data <- data - slice(data[1,],rep(1:n(),nrow(data)))#减去起点的数值,以使用无截距项回归
  if(nrow(data)<2 | diff(range(data$c_age))<0.1){#只有1行数据的无法回归,忽略相应片段;时间窗过小的数据不进行回归,以避免不稳定
    return(NULL)
  }else{
    data$c_age_e <- data$c_esal*k1_k2_ratio+data$c_age#将交通荷载折算进环境荷载里面
    lm_model <- lm(c_ppi~c_age_e-1,data = data)#对总荷载(全部折算为环境荷载)进行无截距回归
    tmp <- c(lm_model$coefficients)
    return(tmp)
  }
}
#分阶段回归函数
multi_stage_multiple_linear_regression <- function(road_structure_material,ppi_thresholds,k_range,k_range_quantile,c_ppi,c_esal,c_age){
  tmp <- which(names(ppi_thresholds)==road_structure_material[1])#确定对应道路结构和材料的ppi_thresholds
  tmp2 <- which(k_range$道路结构和材料==road_structure_material[1])#确定对应道路结构和材料的k1/k2上下限
  if(!identical(tmp,integer(0)) & !identical(tmp2,integer(0))){
    ppi_threshold <- ppi_thresholds[[tmp]]$x
    k1_k2_ratio <- quantile(c(0,k_range[tmp2,"k1.max"]/k_range[tmp2,"k2.min"]),k_range_quantile)#根据k_range_quantile确定k1_k2_ratio
    data <- data.frame(c_ppi,c_esal,c_age)#将数据整理到数据框中
    data$stage <- judge_stage(data$c_ppi,ppi_threshold)#阶段划分
    if(data[1,1]!=0){data <- rbind(c(0,0,0,1),data)}#插入生命周期起点数据
    tmp3 <- data.frame(c_ppi=ppi_threshold[-1],c_esal=NA,c_age=NA,stage=2:length(ppi_threshold),front=NA,back=NA)#插入其它阶段起点数据
    tmp3 <- tmp3[tmp3$c_ppi<max(data$c_ppi),]#自动去除大于等于data中最大c_ppi的阈值
    if(nrow(tmp3>0)){#不止一个阶段的情形,需要插入分阶段数据
      tmp3$back <- sapply(tmp3$c_ppi,function(x){which.max(x-data$c_ppi<0)});tmp3$front <- tmp3$back-1#插入到data中的位置
      #线性插值填补c_esal/c_age数据
      tmp3$c_esal <- data[tmp3$front,"c_esal"]+(tmp3$c_ppi-data[tmp3$front,"c_ppi"])/(data[tmp3$back,"c_ppi"]-data[tmp3$front,"c_ppi"])*(data[tmp3$back,"c_esal"]-data[tmp3$front,"c_esal"])
      tmp3$c_age <- data[tmp3$front,"c_age"]+(tmp3$c_ppi-data[tmp3$front,"c_ppi"])/(data[tmp3$back,"c_ppi"]-data[tmp3$front,"c_ppi"])*(data[tmp3$back,"c_age"]-data[tmp3$front,"c_age"])
      data <- rbind(data,tmp3[,1:4])
      data <- data[order(data$c_ppi),]#按c_ppi升序排序
    }
    data <- setDT(data)[, as.list(c(val = single_stage_regression(k1_k2_ratio,c_ppi,c_esal,c_age))), .(stage)]#各阶段分别回归
    if(nrow(data)==0){
      return(NULL)
    }else{
      # names(data) <- c("stage","k_age","k1_k2_ratio")
      data$interval_start <- ppi_threshold[data$stage];data$interval_end <- ifelse(data$stage==length(ppi_threshold),100,ppi_threshold[data$stage+1]);data$k1_k2_ratio <- k1_k2_ratio
      return(data)
    }
  }else{
    return(NULL)
  }
}
k_range_calculation <- function(c_ppi,c_esal,c_age){
  tmp <- c(k1=c_ppi[length(c_ppi)]/c_esal[length(c_esal)],k2=c_ppi[length(c_ppi)]/c_age[length(c_age)])
  return(tmp)
}
#计算不同道路结构和材料的ppi_thresholds和k1/k2范围
ppi_thresholds <- plyr::dlply(data_deterioration,c('道路结构和材料'),reframe,x=divide_stage(c_ppi,4))
tmp <- setDT(data_deterioration)[, as.list(c(val = k_range_calculation(c_ppi,c_esal,c_age))), .(路线代码,方向,车道编号,起点桩号,止点桩号,技术等级,路面类型,道路结构和材料)]
k_range <- plyr::ddply(tmp,c('道路结构和材料'),summarise,k1.min=min(val.k1),k1.max=max(val.k1),k2.min=min(val.k2),k2.max=max(val.k2))

# # 测试
# k_range_quantile <- 0
# tmp <- data_deterioration[data_deterioration$路线代码=="S20" & data_deterioration$方向=="下行" & data_deterioration$车道编号==3 & data_deterioration$起点桩号==90.8,]
# # tmp <- data_deterioration[data_deterioration$路线代码=="S20" & data_deterioration$方向=="上行" & data_deterioration$车道编号==2 & data_deterioration$起点桩号==79.5,]
# tmp2 <- multi_stage_multiple_linear_regression(tmp$道路结构和材料[1],ppi_thresholds,k_range,k_range_quantile,tmp$c_ppi,tmp$c_esal,tmp$c_age)
# # tmp3 <- setDT(data_deterioration)[, as.list(c(val = multi_stage_multiple_linear_regression(道路结构和材料,ppi_thresholds,k_range,k_range_quantile,c_ppi,c_esal,c_age))), .(路线代码,方向,车道编号,起点桩号,止点桩号,技术等级,路面类型,道路结构和材料)]

#对于不同的k1_k2_ratio,并行计算
myCluster <- makeCluster(detectCores()-2, type = "PSOCK")#计算所用的核心数
registerDoParallel(myCluster)#注册计算
##tmp4即为衰变模型,包含不同k1_k2_ratio/不同道路结构和材料/不同stage下的衰变速率信息
tmp4 <- foreach (k_range_quantile=seq(0,0.03,0.0005),.combine = rbind,.packages = c("data.table","dplyr")) %dopar% {
  tmp3 <- setDT(data_deterioration)[, as.list(c(val = multi_stage_multiple_linear_regression(道路结构和材料,ppi_thresholds,k_range,k_range_quantile,c_ppi,c_esal,c_age))), .(路线代码,方向,车道编号,起点桩号,止点桩号,技术等级,路面类型,道路结构和材料)]
}
stopCluster(myCluster)
names(tmp4) <- gsub(fixed=TRUE,"val.","",names(tmp4));tmp4 <- plyr::rename(tmp4,replace=c("c_age_e"="k_d_age_e"))#列名称替换

#对data_deterioration进行预处理,使其仅包含各stage的相对其起点的c_ppi/c_esal/c_age增量信息
delta_information <- function(c_ppi,c_esal,c_age){
  data <- data.frame(c_ppi,c_esal,c_age)#将数据整理到数据框中
  if(nrow(data)>1){
    if(data[1,"c_ppi"]==data[2,"c_ppi"]){#数据点的c_ppi值恰好在ppi_threshold中的情形
      data <- data[-1,]
    }
  }
  data <- data-dplyr::slice(.data = data[1,],rep(1:dplyr::n(), each = nrow(data)))
  return(data[-1,])
}
initialize_validation_data <- function(road_structure_material,ppi_thresholds,c_ppi,c_esal,c_age){
  tmp <- which(names(ppi_thresholds)==road_structure_material[1])#确定对应道路结构和材料的ppi_thresholds
  if(!identical(tmp,integer(0))){
    ppi_threshold <- ppi_thresholds[[tmp]]$x
    data <- data.frame(c_ppi,c_esal,c_age)#将数据整理到数据框中
    data$stage <- judge_stage(data$c_ppi,ppi_threshold = ppi_threshold)
    if(data[1,1]!=0){data <- rbind(c(0,0,0,1),data)}#插入生命周期起点数据
    tmp2 <- data.frame(c_ppi=ppi_threshold[-1],c_esal=NA,c_age=NA,stage=2:length(ppi_threshold),front=NA,back=NA)#插入其它阶段起点数据(其它阶段可以用插值处理,第一阶段不能)
    tmp2 <- tmp2[tmp2$c_ppi<max(data$c_ppi),]#自动去除大于等于data中最大c_ppi的阈值
    if(nrow(tmp2>0)){#不止一个阶段的情形,需要插入分阶段数据
      tmp2$back <- sapply(tmp2$c_ppi,function(x){which.max(x-data$c_ppi<0)});tmp2$front <- tmp2$back-1#插入到data中的位置
      #线性插值填补c_esal/c_age数据
      tmp2$c_esal <- data[tmp2$front,"c_esal"]+(tmp2$c_ppi-data[tmp2$front,"c_ppi"])/(data[tmp2$back,"c_ppi"]-data[tmp2$front,"c_ppi"])*(data[tmp2$back,"c_esal"]-data[tmp2$front,"c_esal"])
      tmp2$c_age <- data[tmp2$front,"c_age"]+(tmp2$c_ppi-data[tmp2$front,"c_ppi"])/(data[tmp2$back,"c_ppi"]-data[tmp2$front,"c_ppi"])*(data[tmp2$back,"c_age"]-data[tmp2$front,"c_age"])
      data <- rbind(data,tmp2[,1:4])
      data <- data[order(data$c_ppi),]#按c_ppi升序排序
    }
    data <- setDT(data)[, as.list(c(val = delta_information(c_ppi,c_esal,c_age))), .(stage)]
    return(data)
  }
}
#测试
data_deterioration <- setDT(data_deterioration)[, as.list(c(val = initialize_validation_data(道路结构和材料,ppi_thresholds,c_ppi,c_esal,c_age))), .(路线代码,方向,车道编号,起点桩号,止点桩号,技术等级,路面类型,道路结构和材料)]
data_deterioration <- dplyr::rename(data_deterioration,stage=val.stage,d_ppi=val.val.c_ppi,d_esal=val.val.c_esal,d_age=val.val.c_age)
# tmp2 <- plyr::ddply(data_deterioration,colnames(data_deterioration)[1:8],summarise,num=NROW(c_ppi))
# tmp3 <- plyr::ddply(tmp,colnames(tmp)[1:8],summarise,num=NROW(d_ppi))
# tmp5 <- left_join(tmp2,tmp3,by=colnames(tmp2)[1:8])

#通过网格搜索确定每种道路结构和材料/每个stage下的最优k1_k2_ratio和k_d_age_e
optimize_ratio_k <- function(road_structure_material,stage,k_d_age_e,k1_k2_ratio,validation_data){#validation_data以data_deterioration为模板
  validation_data <- validation_data[validation_data$道路结构和材料==road_structure_material[1] & validation_data$stage==stage[1],]#根据道路结构和材料/stage匹配验证集
  validation_data$d_age_e <- validation_data$d_esal*k1_k2_ratio+validation_data$d_age#计算总荷载(以环境荷载表征)
  tmp <- validation_data$d_age_e %o% k_d_age_e - matrix(data = rep(validation_data$d_ppi,length(k_d_age_e)),nrow = nrow(validation_data))
  tmp2 <- colMeans(abs(tmp))
  tmp3 <- which.min(tmp2)
  return(c(overall_mae=mean(abs(tmp)),optimal_mae=tmp2[tmp3],optimal_k_d_age_e=k_d_age_e[tmp3]))
}
tmp3 <- setDT(tmp4)[, as.list(c(val = optimize_ratio_k(道路结构和材料,stage,k_d_age_e,k1_k2_ratio,data_deterioration))), .(道路结构和材料,stage,interval_start,interval_end,k1_k2_ratio)]
names(tmp3) <- gsub(fixed=TRUE,"val.","",names(tmp3))

#分阶段绘制k1_k2_ratio与overall_mae的关系曲线
par(mar=c(4.5,4.5,2,1))
# tmp <- "沥青混凝土 8cm+钢筋混凝土 8cm"#选择道路结构和材料类型  stage 3 stage 1(..)
# tmp <- "沥青混凝土 6cm+钢筋混凝土 8cm"#选择道路结构和材料类型 stage 1(..) stage 2(..)
tmp <- "沥青混凝土 8cm+钢筋混凝土 12cm"#选择道路结构和材料类型 stage 1
# tmp <- "SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm"#选择道路结构和材料类型 stage 1
tmp2 <- tmp3[tmp3$道路结构和材料==tmp,]
plot(unlist(tmp2[tmp2$stage==1,"k1_k2_ratio"]),unlist(tmp2[tmp2$stage==1,"overall_mae"]),xlab = expression(paste(k[ESAL]," : ",k[Age])),ylab = "MAE",main=paste("道路结构和材料:",tmp),ylim=c(0,15),col="DarkTurquoise",type = "p",cex.main=0.9)
lines(unlist(tmp2[tmp2$stage==2,"k1_k2_ratio"]),unlist(tmp2[tmp2$stage==2,"overall_mae"]),col="DeepPink",type = "p")
lines(unlist(tmp2[tmp2$stage==3,"k1_k2_ratio"]),unlist(tmp2[tmp2$stage==3,"overall_mae"]),col="RosyBrown",type = "p")
legend("topleft",c("阶段 1","阶段 2","阶段 3"),col=c("DarkTurquoise","DeepPink","RosyBrown"),text.col=c("DarkTurquoise","DeepPink","RosyBrown"),pch=1,cex=0.8)
# tmp<- tmp2[tmp2$stage==3]#测试

#提取最优模型信息
optimal_model_information <- function(k1_k2_ratio,overall_mae,optimal_mae,optimal_k_d_age_e){
  tmp <- which.min(overall_mae)#最优模型位置
  tmp2 <- which(k1_k2_ratio==0)#对比基准位置
  return(data.frame(optimal_k1_k2_ratio=k1_k2_ratio[tmp],overall_mae=overall_mae[tmp],delta_overall_mae=(overall_mae[tmp2]-overall_mae[tmp])/overall_mae[tmp],optimal_mae=optimal_mae[tmp],delta_optimal_mae=optimal_mae[tmp2]-optimal_mae[tmp],optimal_k_d_age_e=optimal_k_d_age_e[tmp]))
}
prediction_model <-  setDT(tmp3)[, as.list(c(val = optimal_model_information(k1_k2_ratio,overall_mae,optimal_mae,optimal_k_d_age_e))), .(道路结构和材料,stage,interval_start,interval_end)]
names(prediction_model) <- gsub(fixed=TRUE,"val.","",names(prediction_model))

# 分阶段多元回归模型回归效果图
# S20-上行-2-79.5-高速-沥青-SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm #较好
# S20-上行-2-81.789-高速-沥青-沥青混凝土 8cm+钢筋混凝土 8cm #一般
# S20.上行.2.84-33.84-4.高速.沥青.SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm #可行
# S20.上行.2.82-7.82-8.高速.沥青.沥青混凝土 8cm+钢筋混凝土 8cm #一般
# S20.上行.2.83.6 #误差大
# S20.上行.2.85-6.85-7.高速.沥青.SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm #效果最好
# S20.上行.2.95-4.95-5.高速.沥青.SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm #可行
# S20.下行.2.87.87-1.高速.沥青.沥青混凝土 8cm+钢筋混凝土 12cm #可行
# S20.下行.2.95-2.95-3.高速.沥青.SMA-13 4cm+AC-20 6cm+连续配筋混凝土 26cm #准确度相对不高
# tmp <- plyr::ddply(.data = data_deterioration,.variables = c("路线代码","方向","车道编号","起点桩号","止点桩号","技术等级","道路结构和材料"),summarise,count=length(路线代码));tmp <- tmp[tmp$count>=5,]

tmp <- filter(data_deterioration,路线代码=="S20" & 方向=="下行" & 车道编号==2 & 起点桩号==83.6)
##附上模型信息
tmp2<- foreach(i=1:nrow(tmp),.combine = "rbind") %do%
  {
    tmp3 <- tmp[i,]
    tmp4 <- which(prediction_model$道路结构和材料==tmp3$道路结构和材料 & prediction_model$stage==tmp3$stage)
    tmp3$k1_k2_ratio <- prediction_model[tmp4,"optimal_k1_k2_ratio"]
    tmp3$k_d_age_e <- prediction_model[tmp4,"optimal_k_d_age_e"]
    return(tmp3)
  }
tmp2$predicted_d_ppi <- round((tmp2$k1_k2_ratio*tmp2$d_esal+tmp2$d_age)*tmp2$k_d_age_e,2)
ppi_threshold <- ppi_thresholds[[which(names(ppi_thresholds)==tmp$道路结构和材料[1])]]$x
##转换为累计值,以便绘图
accumulation_information <- function(stage,d_ppi,d_esal,d_age,k1_k2_ratio,k_d_age_e,predicted_d_ppi,ppi_threshold){
  data <- data.frame(d_ppi,d_esal,d_age,k1_k2_ratio,k_d_age_e,predicted_d_ppi)
  #初始化本stage起点和终点的数值
  data <- rbind(data[1,],data,data[nrow(data),])
  data[1,c("d_ppi","d_esal","d_age","predicted_d_ppi")] <- 0
  data[nrow(data),c("d_ppi","d_esal","d_age","predicted_d_ppi")] <- c(ppi_threshold[stage+1]-ppi_threshold[stage],NA,NA,NA)#注意是第stage+1个与第stage个ppi_threshold的差值
  #按平均增加量填充ppi_threshold阈值对应的ESAL/Age
  data[nrow(data),"d_esal"] <- mean(d_esal/d_ppi)*(data[nrow(data),"d_ppi"]-data[nrow(data)-1,"d_ppi"])+data[nrow(data)-1,"d_esal"]
  data[nrow(data),"d_age"] <- mean(d_age/d_ppi)*(data[nrow(data),"d_ppi"]-data[nrow(data)-1,"d_ppi"])+data[nrow(data)-1,"d_age"]
  #按照预测模型填充predicted_d_ppi
  data[nrow(data),"predicted_d_ppi"] <- (data[nrow(data),"k1_k2_ratio"]*data[nrow(data),"d_esal"]+data[nrow(data),"d_age"])*data[nrow(data),"k_d_age_e"]
  data <- data.frame(d_ppi=diff(data$d_ppi),d_esal=diff(data$d_esal),d_age=diff(data$d_age),predicted_d_ppi=diff(data$predicted_d_ppi))
  if(stage==1){data <- rbind(c(0,0,0,0),data)}
  return(data)
}
tmp <- setDT(tmp2)[, as.list(c(val = accumulation_information(stage,d_ppi,d_esal,d_age,k1_k2_ratio,k_d_age_e,predicted_d_ppi,ppi_threshold))), .(路线代码,方向,车道编号,起点桩号,止点桩号,技术等级,路面类型,道路结构和材料,stage)]
tmp <- tmp[-nrow(tmp),]#去掉最后一行
names(tmp) <- gsub(fixed=TRUE,"val.","",names(tmp))
tmp[,c("d_ppi","d_esal","d_age","predicted_d_ppi")] <- lapply(tmp[,c("d_ppi","d_esal","d_age","predicted_d_ppi")],FUN = cumsum)
#开始绘图
locate_stage_label <- function(stage){
  # return(quantile(seq(1,length(unique(stage)),length.out=length(stage)),probs = ((table(tmp$stage)[order(unique(tmp$stage))]+1)/2+c(0,cumsum(table(tmp$stage))[order(unique(tmp$stage))])[1:length(unique(tmp$stage))])/length(tmp$stage)))#stage必须提前按升序排列
  return(seq(from=(length(unique(stage))-1)/length(unique(stage))/2+1,by=(length(unique(stage))-1)/length(unique(stage)),length.out=length(unique(stage))))
  # return(seq(from=1,to=2,length.out=length(unique(stage))))
}
switch_stage_col <- function(stage){
  if(stage==1){
    "green"
  }else if(stage==2){
    "orange"
  }else{
    "red"
  }
}
stage_order <- function(stage,unique_stage){
  return(which(unique_stage==stage))
}
switch_colvar <- function(stage){#折线图每个线段的颜色值与两个端点有关
  stage <- sapply(stage,stage_order,unique_stage=unique(stage))#阶段标准化为从1开始,相邻阶段差为1
  if(length(stage)<=2){#长度过短
    return(stage)
  }else{
    tmp <- which(diff(stage)>0)#stage变化的地方
    if(identical(tmp,integer(0))){
      return(stage)
    }else if(length(tmp)==1){
      stage[tmp] <- stage[tmp+1]
    }else{
      stage[tmp[-length(tmp)]] <- ifelse(table(stage)[stage[tmp[-length(tmp)]]]>1,stage[tmp[-length(tmp)]+1],stage[tmp[-length(tmp)]])
      stage[tmp[-length(tmp)]+1] <- ifelse(table(stage)[stage[tmp[-length(tmp)]+1]]>1,stage[tmp[length(tmp)]],stage[tmp[length(tmp)]+1])
    }
  }
  return(stage)
}
par(mar=c(1,0,2,2))
plot3D::lines3D(x=tmp$d_esal,y=tmp$d_age,z=tmp$d_ppi,lwd=2,axes = FALSE,colvar = switch_colvar(tmp$stage),col=sapply(unique(tmp$stage),switch_stage_col),colkey = list(plot=TRUE,cex.clab=0.8,length=0.7,at=locate_stage_label(tmp$stage),labels=as.character(unique(tmp$stage)),cex.axis=0.7),
                clab = "Stage",main=paste(tmp$路线代码[1],tmp$方向[1],paste(tmp$车道编号[1],"#",sep = ""),paste("K",tmp$起点桩号[1],"-",tmp$止点桩号[1],sep = ""),"PPI自然衰变预测及验证"),cex.main=0.9,scale=TRUE,phi = 30)
plot3D::scatter3D(x=tmp$d_esal,y=tmp$d_age,z=tmp$predicted_d_ppi,scale=TRUE,colvar=tmp$stage,col=sapply(unique(tmp$stage), switch_stage_col),phi = 30,colkey = FALSE, type="p",add=TRUE)
#标签
x.tick.locations <- round(seq(from=range(tmp$d_esal)[1],to=range(tmp$d_esal)[2],length.out=7),0)
text3D(x.tick.locations*0.8, rep(-max(tmp$d_age)*0.2, length(x.tick.locations)), rep(0, length(x.tick.locations)), labels=round(seq(range(tmp$d_esal)[1],range(tmp$d_esal)[2],length.out=7),0),cex=0.6,add = TRUE)
text3D(mean(range(tmp$d_esal)), -max(tmp$d_age)*0.4, 0, labels="ESAL",cex=0.7,add = TRUE)
y.tick.locations <- round(seq(from=range(tmp$d_age)[1],to=range(tmp$d_age)[2],length.out=6),1)
text3D(rep(max(tmp$d_esal)*1.05, length(y.tick.locations)),y.tick.locations,rep(0, length(y.tick.locations)), labels=round(seq(from=range(tmp$d_age)[1],to=range(tmp$d_age)[2],length.out=6),0),cex=0.6,add = TRUE)
text3D(max(tmp$d_esal)*1.2,mean(tmp$d_age)*0.7, 0, labels="Road Age",cex=0.7,add = TRUE)
z.tick.locations <- round(seq(from=range(tmp$d_ppi)[1],to=range(tmp$d_ppi)[2],length.out=7),0)
text3D(rep(-max(tmp$d_esal)*0.15, length(z.tick.locations)),rep(0, length(z.tick.locations)),z.tick.locations, labels=z.tick.locations,cex=0.6,add = TRUE)
text3D(-max(tmp$d_esal)*0.15, 0, max(z.tick.locations)*1.1, labels=expression(paste(Delta," PPI")),cex=0.7,add = TRUE)
# write_xlsx(prediction_model,path = 'C:/Users/Archon/Desktop/prediction_model.xlsx')
print(Sys.time()-t1)

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
# tmp <- data[,c(1:5,11,12,15:24,32,34,35,37,39,43,44,46:55)]
tmp <- data[,c(1,3,4,35,37,39,43,44,53:55)]
#动态划分
info <- data.frame(养护对策=c("日常养护","封层","一层式铣刨加罩","二层式铣刨加罩","局部补强+二层式铣刨加罩","全面补强+翻修"),单价=c(7,42,105.9,207.86,268.5,655.82),最小连续实施长度=c(1,2,3,3,3,3),养护对策级别=c(0:5))
extract_price_info <- function(no,x,info){#no为需要提取信息的序号向量,x是各单元的养护对策级别序列,info为各养护对策的信息
  return(info[x[no]+1,"单价"])
}
dynamic_division <- function(x,info){#x是各单元的养护对策级别序列,info为各养护对策的信息(其中,最小连续实施长度是基本单元长度的整数倍)
  y <- rep(NA,length(x))#最终推荐养护对策级别序列初始化
  #第一步,从最高level开始,基于每个点,根据其min_length要求,拟将相邻片段置为本level
  highest_level <- max(x)#最高级别
  while(sum(!is.na(x))>0){
    tmp <- sort(unique(x),decreasing = TRUE)#序列中唯一的养护对策级别按降序排列,先处理级别高的
    level <- tmp[1]#当前考虑的养护对策级别
    min_length <- info[level+1,"最小连续实施长度"]
    tmp2 <- which(x==level)#该级别最小单元所在位置
    tmp3 <- foreach(i=tmp2,.combine = c) %do%
      {
        #从tmp2的位置起,往前往后分别考虑min_length内的单元,且不超过x序列本身的范围
        start <- max(i-min_length+1,1)
        end <- min(i+min_length-1,length(x))
        #在该范围内搜索
        if(end-start<=min_length-1){#总长度小于min_length,直接全选
          return(start:end)
        }else{#范围够大,则取min_length长度的序列,然后取全部替换为level级别后代价增加最小的
          tmp4 <- lapply(seq(from=start,to=end-min_length+1), seq,length.out=min_length)#枚举start:end内所有长为min_length的连续片段
          tmp5 <- lapply(tmp4, extract_price_info,x=x,info=info)#通过序号提取相应的价格信息
          tmp5 <- sapply(tmp5, sum,na.rm=TRUE)
          tmp5 <- which.max(tmp5)#取第一个和最大的作为初始解
          return(tmp4[[tmp5]])#范围该片段在x中的序号
        }
      }
    #输出拟设置为本级level的序号
    tmp3 <- unique(tmp3)#序号去重
    tmp4 <- tmp3[!is.na(y[tmp3])];tmp3 <- setdiff(tmp3,tmp4)#已有上一级措施的不替换
    #第二步,从第一步已经实现自动聚合的拟实施本level措施的片段中,筛选出连续实施长度超过min_length的,然后将两端的非本级措施删除,以实现节省资金的目的.注意删除时如果要使本片段长度小于min_length,则不再删除.参考示例片段为033433400
    if(!identical(tmp3,numeric(0))){#如果tmp3非空,则进行处理
      #存在多个拟实施本级措施的片段,则需要对每个片段分别处理.注意是!=1,因为是基于序号的差分进行的判断
      start <- c(tmp3[1],tmp3[which(diff(tmp3)!=1)+1])#连续实施片段的起点序号
      end <- c(tmp3[which(diff(tmp3)!=1)],tmp3[length(tmp3)])#连续实施片段的止点序号
      tmp5 <- which(end-start>=min_length)#筛选出连续实施长度超过min_length的,注意没有-1,因为是要超过
      if(!identical(tmp5,integer(0))){#如果存在连续实施长度超过min_length的片段
        tmp6 <- foreach(i=tmp5,.combine = c) %do% #对于每个片段,分别处理
          {
            tmp7 <- x[start[i]:end[i]]#取得该片段
            tmp8 <- length(tmp7)-min_length#允许删除的最大数量
            tmp9 <- which(tmp7==level)#本级措施所在位置
            tmp10 <- seq(from=1,to=length(tmp7))#tmp7中的局部序号
            tmp11 <- c(which(tmp10<min(tmp9)),which(tmp10>max(tmp9)))#两端最后一个本级level点以外的位置(局部序号)
            if(!identical(tmp11,integer(0))){#如果有数据点
              if(length(tmp11)<=tmp8){
                return((start[i]:end[i])[tmp11])#返回可以删除的全局序号
              }else{
                return((start[i]:end[i])[tmp11[1:tmp8]])#从前面开始删,因为初始解也是从前面开始取的
              }
            }else{
              return(NULL)
            }
          }
        tmp3 <- setdiff(tmp3,tmp6)#输出拟设置为本级level的序号,已根据第二步的原则删除了部分非必要实施的序号
      }
      #第三步,对于端头level低于本级level的片段(连续长度必然小于等于min_length,因为经过了第二步的处理),尝试进行实施窗口的滑动,使其与min_length范围内的其它片段更紧凑,从而实现经费节省的效果
      #tmp3修改后,重新计算每个拟设置为本级level片段的起止点
      start <- c(tmp3[1],tmp3[which(diff(tmp3)!=1)+1])
      end <- c(tmp3[which(diff(tmp3)!=1)],tmp3[length(tmp3)])
      tmp2 <- which(end-start<=min_length-1)
      while(!identical(tmp2,integer(0))){
        tmp4 <- start[tmp2[1]]:end[tmp2[1]]#第一个片段的全局序号
        tmp5 <- x[tmp4]#该片段对应的level序列
        tmp6 <- which(tmp5==level)#本级措施所在位置(局部序号)
        tmp7 <- 1:length(tmp5)#tmp5中的局部序号
        tmp8 <- which(tmp7<min(tmp6))#左边端点以外的位置(局部序号)
        tmp9 <- which(tmp7>max(tmp6))#右边端点以外的位置(局部序号)
        slided <- FALSE#初始化,未曾滑动
        while (!identical(c(tmp8),integer(0))){#左右端点中存在小于本级level的片段
          tmp10 <- tmp4[tmp8[1]]#逐个全局序号判断是否需要移动
          tmp8 <- tmp8[-1]#将当前序号从tmp8中移除
          tmp11 <- tmp10+length(tmp4)#检查该片段右边第一个位置
          #检查能否滑动到tmp11的位置
          if(!any(is.na(x[tmp10:tmp11])) & x[tmp11]==x[tmp10]){#tmp10:tmp11之间不包含已经处理过的数据,且tmp10和tmp11位置处措施相同时,才可以滑动
            tmp12 <- c(setdiff(tmp4,tmp10),tmp11)#向右移动一位后该片段的全局序号
            tmp13 <- tmp3;tmp13[seq(from=which(tmp3==tmp10),length.out=length(tmp4))] <- tmp12;tmp13 <- sort(c(tmp13,which(!is.na(y))))#移动后拟实施本级及更高level措施的全局序号
            tmp14 <- sort(c(tmp3,which(!is.na(y))))#移动前拟实施本级及更高level措施的全局序号
            tmp15 <- which(diff(tmp14)>1 & diff(tmp14)<=min_length)#移动前相邻距离小于等于min_length且大于1的位置
            tmp16 <- which(diff(tmp13)>1 & diff(tmp13)<=min_length)#移动后相邻距离小于等于min_length且大于1的位置
            if(sum(diff(tmp13)[tmp16]) < sum(diff(tmp14)[tmp15])){#注意如果tmp15或tmp16为空sum后的值为0
              tmp3 <- setdiff(tmp13,which(!is.na(y)))#需要向右移动,当且仅当存在更多相邻距离小于min_length的片段时
              slided <- TRUE#已经移动
            }
          }
        }
        if(slided==FALSE){#未曾向右移动,可以考虑向左移动
          while (!identical(c(tmp9),integer(0))){
            tmp10 <- tmp4[tmp9[1]]#逐个序号(全局序号)判断是否需要移动
            tmp9 <- tmp9[-1]#将当前序号从tmp9中移除
            tmp11 <- tmp10-length(tmp4)#检查该片段左边第一个位置
            #检查能否移动到tmp11的位置
            if(!any(is.na(x[tmp11:tmp10])) & x[tmp11]==x[tmp10]){#tmp11:tmp10之间不包含已经处理过的数据,且tmp11和tmp10位置处措施相同时,才可以移动
              tmp12 <- c(tmp11,setdiff(tmp4,tmp10))#向左移动一位后该片段的全局序号
              tmp13 <- tmp3;tmp13[seq(to=which(tmp3==tmp10),length.out=length(tmp4))] <- tmp12;tmp13 <- sort(c(tmp13,which(!is.na(y))))#移动后拟实施本级及更高level措施的全局序号
              tmp14 <- sort(c(tmp3,which(!is.na(y))))#移动前拟实施本级及更高level措施的全局序号
              tmp15 <- which(diff(tmp14)>1 &diff(tmp14)<=min_length)#移动前相邻距离小于等于min_length且大于1的位置
              tmp16 <- which(diff(tmp13)>1 & diff(tmp13)<=min_length)#移动后相邻距离小于等于min_length且大于1的位置
              if(sum(diff(tmp13)[tmp16]) < sum(diff(tmp14)[tmp15])){#注意如果tmp15或tmp16为空sum后的值为0
                tmp3 <- setdiff(tmp13,which(!is.na(y)))#需要向左移动,当且仅当存在更多相邻距离小于min_length的片段时
              }
            }
          }
        }
        tmp2 <- tmp2[-1]#不再考虑该片段
      }
    }
    #第四步,如果本级level非highest_level,则判断tmp3中每个片段,是部分实施更高level，还是整体实施本级level
    if(level!=highest_level){
      while(!(identical(tmp3,integer(0))|identical(tmp3,numeric(0)))){#tmp3逐个片段进行处理
        start <- tmp3[c(1,which(diff(tmp3)!=1)+1)][1]#第一个片段的起点全局序号
        end <- tmp3[c(which(diff(tmp3)!=1),length(tmp3))][1]#第一个片段的止点全局序号
        tmp2 <- x[start:end]#取出第一个片段的等级序列
        if(max(tmp2)<level){#跨片段设置导致本片段中本级level缺失
          tmp3 <- setdiff(tmp3,c(start:end))#移除已经考虑过的全局序号
          next
        }else{
          if(tmp2[1]==level & tmp2[length(tmp2)]==level){#如果该片段首尾的level均为本级level,则整体实施本级level
            tmp3 <- setdiff(tmp3,c(start:end))#移除已经考虑过的全局序号
            y[start:end] <- level#设置本级level序列
            x[start:end] <- NA#已经考虑过的位置置为NA
            next
          }else{
            delta_cost_default <- sum(info[level+1,"单价"]-info[tmp2+1,"单价"])#整体实施本级level的增量代价
            location_this <- (start:end)[which(tmp2==level)]#本级level的全局序号
            location_higher <- which(!is.na(y))#比本级level更高的位置
            if(max(location_this)<min(location_higher)){#只能向右升级
              no_right <- min(location_this):(min(location_higher)-1)#拟升级的全局序号
              upgraded_level_right <- y[min(location_higher)]#拟升级为的级别
              delta_cost_right <- info[upgraded_level_right+1,"单价"]*length(no_right)-sum(info[x[no_right]+1,"单价"])#采用升级方法的增量代价
              delta_cost_left <- Inf
            }else if(min(location_this)>max(location_higher)){#只能向左升级
              no_left <- (max(location_higher)+1):min(location_this)#拟升级的全局序号
              upgraded_level_left <- y[max(location_higher)]#拟升级为的级别
              delta_cost_left <- info[upgraded_level_left+1,"单价"]*length(no_left)-sum(info[x[no_left]+1,"单价"])#采用升级方法的增量代价
              delta_cost_right <- Inf
            }else{
              no_left <- (location_higher[which.max(location_higher-min(location_this)>0)-1]+1):min(location_this)#往左侧升级拟采用的全局序号
              no_right <- max(location_this):(location_higher[which.max(location_higher-min(location_this)>0)]-1)#往右侧升级拟采用的全局序号
              upgraded_level_left <- y[location_higher[which.max(location_higher-min(location_this)>0)-1]]#往左侧升级拟升级为的级别
              upgraded_level_right <- y[location_higher[which.max(location_higher-min(location_this)>0)]]#往右侧升级拟升级为的级别
              delta_cost_left <- info[upgraded_level_left+1,"单价"]*length(no_left)-sum(info[x[no_left]+1,"单价"])#往左侧升级的增量代价
              delta_cost_right <- info[upgraded_level_right+1,"单价"]*length(no_right)-sum(info[x[no_right]+1,"单价"])#往右侧升级的增量代价
            }
            if(delta_cost_default <= min(delta_cost_left,delta_cost_right)){
              tmp3 <- setdiff(tmp3,c(start:end))#移除已经考虑过的全局序号
              y[start:end] <- level#设置本级level序列
              x[start:end] <- NA#已经考虑过的位置置为NA
              next
            }else if(delta_cost_left<=delta_cost_right){#往左侧升级
              y[no_left] <- upgraded_level_left#设置左侧升级序列
              x[no_left] <- NA#已经考虑过的位置置为NA
              tmp3 <- setdiff(tmp3,c(start:end,no_left))#移除已经考虑过的全局序号
            }else{#往右侧升级
              y[no_right] <- upgraded_level_right#设置右侧升级序列
              x[no_right] <- NA#已经考虑过的位置置为NA
              tmp3 <- setdiff(tmp3,c(start:end,no_right))#移除已经考虑过的全局序号
            }
          }
        }
      }
    }else{
      y[tmp3] <- level#设置本级level序列
      x[tmp3] <- NA#已经考虑过的位置置为NA
    }
  }
  # 第五步,对于不满足连续实施最小长度的片段,考虑两种处理方式,一种是合并到相邻更高level的片段中，一种是相邻更低level的(部分)片段替换为本level
  repeat{
    tmp <- c(1,which(diff(y)!=0)+1)#所有片段的起点序号
    segment_info <- data.frame(start=tmp,end=c(which(diff(y)!=0),length(y)),level=y[tmp])#每个片段基本信息
    segment_info$length <- segment_info$end-segment_info$start+1;segment_info$min_length <- info[segment_info$level+1,"最小连续实施长度"]#补充每个片段的基本信息
    tmp2 <- which(segment_info$length<segment_info$min_length)#需要处理的片段在segment_info中的局部序号
    if(identical(tmp2,integer(0))){#没有需要处理的片段了
      break
    }
    tmp2 <- tmp2[1]#逐个片段进行处理
    if(nrow(segment_info)==1){#只有一个片段,则无需处理
      break
    }else if(tmp2==1){#片段开头,只能向右处理
      right_level <- segment_info[tmp2+1,"level"]
      if(right_level>segment_info[tmp2,"level"]){
        y[segment_info[tmp2,"start"]:segment_info[tmp2,"end"]] <- right_level#右侧level更大,则本段的level置为右侧level
      }else{
        additional_length <- segment_info[tmp2,"min_length"]-segment_info[tmp2,"length"]#需要扩大的长度
        right_length <- min(additional_length,segment_info[tmp2+1,"length"])#最大扩展至下一个完整的相邻片段,如果后续还需要扩大可以通过反复迭代实现
        y[segment_info[tmp2,"start"]:(segment_info[tmp2,"end"]+right_length)] <- segment_info[tmp2,"level"]#将相邻更低level的(部分)片段替换为本level
      }
    }else if(tmp2==nrow(segment_info)){#片段末尾,只能向左处理
      left_level <- segment_info[tmp2-1,"level"]
      if(left_level>segment_info[tmp2,"level"]){
        y[segment_info[tmp2,"start"]:segment_info[tmp2,"end"]] <- left_level#左侧level更大,则本段的level置为右侧level
      }else{
        additional_length <- segment_info[tmp2,"min_length"]-segment_info[tmp2,"length"]#需要扩大的长度
        left_length <- min(additional_length,segment_info[tmp2-1,"length"])#最大扩展至下一个完整的相邻片段,如果后续还需要扩大可以通过反复迭代实现
        y[(segment_info[tmp2,"start"]-left_length):(segment_info[tmp2,"end"])] <- segment_info[tmp2,"level"]#将相邻更低level的(部分)片段替换为本level
      }
    }else{#中间片段,对可以向两边处理
      left_level <- segment_info[tmp2-1,"level"]
      right_level <- segment_info[tmp2+1,"level"]
      if(min(left_level,right_level)>segment_info[tmp2,"level"]){#如果两边的level都更高,则本段的level设置为其中更低的
        y[segment_info[tmp2,"start"]:segment_info[tmp2,"end"]] <- min(left_level,right_level)
      }else{
        additional_length <- segment_info[tmp2,"min_length"]-segment_info[tmp2,"length"]#需要扩大的长度
        if(left_level>segment_info[tmp2,"level"]){#只能向右扩展
          right_length <- min(additional_length,segment_info[tmp2+1,"length"])#最大扩展至下一个完整的相邻片段,如果后续还需要扩大可以通过反复迭代实现
          y[segment_info[tmp2,"start"]:(segment_info[tmp2,"end"]+right_length)] <- segment_info[tmp2,"level"]#将相邻更低level的(部分)片段替换为本level
        }else if(right_level>segment_info[tmp2,"level"]){
          left_length <- min(additional_length,segment_info[tmp2-1,"length"])#最大扩展至下一个完整的相邻片段,如果后续还需要扩大可以通过反复迭代实现
          y[(segment_info[tmp2,"start"]-left_length):(segment_info[tmp2,"end"])] <- segment_info[tmp2,"level"]#将相邻更低level的(部分)片段替换为本level
        }else{
          #可以向两边扩展的长度
          left_length <- min(additional_length,segment_info[tmp2-1,"length"])
          right_length <- min(additional_length,segment_info[tmp2+1,"length"])
          if(segment_info[tmp2,"length"]+left_length+right_length<segment_info[tmp2,"min_length"]){#向两边最大程度扩展后仍不满足最小连续实施长度要求,则整段置为本级level,待后续迭代处理
            y[(segment_info[tmp2,"start"]-left_length):(segment_info[tmp2,"end"]+right_length)] <- segment_info[tmp2,"level"]#将本片段扩展后的片段替换为本级level
          }else{
            tmp3 <- lapply(seq(from=segment_info[tmp2,"start"]-left_length,to=segment_info[tmp2,"end"]+right_length-segment_info[tmp2,"min_length"]+1), seq,length.out=segment_info[tmp2,"min_length"])#枚举可选全局序号范围中任意连续min_length长度的序号
            tmp4 <- lapply(tmp3, extract_price_info,x=y,info=info)#通过序号提取相应的价格信息
            tmp5 <- sapply(tmp4, sum)
            tmp6 <- which.max(tmp5)#第一个最大值所在位置
            y[tmp3[[tmp6]]] <- segment_info[tmp2,"level"]#将本片段扩展后的片段替换为本级level
          }
        }
      }
    }
  }
  return(y)
}
tmp <- c(0,2,2,2,3,4,3,3,2,4,1,2,1,2,0,2,3,1,1,2,1,4,3,3,2,4,0,2,1,0,4,3,0,4,4,4,4,4,2,0,0,1)
print(dynamic_division(tmp,info = info))

# #动态分段
# x_info <- data.frame(养护对策=c("日常养护","封层","一层式铣刨加罩","二层式铣刨加罩","局部补强+二层式铣刨加罩","全面补强+翻修"),单价=c(0,42,105.9,207.86,268.5,655.82),最小连续实施长度=c(0,200,300,300,300,300),养护对策级别=c(0:5))
# dynamic_division <- function(x,len,info){#x是各单元的养护对策级别序列,len为各单元的长度序列,info为各养护对策的信息
#   tmp <- sort(unique(x),decreasing = TRUE)#序列中唯一的养护对策级别按降序排列,先处理级别高的
#   while(!identical(tmp,numeric(0))){
#     level <- tmp[1]#当前考虑的养护对策级别
#     
#     
#   }
#   
# }
# min_enclosure_length <- 0.5#最小围封长度为0.5km
# # sample(0:4,40,replace = TRUE)
# tmp2 <- data.frame(养护对策级别=c(0,2,2,4,3,3,2,3,1,2,1,2,0,2,3,1,1,2,1,4,3,3,2,4,0,2,1,0,4,3,0,4,4,4,4,4,2,0,0,1))


# outcome <- function(start,end,unit_stake_length,width,level,iri,iri_annual_increase){
#   outcome <- ""#输出项的初始值
#   price <- c(70,115,213)#轻中重三级单价
#   if(level %in% c("高速","一级","快速路")){
#     iri_threshold <- c(2.23,2.95,3.48)#分别对应RQI=90,85,80
#   }else{
#     iri_threshold <- c(3.09,3.89,4.49)
#   }
#   tmp <- ifelse(iri>=max(iri_threshold),3,which.max(iri-iri_threshold<=0))#iri在哪一档
#   if(tmp==3){#在第3档时要多滚动一个周期
#     if(iri<=iri_threshold[3]){#iri小于第三档阈值的情况
#       interval <- round((iri_threshold[3]-iri)/iri_annual_increase,1)#时间间隔
#     }else{
#       interval <- 0
#     }
#     iri_next <- iri+iri_annual_increase*interval#下次实施时对应的iri
#     measure_next <- "重强度养护"#下次养护措施
#     total_price_next <- round(abs(end-start)*0.0001*unit_stake_length*width*price[3],2)#下次实施时的养护措施总价
#     outcome <- paste(outcome,"_",interval,"(",iri_next,",",measure_next,",",total_price_next,")",sep = "")
#     iri <- 0#重置iri
#     tmp <- 1#重置tmp
#   }
#   while (tmp<=3) {
#     interval <- round((iri_threshold[tmp]-iri)/iri_annual_increase,1)#时间间隔
#     iri_next <- iri+iri_annual_increase*interval#下次实施时对应的iri
#     measure_next <- c("轻强度养护","中强度养护","重强度养护")[tmp]#下次养护措施
#     total_price_next <- round(abs(end-start)*0.0001*unit_stake_length*width*price[tmp],2)#下次实施时的养护措施总价
#     outcome <- paste(outcome,"_",interval,"(",iri_next,",",measure_next,",",total_price_next,")",sep = "")
#     iri <- 0#重置iri
#     tmp <- tmp+1
#   }
#   return(outcome)
# }
# segmented$长周期养护规划方案 <- pmap_chr(.l=list(start=segmented$起点桩号,end=segmented$止点桩号,unit_stake_length=segmented$单位桩号长度,width=segmented$车道宽度,level=segmented$技术等级,iri=segmented$IRI,iri_annual_increase=segmented$iri_annual_increase),.f=outcome)
# outcome <- segmented[,c("路段名称","段标志头","起点桩号","止点桩号","相邻桩间距","方向或方位","车道编号","车道宽度","路面类型","IRI","长周期养护规划方案")]
# 
# #完整规划路径
# full_planning_results <- segmented[,c("路段名称","段标志头","起点桩号","止点桩号","相邻桩间距","单位桩号长度","方向或方位","车道编号","技术等级","车道宽度","路面类型","IRI","iri_annual_increase")]
# ##split函数分组依赖的字段组合
# full_planning_results$id <- paste(full_planning_results$路段名称,full_planning_results$段标志头,full_planning_results$起点桩号,full_planning_results$方向或方位,full_planning_results$车道编号,sep = "-")
# #分组规划函数
# segment_plannning <- function(one_row,latest_year){
#   n <- 20#规划期
#   iri_initial <- one_row$IRI;#IRI初始值
#   level <- one_row$技术等级;#技术等级
#   iri_annual_increase <- one_row$iri_annual_increase;#IRI年增量
#   one_row <- dplyr::slice(.data = one_row,rep(1:dplyr::n(), each = n))
#   one_row$数据年份 <- rep(1:n)+latest_year
#   #各措施对应的IRI触发阈值
#   if(level %in% c("高速","一级","快速路")){
#     iri_threshold <- c(0,2.23,2.95,3.48)#分别对应RQI=100,90,85,80
#   }else{
#     iri_threshold <- c(0,3.09,3.89,4.49)
#   }
#   #计算规划期内的ppi序列
#   tmp <- max(which(iri_initial-iri_threshold>=0))#iri_initial在哪一档(1-4档)
#   n0 <- 1#已经规划到哪一年
#   ppi <- rep(NA,n)#初始化ppi序列
#   while(n0<=n){
#     if(tmp==4){
#       if(n0==1){ppi[1] <- iri_initial;n0 <- 2}#如果在n0=1的时候进入,则保留初始ppi,跳入第二年
#       iri_initial <- 0;tmp <- 1;#下一个生命周期
#     }else{
#       ppi_0 <- seq(from=iri_initial,to=iri_threshold[tmp+1],by=iri_annual_increase)#当前片段ppi序列
#       n_max <- if(n0+length(ppi_0)-1>=n){n}else{n0+length(ppi_0)-1}#赋值时的最大年限
#       ppi[n0:n_max] <- ppi_0[1:length(n0:n_max)]#将当前片段ppi序列赋值到对应年限的总的ppi序列中
#       n0 <- n0+length(ppi_0)#更新已经规划到的年份
#       iri_initial <- 0;#iri重归于0
#       tmp <- tmp+1#下一个生命周期的终点为下一个档次
#     }
#   }
#   one_row$IRI <- ppi#更新ppi序列
#   #计算养护措施序列
#   measure <- rep(NA,n)#初始化养护措施序列
#   tmp <- (which(ppi==0)-1)[which(ppi==0)-1>0]#实施养护措施的节点
#   ##判断最后一个节点是否需要对应专项养护措施
#   tmp2 <- max(which(ppi[length(ppi)]-iri_threshold>=0))
#   tmp3 <- max(which(ppi[length(ppi)]+iri_annual_increase-iri_threshold>=0))
#   if(tmp3-tmp2>0 | tmp2==4){tmp <- c(tmp,length(ppi))}#如果当前ppi增加一个iri_annual_increase导致ppi进入下一个档次,或当前ppi已经在最高档,则需要
#   #计算养护措施类型序号
#   tmp4 <- apply(abs(matrix(rep(ppi,4),ncol = 4,byrow = FALSE)-matrix(rep(iri_threshold,n),ncol = 4,byrow = TRUE)),1,which.min)
#   measure_type <- c("日常养护","轻强度养护","中强度养护","重强度养护")#养护措施类型
#   measure[tmp] <- tmp4[tmp]#专项养护措施对应的序号
#   measure[is.na(measure)] <- 1#其它均为默认的日常养护
#   #计算各措施所需费用
#   price <- c(7,70,115,213)#日常养护,轻中重强度养护单价
#   total_price <- round(abs(one_row$起点桩号-one_row$止点桩号)*0.0001*one_row$单位桩号长度*one_row$车道宽度*price[measure],2)
#   measure <- measure_type[measure]#转化为文本形式
#   one_row$推荐养护措施 <- measure
#   one_row$工程费用 <- total_price
#   return(one_row)
# }
# cl <- makeCluster(8)#并行计算核心(8个)
# #并行计算各分组的养护规划方案,然后用rbind合并到一起
# full_planning_results <- reduce(parLapply(cl,split(full_planning_results,full_planning_results$id),segment_plannning,latest_year=latest_year),rbind)
# stopCluster(cl)#关闭并行计算核心
# 
# #按数据年份分别绘制3D图,按桩号和车道展示各最小单元的PPI,维修对策,所需资金
# year <- 2024#指定数据年份
# facility_data <- full_planning_results[full_planning_results$路段名称==facility_name & full_planning_results$数据年份==year,]
# #各措施对应的IRI触发阈值
# if(full_planning_results[1,"技术等级"] %in% c("高速","一级","快速路")){
#   iri_threshold <- c(0,2.23,2.95,3.48)
# }else{
#   iri_threshold <- c(0,3.09,3.89,4.49)
# }
# #标签
# iri_threshold_label <- paste(iri_threshold,c("日常养护","轻强度养护","中强度养护","重强度养护"))
# #xyz
# x <- seq(from=min(c(facility_data$起点桩号,facility_data$止点桩号)),to=max(c(facility_data$起点桩号,facility_data$止点桩号)),by=facility_data$相邻桩间距[1])#以基本单元为间隔的里程桩号序列
# ##y 方向强制为上行和下行,分别查看有几个车道的数据
# y_s <- unique(facility_data[facility_data$方向或方位=="上行","车道编号"]);y_s <- y_s[order(y_s)]
# y_x <- unique(facility_data[facility_data$方向或方位=="下行","车道编号"]);y_x <- y_x[order(y_x)]
# y <- length(c(y_s,y_x))
# ##y_tick_labels
# if(!identical(y_x,numeric(0)) & !identical(y_s,numeric(0))){
#   y_tick_labels <- c(paste("下行",y_x[order(y_x,decreasing = TRUE)],"#",sep = ""),paste("上行",y_s,"#",sep = ""))
# }else if(identical(y_x,numeric(0))){
#   y_tick_labels <- paste("上行",y_s,"#",sep = "")
# }else{
#   y_tick_labels <- paste("下行",y_x[order(y_x,decreasing = TRUE)],"#",sep = "")
# }
# #措施转换为数字级别,方便绘图
# facility_data$推荐养护措施 <- sapply(facility_data$推荐养护措施,FUN = function(x){switch(x,"日常养护" = iri_threshold[1],"轻强度养护" = iri_threshold[2],"中强度养护" = iri_threshold[3],"重强度养护" = iri_threshold[4])})
# z_ppi <- z_measure <- matrix(data = NA,nrow = length(x),ncol = y)#ppi矩阵及推荐养护措施矩阵,对应于相应的桩号和车道编号
# ##对z_ppi,z_measure赋值
# tmp <- foreach(i=1:nrow(facility_data)) %do%
#   {
#     tmp <- facility_data[i,]
#     start <- which.min(abs(min(tmp$起点桩号,tmp$止点桩号)-x));end <- which.min(abs(max(tmp$起点桩号,tmp$止点桩号)-x))-1#注意end里有-1
#     if(tmp$方向或方位=="下行"){
#       col_no <- which.min(abs(tmp$车道编号-y_x[order(y_x,decreasing = TRUE)]))#tmp这一行的车道编号与y_x取逆序第几个相近就在第几列
#     }else{
#       col_no <- which.min(abs(tmp$车道编号-y_s))+length(y_x)#y轴先下行再上行,下行车道编号从大到小,上行车道编号从小到大,因此此处y_s取正常顺序,注意要加一个length(y_x)而不是length(y_s)
#     }
#     z_ppi[start:end,col_no] <- tmp$IRI
#     z_measure[start:end,col_no] <- tmp$推荐养护措施
#   }
# #绘图前配置
# ##配置调色板palette,以固定颜色-IRI阈值的关系
# tmp <- unique(as.vector(z_measure));tmp <- tmp[!is.na(tmp)]
# tmp <- tmp[order(tmp)]
# tmp2 <- lm(y~x,data = data.frame(x=c(iri_threshold[1],iri_threshold[4]),y=c(1,100)))
# start <- round(tmp2$coefficients[1]+tmp2$coefficients[2]*min(tmp),0)
# end <- round(tmp2$coefficients[1]+tmp2$coefficients[2]*max(tmp),0)
# #资金量统计
# ##推荐养护措施由数值逆转换为文本
# measure_num_text <- function(x){
#   if(x==iri_threshold[1]){
#     "日常养护"
#   }else if(x==iri_threshold[2]){
#     "轻强度养护"
#   }else if(x==iri_threshold[3]){
#     "中强度养护"
#   }else if(x==iri_threshold[4]){
#     "重强度养护"
#   }else{
#     NA
#   }
# }
# facility_data$推荐养护措施 <- map_chr(.x=facility_data$推荐养护措施,.f=measure_num_text)
# tmp <- aggregate(工程费用~推荐养护措施,data=facility_data,FUN = sum,na.rm=TRUE)
# tmp$推荐养护措施 <- factor(tmp$推荐养护措施,levels=c("日常养护","轻强度养护","中强度养护","重强度养护"))
# tmp <- tmp[order(tmp$推荐养护措施),]
# tmp2 <- "      资金需求（万元）："
# for (i in 1:nrow(tmp)) {
#   tmp2 <- paste(tmp2,tmp[i,"推荐养护措施"],tmp[i,"工程费用"]," ",sep = "")
# }
# tmp2 <- gsub("养护","",tmp2,fixed = TRUE)

# #统计分析
# tmp <- aggregate(full_planning_results,工程费用~路段名称+推荐养护措施,FUN = sum)
# tmp2 <- aggregate(full_planning_results,工程费用~路段名称,FUN = sum)
# ##扩展segmented至基本单元
# expand_segmented <- function(one_row){
#   if(!is.na(one_row$段标志头)){#按特殊桩
#     start <- min(one_row$起点桩号,one_row$止点桩号);end <- max(one_row$起点桩号,one_row$止点桩号);interval <- one_row$相邻桩间距
#     row_number <- floor((one_row$止点桩号-one_row$起点桩号)/interval)#扩展后的行数
#     one_row <- dplyr::slice(one_row, rep(1:dplyr::n(), each = row_number))#扩展
#     #从起点起按相邻桩间距依次增加至止点
#     one_row$起点桩号 <- seq(from=start,to=end-interval,by=interval)
#     one_row$止点桩号 <- one_row$起点桩号+interval
#     return(one_row)
#   }else if(!is.na(one_row$起点桩号)){#按公里桩
#     start <- min(one_row$起点桩号,one_row$止点桩号)
#     end <- max(one_row$起点桩号,one_row$止点桩号)
#     interval <- one_row$相邻桩间距
#     if(start%%interval==interval){
#       start_new <- start
#     }else{
#       start_new <- start-start%%interval+interval#取start的interval最高整数倍并加一个interval，以避免从非整部分起算，同时从后段开始
#     }
#     if(end%%interval==interval){
#       end_new <- end
#     }else{
#       end_new <- end-end%%interval#取end的interval最高整数倍
#     }
#     row_number <- round((end_new-start_new)/interval,digits = 0)#行数
#     one_row <- dplyr::slice(one_row, rep(1:dplyr::n(), each = row_number))
#     one_row$起点桩号 <- seq(from=start_new,to=end_new-interval,by=interval)
#     one_row$止点桩号 <- one_row$起点桩号+interval
#     one_row$起点桩号[1] <- start#起点桩号更新为原始起点桩号
#     one_row$止点桩号[NROW(one_row)] <- end#止点桩号更新为原始止点桩号
#     return(one_row)
#   }else{#非按桩号
#     return(one_row)
#   }
# }
# cl <- makeCluster(8)
# segmented_expanded <- reduce(parLapply(cl,split(segmented,1:NROW(segmented)),expand_segmented),rbind)#生成完整数据集
# stopCluster(cl)
# #筛选数据
# tmp <- segmented_expanded[segmented_expanded$路段名称==facility_name,]
# tmp$车道编号 <- ifelse(tmp$方向或方位=="下行",4-tmp$车道编号+1,tmp$车道编号)
# tmp$车道编号 <- ifelse(tmp$方向或方位=="上行",tmp$车道编号+4,tmp$车道编号)
# tmp$group_id <- as.factor(tmp$group_id)
# #绘制分组情况格子图
# Color_jet <- jet.col(n=length(unique(tmp$group_id)), alpha=1)[5:80] # 设置颜色
# ggplot(tmp, aes(x = 起点桩号, y = 车道编号, fill = group_id)) +
#   geom_tile() +
#   scale_fill_manual(name = "Category",
#                     values = Color_jet)+
#   theme(panel.background = element_blank(),
#     plot.title = element_text(size = rel(1.2)),
#     axis.title = element_blank(),
#     axis.ticks = element_blank(),
#     legend.title = element_blank(),
#     legend.position = "right")
# #使用性能衰变速率热力图
# ggplot(tmp, aes(x = 起点桩号, y = 车道编号)) +
#   xlab("桩号") +  #x轴标签
#   theme_bw() + #设置系统自带主题
#   theme(panel.grid.major = element_blank()) +  #设置主项网格
#   theme(legend.key=element_blank()) + #去掉背景颜色
#   theme(axis.text.x=element_text(angle=45,hjust=1, vjust=1)) +  #设置坐标轴标签
#   theme(legend.position="top") +  #设置图例的位置
#   geom_tile(aes(fill=iri_annual_increase)) +  #设置填充的值
#   scale_fill_gradient("年衰变量",low = "white", high = "red") #设置颜色梯度
# #使用性能热力图
# whole$方向和车道 <- factor(paste(whole$方向或方位,whole$车道编号,sep = ""),levels = c("下行4","下行3","下行2","下行1","上行1","上行2","上行3","上行4"))
# ggplot(whole, aes(x = 起点桩号, y = 方向和车道)) +
#   xlab("桩号") +  #x轴标签
#   theme_bw() + #设置系统自带主题
#   theme(panel.grid.major = element_blank()) +  #设置主项网格
#   theme(legend.key=element_blank()) + #去掉背景颜色
#   theme(axis.text.x=element_text(angle=45,hjust=1, vjust=1)) +  #设置坐标轴标签
#   theme(legend.position="top") +  #设置图例的位置
#   geom_tile(aes(fill=IRI)) +  #设置填充的值
#   scale_fill_gradient("IRI",low = "white", high = "red") #设置颜色梯度
# #嘉浏课题的养护工程量及费用
# tmp <- read_excel(path = 'D:/Works/道路长周期养护规划/嘉浏课题20年养护规划结果2.xlsx')
# # tmp$单价 <- sapply(tmp$养护措施,FUN = function(x){switch(x,"日常养护" = 7,"轻强度养护" = 70,"中强度养护" = 115,"重强度养护" = 213)})
# # tmp$总价 <- round(tmp$单价*tmp$里程/10000,2)
# tmp$养护措施 <- factor(x=tmp$养护措施,levels = c("预防性养护","4cm铣刨加罩","10cm铣刨加罩"))
# ggplot(data=tmp, mapping=aes(x = 数据年份, y = 总价,fill=养护措施))+geom_bar(stat="identity",position=position_dodge(0.75))+
#   scale_fill_manual(values=c('yellow', 'brown1', 'brown4'))+
#   theme(panel.background = element_blank(),
#         plot.title = element_text(size = rel(1.2)),
#         legend.title = element_blank(),
#         legend.position = "right")
# ##统计
# tmp2 <- aggregate(总价~养护措施,data = tmp,FUN = sum)
# #本课题的养护工程量及费用
# tmp <- full_planning_results[full_planning_results$路段名称=="G15高速嘉浏段",]
# # tmp$推荐养护措施 <- ifelse(tmp$推荐养护措施=="重强度养护","中强度养护",tmp$推荐养护措施)
# tmp2 <- aggregate(工程费用~推荐养护措施+数据年份,data = tmp,FUN = sum)
# tmp2$推荐养护措施 <- factor(x=tmp2$推荐养护措施,levels = c("日常养护","轻强度养护","中强度养护","重强度养护"))
# ggplot(data=tmp2, mapping=aes(x = 数据年份, y = 工程费用,fill=推荐养护措施))+geom_bar(stat="identity",position=position_dodge(0.75))+
#   scale_fill_manual(values=c('blue','yellow', 'brown1', 'brown4'))+
#   theme(panel.background = element_blank(),
#         plot.title = element_text(size = rel(1.2)),
#         legend.title = element_blank(),
#         legend.position = "right")
# ##统计
# tmp2 <- aggregate(工程费用~推荐养护措施,data = tmp,FUN = sum)

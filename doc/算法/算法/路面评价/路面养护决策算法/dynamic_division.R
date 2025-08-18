tmp2 <- data.frame(养护对策级别=c(0,2,2,2,3,4,3,3,2,4,1,2,1,2,0,2,3,1,1,2,1,4,3,3,2,4,0,2,1,0,4,3,0,4,4,4,4,4,2,0,0,1))
#动态分段
info <- data.frame(养护对策=c("日常养护","封层","一层式铣刨加罩","data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABIAAAASCAYAAABWzo5XAAAAbElEQVR4Xs2RQQrAMAgEfZgf7W9LAguybljJpR3wEse5JOL3ZObDb4x1loDhHbBOFU6i2Ddnw2KNiXcdAXygJlwE8OFVBHDgKrLgSInN4WMe9iXiqIVsTMjH7z/GhNTEibOxQswcYIWYOR/zAjBJfiXh3jZ6AAAAAElFTkSuQmCC二层式铣刨加罩","局部补强+二层式铣刨加罩","全面补强+翻修"),单价=c(7,42,105.9,207.86,268.5,655.82),最小连续实施长度=c(1,2,3,3,3,3),养护对策级别=c(0:5))
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

print(dynamic_division(tmp2$养护对策级别,info))
# sample(0:4,40,replace = TRUE)

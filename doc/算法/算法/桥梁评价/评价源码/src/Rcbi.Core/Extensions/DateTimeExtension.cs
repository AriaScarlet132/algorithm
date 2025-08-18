namespace Rcbi.Core.Extensions
{
    using System;
    using System.Diagnostics;

    public static class DateTimeExtension
    {
        private static readonly DateTime MinDate = new DateTime(1900, 1, 1);
        private static readonly DateTime MaxDate = new DateTime(9999, 12, 31, 23, 59, 59, 999);

        //[DebuggerStepThrough]
        public static bool IsValid(this DateTime target)
        {
            return (target >= MinDate) && (target <= MaxDate);
        }

        public static string ToWeek(this DateTime dt)
        {
            var weekdays = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            return weekdays[(int)dt.DayOfWeek];
        }

        public static long ToUnixTimestamp(this DateTime target)
        {
            return (long)(target - TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1))).TotalSeconds;
        }

        public static DateTime SqlMinDate(this DateTime target)
        {
            return MinDate;
        }

        //使用C#把发表的时间改为几个月,几天前,几小时前,几分钟前,或几秒前
        public static string ToDateStringFromNow(this DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToString("yyyy-MM-dd");
            }
            else
            {
                if (span.TotalDays > 30)
                {
                    return
                    string.Format("1个月前({0})", dt.ToString("yyyy-MM-dd"));
                }
                else
                {
                    if (span.TotalDays > 14)
                    {
                        return
                        string.Format("2周前({0})", dt.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        if (span.TotalDays > 7)
                        {
                            return
                           string.Format("1周前({0})", dt.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            if (span.TotalDays > 1)
                            {
                                return
                                string.Format("{0}天前({1})", (int)Math.Floor(span.TotalDays), dt.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                if (span.TotalHours > 1)
                                {
                                    return
                                    string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                {
                                    if (span.TotalMinutes > 1)
                                    {
                                        return
                                        string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                    {
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return
                                            string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return
                                            "1秒前";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static string ToDateString(this DateTime target)
        {
            return target.ToString("yyyy-MM-dd");
        }

        public static string ToDateTimeString(this DateTime target)
        {
            return target.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToDateHourString(this DateTime target)
        {
            return target.ToString("yyyy-MM-dd HH:00");
        }

        public static string ToDateString(this DateTime? target)
        {
            if (!target.HasValue)
            {
                return null;
            }

            return ToDateString(target.Value);
        }

        /// <summary>
        /// Gets the start DateTime of the current instance on the day.
        /// </summary>
        /// <param name="target">The DateTime to convert.</param>
        /// <returns>00:00:00</returns>
        public static DateTime StartTimeOfDay(this DateTime target)
        {
            return new DateTime(target.Year, target.Month, target.Day, 0, 0, 0);
        }

        /// <summary>
        /// Gets the end DateTime of the current instance on the day.
        /// </summary>
        /// <param name="target">The DateTime to convert.</param>
        /// <returns>23:59:59</returns>
        public static DateTime EndTimeOfDay(this DateTime target)
        {
            return new DateTime(target.Year, target.Month, target.Day, 23, 59, 59);
        }

        public static int ToAge(this DateTime target)
        {
            var now = DateTime.Now;
            int age = now.Year - target.Year;
            if (now.Month < target.Month || (now.Month == target.Month && now.Day < target.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }

        /// <summary>  
        /// Gets the DateTime of the current instance on the first day of the week.
        /// </summary>  
        /// <param name="target">The DateTime to convert.</param>  
        /// <returns>The Monday.</returns>
        public static DateTime FirstDayOfWeek(this DateTime target)
        {
            var weeknow = Convert.ToInt32(target.DayOfWeek);
            weeknow = (weeknow == 0 ? (7 - 1) : (weeknow - 1));
            return target.AddDays((-1) * weeknow);
        }

        /// <summary>  
        /// Gets the DateTime of the current instance on the last day of the week.。
        /// </summary>  
        /// <param name="target">The DateTime to convert.</param>  
        /// <returns>The Sunday.</returns>
        public static DateTime LastDayOfWeek(this DateTime target)
        {
            var weeknow = Convert.ToInt32(target.DayOfWeek);
            weeknow = (weeknow == 0 ? 7 : weeknow);
            return target.AddDays(7 - weeknow);
        }

        /// <summary>  
        /// Gets the DateTime of the current instance on the first day of the month.
        /// </summary>  
        /// <param name="target">The DateTime to convert.</param>  
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime target)
        {
            return new DateTime(target.Year, target.Month, 1);
        }

        /// <summary>  
        /// Gets the DateTime of the current instance on the last day of the month.
        /// </summary>  
        /// <param name="target">The DateTime to convert.</param>  
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime target)
        {
            var firstDate = target.FirstDayOfMonth();
            return firstDate.AddMonths(1).AddDays(-1);
        }
    }
}
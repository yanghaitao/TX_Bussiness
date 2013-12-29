using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussiness.Common
{
    public class Dates
    {
        //说明：
        //1.DateTime值类型代表了一个从公元0001年1月1日0点0分0秒到公元9999年12月31日23点59分59秒之间的具体日期时刻。因此，你可以用DateTime值类型来描述任何在想象范围之内的时间。一个DateTime值代表了一个具体的时刻
        //2.TimeSpan值包含了许多属性与方法，用于访问或处理一个TimeSpan值
        //下面的列表涵盖了其中的一部分：
        //Add：与另一个TimeSpan值相加。 
        //Days:返回用天数计算的TimeSpan值。 
        //Duration:获取TimeSpan的绝对值。 
        //Hours:返回用小时计算的TimeSpan值 
        //Milliseconds:返回用毫秒计算的TimeSpan值。 
        //Minutes:返回用分钟计算的TimeSpan值。 
        //Negate:返回当前实例的相反数。 
        //Seconds:返回用秒计算的TimeSpan值。 
        //Subtract:从中减去另一个TimeSpan值。 
        //Ticks:返回TimeSpan值的tick数。 
        //TotalDays:返回TimeSpan值表示的天数。 
        //TotalHours:返回TimeSpan值表示的小时数。 
        //TotalMilliseconds:返回TimeSpan值表示的毫秒数。 
        //TotalMinutes:返回TimeSpan值表示的分钟数。 
        //TotalSeconds:返回TimeSpan值表示的秒数。

        /// <summary>
        /// 获取指定时间距离现在的时间差
        /// </summary>
        /// <param name="dt">制定时间</param>
        /// <returns>时间差</returns>
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 7)
            {
                return dt.ToShortDateString();
            }
            else
                if (span.TotalDays > 1)
                {
                    return
                    string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                }
                else
                    if (span.TotalHours > 1)
                    {
                        return
                        string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                    }
                    else
                        if (span.TotalMinutes > 1)
                        {
                            return
                            string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                        }
                        else
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
        /// <summary>
        /// 获取指定时间距离现在的时间差
        /// </summary>
        /// <param name="dt">指定时间</param>
        /// <param name="formatStr">差值大于7天时的返回值</param>
        /// <returns>时间差</returns>
        public static string DateStringFromNow(DateTime dt, string formatStr)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 7)
            {
                return dt.ToString(formatStr);
            }
            else
                if (span.TotalDays > 1)
                {
                    return
                    string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                }
                else
                    if (span.TotalHours > 1)
                    {
                        return
                        string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                    }
                    else
                        if (span.TotalMinutes > 1)
                        {
                            return
                            string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                        }
                        else
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
        //C#中使用TimeSpan计算两个时间的差值
        //可以反加两个日期之间任何一个时间单位。
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            return dateDiff;
        }
        /// <summary>
        /// 计算工作日的天数
        /// </summary>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public static int CountWeekdays(DateTime startTime, DateTime endTime)
        {
            TimeSpan span = (TimeSpan)(endTime - startTime);
            Console.WriteLine(span.Days);
            int num = 0;
            for (int i = 0; i < span.Days; i++)
            {
                if (IsWeekDay(startTime.AddDays((double)i)))
                {
                    num++;
                }
            }
            return num;
        }

        public static int CountWeekends(DateTime startTime, DateTime endTime)
        {
            TimeSpan span = (TimeSpan)(endTime - startTime);
            Console.WriteLine(span.Days);
            int num = 0;
            for (int i = 0; i < span.Days; i++)
            {
                if (IsWeekEnd(startTime.AddDays((double)i)))
                {
                    num++;
                }
            }
            return num;
        }

        public static DateTime DaysAgo(int days)
        {
            TimeSpan span = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime DaysFromNow(int days)
        {
            TimeSpan span = new TimeSpan(days, 0, 0, 0);
            return DateTime.Now.Add(span);
        }

        public static TimeSpan Diff(DateTime dateOne, DateTime dateTwo)
        {
            return dateOne.Subtract(dateTwo);
        }

        public static double DiffDays(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalDays;
        }

        public static double DiffDays(string dateOne, string dateTwo)
        {
            DateTime time;
            DateTime time2;
            if (DateTime.TryParse(dateOne, out time) && DateTime.TryParse(dateTwo, out time2))
            {
                return Diff(time, time2).TotalDays;
            }
            return 0.0;
        }

        public static double DiffHours(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalHours;
        }

        public static double DiffHours(string dateOne, string dateTwo)
        {
            DateTime time;
            DateTime time2;
            if (DateTime.TryParse(dateOne, out time) && DateTime.TryParse(dateTwo, out time2))
            {
                return Diff(time, time2).TotalHours;
            }
            return 0.0;
        }

        public static double DiffMinutes(DateTime dateOne, DateTime dateTwo)
        {
            return Diff(dateOne, dateTwo).TotalMinutes;
        }

        public static double DiffMinutes(string dateOne, string dateTwo)
        {
            DateTime time;
            DateTime time2;
            if (DateTime.TryParse(dateOne, out time) && DateTime.TryParse(dateTwo, out time2))
            {
                return Diff(time, time2).TotalMinutes;
            }
            return 0.0;
        }

        private static string FormatString(string str, string previousStr, int t)
        {
            if ((t == 0) && (previousStr.Length == 0))
            {
                return string.Empty;
            }
            string str2 = (t == 1) ? string.Empty : "s";
            return string.Concat(new object[] { t, " ", str, str2, " " });
        }

        public static string GetDateDayWithSuffix(DateTime date)
        {
            int day = date.Day;
            string str = "th";
            switch (day)
            {
                case 1:
                case 0x15:
                case 0x1f:
                    str = "st";
                    goto Label_0044;

                case 2:
                case 0x16:
                    str = "nd";
                    goto Label_0044;

                case 3:
                case 0x17:
                    str = "rd";
                    break;
            }
        Label_0044:
            return (day + str);
        }

        public static string GetFormattedMonthAndDay(DateTime date)
        {
            return (string.Format("{0:MMMM}", date) + " " + GetDateDayWithSuffix(date));
        }

        public static DateTime HoursAgo(int hours)
        {
            TimeSpan span = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime HoursFromNow(int hours)
        {
            TimeSpan span = new TimeSpan(hours, 0, 0);
            return DateTime.Now.Add(span);
        }

        public static bool IsDate(object dt)
        {
            DateTime time;
            return DateTime.TryParse(dt.ToString(), out time);
        }

        public static bool IsWeekDay(DateTime dt)
        {
            return ((dt.DayOfWeek != DayOfWeek.Saturday) && (dt.DayOfWeek != DayOfWeek.Sunday));
        }

        public static bool IsWeekEnd(DateTime dt)
        {
            if (dt.DayOfWeek != DayOfWeek.Saturday)
            {
                return (dt.DayOfWeek == DayOfWeek.Sunday);
            }
            return true;
        }

        public static DateTime MinutesAgo(int minutes)
        {
            TimeSpan span = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime MinutesFromNow(int minutes)
        {
            TimeSpan span = new TimeSpan(0, minutes, 0);
            return DateTime.Now.Add(span);
        }


        public static DateTime SecondsAgo(int seconds)
        {
            TimeSpan span = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Subtract(span);
        }

        public static DateTime SecondsFromNow(int seconds)
        {
            TimeSpan span = new TimeSpan(0, 0, seconds);
            return DateTime.Now.Add(span);
        }

        public static string TimeDiff(DateTime startTime, DateTime endTime)
        {
            int t = endTime.Second - startTime.Second;
            int num2 = endTime.Minute - startTime.Minute;
            int num3 = endTime.Hour - startTime.Hour;
            int num4 = endTime.Day - startTime.Day;
            int num5 = endTime.Month - startTime.Month;
            int num6 = endTime.Year - startTime.Year;
            if (t < 0)
            {
                num2--;
                t += 60;
            }
            if (num2 < 0)
            {
                num3--;
                num2 += 60;
            }
            if (num3 < 0)
            {
                num4--;
                num3 += 0x18;
            }
            if (num4 < 0)
            {
                num5--;
                int month = (endTime.Month == 1) ? 12 : (endTime.Month - 1);
                int year = (month == 12) ? (endTime.Year - 1) : endTime.Year;
                num4 += DateTime.DaysInMonth(year, month);
            }
            if (num5 < 0)
            {
                num6--;
                num5 += 12;
            }
            string previousStr = FormatString("year", string.Empty, num6);
            string str2 = FormatString("month", previousStr, num5);
            string str3 = FormatString("day", str2, num4);
            string str4 = FormatString("hour", str3, num3);
            string str5 = FormatString("minute", str4, num2);
            string str6 = FormatString("second", str5, t);
            return (previousStr + str2 + str3 + str4 + str5 + str6);
        }
    }
}

using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Framework
{
    public class CalendarManager
    {
        public Calendar GetCalendarMonth(string date)
        {
            var calendar = new Calendar();
            DateTime target;
            try
            {
                target = DateTime.Parse(date);
            }
            catch (Exception)
            {
                throw new ArgumentException($"date: {date}");
            }
            calendar.Today = target.ToShortDateString();

            // 当月の日数
            var daysInMonth = DateTime.DaysInMonth(target.Year, target.Month);
            // 当月の1日
            var firstDayOfMonth = new DateTime(target.Year, target.Month, 1);
            
            var list = new List<CalendarDate>();
            for (int day = 1; day <= daysInMonth; day++)
            {
                var theDay = new CalendarDate();
                theDay.Year = target.Year;
                theDay.Month = target.Month;
                theDay.Day = day;
                theDay.DayOfWeek = new DateTime(target.Year, target.Month, day).ToString("ddd");
                list.Add(theDay);
            }
            calendar.CalendarMonth = list;

            return calendar;
        }
    }
}
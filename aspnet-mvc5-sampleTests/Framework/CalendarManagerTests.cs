using Microsoft.VisualStudio.TestTools.UnitTesting;
using aspnet_mvc5_sample.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Framework.Tests
{
    [TestClass()]
    public class CalendarManagerTests
    {
        [TestMethod()]
        public void GetCalendarMonthTest_daysInMonth()
        {
            var target = new CalendarManager();
            var expected = 31;
            var date = "2017-3-16";
            var actual = target.GetCalendarMonth(date).CalendarMonth.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCalendarMonthTest_Today_2017_3_16()
        {
            var target = new CalendarManager();
            var expected = "3/16/2017";
            var date = "2017-3-16";
            var calendar = target.GetCalendarMonth(date);
            var actual = calendar.Today;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCalendarMonthTest_Year_2017_3_16()
        {
            var target = new CalendarManager();
            var expected = 2017;
            var date = "2017-3-16";
            var calendarData = target.GetCalendarMonth(date).CalendarMonth
                .First();
            var actual = calendarData.Year;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCalendarMonthTest_Month_2017_3_16()
        {
            var target = new CalendarManager();
            var expected = 3;
            var date = "2017-3-16";
            var calendarData = target.GetCalendarMonth(date).CalendarMonth
                .First();
            var actual = calendarData.Month;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCalendarMonthTest_Day_2017_3_16()
        {
            var target = new CalendarManager();
            var expected = 16;
            var date = "2017-3-16";
            var calendarData = target.GetCalendarMonth(date).CalendarMonth
                .Where(x => x.Day == 16)
                .First();
            var actual = calendarData.Day;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetCalendarMonthTest_DayOfWeek_2017_3_16()
        {
            var target = new CalendarManager();
            var expected = "Thu";
            var date = "2017-3-16";
            var calendarData = target.GetCalendarMonth(date).CalendarMonth
                .Where(x => x.Day == 16)
                .First();
            var actual = calendarData.DayOfWeek;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentException))]
        public void GetCalendarMonthTest_ArgumentException_2017_13_36()
        {
            var target = new CalendarManager();
            var date = "2017-13-36";
            var calendar = target.GetCalendarMonth(date);
        }
    }
}
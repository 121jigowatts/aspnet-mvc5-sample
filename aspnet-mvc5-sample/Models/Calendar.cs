using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_sample.Models
{
    public class Calendar
    {
        public string Today { get; set; }
        public IEnumerable<CalendarDate> CalendarMonth { get; set; }
    }

    public class CalendarDate
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string DayOfWeek { get; set; }
    }
}
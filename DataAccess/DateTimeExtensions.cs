using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public static class DateTimeExtensions
    {
        public static DateTime FromStrings(this DateTime dateTime, string stringYear, string stringMonth, string stringDay)
        {
            int year = int.Parse(stringYear);
            int month = int.Parse(stringMonth);
            int day = int.Parse(stringDay);

            return new DateTime(year, month, day);
        }
    }
}

using System;

namespace TaxCalculator
{
    static class DateHelper
    {
        private static int YearDays = 365;
        public static int Counter = 0;
        public static int GetAge(this DateTime birthDate)
        {
            Counter++;
            var age = DateTime.Now - birthDate;
            var years = age.TotalDays / YearDays;
            return Convert.ToInt32(Math.Floor(years));
        }

        public static int GetAge(this IBirthDate person)
        {
            Counter++;
            person.GetCount(true);
            var age = DateTime.Now - person.BirthDate;
            var years = age.TotalDays / YearDays;
            return Convert.ToInt32(Math.Floor(years));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StaticConstructors
{
    public static class UserPreferences
    {
        public static Color BackColor { get; }

        static UserPreferences()
        {
            DateTime now = DateTime.Now;

            if (now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
                BackColor = Color.Green;
            else
                BackColor = Color.Red;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EnumColor
{
    public enum DaysOfWeek
    {
        Monday = 0x1, // 1
        Tuesday = 0x2, // 2
        Wednesday = 0x4, // 4
        Thursday = 0x8, // 8
        Friday = 0x10, // 16
        Saturday = 0x20, // 32
        Sunday = 0x40, // 64
        Weekend = Saturday | Sunday,
        Workday = 0x1f, // 31
        AllWeek = Workday | Weekend
    }
}

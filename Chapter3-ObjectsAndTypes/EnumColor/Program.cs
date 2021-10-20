using System;

namespace EnumColor
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorSample();
            DayOfWeekSamples();
            UsingEnumClass();
        }

        private static void UsingEnumClass()
        {
            Color red;

            if (Enum.TryParse<Color>("Red", out red))
                Console.WriteLine($"Successfully parsed {red}");
            Console.WriteLine(red);

            string redtext = Enum.GetName(typeof(Color), red);
            Console.WriteLine(redtext);

            foreach (var day in Enum.GetNames(typeof(Color)))
                Console.WriteLine(day);

            foreach (short item in Enum.GetValues(typeof(Color)))
                Console.WriteLine(item);
        }

        private static void DayOfWeekSamples()
        {
            DaysOfWeek mondayAndWednesday = DaysOfWeek.Monday | DaysOfWeek.Wednesday;
            Console.WriteLine(mondayAndWednesday);

            DaysOfWeek day1 = DaysOfWeek.Monday;
            Console.WriteLine((short)day1);
            DaysOfWeek day2 = DaysOfWeek.Tuesday;
            Console.WriteLine((short)day2);
            DaysOfWeek day3 = DaysOfWeek.Wednesday;
            Console.WriteLine((short)day3);
            DaysOfWeek day4 = DaysOfWeek.Thursday;
            Console.WriteLine((short)day4);
            DaysOfWeek day5 = DaysOfWeek.Friday;
            Console.WriteLine((short)day5);
            DaysOfWeek day6 = DaysOfWeek.Saturday;
            Console.WriteLine((short)day6);
            DaysOfWeek day7 = DaysOfWeek.Sunday;
            Console.WriteLine((short)day7);

            DaysOfWeek weekend = DaysOfWeek.Saturday | DaysOfWeek.Sunday;
            Console.WriteLine(weekend);

            DaysOfWeek workday = DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Wednesday | DaysOfWeek.Thursday | DaysOfWeek.Friday;
            Console.WriteLine(workday);
        }

        private static void ColorSample()
        {
            Color c1 = Color.Red;
            Console.WriteLine(c1);

            Color c2 = (Color)2;
            Console.WriteLine(c2);
            Console.WriteLine((short)c2);
        }
    }
}

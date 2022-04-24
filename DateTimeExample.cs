namespace DateTimeNameSpace
{
    public class DateTimeExample
    {
        private static readonly DateTime dateTimeNow = DateTime.Now;
        private static readonly DateTime dateTimeUTC = DateTime.UtcNow;

        private static void DateTimeMethod()
        {
            Console.WriteLine($"\nCompare local and UTC datetimes: {DateTime.Compare(dateTimeNow, dateTimeUTC)}");
            Console.WriteLine($"DateTime.Now: {dateTimeNow} is of kind: {dateTimeNow.Kind}, \nDateTime.UtcNow: {dateTimeUTC} is of kind: {dateTimeUTC.Kind}");
            Console.WriteLine($"Convert from local to utc using: {dateTimeNow.ToUniversalTime()}, \nConvert from UTC to local: {dateTimeUTC.ToLocalTime()}");
            Console.WriteLine($"Day of year: {dateTimeNow.DayOfYear}, DayOfWeek: {dateTimeNow.DayOfWeek}");
            Console.WriteLine($"Addition: {dateTimeNow.AddDays(-10).AddHours(3).AddMinutes(-20)}");
        }

        private static void TimeSpanMethod()
        {
            // A timespan represents a span of interval of time.
            // For exmaple let's create a timespan of 3 days.
            TimeSpan timeSpan = TimeSpan.FromDays(3);
            Console.WriteLine($"\nNumber of total hours in a time span of 3 days: {TimeSpan.FromDays(3).TotalHours}");
            Console.WriteLine($"Number of total minutes in a time span of 3 days: {TimeSpan.FromDays(3).TotalMinutes}");
            Console.WriteLine($"Timespan of three days: {timeSpan}");
            Console.WriteLine($"Add timespan of three days to now: {dateTimeNow.Add(timeSpan)}");
            Console.WriteLine($"Subtracting two dates gives a timespan: {dateTimeNow.AddDays(5).AddHours(3).AddMinutes(-20).Subtract(dateTimeNow)}");
        }

        private static void DateTimeParsing()
        {
            Console.WriteLine($"\nFull Long datetime: {dateTimeNow.ToString("F")}");
            Console.WriteLine($"Short date: {dateTimeNow.ToString("d")}");
            Console.WriteLine($"Long date: {dateTimeNow:D}");
            Console.WriteLine($"Short time: {dateTimeNow:t}");
            Console.WriteLine($"Long time: {dateTimeNow.ToString("T")}");
            Console.WriteLine($"Custom date: {dateTimeNow:dd MMM yyyy}");
            DateTime parsedDateTime = DateTime.Parse("3/11/2022");
            Console.WriteLine($"\nFull Long datetime: {parsedDateTime:F}");
        }

        public static void Main()
        {
            DateTimeMethod();
            TimeSpanMethod();
            DateTimeParsing();
        }
    }
}

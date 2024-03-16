using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace gmis.Infrastructure.Converter
{
    public class DateOnlyComparer : ValueComparer<DateOnly>
    {
        public DateOnlyComparer() : base(
            (x, y) => x.DayNumber == y.DayNumber,
            dateOnly => dateOnly.GetHashCode())
        { }
    }
    public class TimeOnlyComparer : ValueComparer<TimeOnly>
    {
        public TimeOnlyComparer() : base(
            (x, y) => x.Ticks == y.Ticks,
            timeOnly => timeOnly.GetHashCode())
        { }
    }
}

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DateOnlyAndTimeOnlyTypes;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue), 
        dateTime => DateOnly.FromDateTime(dateTime))
    { }
}
namespace EventHorizon.src.Events
{
    public class RandomTimeOffsetGenerator
    {
        internal static TimeOnly GetTimeOffset(TimeOnly start, TimeOnly offset)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            start.AddHours(rnd.Next(0, offset.Hour));
            start.AddMinutes(rnd.Next(0, offset.Minute));
            return start;
        }
    }
}
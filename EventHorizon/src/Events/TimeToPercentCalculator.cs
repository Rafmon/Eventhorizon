namespace EventHorizon.src.Events
{
    public class TimeToPercentCalculator
    {
        public static float GetTimeInPercent(TimeOnly time)
        {
            float hourPercent = time.Hour / 24.0F;
            float Minutepercent = time.Minute / (60.0F * 24.0F);
            return hourPercent + Minutepercent;
        }
    }
}
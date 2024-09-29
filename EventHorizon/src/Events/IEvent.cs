namespace EventHorizon.src.Events
{
    public interface IEvent
    {

        public TimeOnly GetEventStart();
        public TimeOnly GetEventEnd();

    }
}
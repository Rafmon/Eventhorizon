using System.ComponentModel.DataAnnotations;

namespace EventHorizon.src.Events
{
    public class Event
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = "Event";

        [Required(ErrorMessage = "Please enter a start time.")]
        public TimeOnly EventStart { get; set; }

        [Required(ErrorMessage = "Please enter an end time.")]
        public TimeOnly EventEnd { get; set; }

        public bool IsEventStartRandom { get; set; } = false;
        public bool IsEventEndRandom { get; set; } = false;
        public TimeOnly EventStartOffset { get; set; }
        public TimeOnly EventEndOffset { get; set; }
        public int Address { get; set; }
        public Guid ID { get; set; }

        public Event()
        {
            ID = Guid.NewGuid();
        }

        /// <summary>
        /// Calculates the event start time as a percentage of the day.
        /// If the event has a random start time offset, it will be included.
        /// </summary>
        /// <returns>Start time as a percentage.</returns>
        public float GetEventStartPercent()
        {
            return CalculateTimeInPercent(EventStart, EventStartOffset, IsEventStartRandom);
        }

        /// <summary>
        /// Calculates the event end time as a percentage of the day.
        /// If the event has a random end time offset, it will be included.
        /// </summary>
        /// <returns>End time as a percentage.</returns>
        public float GetEventEndPercent()
        {
            return CalculateTimeInPercent(EventEnd, EventEndOffset, IsEventEndRandom);
        }

        private float CalculateTimeInPercent(TimeOnly time, TimeOnly offset, bool hasRandomTimeOffset)
        {
            if (hasRandomTimeOffset)
            {
                return TimeToPercentCalculator.GetTimeInPercent(RandomTimeOffsetGenerator.GetTimeOffset(time, offset));
            }
            return TimeToPercentCalculator.GetTimeInPercent(time);
        }

        public override string ToString() => Address.ToString();
    }
}

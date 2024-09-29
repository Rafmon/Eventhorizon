using System;
using System.Threading;
using System.Threading.Tasks;
using EventHorizon.src.TimeLine;
using Microsoft.Extensions.Hosting;

//Handels the starting and stopping of the timeline on program startup
namespace EventHorizon.Services
{
    public class TimeLineBackgroundService : BackgroundService
    {
        private readonly TimeLineController _timeLineController;

        public TimeLineBackgroundService(TimeLineController timeLineController)
        {
            _timeLineController = timeLineController ?? throw new ArgumentNullException(nameof(timeLineController));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _timeLineController.RunTimeLineAsync(stoppingToken);
        }
    }
}

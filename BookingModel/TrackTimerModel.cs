using Timer = System.Timers.Timer;

namespace CabScheduling.BookingModel
{
    public class TrackTimerModel
    {
        public CabBookingModel CabBookingModel { get; set; }

        public Timer ScheduledTimer { get; set; }
    }
}

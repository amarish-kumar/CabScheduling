using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using CabScheduling.BookingModel;

namespace CabScheduling.CabScheduler
{
    public class CabScheduler : ICabScheduler
    {
        private readonly List<TrackTimerModel> allTimers = new List<TrackTimerModel>();

        public void StartCabScheduler(CabBookingModel scheduledJob)
        {
            var cabTimer = new Timer();
            var tickTime = (scheduledJob.BookingTimeScheduled - DateTime.Now).TotalMilliseconds;
            cabTimer.Elapsed += (sender, e) => OnTimedEvent(sender, e, scheduledJob);
            cabTimer.Interval = tickTime;
            cabTimer.Enabled = true;
            allTimers.Add(new TrackTimerModel { CabBookingModel = scheduledJob , ScheduledTimer = cabTimer});
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e, CabBookingModel scheduledJob)
        {
            var source = (Timer)sender;
            if (source == null) return;
            Console.WriteLine("\n{0} - {1} !!! - Arriving Scheduled Cab At {2}\n", scheduledJob.CabId, scheduledJob.CabName, scheduledJob.BookingTimeScheduled);
            Console.WriteLine("{0} - {1} - has Cab Arrived", scheduledJob.CabId, scheduledJob.CabName);
            source.Stop();
            source.Dispose();
            if (allTimers.Any()) {
                var removeTimer = allTimers.FirstOrDefault(f => f.CabBookingModel.CabId == scheduledJob.CabId);
                allTimers.Remove(removeTimer);
            }
        }

        public void CancelCabScheduler(CabBookingModel scheduledJob) {
            if(!allTimers.Any()) return;
            
            var cancelTimer = allTimers.FirstOrDefault(e => e.CabBookingModel.CabId == scheduledJob.CabId);
            if (cancelTimer == null) return;

            cancelTimer.ScheduledTimer.Stop();
            Console.WriteLine("*******************************************");
            Console.WriteLine("\n{0} - {1} !!! - Cancelled Cab, Scheduled for {2}\n", scheduledJob.CabId, scheduledJob.CabName, scheduledJob.BookingTimeScheduled);
        }
    }
}

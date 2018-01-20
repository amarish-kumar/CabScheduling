
using System;

namespace CabScheduling.BookingModel
{
    public class CabBookingModel
    {
        public string RequestId { get; set; }

        public string UserName { get; set; }

        public string CabId { get; set; }

        public string CabName { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime BookingTimeScheduled { get; set; }
    }
}

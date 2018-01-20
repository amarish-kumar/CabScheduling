using System;
using CabScheduling.BookingModel;

namespace CabScheduling.CabBooking
{
    public class BookingRequest {

        public CabBookingModel CabBookingModel { get; set; }
  
        public void Book() {
            Console.WriteLine("\n{0} Cab Book for Time {1}", CabBookingModel.CabName, CabBookingModel.BookingTimeScheduled);
            Console.WriteLine("\n{0} Cab Book for Time {1} is Arriving", CabBookingModel.CabName, CabBookingModel.BookingTimeScheduled);
        }

        public void Cancel() {
            Console.WriteLine("\n{0} Cab cancelled for Time {1}", CabBookingModel.CabName, CabBookingModel.BookingTime);
        }
    }
}

using System;
using CabScheduling.BookingHandler;
using CabScheduling.CabBooking;

namespace CabScheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookingService = new BookingService();
            var cabBookingHandler = new CabBookingHandler();
            cabBookingHandler.ScheduleCab(bookingService);
            var cabCancellationHandler = new CabCancellationHandler();
            cabCancellationHandler.ScheduleCabCancellation(bookingService);

            Console.ReadLine();
        }
    }
}

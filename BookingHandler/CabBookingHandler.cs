using System;
using System.Linq;
using CabScheduling.BookingModel;
using CabScheduling.CabBooking;

namespace CabScheduling.BookingHandler
{
    public class CabBookingHandler
    {
        public void ScheduleCab(BookingService bookingService) {
            Console.WriteLine("Do You Want to Book a Cab (y/n)...");
            var answer = Console.ReadKey();
            if (answer.Key != ConsoleKey.Y) return;

            ConsoleKeyInfo moreCab;
            do
            {
                var bookingDetails = InputBookingDetails();
                BookCab bookCab = new BookCab(bookingDetails);
                bookingService.ScheduleCab(bookCab);
                Console.WriteLine("Do You Want to Book More Cab (y/n)...");
                moreCab = Console.ReadKey();
            } while (moreCab.Key == ConsoleKey.Y);

            Console.WriteLine("\n***********************************");
            Console.WriteLine("\nConfirm Booking (y/n)...");
            var confirmed = Console.ReadKey();
            Console.WriteLine("***********************************");
            if (confirmed.Key == ConsoleKey.Y)
            {
                bookingService.ConfirmService(true);
            }
            Console.WriteLine("\n***********************************");
        }

        public static BookingRequest InputBookingDetails()
        {
            BookingRequest bookingRequest = new BookingRequest();
            bookingRequest.CabBookingModel = new CabBookingModel();
            bookingRequest.CabBookingModel.RequestId = String.Format("CAB {0}", Guid.NewGuid().ToString());
            Console.WriteLine("\nEnter Your Name:");
            bookingRequest.CabBookingModel.UserName = Console.ReadLine();
            Console.WriteLine("Enter Cab Id:");
            bookingRequest.CabBookingModel.CabId = Console.ReadLine();
            Console.WriteLine("Enter Cab Name:");
            bookingRequest.CabBookingModel.CabName = Console.ReadLine();
            bookingRequest.CabBookingModel.BookingTime = DateTime.Now;
            Console.WriteLine("Schedule Date & time --- (dd.mm.yyyy.hh.mm");
            var scheduledDate = Console.ReadLine();
            bookingRequest.CabBookingModel.BookingTimeScheduled = GetDateTime(scheduledDate);

            return bookingRequest;
        }

        private static DateTime GetDateTime(string scheduledDate) {
            if (string.IsNullOrEmpty(scheduledDate)) return DateTime.MinValue;

            var result = scheduledDate.Split('.');
            if(!result.Any())
                return DateTime.MinValue;

            int dd = Convert.ToInt32(result[0]);
            int mm = Convert.ToInt32(result[1]);
            int yy = Convert.ToInt32(result[2]);
            int hh = Convert.ToInt32(result[3]);
            int min = Convert.ToInt32(result[4]);

            var scheduled =  new DateTime(yy, mm, dd, hh, min, 0, 0);
            return scheduled;
        }
    }
}

using System;
using CabScheduling.BookingModel;
using CabScheduling.CabBooking;

namespace CabScheduling.BookingHandler
{
    public class CabCancellationHandler
    {
        public void ScheduleCabCancellation(BookingService bookingService) {
            Console.WriteLine("\nDo You Want to Cancel any Cab (y/n)...");
            var isCancel = Console.ReadKey();
            if (isCancel.Key == ConsoleKey.Y)
            {
                var cancelDetails = InputCancelDetails();
                CancelCab cancelCab = new CancelCab(cancelDetails);
                bookingService.CancelCab(cancelCab);

                Console.WriteLine("\nConfirm Cancel (y/n)...");
                var confirmedCancel = Console.ReadKey();
                if (confirmedCancel.Key == ConsoleKey.Y)
                {
                    bookingService.ConfirmService(false);
                }
            }
        }

        public static BookingRequest InputCancelDetails()
        {
            BookingRequest bookingRequest = new BookingRequest();
            bookingRequest.CabBookingModel = new CabBookingModel();
            Console.WriteLine("Enter Your Name:");
            bookingRequest.CabBookingModel.UserName = Console.ReadLine();
            Console.WriteLine("Enter Cab Id:");
            bookingRequest.CabBookingModel.CabId = Console.ReadLine();

            return bookingRequest;
        }
    }
}

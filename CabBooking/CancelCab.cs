
namespace CabScheduling.CabBooking
{
    public class CancelCab : ICabService
    {
        public BookingRequest _bookingRequest;

        public CancelCab(BookingRequest bookingRequest) {
            _bookingRequest = bookingRequest;
        }

        public void Execute()
        {
           _bookingRequest.Cancel();
        }
    }
}

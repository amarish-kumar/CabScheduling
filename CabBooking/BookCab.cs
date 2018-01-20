namespace CabScheduling.CabBooking
{
    public class BookCab : ICabService {

        public readonly BookingRequest _bookingRequest;
        public BookCab(BookingRequest bookingRequest) {
            _bookingRequest = bookingRequest;
        }

        public void Execute() {
            _bookingRequest.Book();
        }
    }
}

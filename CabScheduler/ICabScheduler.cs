
using CabScheduling.BookingModel;

namespace CabScheduling.CabScheduler
{
    public interface ICabScheduler {
        void StartCabScheduler(CabBookingModel scheduledJob);
        void CancelCabScheduler(CabBookingModel scheduledJob);
    }
}

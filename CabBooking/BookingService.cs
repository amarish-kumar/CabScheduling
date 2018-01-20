using System.Collections.Generic;
using System.Linq;
using CabScheduling.CabScheduler;

namespace CabScheduling.CabBooking
{
    public class BookingService
    {
        public readonly List<BookCab> BookedCabList = new List<BookCab>();
        public readonly List<CancelCab> CanceledCabList = new List<CancelCab>();
        private readonly ICabScheduler cabScheduler = new CabScheduler.CabScheduler();

        public void ScheduleCab(BookCab cabService)
        {
            BookedCabList.Add(cabService);
        }

        public void CancelCab(CancelCab cabService)
        {
            CanceledCabList.Add(cabService);
        }

        public void ConfirmService(bool booking) {
            if (booking) {
                foreach (var bookingItem in BookedCabList)
                {
                    bookingItem.Execute();
                    cabScheduler.StartCabScheduler(bookingItem._bookingRequest.CabBookingModel);
                }
            } else {
                foreach (var cancelItem in CanceledCabList)
                {
                    cancelItem.Execute();
                    var cancelledCabId = cancelItem._bookingRequest.CabBookingModel.CabId;
                    var removeCab = BookedCabList.FirstOrDefault(e => e._bookingRequest.CabBookingModel.CabId == cancelledCabId);
                    if (removeCab == null || !BookedCabList.Any()) continue;
                    cabScheduler.CancelCabScheduler(removeCab._bookingRequest.CabBookingModel);
                    BookedCabList.Remove(removeCab);
                }
            }
        }
    }
}

using ETour.DbRepos;

namespace ETour.Repository
{

    public class BookingRepository : IBookingRepository
    {
        private readonly ScottDbContext context;
        private Task<Booking> booking;

        public BookingRepository(ScottDbContext context)
        {
            this.context = context;
        }


        void IBookingRepository.addBooking(Booking booking)
        {
            context.Bookings.Add(booking);
        }

         List<Booking> IBookingRepository.GetBooking()
        {
            if(context.Bookings==null)
            {
                return null;
            }
            return context.Bookings.ToList();
        }

       
    }
}

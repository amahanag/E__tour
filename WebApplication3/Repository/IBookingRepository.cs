using ETour.DbRepos;
namespace ETour.Repository
{
    public interface IBookingRepository
    {

        List<Booking> GetBooking();
        
       
        void addBooking(Booking booking);
    }
}


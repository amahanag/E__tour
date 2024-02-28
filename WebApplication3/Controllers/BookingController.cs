using ETour.Repository;
using Microsoft.AspNetCore.Mvc;
using ETour.DbRepos;

namespace ETour.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public List<Booking> GetBookings()
        {
            if(_bookingRepository.GetBooking() == null)
            {
                return null;
            }
            return _bookingRepository.GetBooking();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Booking Booking)
        {
            _bookingRepository.addBooking(Booking);
            return CreatedAtAction(nameof(Post), new { id = Booking.id }, Booking);
        }
    }
}

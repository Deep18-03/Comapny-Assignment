using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class Booking
    {
        public int id { get; set; }
        public int? Roomid { get; set; }
        public DateTime? BookingDate { get; set; }
        public string StatusOfBooking { get; set; }
    }
}

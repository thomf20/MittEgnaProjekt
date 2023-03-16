using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Models
{
    internal class Boat
    {
        public Guid Id { get; set; }
        public string BoatName { get; set; }
        public DateTime BookingDate { get; set; }
        public string CustomerName { get; set; }
    }
}

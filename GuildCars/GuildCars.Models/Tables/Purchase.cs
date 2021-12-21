using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public string VIN { get; set; }
        public int PurchaseTypeID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateAbbr { get; set; }
        public string Zipcode { get; set; }

    }
}

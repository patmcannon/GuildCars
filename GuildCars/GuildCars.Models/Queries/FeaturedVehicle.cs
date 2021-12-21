using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class FeaturedVehicle
    {
        public string VIN { get; set; }
        public int ModelYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public bool IsFeatured { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public string ImageFileName { get; set; }
    }
}

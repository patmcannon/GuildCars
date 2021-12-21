using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class VehicleDetail
    {
        public string VIN { get; set; }
        public string BodyTypeName { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string InteriorColorName { get; set; }
        public string ExteriorColorName { get; set; }
        public int ModelYear { get; set; }
        public bool IsNew { get; set; }
        public bool IsManual { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSold { get; set; }
        public int Mileage { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string VehicleDesc { get; set; }
        public string ImageFileName { get; set; }
    }
}

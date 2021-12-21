using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Vehicle
    {
        [Required]
        public string VIN { get; set; }
        [Required]
        public int BodyTypeID { get; set; }
        [Required]
        public int ModelID { get; set; }
        [Required]
        public int InteriorColorID { get; set; }
        [Required]
        public int ExteriorColorID { get; set; }
        [Required]
        public int ModelYear { get; set; }
        [Required]
        public bool IsNew { get; set; }
        [Required]
        public bool IsManual { get; set; }
        [Required]
        public bool IsFeatured { get; set; }
        [Required]
        public bool IsSold { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public decimal RetailPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public string VehicleDesc { get; set; }
        public string ImageFileName { get; set; }

    }
}

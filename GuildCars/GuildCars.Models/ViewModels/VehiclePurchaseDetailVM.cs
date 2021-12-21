using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.ViewModels
{
    public class VehiclePurchaseDetailVM
    {
        public Vehicle Vehicle { get; set; }
        public VehicleDetail VehicleDetail { get; set; }
        public Purchase Purchase { get; set; }
    }
}

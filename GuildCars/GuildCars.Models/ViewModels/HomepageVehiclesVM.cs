using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.ViewModels
{
    public class HomepageVehiclesVM
    {
        public IEnumerable<FeaturedVehicle> FeaturedVehicles { get; set; }
        public IEnumerable<Special> Specials { get; set; }
    }
}

using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAll();
        Vehicle GetByID(string vin);
        void Insert(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(string vin);
        IEnumerable<FeaturedVehicle> GetFeatured();
        List<VehicleDetail> GetByNewOrUsed(bool isNew);
        VehicleDetail GetDetailByID(string vin);
        IEnumerable<VehicleDetail> Search(VehicleSearchParameters parameters);
    }
}

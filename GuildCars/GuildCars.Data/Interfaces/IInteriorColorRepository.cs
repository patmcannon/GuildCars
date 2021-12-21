using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IInteriorColorRepository
    {
        List<InteriorColor> GetAll();
        InteriorColor GetByID(int interiorColorID);
        void Insert(InteriorColor exteriorColor);
        void Update(InteriorColor exteriorColor);
        void Delete(int interiorColorID);
    }
}

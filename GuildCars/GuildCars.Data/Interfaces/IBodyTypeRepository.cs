using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IBodyTypeRepository
    {
        List<BodyType> GetAll();
        BodyType GetByID(int bodyTypeID);
        void Insert(BodyType bodyType);
        void Update(BodyType bodyType);
        void Delete(int bodyTypeID);
    }
}

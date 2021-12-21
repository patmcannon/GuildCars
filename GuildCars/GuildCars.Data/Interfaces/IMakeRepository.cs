using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IMakeRepository
    {
        List<Make> GetAll();
        Make GetByID(int makeID);
        void Insert(Make make);
        void Update(Make make);
        void Delete(int makeID);
    }
}

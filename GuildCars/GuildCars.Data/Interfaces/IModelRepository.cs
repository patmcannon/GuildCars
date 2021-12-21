using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IModelRepository
    {
        List<Model> GetAll();
        Model GetByID(int modelID);
        void Insert(Model model);
        void Update(Model model);
        void Delete(int modelID);
    }
}

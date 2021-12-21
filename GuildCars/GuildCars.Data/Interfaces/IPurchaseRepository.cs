using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        List<Purchase> GetAll();
        Purchase GetByID(int purchaseID);
        void Insert(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int purchaseID);
    }
}

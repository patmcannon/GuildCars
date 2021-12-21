using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IPurchaseTypeRepository
    {
        List<PurchaseType> GetAll();
        PurchaseType GetByID(int purchaseTypeID);
        void Insert(PurchaseType purchaseType);
        void Update(PurchaseType purchaseType);
        void Delete(int purchaseTypeID);
    }
}

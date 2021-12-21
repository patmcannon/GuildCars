using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetByID(int contactID);
        void Insert(Contact contact);
        void Delete(int contactID);
    }
}

﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
        Special GetByID(int specialID);
        void Insert(Special special);
        void Update(Special special);
        void Delete(int specialID);
    }
}

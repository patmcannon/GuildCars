﻿using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IStateRepository
    {
        List<State> GetAll();
        State GetByID(string stateAbbr);
        void Insert(State state);
        void Update(State state);
        void Delete(string stateAbbr);
    }
}

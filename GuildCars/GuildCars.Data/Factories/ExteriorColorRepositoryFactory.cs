using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class ExteriorColorRepositoryFactory
    {
        public static IExteriorColorRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new ExteriorColorRepositoryADO();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}

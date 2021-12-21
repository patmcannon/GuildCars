using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using GuildCars.Models.Tables;

namespace GuildCars.Models
{
    public class GuildCarsEntities : DbContext
    {
        public GuildCarsEntities() : base("CodeFirstConnection")
        { }

        public DbSet<State> States { get; set; }
    }
}

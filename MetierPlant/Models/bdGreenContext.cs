using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MetierPlant.Models
{
    public class bdGreenContext: DbContext
    {
        public bdGreenContext() : base("conn") { }

        public DbSet<Profil> profils { get; set; }
        public DbSet<Utilisateur> utilisateurs { get; set; }
        public DbSet<Fruitier> fruitiers { get; set; }
        public DbSet<Marecher> marechers { get; set; }

        public System.Data.Entity.DbSet<MetierPlant.Models.Plante> Plantes { get; set; }
    }
}
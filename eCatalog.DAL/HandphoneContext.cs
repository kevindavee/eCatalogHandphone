using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.DAL
{
    public class HandphoneContextInitializer : CreateDatabaseIfNotExists<HandphoneContext>
    {
        protected override void Seed(HandphoneContext context)
        {
            base.Seed(context);
        }
    }

    public class HandphoneContext : DbContext
    {
        public HandphoneContext() : base("DefaultConnection")
        {

        }

        static HandphoneContext()
        {
            Database.SetInitializer(new HandphoneContextInitializer());
        }

        public static HandphoneContext Create()
        {
            return new HandphoneContext();
        }

        public DbSet<Handphone> Handphone { get; set; }
        public DbSet<Brand> Brand { get; set; }
    }
}

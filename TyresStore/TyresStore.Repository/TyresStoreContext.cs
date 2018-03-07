using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TyresStore.Repository.Models;

namespace TyresStore.Repository
{
    public class TyresStoreContext: DbContext
    {
        public TyresStoreContext() : base("name=TyresStoreContext")
        {
        }

        public DbSet<Tyre> Tyres { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Basket> BasketItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(string.Empty, ex);
            }
        }
    }
}

using System.Data.Entity;
using YouFood.Data.Configurations;
using YouFood.Domain.Model;

namespace YouFood.Data.Context
{
    public class WebContext : DbContext
    {
        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public WebContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<WebContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CorporatesConfiguration());
            modelBuilder.Configurations.Add(new RestaurantsConfiguration());
            modelBuilder.Configurations.Add(new ZonesConfiguration());
            modelBuilder.Configurations.Add(new TablesConfiguration());
            modelBuilder.Configurations.Add(new DishesConfiguration());
            modelBuilder.Configurations.Add(new MenusConfiguration());
            modelBuilder.Configurations.Add(new SpecialtiesConfiguration());
            modelBuilder.Configurations.Add(new OrdersConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}

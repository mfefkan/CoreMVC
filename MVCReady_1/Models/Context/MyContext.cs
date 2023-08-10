using Microsoft.EntityFrameworkCore;
using MVCReady_1.Models.DBConfigurations;
using MVCReady_1.Models.Entities;

namespace MVCReady_1.Models.Context
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) : base(options) 
        {
        

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
         
        }
        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}

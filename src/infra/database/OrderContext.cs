using Microsoft.EntityFrameworkCore;
using domain.entities;

namespace infra.database
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        { }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().Ignore(_ => _.Menus);
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
    }
}
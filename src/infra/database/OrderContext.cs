using Microsoft.EntityFrameworkCore;
using domain.entities;
using domain.factories;

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
            modelBuilder.Entity<OrderDish>().HasKey(od => new { od.OrderId, od.DishId });
            modelBuilder.Entity<OrderDish>()
                .HasOne(_ => _.Order)
                .WithMany(_ => _.OrderDishes)
                .HasForeignKey(_ => _.OrderId);

            modelBuilder.Entity<OrderDish>()
                .HasKey(_ => _.Id);

            modelBuilder.Entity<OrderDish>()
                .HasOne(_ => _.Dish)
                .WithMany(_ => _.OrderDishes)
                .HasForeignKey(_ => _.DishId);

            modelBuilder.Entity<Dish>()
                .Ignore(_ => _.Menus);
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<OrderDish> OrderDishes { get; set; }
    }
}
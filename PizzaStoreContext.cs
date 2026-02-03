using Microsoft.EntityFrameworkCore;
using BlazingPizza.Model;

namespace BlazingPizza
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<Pizza> Pizzas { get; set; } = default!;
        public DbSet<PizzaSpecial> Specials { get; set; } = default!;
        public DbSet<Topping> Toppings { get; set; } = default!;
        public DbSet<PizzaTopping> PizzaToppings { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pt => new { pt.PizzaId, pt.ToppingId });

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Pizza)
                .WithMany(p => p.Toppings)
                .HasForeignKey(pt => pt.PizzaId);

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pt => pt.Topping)
                .WithMany()
                .HasForeignKey(pt => pt.ToppingId);
        }
    }
}
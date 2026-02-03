using BlazingPizza.Model;
using System.Linq;

namespace BlazingPizza
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            // Seed only if no pizza specials exist
            if (db.Specials.Any())
            {
                return;
            }

            var specials = new PizzaSpecial[]
            {
                new PizzaSpecial
                {
                    Name = "Basic Cheese Pizza",
                    Description = "It's cheesy and delicious. Why wouldn't you want one?",
                    Price = 9.99m,
                    ImageUrl = "img/pizzas/cheese.jpg"
                },
                new PizzaSpecial
                {
                    Name = "The Baconatorizor",
                    Description = "It has EVERY kind of bacon",
                    Price = 11.99m,
                    ImageUrl = "img/pizzas/bacon.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Classic Pepperoni",
                    Description = "It's the pizza you grew up with, but Blazing hot!",
                    Price = 10.50m,
                    ImageUrl = "img/pizzas/pepperoni.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Buffalo Chicken",
                    Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                    Price = 12.75m,
                    ImageUrl = "img/pizzas/meaty.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Mushroom Lovers",
                    Description = "It has mushrooms. Isn't that obvious?",
                    Price = 11.00m,
                    ImageUrl = "img/pizzas/mushroom.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Veggie Delight",
                    Description = "It's like salad, but on a pizza",
                    Price = 11.50m,
                    ImageUrl = "img/pizzas/salad.jpg"
                },
                new PizzaSpecial
                {
                    Name = "Margherita",
                    Description = "Traditional Italian pizza with tomatoes and basil",
                    Price = 9.99m,
                    ImageUrl = "img/pizzas/margherita.jpg"
                }
            };

            db.Specials.AddRange(specials);
            db.SaveChanges();
        }
    }
}
namespace BlazingPizza.Model
{
    public class Pizza
    {
        public int PizzaId { get; set; }

        public int SpecialId { get; set; }
        public PizzaSpecial? Special { get; set; }

        public string Size { get; set; } = "Medium"; // ✅ Changed from int to string

        public List<PizzaTopping> Toppings { get; set; } = new();

        public decimal Price => GetTotalPrice();

        public decimal GetTotalPrice()
        {
            decimal total = Special?.Price ?? 0m;
            total += Toppings.Sum(t => t.Topping?.Price ?? 0m);
            return total;
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("C2", new System.Globalization.CultureInfo("en-ZW"));
        }
    }
}
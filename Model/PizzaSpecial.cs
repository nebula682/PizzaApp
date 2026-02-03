namespace BlazingPizza.Model
{
    public class PizzaSpecial
    {
        public int Id { get; set; }                 
        public string Name { get; set; } = "";      
        public string Description { get; set; } = ""; 
        public decimal Price { get; set; }          // ✅ Base price
        public string ImageUrl { get; set; } = "";  
        public string GetFormattedBasePrice() => Price.ToString("0.00");
    }
}
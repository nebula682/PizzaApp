using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazingPizza.Model
{
    public class Order
    {
        public int OrderId { get; set; }                      // Primary key required by EF
        public DateTime CreatedTime { get; set; } = DateTime.Now; // Optional, but needed for UI
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();

        public decimal GetFormattedTotalPrice()
        {
            return Pizzas.Sum(p => p.Price);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using BlazingPizza.Model;

namespace BlazingPizza
{
    public class OrderState
    {
        // Current order (MODEL Order)
        public Order Order { get; private set; } = new Order();

        // Configure Pizza dialog state
        public bool ShowingConfigureDialog { get; private set; }
        public Pizza? ConfiguringPizza { get; private set; }

        // Show configure dialog
        public void ShowConfigurePizzaDialog(PizzaSpecial special)
        {
            ConfiguringPizza = new Pizza
            {
                Special = special,
                Size = "Medium"
            };

            ShowingConfigureDialog = true;
        }

        // Cancel dialog
        public void CancelConfigurePizzaDialog()
        {
            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
        }

        // Confirm dialog
        public void ConfirmConfigurePizzaDialog()
        {
            if (ConfiguringPizza != null)
            {
                Order.Pizzas.Add(ConfiguringPizza);
            }

            ConfiguringPizza = null;
            ShowingConfigureDialog = false;
        }

        // Remove a pizza
        public void RemoveConfiguredPizza(Pizza pizza)
        {
            Order.Pizzas.Remove(pizza);
        }

        // Reset order
        public void ResetOrder()
        {
            Order = new Order();
        }
    }
}
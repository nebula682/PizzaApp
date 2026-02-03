namespace BlazingPizza.Model;

public class OrderWithStatus
{
    public Order Order { get; set; } = default!;
    public string StatusText { get; set; } = "";

    public static OrderWithStatus FromOrder(Order order)
    {
        return new OrderWithStatus
        {
            Order = order,
            StatusText = "Preparing" // demo value
        };
    }
}

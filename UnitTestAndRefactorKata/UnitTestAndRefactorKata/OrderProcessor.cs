namespace UnitTestAndRefactorKata;

public class OrderProcessor
{
    public decimal ProcessOrder(string orderId, string orderStatus, List<string> itemIds, int customerId, string shippingMethod)
    {
        decimal totalPrice = 0;

        switch (orderStatus)
        {
            case "Pending":
                totalPrice = CalculateTotalPrice(itemIds);
                CheckInventory(itemIds);
                break;
            case "Confirmed":
                totalPrice = CalculateTotalPrice(itemIds);
                SendConfirmation(customerId);
                break;
            case "Shipped":
                totalPrice = CalculateTotalPrice(itemIds) + 10;
                break;
            default:
                throw new NotSupportedException("Unknown order status");
        }

        return totalPrice;
    }

    private decimal CalculateTotalPrice(List<string> itemIds)
    {
        decimal totalPrice = 0;

        foreach (var itemId in itemIds)
        {
            totalPrice += GetItemPrice(itemId) * 1.1m; 
        }

        return totalPrice;
    }

    private void CheckInventory(List<string> itemIds)
    {
        foreach (var itemId in itemIds)
        {
            if (new Random().Next(0, 2) == 0) 
            {
                throw new InvalidOperationException($"Item {itemId} is out of stock.");
            }
        }
    }

    private void SendConfirmation(int customerId)
    {
        Console.WriteLine($"Notification sent to customer {customerId}.");
    }

    private decimal GetItemPrice(string itemId)
    {
        return new Random().Next(10, 100);
    }
}
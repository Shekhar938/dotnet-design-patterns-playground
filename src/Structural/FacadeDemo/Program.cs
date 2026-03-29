using System;

namespace FacadeDemo
{
    // The Facade Pattern provides a simplified interface to a 
    // complex system of classes, a library, or a framework.

    // The Subsystem classes have their own complex interfaces and behaviors.
    // They are not aware of the facade.

    public class InventorySystem
    {
        public bool CheckStock(string itemId)
        {
            Console.WriteLine($"[Inventory] Checking stock for {itemId}...");
            return true; // Simple logic
        }

        public void ReduceStock(string itemId)
        {
            Console.WriteLine($"[Inventory] Reducing stock for {itemId}...");
        }
    }

    public class PaymentSystem
    {
        public bool Charge(string userId, double amount)
        {
            Console.WriteLine($"[Payment] Charging {amount:C} to user {userId}...");
            return true;
        }
    }

    public class ShippingSystem
    {
        public void ShipOrder(string itemId)
        {
            Console.WriteLine($"[Shipping] Shipping item {itemId} to customer address.");
        }
    }

    public class NotificationSystem
    {
        public void SendEmail(string userId, string message)
        {
            Console.WriteLine($"[Notification] Sending email to user {userId}: {message}");
        }
    }

    // The Facade class provides a simple interface to the complex subsystems.
    public class OrderFacade
    {
        private readonly InventorySystem _inventory = new InventorySystem();
        private readonly PaymentSystem _payment = new PaymentSystem();
        private readonly ShippingSystem _shipping = new ShippingSystem();
        private readonly NotificationSystem _notification = new NotificationSystem();

        public bool PlaceOrder(string userId, string itemId, double price)
        {
            Console.WriteLine($"\n--- Facade: Processing order for User: {userId}, Item: {itemId} ---");
            
            if (!_inventory.CheckStock(itemId))
            {
                _notification.SendEmail(userId, "Order failed: Item out of stock.");
                return false;
            }

            if (!_payment.Charge(userId, price))
            {
                _notification.SendEmail(userId, "Order failed: Payment declined.");
                return false;
            }

            _inventory.ReduceStock(itemId);
            _shipping.ShipOrder(itemId);
            _notification.SendEmail(userId, "Success: Your order is on its way!");

            Console.WriteLine("--- Facade: Order complete! ---\n");
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Facade Pattern: Order Processing ---");

            // Client code only interacts with the Facade, 
            // not the underlying systems.
            var orderFacade = new OrderFacade();

            // Client simple call
            orderFacade.PlaceOrder("user_88", "Laptop-Pro", 1200.00);
            
            orderFacade.PlaceOrder("user_99", "Smartphone-X", 800.00);

            Console.WriteLine("\nSuccess: Facade simplified complex interactions for the client.");
        }
    }
}

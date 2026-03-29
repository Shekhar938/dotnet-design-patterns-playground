using System;

namespace StrategyDemo
{
    // The Strategy Pattern defines a family of algorithms, 
    // encapsulates each one, and makes them interchangeable. 
    // It lets the algorithm vary independently from the clients that use it.

    // The Strategy interface declares operations common to all 
    // supported versions of some algorithm.
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // Concrete Strategies implement different variations of an algorithm.
    public class CreditCardStrategy : IPaymentStrategy
    {
        private string _name;
        private string _cardNumber;
        private string _cvv;

        public CreditCardStrategy(string name, string cardNumber, string cvv)
        {
            _name = name;
            _cardNumber = cardNumber;
            _cvv = cvv;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"[Strategy] Paying {amount:C} using Credit Card ({_cardNumber}). Holder: {_name}");
        }
    }

    public class PayPalStrategy : IPaymentStrategy
    {
        private string _email;

        public PayPalStrategy(string email)
        {
            _email = email;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"[Strategy] Paying {amount:C} using PayPal account: {_email}");
        }
    }

    public class BitcoinStrategy : IPaymentStrategy
    {
        private string _walletAddress;

        public BitcoinStrategy(string walletAddress)
        {
            _walletAddress = walletAddress;
        }

        public void Pay(double amount)
        {
            Console.WriteLine($"[Strategy] Paying {amount:C} using Bitcoin wallet: {_walletAddress}");
        }
    }

    // The Context defines the interface of interest to clients.
    public class ShoppingCart
    {
        private List<(string item, double price)> _items = new List<(string, double)>();

        public void AddItem(string item, double price)
        {
            _items.Add((item, price));
            Console.WriteLine($"[Cart] Added {item} - {price:C}");
        }

        public double CalculateTotal()
        {
            double sum = 0;
            _items.ForEach(x => sum += x.price);
            return sum;
        }

        // The Context maintains a reference to one of the Strategy objects 
        // and communicates with it only via the Strategy interface.
        public void Checkout(IPaymentStrategy paymentStrategy)
        {
            double total = CalculateTotal();
            Console.WriteLine($"[Cart] Processing total checkout of {total:C}...");
            paymentStrategy.Pay(total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Strategy Pattern: Payment Processing ---");

            var cart = new ShoppingCart();
            cart.AddItem("Logitech Mouse", 25.50);
            cart.AddItem("Mechanical Keyboard", 120.00);

            // Client chooses strategy at runtime
            Console.WriteLine("\nClient selects Credit Card payment:");
            cart.Checkout(new CreditCardStrategy("John Doe", "1234-5678-9012-3456", "123"));

            Console.WriteLine("\nClient selects PayPal payment:");
            cart.Checkout(new PayPalStrategy("john.doe@example.com"));

            Console.WriteLine("\nClient selects Bitcoin payment:");
            cart.Checkout(new BitcoinStrategy("bc1qxy2kg2ry4jk244rl05868vfs8v55hkh2974"));

            Console.WriteLine("\nSuccess: The algorithms (payment methods) can vary independently from the client (ShoppingCart).");
        }
    }
}

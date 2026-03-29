using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    // The Observer Pattern defines a subscription mechanism 
    // to notify multiple objects about any events that happen 
    // to the object they're observing.

    // The Observer interface declares the update method, 
    // used by the Subject to notify observers.
    public interface IStockObserver
    {
        void Update(string stockSymbol, double price);
    }

    // The Subject declares a set of methods for managing subscribers.
    public interface IStockSubject
    {
        void RegisterObserver(IStockObserver observer);
        void RemoveObserver(IStockObserver observer);
        void NotifyObservers();
    }

    // Concrete Subject stores state of interest to ConcreteObservers 
    // and sends notifications when state changes.
    public class StockMarket : IStockSubject
    {
        private readonly List<IStockObserver> _observers = new List<IStockObserver>();
        private string _symbol = string.Empty;
        private double _price;

        public void RegisterObserver(IStockObserver observer)
        {
            _observers.Add(observer);
            Console.WriteLine($"[Market] Registered a new observer.");
        }

        public void RemoveObserver(IStockObserver observer)
        {
            _observers.Remove(observer);
            Console.WriteLine($"[Market] Removed an observer.");
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_symbol, _price);
            }
        }

        public void SetStockPrice(string symbol, double price)
        {
            Console.WriteLine($"[Market] Stock price changed: {symbol} is now {price:C}");
            _symbol = symbol;
            _price = price;
            NotifyObservers();
        }
    }

    // Concrete Observers react to updates issued by the Subject.
    public class MobileAppObserver : IStockObserver
    {
        private readonly string _userName;

        public MobileAppObserver(string userName)
        {
            _userName = userName;
        }

        public void Update(string stockSymbol, double price)
        {
            Console.WriteLine($"[Mobile App - {_userName}] ALERT: {stockSymbol} reached {price:C}. Updating dashboard.");
        }
    }

    public class EmailAlertObserver : IStockObserver
    {
        private readonly string _email;

        public EmailAlertObserver(string email)
        {
            _email = email;
        }

        public void Update(string stockSymbol, double price)
        {
            Console.WriteLine($"[Email Alert - {_email}] Notification: {stockSymbol} is trading at {price:C}. Analysis attached.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Observer Pattern: Stock Market ---");

            var stockMarket = new StockMarket();

            var user1 = new MobileAppObserver("John-Invests");
            var user2 = new MobileAppObserver("Sarah-Stocks");
            var emailService = new EmailAlertObserver("alerts@fintech.com");

            stockMarket.RegisterObserver(user1);
            stockMarket.RegisterObserver(user2);
            stockMarket.RegisterObserver(emailService);

            // Update price
            Console.WriteLine("\nUpdate 1:");
            stockMarket.SetStockPrice("MSFT", 420.50);

            // Unregister one observer
            Console.WriteLine("\nUnregistering Sarah...");
            stockMarket.RemoveObserver(user2);

            // Update price again
            Console.WriteLine("\nUpdate 2:");
            stockMarket.SetStockPrice("MSFT", 425.00);

            Console.WriteLine("\nSuccess: Multiple objects notified of state changes without being tightly coupled.");
        }
    }
}

using System;

namespace FactoryDemo
{
    // The Factory Method Pattern defines an interface for creating an object, 
    // but lets subclasses decide which class to instantiate. 
    // It lets a class defer instantiation to subclasses.

    // The Product interface declares the operations that all concrete products must implement.
    public interface INotification
    {
        void Send(string message);
    }

    // Concrete Products provide various implementations of the Product interface.
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Email] Sending notification: {message}");
        }
    }

    public class SmsNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS] Sending notification: {message}");
        }
    }

    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Push] Sending notification: {message}");
        }
    }

    // The Creator class declares the factory method that is supposed to return
    // an object of a Product class. The Creator's subclasses usually provide
    // the implementation of this method.
    public abstract class NotificationFactory
    {
        public abstract INotification CreateNotification();

        // The Creator's primary responsibility isn't creating products. 
        // Usually, it contains some core business logic that relies on
        // Product objects, returned by the factory method. 
        public void Notify(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }

    // Concrete Creators override the factory method to change the 
    // resulting product's type.
    public class EmailNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new EmailNotification();
    }

    public class SmsNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new SmsNotification();
    }

    public class PushNotificationFactory : NotificationFactory
    {
        public override INotification CreateNotification() => new PushNotification();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Factory Method Pattern: Notification Service ---");

            NotificationFactory factory;

            // Real-world scenario: Factory selection based on configuration/type
            Console.WriteLine("Client: Sending Email notification...");
            factory = new EmailNotificationFactory();
            factory.Notify("Hello! Your order has been shipped.");

            Console.WriteLine("\nClient: Sending SMS notification...");
            factory = new SmsNotificationFactory();
            factory.Notify("Your verification code is 12345.");

            Console.WriteLine("\nClient: Sending Push notification...");
            factory = new PushNotificationFactory();
            factory.Notify("New message received!");
        }
    }
}

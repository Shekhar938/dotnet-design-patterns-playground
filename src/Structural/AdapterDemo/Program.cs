using System;

namespace AdapterDemo
{
    // The Adapter Pattern allows objects with incompatible interfaces to collaborate.

    // The Target defines the domain-specific interface used by the client code.
    public interface IPaymentProcessor
    {
        void ProcessPayment(string merchantId, double amount);
    }

    // The Adaptee contains some useful behavior, but its interface is 
    // incompatible with the existing client code. 
    // Let's say we have a legacy or third-party PayPal API.
    public class LegacyPayPalApi
    {
        public void MakePayment(string paypalEmail, string amountInCents)
        {
            Console.WriteLine($"[Legacy PayPal] Processing payment for {paypalEmail}. Amount: {amountInCents} cents.");
        }
    }

    // The Adapter makes the Adaptee's interface compatible with the Target's interface.
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly LegacyPayPalApi _legacyPayPalApi;

        public PayPalAdapter(LegacyPayPalApi legacyPayPalApi)
        {
            _legacyPayPalApi = legacyPayPalApi;
        }

        public void ProcessPayment(string merchantId, double amount)
        {
            // Conversion logic inside the adapter
            string paypalEmail = $"{merchantId}@paypal.com";
            string amountInCents = (amount * 100).ToString();

            _legacyPayPalApi.MakePayment(paypalEmail, amountInCents);
        }
    }

    // Another Adaptee - Stripe API
    public class StripeApi
    {
        public void Pay(string token, decimal total)
        {
            Console.WriteLine($"[Stripe] Charging {total:C} using token {token}.");
        }
    }

    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeApi _stripeApi;

        public StripeAdapter(StripeApi stripeApi)
        {
            _stripeApi = stripeApi;
        }

        public void ProcessPayment(string merchantId, double amount)
        {
            string token = $"tok_{merchantId}";
            decimal total = (decimal)amount;

            _stripeApi.Pay(token, total);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Adapter Pattern: Payment Gateway ---");

            // Client code expects IPaymentProcessor
            IPaymentProcessor processor;

            // Using PayPal through Adapter
            Console.WriteLine("\nClient: Using PayPal Adapter...");
            processor = new PayPalAdapter(new LegacyPayPalApi());
            processor.ProcessPayment("merchant_123", 49.99);

            // Using Stripe through Adapter
            Console.WriteLine("\nClient: Using Stripe Adapter...");
            processor = new StripeAdapter(new StripeApi());
            processor.ProcessPayment("merchant_456", 99.50);

            Console.WriteLine("\nSuccess: Client code interacted with incompatible APIs through the same interface.");
        }
    }
}

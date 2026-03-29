using System;

namespace StateDemo
{
    // The State Pattern lets an object alter its behavior when 
    // its internal state changes. It appears as if the object 
    // changed its class.

    // The Context defines the interface of interest to clients. 
    // It also maintains a reference to an instance of a State 
    // subclass, which represents the current state.
    public class OrderContext
    {
        private IOrderState _state;

        public OrderContext(IOrderState state)
        {
            _state = state;
            Console.WriteLine($"[Order Context] Initial state set to: {state.GetType().Name}");
        }

        public void TransitionTo(IOrderState state)
        {
            Console.WriteLine($"[Order Context] Transitioning to state: {state.GetType().Name}");
            _state = state;
        }

        // The Context delegates state-specific work to the current State object.
        public void Proceed() => _state.Proceed(this);
        public void Cancel() => _state.Cancel(this);
    }

    // The base State interface declares methods that all 
    // Concrete States should implement and also provides 
    // a backreference to the Context object.
    public interface IOrderState
    {
        void Proceed(OrderContext context);
        void Cancel(OrderContext context);
    }

    // Concrete States implement behaviors associated with 
    // a state of the Context.
    public class NewOrderState : IOrderState
    {
        public void Proceed(OrderContext context)
        {
            Console.WriteLine("[NewOrderState] Payment processed. Moving to Paid state.");
            context.TransitionTo(new PaidOrderState());
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("[NewOrderState] Order cancelled. Moving to Cancelled state.");
            context.TransitionTo(new CancelledOrderState());
        }
    }

    public class PaidOrderState : IOrderState
    {
        public void Proceed(OrderContext context)
        {
            Console.WriteLine("[PaidOrderState] Item shipped. Moving to Shipped state.");
            context.TransitionTo(new ShippedOrderState());
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("[PaidOrderState] Refunding payment. Moving to Cancelled state.");
            context.TransitionTo(new CancelledOrderState());
        }
    }

    public class ShippedOrderState : IOrderState
    {
        public void Proceed(OrderContext context)
        {
            Console.WriteLine("[ShippedOrderState] Item delivered. Final state reached.");
            // No transition here, end of lifecycle.
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("[ShippedOrderState] ERROR: Cannot cancel an order that has already been shipped.");
        }
    }

    public class CancelledOrderState : IOrderState
    {
        public void Proceed(OrderContext context)
        {
            Console.WriteLine("[CancelledOrderState] ERROR: Cannot proceed with a cancelled order.");
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("[CancelledOrderState] Order is already cancelled.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- State Pattern: Order Lifecycle ---");

            // 1. Initial order
            Console.WriteLine("\nScenario 1: Happy Path (New -> Paid -> Shipped)");
            var order1 = new OrderContext(new NewOrderState());
            order1.Proceed(); // New -> Paid
            order1.Proceed(); // Paid -> Shipped
            order1.Proceed(); // End

            // 2. Cancellation
            Console.WriteLine("\nScenario 2: Cancellation (New -> Cancelled)");
            var order2 = new OrderContext(new NewOrderState());
            order2.Cancel();  // New -> Cancelled
            order2.Proceed(); // Error

            // 3. Shipped Cancellation
            Console.WriteLine("\nScenario 3: Attempting to cancel a shipped order");
            var order3 = new OrderContext(new ShippedOrderState());
            order3.Cancel(); // Error

            Console.WriteLine("\nSuccess: The order's behavior changes dynamically based on its state.");
        }
    }
}

using System;
using System.Collections.Generic;

namespace CommandDemo
{
    // The Command Pattern turns a request into a stand-alone object 
    // that contains all information about the request. 
    // This transformation lets you pass requests as a method arguments, 
    // delay or queue a request's execution, and support undoable operations.

    // The Command interface declares a method for executing a command.
    public interface ICommand
    {
        void Execute();
    }

    // The Receiver class contains some important business logic. 
    // It knows how to perform the operations associated with 
    // carrying out a request.
    public class OrderReceiver
    {
        public void CreateOrder(int id)
        {
            Console.WriteLine($"[Order System] Order {id} created.");
        }

        public void CancelOrder(int id)
        {
            Console.WriteLine($"[Order System] Order {id} cancelled.");
        }
    }

    // Concrete Commands implement various kinds of requests. 
    // A concrete command isn't supposed to perform the work on its own, 
    // but rather to pass the call to one of the business logic objects.
    public class PlaceOrderCommand : ICommand
    {
        private readonly OrderReceiver _receiver;
        private readonly int _orderId;

        public PlaceOrderCommand(OrderReceiver receiver, int orderId)
        {
            _receiver = receiver;
            _orderId = orderId;
        }

        public void Execute()
        {
            _receiver.CreateOrder(_orderId);
        }
    }

    public class CancelOrderCommand : ICommand
    {
        private readonly OrderReceiver _receiver;
        private readonly int _orderId;

        public CancelOrderCommand(OrderReceiver receiver, int orderId)
        {
            _receiver = receiver;
            _orderId = orderId;
        }

        public void Execute()
        {
            _receiver.CancelOrder(_orderId);
        }
    }

    // The Invoker is associated with one or several commands. 
    // It sends a request to the command.
    public class CommandQueue
    {
        private readonly Queue<ICommand> _commands = new Queue<ICommand>();

        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);
            Console.WriteLine("[Invoker] Command added to queue.");
        }

        public void ProcessCommands()
        {
            Console.WriteLine($"[Invoker] Processing {_commands.Count} commands...");
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                command.Execute();
            }
            Console.WriteLine("[Invoker] All commands processed.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Command Pattern: Order Commands ---");

            var receiver = new OrderReceiver();
            var invoker = new CommandQueue();

            // Client creates commands and gives them to the invoker
            Console.WriteLine("\nClient: Queuing commands...");
            invoker.AddCommand(new PlaceOrderCommand(receiver, 101));
            invoker.AddCommand(new PlaceOrderCommand(receiver, 102));
            invoker.AddCommand(new CancelOrderCommand(receiver, 101));

            // Execute the commands
            Console.WriteLine("\nClient: Triggering process...");
            invoker.ProcessCommands();

            Console.WriteLine("Success: Commands are decoupled from the requester and can be queued/logged.");
        }
    }
}

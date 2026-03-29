# Command Pattern

## Problem
Imagine you’re working on a new text-editor app. Your current task is to create a toolbar with a bunch of buttons for various operations of the editor. You created a very neat `Button` subclass that can be used for buttons on the toolbar, as well as for generic buttons in various dialogs. While all of these buttons look similar, they’re all supposed to do different things. Where would you put the code for handling clicks on these buttons? The simplest solution is to create tons of subclasses for each place where the button is used. These subclasses would contain the code that should be executed on a button click.

## Structure
- **Sender (Invoker)**: The class responsible for initiating requests. This class must have a field for storing a reference to a command object. The sender triggers that command instead of sending the request directly to the receiver.
- **Command Interface**: Usually declares just a single method for executing the command.
- **Concrete Commands**: Implement various kinds of requests. A concrete command isn’t supposed to perform the work on its own, but rather to pass the call to one of the business logic objects.
- **Receiver**: Contains the actual business logic. Almost any object may act as a receiver. Most commands only handle the details of how a request is passed to the receiver, while the receiver itself does the actual work.
- **Client**: Creates and configures concrete command objects. The client must pass all of the request parameters, including a receiver instance, into the command’s constructor. After that, the resulting command may be associated with one or multiple senders.

## When to use
- When you want to parameterize objects with operations.
- When you want to queue operations, schedule their execution, or execute them remotely.
- When you want to implement reversible operations (Undo/Redo).

## Real-world examples
- **Remote Control**: Each button on a remote control is a command that performs an action on a device.
- **Task Scheduling**: Queuing up tasks like database backups or report generation to be executed later.
- **Transactional systems**: Logging operations so they can be replayed or rolled back.

## Pros
- **Single Responsibility Principle**: You can decouple classes that invoke operations from classes that perform these operations.
- **Open/Closed Principle**: You can introduce new commands into the app without breaking existing client code.
- **Composition**: You can assemble a set of simple commands into a complex one.

## Cons
- **Code complexity**: The code may become more complicated since you’re introducing a whole new layer between senders and receivers.

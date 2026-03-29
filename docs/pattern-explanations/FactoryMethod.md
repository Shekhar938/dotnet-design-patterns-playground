# Factory Method Pattern

## Problem
A class can't anticipate the class of objects it must create. The class wants its subclasses to specify the objects it creates.

## Structure
- **Product Interface**: Declares the operations common to all products.
- **Concrete Products**: Implementations of the Product interface.
- **Creator (Base Class)**: Declares the factory method.
- **Concrete Creators**: Override the factory method to return an instance of a Concrete Product.

## When to use
- When a class can't predict the class of objects it must create.
- When a class wants its subclasses to specify the objects it creates.
- When you want to localize the knowledge of which helper subclass is the delegate.

## Real-world examples
- **Notification Service**: (Email, SMS, Push) - The client doesn't care how the message is sent, only that it is sent.
- **UI Components**: A cross-platform UI framework creates different button styles for Windows, macOS, or Linux.
- **Logging Libraries**: A factory can create loggers that output to Console, File, or Database.

## Pros
- **Decoupling**: You don't need to bind application-specific classes into your code.
- **Single Responsibility Principle**: The product creation code is in one place.
- **Open/Closed Principle**: You can introduce new types of products without breaking existing code.

## Cons
- **Complexity**: The code may become more complicated since you need to introduce many new subclasses.

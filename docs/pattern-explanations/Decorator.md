# Decorator Pattern

## Problem
You are working on a notification library. It initially supports sending emails. Later, users want to receive SMS, Facebook, or Slack notifications. You start creating subclasses for each combination (Email + SMS, Email + Slack, etc.). This leads to an explosion of subclasses that are hard to maintain.

## Structure
- **Component Interface**: Declares the common interface for both wrappers and wrapped objects.
- **Concrete Component**: The class of objects being wrapped. It defines the basic behavior.
- **Base Decorator**: Has a field for referencing a wrapped object. The field’s type should be declared as the component interface so it can contain both concrete components and decorators.
- **Concrete Decorators**: Define extra behaviors that can be added to components dynamically.

## When to use
- When you need to assign extra behaviors to objects at runtime without breaking the code that uses these objects.
- When it’s awkward or impossible to extend an object’s behavior using inheritance.

## Real-world examples
- **Encryption and Compression**: Adding layers of encryption or compression to data streams.
- **Logging**: Adding different levels of logging or formatting to a logger.
- **UI Styling**: Adding borders, scrolls, or shadows to UI elements.

## Pros
- **Flexibility**: You can extend an object’s behavior without creating a new subclass.
- **Run-time customization**: You can add or remove responsibilities from an object at runtime.
- **Single Responsibility Principle**: You can divide a monolithic class that implements many possible variants of behavior into several smaller classes.

## Cons
- **Order dependency**: It’s hard to remove a specific wrapper from the wrappers stack.
- **Complex configuration**: It’s hard to implement a decorator in such a way that its behavior doesn’t depend on the order in the decorators stack.

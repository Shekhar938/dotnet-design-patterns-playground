# Singleton Pattern

## Problem
In some scenarios, you need to ensure that only one instance of a class exists and provide a global point of access to it. Common examples include configuration managers, connection pools, or loggers.

## Structure
The class defines a static property (often called `Instance`) that returns the same instance of the class. The constructor is private to prevent other objects from using the `new` operator.

## When to use
- When there should be exactly one instance of a class, and it must be accessible to clients from a well-known access point.
- When the sole instance should be extensible by subclassing, and clients should be able to use an extended instance without modifying their code.

## Real-world examples
- **Configuration Manager**: To maintain application-wide settings.
- **Logger**: To ensure all log entries are handled by a single file/service.
- **Database Connection Pool**: To manage a limited set of connections.

## Pros
- **Controlled access to the sole instance**: Tight control over how and when clients access it.
- **Reduced namespace**: An improvement over global variables.
- **Lazy initialization**: The instance is only created when first needed.

## Cons
- **Global state**: Can introduce hidden dependencies.
- **Testing difficulties**: Singleton objects are hard to mock or replace in unit tests.
- **Concurrency**: Requires careful implementation in multi-threaded environments.

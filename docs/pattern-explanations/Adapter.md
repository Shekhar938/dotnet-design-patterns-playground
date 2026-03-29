# Adapter Pattern

## Problem
Imagine that you’re creating a stock market monitoring app. The app downloads the stock data from multiple sources in XML format and then displays nice-looking charts for the user. At some point, you decide to improve the app by integrating a smart 3rd-party analytics library. But there’s a catch: the analytics library only works with data in JSON format.

## Structure
- **Client**: A class that contains the existing business logic of the program.
- **Client Interface**: Describes a protocol that other classes must follow to be able to collaborate with the client code.
- **Service**: Some useful class (usually 3rd-party or legacy). The client can’t use this class directly because it has an incompatible interface.
- **Adapter**: A class that’s able to work with both the client and the service: it implements the client interface, while wrapping the service object.

## When to use
- When you want to use some existing class, but its interface isn’t compatible with the rest of your code.
- When you want to reuse several existing subclasses that lack some common functionality that can’t be added to the superclass.

## Real-world examples
- **Data Conversion**: Converting data from one format (XML) to another (JSON) for a library.
- **Hardware Drivers**: Adapting a generic OS interface to specific hardware.
- **Legacy Integration**: Integrating old code into a new system without modifying the old code.

## Pros
- **Single Responsibility Principle**: You can separate the interface or data conversion code from the primary business logic of the program.
- **Open/Closed Principle**: You can introduce new types of adapters into the program without breaking the existing client code, as long as they work with the adapters through the client interface.

## Cons
- **Code complexity**: The overall complexity of the code increases because you need to introduce a set of new interfaces and classes.

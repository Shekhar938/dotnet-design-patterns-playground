# Facade Pattern

## Problem
Imagine your code has to work with a broad set of objects that belong to a sophisticated library or framework. Ordinarily, you’d need to initialize all of those objects, keep track of dependencies, execute methods in the correct order, and so on. As a result, the business logic of your classes would become tightly coupled to the implementation details of 3rd-party classes.

## Structure
- **Facade**: Provides convenient access to a particular part of the subsystem’s functionality. It knows where to direct the client’s request and how to operate all the moving parts.
- **Additional Facade**: Can be created to prevent polluting a single facade with unrelated features that might make it yet another complex structure.
- **Complex Subsystem**: Consists of dozens of various objects. To make them all do something meaningful, you have to dive deep into the subsystem’s implementation details.
- **Client**: Uses the facade instead of calling the subsystem objects directly.

## When to use
- When you need to provide a simple interface to a complex subsystem.
- When you want to structure a subsystem into layers.

## Real-world examples
- **Video Conversion**: A facade that hides the complexity of codecs, bitrate settings, and audio syncing.
- **Travel Booking**: A single interface to book flights, hotels, and car rentals from different providers.
- **Home Automation**: A central "Away" button that turns off lights, locks doors, and sets the alarm.

## Pros
- **Isolation**: You can isolate your code from the complexity of a subsystem.
- **Decoupling**: It provides a way to reduce the number of dependencies between your code and the subsystem.

## Cons
- **God Object**: A facade can become a god object coupled to all classes of an app.

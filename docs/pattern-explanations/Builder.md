# Builder Pattern

## Problem
Imagine a complex object that requires incremental, step-by-step initialization of many fields and nested objects. Such initialization code is usually buried inside a monstrous constructor with lots of parameters. Or even worse: scattered all over the client code.

## Structure
- **Builder Interface**: Declares product construction steps that are common to all types of builders.
- **Concrete Builders**: Provide different implementations of the construction steps. Concrete builders may produce products that don't follow the common interface.
- **Product**: The resulting object.
- **Director**: Defines the order in which to call construction steps, so you can create and reuse specific configurations of products.

## When to use
- When you want to get rid of a "telescoping constructor" (when a constructor has too many parameters).
- When you want your code to be able to create different representations of some product (for example, stone and wooden houses).
- When you need to construct complex objects.

## Real-world examples
- **Car Manufacturing**: Building a car with optional features like GPS, sunroof, or premium audio system.
- **Document Generators**: Creating complex documents (PDF, HTML, RTF) using the same construction process.
- **Meal Ordering**: Constructing a fast-food meal with different items (burger, drink, side).

## Pros
- **Step-by-step construction**: You can defer construction steps or run steps recursively.
- **Single Responsibility Principle**: You can isolate complex construction code from the business logic of the product.
- **Open/Closed Principle**: You can introduce new builders without breaking existing code.

## Cons
- **Code complexity**: The overall complexity of the code increases since the pattern requires creating multiple new classes.

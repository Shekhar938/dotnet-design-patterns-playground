# Observer Pattern

## Problem
Imagine that you have two types of objects: a `Customer` and a `Store`. The customer is very interested in a particular brand of product (say, a new model of the iPhone) which should become available in the store very soon. The customer could visit the store every day and check product availability. But while the product isn’t available, most of these trips would be pointless. On the other hand, the store could send tons of emails (which might be considered spam) to all customers each time a new product becomes available. This would save some customers from endless trips to the store. At the same time, it’d upset other customers who aren’t interested in new products.

## Structure
- **Publisher (Subject)**: Issues events of interest to other objects. These events occur when the publisher changes its state or executes some behaviors. Publishers contain a subscription infrastructure that lets new subscribers join and current subscribers leave the list.
- **Subscriber Interface**: Declares the notification interface. In most cases, it consists of a single `update` method.
- **Concrete Subscribers**: Perform some actions in response to notifications issued by the publisher. All these classes must implement the same interface so the publisher isn’t coupled to concrete classes.
- **Client**: Creates publisher and subscriber objects separately and then registers subscribers for publisher updates.

## When to use
- When changes to the state of one object may require changing other objects, and the actual set of objects is unknown beforehand or changes dynamically.
- When some objects in your app must observe others, but only for a limited time or in specific cases.

## Real-world examples
- **Stock Market**: Multiple displays showing live stock prices that update when the market changes.
- **Social Media**: Followers being notified when a user posts a new update.
- **GUI Events**: Button clicks or mouse movements being handled by various event listeners.

## Pros
- **Open/Closed Principle**: You can introduce new subscriber classes without having to change the publisher’s code.
- **Runtime relationships**: You can establish relations between objects at runtime.

## Cons
- **Random notification order**: Subscribers are notified in random order.
- **Memory leaks**: If subscribers aren't removed, they might stay in memory, causing leaks.

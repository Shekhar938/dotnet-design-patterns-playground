# State Pattern

## Problem
The State pattern is closely related to the concept of a Finite State Machine. The main idea is that, at any given moment, there’s a finite number of states which a program can be in. Within any unique state, the program behaves differently, and the program can be switched from one state to another instantaneously. However, depending on a current state, the program may or may not switch to certain other states. These switching rules, called transitions, are also finite and predetermined.

## Structure
- **Context**: Stores a reference to one of the concrete state objects and delegates to it all state-specific work. The context communicates with the state object via the state interface. The context exposes a setter for passing it a new state object.
- **State Interface**: Declares the state-specific methods. These methods should make sense for all concrete states because you don’t want some of your states to have useless methods that will never be called.
- **Concrete States**: Provide their own implementations for the state-specific methods. To avoid duplication of similar code across multiple states, you may provide intermediate abstract classes that encapsulate some common behavior.
- **Transition logic**: Both Context and Concrete States can set the next state of the context and perform the actual state transition by replacing the state object linked to the context.

## When to use
- When you have an object that behaves differently depending on its current state, the number of states is enormous, and the state-specific code changes frequently.
- When you have a class polluted with massive conditionals that alter how the class behaves according to the current values of the class’s fields.
- When you have a lot of duplicate code across similar states and transitions of a condition-based state machine.

## Real-world examples
- **Vending Machine**: Behavior changes based on states like NoCoin, HasCoin, Sold, or SoldOut.
- **Order Processing**: An order moves through states like New, Paid, Shipped, Delivered, or Cancelled.
- **Media Player**: States like Playing, Paused, Stopped, each handling buttons differently.

## Pros
- **Single Responsibility Principle**: Organize the code related to particular states into separate classes.
- **Open/Closed Principle**: Introduce new states without changing existing state classes or the context.
- **Simpler code**: Simplify the code of the context by eliminating bulky state machine conditionals.

## Cons
- **Overkill**: Applying the pattern can be overkill if a state machine has only a few states or rarely changes.

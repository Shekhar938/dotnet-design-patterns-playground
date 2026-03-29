# Strategy Pattern

## Problem
One day you decided to create a navigation app for casual travelers. The app was centered around a beautiful map that helped users quickly orient themselves in any city. One of the most requested features for the app was automatic route planning. A user should be able to enter an address and see the fastest route to that destination displayed on the map. The first version of the app could only build the routes over roads. People who traveled by car were ecstatic. But apparently, not everybody likes to drive on their vacation. So with the next update, you added an option to build walking routes. After that, you added another option to use public transport in their routes.

## Structure
- **Context**: Maintains a reference to one of the concrete strategies and communicates with this object only via the strategy interface.
- **Strategy Interface**: Common to all concrete strategies. It declares a method the context uses to execute a strategy.
- **Concrete Strategies**: Implement different variations of an algorithm the context uses.
- **Client**: Creates a specific strategy object and passes it to the context.

## When to use
- When you want to use different variants of an algorithm within an object and be able to switch from one algorithm to another during runtime.
- When you have a lot of similar classes that only differ in the way they execute some behavior.
- When you want to isolate the business logic of a class from the implementation details of algorithms that may not be as important in the context of that logic.
- When your class has a massive conditional operator that switches between different variants of the same algorithm.

## Real-world examples
- **Sorting Algorithms**: Switching between QuickSort, MergeSort, or BubbleSort based on data size.
- **Payment Methods**: Choosing between Credit Card, PayPal, or Crypto at checkout.
- **Compression**: Selecting different compression levels or algorithms (ZIP, RAR, 7Z).

## Pros
- **Swap at runtime**: You can swap algorithms used inside an object at runtime.
- **Isolation**: You can isolate the implementation details of an algorithm from the code that uses it.
- **Open/Closed Principle**: You can introduce new strategies without having to change the context.

## Cons
- **Strategy awareness**: Clients must be aware of the differences between strategies to be able to select the right one.
- **Communication overhead**: The strategy interface might be complex, even if some strategies don't use all the information provided to them.

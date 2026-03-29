# Prototype Pattern

## Problem
You have an object, and you want to create an exact copy of it. How would you do it? First, you must create a new object of the same class. Then you have to go through all the fields of the original object and copy their values over to the new object. Nice! But there’s a catch. Not all objects can be copied that way because some of the object’s fields may be private and not visible from outside of the object itself.

## Structure
- **Prototype Interface**: Declares the cloning methods. In most cases, it’s a single `clone` method.
- **Concrete Prototype**: Implements the cloning method. In addition to copying the original object’s data to the clone, this method may also handle some edge cases of the cloning process related to cloning linked objects, untangling recursive dependencies, etc.
- **Client**: Creates a copy of an object by calling its `clone` method.

## When to use
- When your code shouldn’t depend on the concrete classes of objects that you need to copy.
- When you want to reduce the number of subclasses that only differ in the way they initialize their respective objects.
- When you have a set of pre-built objects that are ready to be copied.

## Real-world examples
- **Game Development**: Creating many identical NPCs or obstacles in a game level.
- **GUI Frameworks**: Copy-pasting elements like buttons or text fields.
- **Document Templates**: Starting a new document from a pre-defined template.

## Pros
- **Cloning without coupling**: You can clone objects without coupling to their specific classes.
- **Reduced initialization**: You can get rid of repeated initialization code in favor of cloning a pre-configured prototype.
- **Complex object creation**: You can produce complex objects more conveniently.

## Cons
- **Circular references**: Cloning complex objects that have circular references might be very tricky.
- **Interface overhead**: You must implement the clone method in all classes of the hierarchy.

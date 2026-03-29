# .NET 8 Design Patterns Playground

A comprehensive, real-world-oriented repository for learning and exploring the classic Gang of Four (GoF) design patterns implemented in .NET 8 and C#.

## Project Objectives
- Understand the core concepts of various design patterns.
- Explore C# 12 specific implementations of these patterns in a .NET 8 context.
- Bridge the gap between theory and practice with realistic examples.
- Apply SOLID principles in the context of pattern implementations.

## Implemented Patterns

### Creational Patterns
| Pattern | Real-World Example | Description |
| --- | --- | --- |
| [Singleton](./src/Creational/SingletonDemo) | Configuration Manager | Ensures only one instance exists. |
| [Factory Method](./src/Creational/FactoryDemo) | Notification Service | Defer object creation to subclasses. |
| [Builder](./src/Creational/BuilderDemo) | Report Builder | Step-by-step construction of complex objects. |
| [Prototype](./src/Creational/PrototypeDemo) | Document Cloning | Copying existing objects efficiently. |

### Structural Patterns
| Pattern | Real-World Example | Description |
| --- | --- | --- |
| [Adapter](./src/Structural/AdapterDemo) | Payment Gateway | Bridge incompatible interfaces. |
| [Decorator](./src/Structural/DecoratorDemo) | Logging + Caching | Dynamically add new behaviors to objects. |
| [Facade](./src/Structural/FacadeDemo) | Order Processing | Simple interface to complex systems. |
| [Proxy](./src/Structural/ProxyDemo) | API Client with Auth | Control access to an object. |

### Behavioral Patterns
| Pattern | Real-World Example | Description |
| --- | --- | --- |
| [Strategy](./src/Behavioral/StrategyDemo) | Payment Processing | Interchangeable algorithms. |
| [Observer](./src/Behavioral/ObserverDemo) | Stock Market | Notification of state changes. |
| [Command](./src/Behavioral/CommandDemo) | Order Commands | Encapsulate requests as objects. |
| [State](./src/Behavioral/StateDemo) | Order Lifecycle | Change behavior based on internal state. |

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- VS Code, Visual Studio 2022, or JetBrains Rider

### Running the Demos
Each pattern is a separate console application. You can run any of them from the root using the following command:

```bash
# Example: Run Singleton Demo
dotnet run --project src/Creational/SingletonDemo/SingletonDemo.csproj

# Example: Run Strategy Demo
dotnet run --project src/Behavioral/StrategyDemo/StrategyDemo.csproj
```

Alternatively, you can navigate to the specific project folder and run:
```bash
cd src/Creational/SingletonDemo
dotnet run
```

## Documentation
Detailed explanations for each pattern, including diagrams and use cases, can be found in the [docs/pattern-explanations](./docs/pattern-explanations/) folder.

---
Created for learning and demonstration purposes.

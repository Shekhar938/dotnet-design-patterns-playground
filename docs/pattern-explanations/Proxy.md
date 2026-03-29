# Proxy Pattern

## Problem
Why would you want to control access to an object? Here is an example: you have a massive object that consumes a vast amount of system resources. You need it from time to time, but not always. You could implement lazy initialization: create this object only when it’s actually needed. All of the object’s clients would need to execute some deferred initialization code. Unfortunately, this would probably cause a lot of code duplication.

## Structure
- **Service Interface**: Declares the interface of the Service. The proxy must follow this interface to be able to disguise itself as a service object.
- **Service**: A class that provides some useful business logic.
- **Proxy**: Has a reference field that points to a service object. After the proxy finishes its processing (e.g., lazy initialization, logging, access control, caching, etc.), it passes the request to the service object.
- **Client**: Should work with both services and proxies via the same interface.

## When to use
- **Lazy initialization (virtual proxy)**: When you have a heavyweight service object that wastes system resources by being always up, even though you only need it from time to time.
- **Access control (protection proxy)**: When you want only specific clients to be able to use the service object.
- **Local execution of a remote service (remote proxy)**: When the service object is located on a remote server.
- **Logging requests (logging proxy)**: When you want to keep a history of requests to the service object.
- **Caching request results (caching proxy)**: When you need to cache results of client requests and manage the life cycle of this cache.

## Real-world examples
- **Database Driver**: Proxies that manage database connections and transactions.
- **Credit Card**: A proxy for a bank account, providing security and convenience.
- **Virtual Proxies in Hibernate**: Loading data from a database only when it's accessed.

## Pros
- **Lifecycle management**: You can manage the lifecycle of the service object without clients knowing about it.
- **Robustness**: The proxy works even if the service object isn’t ready or is not available.
- **Open/Closed Principle**: You can introduce new proxies without changing the service or clients.

## Cons
- **Latency**: The response from the service might be delayed.
- **Complexity**: The code might become more complicated since you need to introduce a lot of new classes.

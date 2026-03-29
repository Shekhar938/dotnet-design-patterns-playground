using System;
using System.Collections.Generic;

namespace DecoratorDemo
{
    // The Decorator Pattern allows you to attach new behaviors to objects 
    // by placing these objects inside special wrapper objects 
    // that contain the behaviors.

    // The base Component interface defines operations that can be 
    // altered by decorators.
    public interface IDataRepository
    {
        string GetData(int id);
    }

    // Concrete Components provide default implementations of the operations.
    public class SqlDataRepository : IDataRepository
    {
        public string GetData(int id)
        {
            Console.WriteLine($"[SQL Repository] Fetching data for ID: {id} from Database...");
            // Simulate database latency
            System.Threading.Thread.Sleep(500);
            return $"Data Object {id}";
        }
    }

    // The base Decorator class follows the same interface as the other components. 
    // The primary purpose of this class is to define the wrapping 
    // interface for all concrete decorators. 
    public abstract class RepositoryDecorator : IDataRepository
    {
        protected readonly IDataRepository _repository;

        public RepositoryDecorator(IDataRepository repository)
        {
            _repository = repository;
        }

        public virtual string GetData(int id)
        {
            return _repository.GetData(id);
        }
    }

    // Concrete Decorators call the wrapped object and alter its 
    // result in some way.
    public class LoggingDecorator : RepositoryDecorator
    {
        public LoggingDecorator(IDataRepository repository) : base(repository) { }

        public override string GetData(int id)
        {
            Console.WriteLine($"[Log] LOG: Getting data for ID {id} at {DateTime.Now}");
            var result = base.GetData(id);
            Console.WriteLine($"[Log] LOG: Successfully retrieved data for ID {id}");
            return result;
        }
    }

    public class CachingDecorator : RepositoryDecorator
    {
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

        public CachingDecorator(IDataRepository repository) : base(repository) { }

        public override string GetData(int id)
        {
            if (_cache.ContainsKey(id))
            {
                Console.WriteLine($"[Cache] CACHE HIT: Returning cached data for ID {id}");
                return _cache[id];
            }

            Console.WriteLine($"[Cache] CACHE MISS: Fetching data for ID {id}");
            var result = base.GetData(id);
            _cache[id] = result;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Decorator Pattern: Logging + Caching ---");

            // 1. Simple repository
            Console.WriteLine("\nScenario 1: Plain Repository");
            IDataRepository repo = new SqlDataRepository();
            Console.WriteLine(repo.GetData(1));

            // 2. Repository with Logging
            Console.WriteLine("\nScenario 2: Repository with Logging");
            IDataRepository loggedRepo = new LoggingDecorator(repo);
            Console.WriteLine(loggedRepo.GetData(2));

            // 3. Repository with Logging and Caching
            Console.WriteLine("\nScenario 3: Repository with Logging and Caching");
            // Order matters! Logging -> Caching -> SQL
            IDataRepository cachedAndLoggedRepo = new LoggingDecorator(new CachingDecorator(new SqlDataRepository()));

            Console.WriteLine("\nFirst Request (Miss):");
            Console.WriteLine(cachedAndLoggedRepo.GetData(3));

            Console.WriteLine("\nSecond Request (Hit):");
            Console.WriteLine(cachedAndLoggedRepo.GetData(3));
        }
    }
}

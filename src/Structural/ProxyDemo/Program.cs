using System;
using System.Collections.Generic;

namespace ProxyDemo
{
    // The Proxy Pattern provides a surrogate or placeholder for 
    // another object to control access to it.

    // The Service Interface defines common operations for both 
    // the RealService and the Proxy.
    public interface IApiClient
    {
        string GetData(string endpoint);
    }

    // The RealService contains the core business logic.
    public class RealApiClient : IApiClient
    {
        public string GetData(string endpoint)
        {
            Console.WriteLine($"[Real Service] Fetching data from {endpoint}...");
            return $"Response data from {endpoint}";
        }
    }

    // The Proxy implements the same interface as the RealService.
    // It can perform tasks like access control, logging, caching, etc., 
    // and then delegate the work to the real object.
    public class SecureApiProxy : IApiClient
    {
        private readonly RealApiClient _realApiClient;
        private readonly string _authToken;
        private static readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public SecureApiProxy(string authToken)
        {
            _realApiClient = new RealApiClient();
            _authToken = authToken;
        }

        public string GetData(string endpoint)
        {
            // 1. Check access control (Authentication)
            if (!Authenticate())
            {
                return "Unauthorized: Invalid or missing authentication token.";
            }

            // 2. Logging
            Console.WriteLine($"[Proxy] Log: Accessing {endpoint} at {DateTime.Now}");

            // 3. Caching
            if (_cache.ContainsKey(endpoint))
            {
                Console.WriteLine($"[Proxy] Returning cached data for {endpoint}");
                return _cache[endpoint];
            }

            // 4. Delegate request to the RealService
            string result = _realApiClient.GetData(endpoint);

            // Store result in cache
            _cache[endpoint] = result;

            return result;
        }

        private bool Authenticate()
        {
            Console.WriteLine("[Proxy] Authenticating request...");
            return _authToken == "SECRET_TOKEN_123";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Proxy Pattern: API Client with Auth ---");

            // Scenario 1: Access without proper authentication
            Console.WriteLine("\nClient: Accessing with invalid token...");
            IApiClient insecureProxy = new SecureApiProxy("WRONG_TOKEN");
            Console.WriteLine(insecureProxy.GetData("/api/users"));

            // Scenario 2: Access with correct token
            Console.WriteLine("\nClient: Accessing with valid token...");
            IApiClient secureProxy = new SecureApiProxy("SECRET_TOKEN_123");
            
            Console.WriteLine("First Request:");
            Console.WriteLine(secureProxy.GetData("/api/products"));

            // Scenario 3: Cached access
            Console.WriteLine("\nSecond Request (expecting cache):");
            Console.WriteLine(secureProxy.GetData("/api/products"));

            Console.WriteLine("\nSuccess: Proxy controlled access and added extra functionality.");
        }
    }
}

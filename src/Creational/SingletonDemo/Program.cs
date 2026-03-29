using System;

namespace SingletonDemo
{
    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.

    // Real-world Example: Configuration Manager
    // A Configuration Manager should be globally accessible and only one instance 
    // should exist to ensure consistency across the application.
    public sealed class ConfigurationManager
    {
        // The Singleton's instance is stored in a static field. There are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest way of
        // thread-safe lazy initialization.
        private static readonly Lazy<ConfigurationManager> _instance =
            new Lazy<ConfigurationManager>(() => new ConfigurationManager());

        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private ConfigurationManager()
        {
            Console.WriteLine("Initializing Configuration Manager...");
            // Simulate loading settings
            Settings = new System.Collections.Generic.Dictionary<string, string>
            {
                { "AppName", "DesignPatternsPlayground" },
                { "Version", "1.0.0" },
                { "Environment", "Development" }
            };
        }

        public static ConfigurationManager Instance => _instance.Value;

        public System.Collections.Generic.Dictionary<string, string> Settings { get; private set; }

        public string GetSetting(string key)
        {
            return Settings.ContainsKey(key) ? Settings[key] : "Not Found";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Singleton Pattern: Configuration Manager ---");

            // Accessing the singleton instance for the first time
            var config1 = ConfigurationManager.Instance;
            Console.WriteLine($"App Name: {config1.GetSetting("AppName")}");

            // Accessing the singleton instance again
            var config2 = ConfigurationManager.Instance;
            Console.WriteLine($"Environment: {config2.GetSetting("Environment")}");

            // Verify both instances are the same
            if (ReferenceEquals(config1, config2))
            {
                Console.WriteLine("Success: Both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Error: Instances are different.");
            }
        }
    }
}

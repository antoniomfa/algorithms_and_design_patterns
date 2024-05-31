using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_designpatterns
{
    /* The Singleton is a creational design pattern that allows us to create a single instance of an object and to share that instance with all 
      the users that require it. 
      For example, some components have no reason to be instanced more than once in a project. Take a logger for example. It is quite common 
      to register logger class as a singleton component because all we have to do is to provide a string to be logged and the logger is going 
      to write it to the file. Then multiple classes may require to write in the same file at the same time from different threads, so having 
      one centralized place for that purpose is always a good solution. */
    public class Singleton
    {
        //static void Main(string[] args)
        //{
        //    // We can see that we are calling our instance four times but it is initialized only once, which is exactly what we want.
        //    var db = SingletonDataContainer.Instance;
        //    var db2 = SingletonDataContainer.Instance;
        //    var db3 = SingletonDataContainer.Instance;
        //    var db4 = SingletonDataContainer.Instance;
        //}

        public interface ISingletonContainer
        {
            int GetPopulation(string name);
        }

        public class SingletonDataContainer : ISingletonContainer
        {
            private Dictionary<string, int> Capitals = new();

            private SingletonDataContainer()
            {
                Console.WriteLine("Initializing singleton object");

                var elements = File.ReadAllLines("capitals.txt");

                for (int i = 0; i < elements.Length; i += 2)
                {
                    Capitals.Add(elements[i], int.Parse(elements[i + 1]));
                }
            }

            public int GetPopulation(string name)
            {
                return Capitals[name];
            }

            private static SingletonDataContainer instance = new();

            public static SingletonDataContainer Instance => instance;
        }
    }
}

using static dotnet_designpatterns.Factory;

namespace dotnet_designpatterns
{
    /* The Factory Method design pattern defines an interface for creating an object, but let subclasses decide which class to instantiate. 
     * This pattern lets a class defer instantiation to subclasses.  */
    public class Factory
    {
        //static void Main(string[] args)
        //{
        //    // An array of creators
        //    Creator[] creators = new Creator[2];

        //    creators[0] = new ConcreteCreatorA();
        //    creators[1] = new ConcreteCreatorB();

        //    // Iterate over creators and create products
        //    foreach (Creator creator in creators)
        //    {
        //        Product product = creator.FactoryMethod();

        //        Console.WriteLine("Created {0}", product.GetType().Name);
        //    }

        //    // Wait for user
        //    Console.ReadKey();
        //}

        /// <summary>
        /// The 'Product' abstract class
        /// </summary>
        abstract class Product
        {
        }

        /// <summary>
        /// A 'ConcreteProduct' class
        /// </summary>
        class ConcreteProductA : Product
        {
        }

        /// <summary>
        /// A 'ConcreteProduct' class
        /// </summary>
        class ConcreteProductB : Product
        {
        }

        /// <summary>
        /// The 'Creator' abstract class
        /// </summary>
        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }

        /// <summary>
        /// A 'ConcreteCreator' class
        /// </summary>
        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }
        /// <summary>
        /// A 'ConcreteCreator' class
        /// </summary>
        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }
    }
}

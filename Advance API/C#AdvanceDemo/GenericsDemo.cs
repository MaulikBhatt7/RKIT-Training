namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Generic class to demonstrate the use of generics with a property of type T.
    /// </summary>
    public class GenericClassDemo<T>
    {
        /// <summary>
        /// A generic property to hold a value of type T.
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Executes the functionality of the GenericClassDemo with different data types.
    /// </summary>
    public class ExecuteGenericClassDemo
    {
        /// <summary>
        /// Demonstrates the use of GenericClassDemo with integer and string data types.
        /// </summary>
        public void PrintGenericClass()
        {
            // Generic class instance for integer
            GenericClassDemo<int> objGenericClassDemo1 = new GenericClassDemo<int>();
            objGenericClassDemo1.Value = 3;
            Console.WriteLine("Integer - " + objGenericClassDemo1.Value);

            // Generic class instance for string
            GenericClassDemo<string> objGenericClassDemo2 = new GenericClassDemo<string>();
            objGenericClassDemo2.Value = "MyName";
            Console.WriteLine("String - " + objGenericClassDemo2.Value);
        }
    }

    /// <summary>
    /// Demonstrates generic methods in C#.
    /// </summary>
    public class GenericMethodDemo
    {
        /// <summary>
        /// A generic method that adds two values of type T using dynamic typing.
        /// </summary>
        /// <typeparam name="T">The type of the parameters.</typeparam>
        /// <param name="a">First value to add.</param>
        /// <param name="b">Second value to add.</param>
        /// <returns>The sum of the two values.</returns>
        public T Add<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }
    }

    /// <summary>
    /// Executes the functionality of GenericMethodDemo.
    /// </summary>
    public class ExecuteGenericMethodDemo
    {
        /// <summary>
        /// Demonstrates the use of a generic method for addition with integers and doubles.
        /// </summary>
        public void PrintGenericMethodDemo()
        {
            GenericMethodDemo objGenericMethodDemo = new GenericMethodDemo();
            Console.WriteLine("Integer Addition - " + objGenericMethodDemo.Add<int>(5, 10));
            Console.WriteLine("Double Addition - " + objGenericMethodDemo.Add<double>(5.5, 10.0));
        }
    }

    /// <summary>
    /// A generic interface with methods for setting and getting a name.
    /// </summary>
    /// <typeparam name="T">The type of the name.</typeparam>
    public interface GenericInterface<T>
    {
        void SetName<T>(T name) where T : class;
        T GetName<T>();
    }

    /// <summary>
    /// Implements the GenericInterface with string as the type.
    /// </summary>
    public class InheritGenericInterface : GenericInterface<string>
    {
        dynamic myName;

        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <typeparam name="T">The type of the name, constrained to reference types.</typeparam>
        /// <param name="name">The name to set.</param>
        public void SetName<T>(T name) where T : class
        {
            myName = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <typeparam name="T">The type of the name to retrieve.</typeparam>
        /// <returns>The name.</returns>
        public T GetName<T>()
        {
            return myName;
        }
    }

    /// <summary>
    /// Executes the functionality of InheritGenericInterface.
    /// </summary>
    public class ExecuteGenericInterface
    {
        /// <summary>
        /// Demonstrates the use of GenericInterface by setting and getting a name.
        /// </summary>
        public void PrintGenericInterface()
        {
            InheritGenericInterface objInheritGenericInterface = new InheritGenericInterface();
            objInheritGenericInterface.SetName("MyName");
            Console.WriteLine(objInheritGenericInterface.GetName<string>());
        }
    }

    /// <summary>
    /// Base class representing an animal.
    /// </summary>
    public class Animal { }

    /// <summary>
    /// Derived class representing a dog.
    /// </summary>
    public class Dog : Animal { }

    /// <summary>
    /// Derived class representing a cat.
    /// </summary>
    public class Cat : Animal { }

    /// <summary>
    /// A covariant interface demonstrating covariance with generics.
    /// </summary>
    /// <typeparam name="T">The type of object to get.</typeparam>
    public interface ICovariant<out T>
    {
        T Get();
    }

    /// <summary>
    /// Provides animals through a covariant interface.
    /// </summary>
    public class AnimalProvider : ICovariant<Animal>
    {
        public Animal Get() => new Animal();
    }

    /// <summary>
    /// Provides dogs through a covariant interface.
    /// </summary>
    public class DogProvider : ICovariant<Dog>
    {
        public Dog Get() => new Dog();
    }

    /// <summary>
    /// A contravariant interface demonstrating contravariance with generics.
    /// </summary>
    /// <typeparam name="T">The type of object to set.</typeparam>
    public interface IContravariant<in T>
    {
        void Set(T value);
    }

    /// <summary>
    /// Processes animals through a contravariant interface.
    /// </summary>
    public class AnimalProcessor : IContravariant<Animal>
    {
        public void Set(Animal value) => Console.WriteLine(value.GetType().Name);
    }

    /// <summary>
    /// Executes the functionality of covariance and contravariance.
    /// </summary>
    public class ExecuteVariance
    {
        public void PrintVariance()
        {
            // Demonstrates covariance
            ICovariant<Animal> animalProvider = new DogProvider();
            Animal animal = animalProvider.Get();
            Console.WriteLine(animal.GetType().Name); // Output: Dog

            // Demonstrates contravariance
            IContravariant<Dog> dogProcessor = new AnimalProcessor();
            dogProcessor.Set(new Dog());
        }
    }

    /// <summary>
    /// Demonstrates various generic concepts including generic classes, methods, interfaces, and variance.
    /// </summary>
    public class GenericsDemo
    {
        public void PrintInfo()
        {
            ExecuteGenericClassDemo objExecuteGenericClassDemo = new ExecuteGenericClassDemo();
            objExecuteGenericClassDemo.PrintGenericClass();

            ExecuteGenericMethodDemo objExecuteGenericMethodDemo = new ExecuteGenericMethodDemo();
            objExecuteGenericMethodDemo.PrintGenericMethodDemo();

            ExecuteGenericInterface objExecuteGenericInterface = new ExecuteGenericInterface();
            objExecuteGenericInterface.PrintGenericInterface();

            ExecuteVariance objExecuteVariance = new ExecuteVariance();
            objExecuteVariance.PrintVariance();
        }
    }
}

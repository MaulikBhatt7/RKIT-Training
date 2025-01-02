namespace ClassTypeDemoSpace
{
    /// <summary>
    /// Regular class example.
    /// </summary>
    public class RegularClass
    {
        string name = "Hello";

        public void PrintName()
        {
            Console.WriteLine(name);
        }
    }

    /// <summary>
    /// Abstract class with one abstract method PrintVehicleName().
    /// </summary>

    public abstract class Vehicle
    {

        /// <summary>
        /// Abstract method demo.
        /// </summary>
        public abstract void PrintVehicleName();

    }

    /// <summary>
    /// Inherited Vehicle class and implemented PrintVehicleAbstract() method.
    /// </summary>
    public class Car : Vehicle
    {
        /// <summary>
        /// override abstract method of base class.
        /// </summary>
        public override void PrintVehicleName()
        {
            Console.WriteLine("This is Car.");
        }
    }


    /// <summary>
    /// Static class MathUtils.
    /// </summary>
    public static class MathUtils
    {

        // static field of static class
        static string name = "This is static class";

        /// <summary>
        /// Static Addtion method for addition of two variables a and b.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Sum of two numbers.</returns>
        public static int Addition(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Static Substraction method for substraction of two numbers a and b.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Substraction of two numbers.</returns>
        public static int Substraction(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Static Multiplication method for substraction of two numbers a and b.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Multiplication of two numbers.</returns>
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }


        /// <summary>
        /// Static Divison method for substraction of two numbers a and b.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Division of two numbers.</returns>
        public static int Division(int a, int b)
        {
            return a / b;
        }
    }

    /// <summary>
    /// Sealed class example.
    /// </summary>
    public sealed class SealedClass
    {

        /// <summary>
        /// Print message related to sealed class.
        /// </summary>
        public void PrintMessage()
        {
            Console.WriteLine("The class cannot be inherited");
        }
    }

    ///// <summary>
    ///// Try to inherite sealed class
    ///// </summary>
    //public class TempClass : SealedClass
    //{

    //}

    /// <summary>
    /// Partial class Person demo with 1st field Name 
    /// </summary>
    public partial class Person
    {

        public string Name { get; set; } = "MyName";
    }

    /// <summary>
    /// Partial class Person demo with 2nd field Age 
    /// </summary>
    public partial class Person
    {
        static int Age { get; set; }
    }

    /// <summary>
    /// Test all classes demo.
    /// </summary>
    public class ClassTypeDemo
    {
        /// <summary>
        /// Print Information of all classes.
        /// </summary>
        public void PrintInfo()
        {

            // Test regular class.
            RegularClass objRegularClass = new RegularClass();
            Console.Write("Regular class - ");
            objRegularClass.PrintName();

            // Test static class.
            Console.WriteLine("Static class Demo - Addtion of 5 and 10 : "+MathUtils.Addition(5, 10));

            // Test abstract class.
            Car objCar = new Car();
            Console.Write("Abstract class - ");
            objCar.PrintVehicleName();

            // Test sealed class.
            SealedClass objSealedClass = new SealedClass();
            Console.Write("Sealed class - ");
            objSealedClass.PrintMessage();


            // Test Partial class
            Person objPerson = new Person();
            Console.Write("Partial class - ");
            Console.WriteLine("Name : "+objPerson.Name);
        }
    }

}

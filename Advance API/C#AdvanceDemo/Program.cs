using ClassTypeDemoSpace;

namespace CSharpAdvanceDemo
{
    // Main Program class to demonstrate employee management
    public class Program
    {
        // Entry point of the program
        public static void Main(string[] args)
        {
            int choice = 1;
            switch(choice)
            {
                case 1:
                    ClassTypeDemo objClassTypeDemo = new ClassTypeDemo();
                    objClassTypeDemo.PrintInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
           
        }
    }
}

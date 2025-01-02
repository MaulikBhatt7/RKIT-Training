
namespace CSharpAdvanceDemo
{
    // Main Program class to demonstrate employee management
    public class Program
    {
        // Entry point of the program
        public static void Main(string[] args)
        {
            int choice = 3;
            switch(choice)
            {
                case 1:
                    ClassTypeDemo objClassTypeDemo = new ClassTypeDemo();
                    objClassTypeDemo.PrintInfo();
                    break;

                case 2:
                    GenericsDemo objGenericsDemo = new GenericsDemo();
                    objGenericsDemo.PrintInfo();
                    break;

                case 3:
                    DynamicTypeDemo objDynamicTypeDemo = new DynamicTypeDemo(); 
                    objDynamicTypeDemo.PrintInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
           
        }
    }
}

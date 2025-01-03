namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Main Program class to demonstrate employee management.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args">String array parameter from Command Line Interface.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your choice : ");
            Console.WriteLine("1 - Class Types Demo");
            Console.WriteLine("2 - Genrics Demo");
            Console.WriteLine("3 - Dynamic Types Demo");
            Console.WriteLine("4 - File System Demo");
            Console.WriteLine("5 - Data Serialization Demo");
            Console.WriteLine("6 - Lambda Expression Demo");
            Console.WriteLine("7 - Extension Methods Demo");

            // Get User's choice
            int choice = Convert.ToInt32(Console.ReadLine());

            // Switch case to execute the corresponding demo based on the choice.
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
                case 4:
                    FileSystemDemo objFileSystemDemo = new FileSystemDemo();
                    objFileSystemDemo.PrintInfo();
                    break;

                case 5:
                    DataSerializationUsingJSON objDataSerializationUsingJSON = new DataSerializationUsingJSON();
                    objDataSerializationUsingJSON.PrintInfo();
                    break;

                case 6:
                    LambdaExpressionDemo objLamdaExpressionDemo = new LambdaExpressionDemo();
                    objLamdaExpressionDemo.PrintInfo();
                    break;
                case 7:
                    ExtensionMethodDemo objExtensionMethodDemo =  new ExtensionMethodDemo();
                    objExtensionMethodDemo.PrintInfo();
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
           
        }
    }
}

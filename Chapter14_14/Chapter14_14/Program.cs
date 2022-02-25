using System;

namespace Chapter14_14
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Args arg = new Args("l,p#,d*", args);
                bool logging = arg.getBoolean('l');
                int port = arg.getInt('p');
                string directory = arg.getString('d');
                executeApplication(logging, port, directory);
            }
            catch (ArgsException e)
            {
                Console.WriteLine("Argument error: %s\n", e.Message);
            }
        }

        private static void executeApplication(bool logging, int port, string directory)
        {
            Console.WriteLine("Executed application with:");
            Console.WriteLine($"bool logging param = {logging}");
            Console.WriteLine($"int port param = {port}");
            Console.WriteLine($"string directory param = {directory}");
            Console.ReadKey();
        }
    }
}

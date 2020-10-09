using System;

namespace SimplePasswordGenerator.Example
{
    public class Program
    {
        static void Main(string[] args)
        {
            // you'll need the actual generator
            var generator = new Generator();

            var helpText = $"Press any key to generate a new password (ESC to exit).";
            Console.WriteLine(helpText + "\n");

            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                try
                {
                    Console.Clear();

                    // let's generate a password
                    // - it will remove all '@' chars since we provided it in the filter (which is optional)
                    var myPassword = generator.Generate(passwordLength: 32, 
                                                         Casing.Mixed,
                                                         useSpecials: true,
                                                         useNumerics: true,
                                                         filter: "@");

                    Console.WriteLine("The password is:\n");
                    Console.WriteLine("--- BEGINNING OF PASSWORD ---");
                    Console.WriteLine(myPassword);
                    Console.WriteLine("--- END OF PASSWORD ---");
                }
                catch (GeneratorException e)
                {
                    PrintExceptionMessage(e);
                }
                finally
                {
                    Console.WriteLine("\n" + helpText);
                }
            }
        }

        private static void PrintExceptionMessage(GeneratorException e)
        {
            Console.WriteLine($"{e.GetType().Name}: {e.Message}");
        }
    }
}

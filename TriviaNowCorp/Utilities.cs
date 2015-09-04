using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    class Utilities
    {
        //try catch block to make sure user inputs an integer and not a string
        public static int validateInt(string userInput)
        {
            int numberOfErrors = 0;
            int number = 0;
            bool promptUserAgain = false;
            do
            {
                Console.Write(userInput);
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    promptUserAgain = false;
                }
                catch (FormatException)
                {
                    numberOfErrors++;
                    if (numberOfErrors > 2)
                    {
                        Console.WriteLine("You are having some issues. The application will shut down. Try again next time. ");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Input must be numeric. Try Again.");
                        promptUserAgain = true;
                    }
                }
            } while (promptUserAgain == true);
            return number;
        }
        //end of validateInt

        //Overloaded header constructors to handle multiple scenarios of title formatting in main app
        public static string header(string title)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** TriviaNow by Vincent Nguyen***\n\t\t\t\t -{0}-", title);
            return title;
        }
        public static void header()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** TriviaNow by Vincent Nguyen ***\n\n");
        }
        public static void header(int questionSelect)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t*** TriviaNow by Vincent Nguyen***\n\t\t\t\t --Question {0}--", questionSelect);
            return;
            throw new NotImplementedException();
        }
        //end of header

        //simplifies process at the end of menu option selections for main app methods
        public static void PressAnyKey()
        {
            Console.WriteLine("Press any key to head back to the menu...");
            Console.ReadKey();
        }
        //end of PressAnyKey
    }
}

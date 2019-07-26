using System;

namespace Serialize
{
    class Verify
    {
        //Returns only array 'str' element 
        public static string CorrectSwitch(string[] str, string title) // title - Condition for input data
        {
            string Key;
            bool correct;
            do
            {
                correct = true;
                Console.WriteLine(title);
                Key = Console.ReadLine();
                foreach (string s in str)
                {
                    if (Key == s)
                    {
                        correct = false;
                        break;
                    }
                }

            } while (correct);

            return Key;
        }

        //Returns only char (For check if we want to quit or continue to use);
        public static char Repeated(string title) // title - Condition for input data
        {
            char repeat = ' ';
            bool incorrect;
            do
                {
                   try
                   {
                       incorrect = false;
                       Console.WriteLine(title);
                       repeat = Convert.ToChar(Console.ReadLine());
                   }
                   catch (FormatException)
                   {
                       Console.WriteLine("You enter incorrect date.");
                       incorrect = true;
                   }

            } while (incorrect);

            return repeat;
        }
        
    }
}

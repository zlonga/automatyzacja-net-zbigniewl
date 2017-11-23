using System;

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "";

            Console.WriteLine("Witaj świecie!");
            while (x != "exit")
            { Console.WriteLine("Jeśli chcesz zakończyć wpisz 'exit' i naciśnij ENTER");
                x = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

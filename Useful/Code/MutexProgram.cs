using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication11
{
    class Program
    {
        // TODO: Get this from the assembly info
        const string appGuid = "05fd220c-f330-4a52-8ad5-9b62d3093d23";

        static bool firstInstance;
        static Mutex mutex;

        static void Main(string[] args)
        {
            using (mutex = new Mutex(true, @"Global\" + appGuid, out firstInstance))
            {
                Go();
            }
        }

        private static void Go()
        {
            if (!firstInstance)
            {
                Console.WriteLine ("Other instance detected; aborting.");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine ("We're the only instance running - yay!");
            for (int i=0; i < 100; i++)
            {
                Console.WriteLine (i);
                Thread.Sleep(1000);
            }
        }
    }
}

 

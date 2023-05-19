using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6FinalLab.UI
{
    public class MenuUI
    {
        public static void logo()
        {
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("                                   UMAS                                  ");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static string menu()
        {
            Console.WriteLine("1-Add Student");
            Console.WriteLine("2-Add Degree Program");
            Console.WriteLine("3-Generate Merit");
            Console.WriteLine("4-View Registered Students");
            Console.WriteLine("5-View Students of a Specific Program");
            Console.WriteLine("6-Register Subjects For a Specific Student ");
            Console.WriteLine("7-Calculate Fee For All Registerd Students");
            Console.WriteLine("8-Exit");
            string option;
            Console.Write("Enter Your Option ");
            return option = Console.ReadLine();
        }
        public static void GoBack()
        {
            Console.WriteLine("Press Any key to go back on menu ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

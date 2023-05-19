using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.BL;
using Week6FinalLab.DL;

namespace Week6FinalLab.UI
{
    public class StudentUI
    {
        public static Student InputStudent()
        {
            Console.Write("Enter the Name of Student: ");
            string name = Console.ReadLine();
            Console.Write("Enter the Age of Student: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter the Fsc Marks of Student: ");
            int fscmarks = int.Parse(Console.ReadLine());
            Console.Write("Enter the Ecat Marks of Student: ");
            int Ecatmarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Program ");
            foreach (Degree degrees_available in DegreeCrud.degrees)
            {
                Console.WriteLine(degrees_available.degree_title);
            }
            
            Student student = new Student(name, age, fscmarks, Ecatmarks);
            return student;
        }
        public static List<string> TakePreferances()
        {
            List<string> preferances = new List<string>();
            Console.Write("Enter How Many Prefrences You Want To Add ");
            int no_of_preferances = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Priority List Here ");
            for (int i = 0; i < no_of_preferances; i++)
            {
                preferances.Add(Console.ReadLine());
            }
            return preferances;
        }
        public static void Header()
        {
            Console.WriteLine("Name                     FSC                    Ecat                      Age");
        }
        public static void Demand()
        {
            Console.Write("Enter Name of Degree: ");
        }
        public static void Demand1()
        {
            Console.Write("Enter Name of Student: ");
        }
        public static void Message()
        {
            Console.WriteLine("That Subject Has Already being Registered by you");
        }
        public static void Danger()
        {
            Console.WriteLine("That Student Does Not Exsist in Our Record ");
        }
        public static void NoRegisteredSubjects(string name)
        {
            Console.WriteLine(name + "  has not rigestered in any subject");
        }
        public static void ShowFee(int fee, string name)
        {
            Console.WriteLine(name + "  has a fee " + fee);
        }
    }
}

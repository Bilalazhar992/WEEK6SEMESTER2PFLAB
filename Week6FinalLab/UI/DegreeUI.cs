using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.BL;
using Week6FinalLab.DL;



namespace Week6FinalLab.UI
{
    public class DegreeUI
    {
        public static Degree InputDetailsOfDegree()
        {
            List<Subject> subjects = new List<Subject>();
            Console.Write("Enter Degree Name ");
            string degree_name = Console.ReadLine();
            Console.Write("Enter Degree Duration in Year(in numeric figure)");
            int degree_duration = int.Parse(Console.ReadLine());
            Console.Write("Enter Degree Seats ");
            int degree_seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number Of Subjects ");
            int no_of_subjects = int.Parse(Console.ReadLine());
            for(int i=0;i<no_of_subjects;i++)
            {
                Console.WriteLine("Enter Details of Subject No: " + (i + 1));
                Console.Write("Enter Subject Code ");
                int Subject_Code = int.Parse(Console.ReadLine());
                Console.Write("Enter Subject Name ");
                string Subject_Name = Console.ReadLine();
                Console.Write("Enter Subject Credits ");
                int Subject_Credit = int.Parse(Console.ReadLine());
                Console.Write("Enter Subject Fees ");
                int Subject_Fee = int.Parse(Console.ReadLine());
                Subject subject = new Subject(Subject_Code, Subject_Name, Subject_Credit, Subject_Fee);
                subjects.Add(subject);
                SubjectCrud.AddInList(subject);
            }
            Degree degree = new Degree(degree_name, degree_duration, degree_seats,subjects);
            return degree;
        }
        public static int AskaboutSubjects()
        {
            Console.WriteLine("Enter Number of subjects you want to Register ");
            int no_of_Subjects = int.Parse(Console.ReadLine());
            return no_of_Subjects;
        }
        public static int AskCode()
        {
            Console.Write("Enter code of Subject ");
            int code = int.Parse(Console.ReadLine());
            return code;
        }
    }
}

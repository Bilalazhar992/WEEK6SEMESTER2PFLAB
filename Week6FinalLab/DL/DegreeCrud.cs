using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.BL;
using System.IO;

namespace Week6FinalLab.DL
{
    public class DegreeCrud
    {
        public static List<Degree> degrees = new List<Degree>();
        public static void AddInList(Degree user)
        {
            degrees.Add(user);
        }
        public static string RegisterSubject(Student student, int code)
        {
            string Subject = "";
            foreach (Degree degree_address in degrees)
            {
                Subject = degree_address.ReturnSubject(student, code);
                if (Subject != null)
                {
                    break;
                }
            }
            return Subject;
        }
        public static void StoreInFile3(string degree_path)
        {
            StreamWriter file3 = new StreamWriter(degree_path, false);
            foreach(Degree degree in degrees)
            {
                file3.Write(degree.degree_title + "," +degree.degree_time + "," +degree.seats + ",");
                foreach (Subject subject in degree.subjects)
                {
                    file3.Write(subject.Subject_Name + ";");
                }
                file3.WriteLine();
            }
            file3.Flush();
            file3.Close();
        }
        public static void readDegreeFile(string degree_path)
        {
            StreamReader file3 = new StreamReader(degree_path);
            string record;
            if (File.Exists(degree_path))
            {
                while((record=file3.ReadLine())!=null)
                {
                    string[] credentials = record.Split(',');
                    Console.WriteLine(credentials.Length);
                    string degreeTitle = credentials[0];
                    int degree_time = int.Parse(credentials[1]);
                    int degree_seats = int.Parse(credentials[2]);
                    Degree degree = new Degree(degreeTitle, degree_time, degree_seats);
                    string[] splittedSubjects =credentials[3].Split(';');
                    for(int x=0;x<splittedSubjects.Length;x++)
                    {
                        Subject subject=SubjectCrud.ReturnSubject(splittedSubjects[x]);
                        degree.subjects.Add(subject);
                    }
                    DegreeCrud.AddInList(degree);
                }
            }
            else
            {
                Console.WriteLine("File Does not Exists ");
            }
        }
    }
}

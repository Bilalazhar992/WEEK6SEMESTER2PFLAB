using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.BL;
using System.IO;



namespace Week6FinalLab.DL
{
    public class StudentCrud
    {
        public static List<Student> students = new List<Student>();
        public static void AddInList(Student user)
        {
            students.Add(user);
        }
        public static void MeritCalculator()
        {
            foreach (Student student in students)
            {
                student.CalculateMerit();

            }

        }
        public static void Sorting()
        {
            Student student = new Student();
            for (int i = students.Count - 1; i >= 1; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (students[j].merit < students[j + 1].merit)
                    {
                        student = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = student;
                    }
                }
            }
        }
        public static void GenerateMerit()
        {
            foreach (Student student_address in students)
            {
                for (int preferences = 0; preferences <= 9; preferences++)
                {


                    if (student_address.discipline == null)
                    {
                        if (student_address.prefrences.Count > preferences)
                        {
                            student_address.AsignDisicipline(DegreeCrud.degrees, preferences);
                        }

                    }

                }
            }
        }
        public static void ShowMeritList()
        {
            foreach (Student student_address in students)
            {
                student_address.Show();

            }

        }
        public static void ShowRegisteredStudents()
        {
            foreach (Student student_address in students)
            {
                student_address.DisplayStudent();
            }
        }
        public static void ShowSpecificDegreeStudents(string Degree_Name)
        {
            foreach (Student student_address in students)
            {
                if (student_address.discipline == Degree_Name)
                {
                    student_address.DisplayStudent();
                }
            }
        }
        public static Student ReturnStudent(string name)
        {

            foreach (Student student in students)
            {
                if (student.name == name)
                {
                    return student;
                }

            }

            return null;

        }
        public static void StoreInFile1(string student_path)
        {
            StreamWriter file1 = new StreamWriter(student_path, false);
            foreach(Student student in students)
            {
                file1.Write(student.name + "," + student.age + "," +student.Fsc_marks + "," +student.Ecat_marks + "," +student.discipline + "," +student.merit + ",");
                foreach (string preferance in student.prefrences)
                {
                    file1.Write(preferance + ";");
                }
                file1.Write(",");
                foreach (string registered_subjects in student.registered_Subjects)
                {
                    file1.Write(registered_subjects + ";");
                }
                file1.WriteLine();
            }
            file1.Flush();
            file1.Close();
        }
        public static void readStudentFile(string student_path)
        {
            StreamReader file3 = new StreamReader(student_path);
            string record;
            List<string> preferances = new List<string>();
            List<string> registeredSubjects = new List<string>();
            if (File.Exists(student_path))
            {
                while((record = file3.ReadLine()) != null)
                {
                    string[] credentials = record.Split(',');
                    string name=credentials[0];
                    int age=int.Parse(credentials[1]);
                    float Fsc_marks=float.Parse(credentials[2]);
                    float Ecat_marks= float.Parse(credentials[3]);
                    string discipline= credentials[4];
                    float merit= float.Parse(credentials[5]);
                    string[] splittedprefrences = credentials[6].Split(';');
                    for(int i=0;i<splittedprefrences.Length;i++)
                    {
                        preferances.Add(splittedprefrences[i]);
                    }
                    string[] splittedregisteredSubjects = credentials[7].Split(';');
                    for (int i = 0; i < splittedregisteredSubjects.Length; i++)
                    {
                        registeredSubjects.Add(splittedregisteredSubjects[i]);
                    }
                    Student student = new Student(name, age, Fsc_marks, Ecat_marks, discipline, merit, preferances, registeredSubjects);
                    StudentCrud.AddInList(student);
                }               
            }
            else
            {
                Console.WriteLine("File Does not Exists ");
            }
        }
    }
}
    


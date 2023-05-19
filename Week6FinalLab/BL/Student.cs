using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.DL;
using System.IO;

namespace Week6FinalLab.BL
{
    public class Student
    {
        public string name;
        public int age;
        public float Fsc_marks;
        public float Ecat_marks;
        public List<string> prefrences = new List<string>();
        public string discipline;
        public float merit;
        public List<string> registered_Subjects = new List<string>();
        public Student(string name, int age, float fscmarks, float Ecatmarks)
        {
            this.name = name;
            this.age = age;
            this.Fsc_marks = fscmarks;
            this.Ecat_marks = Ecatmarks;
            
        }
        public Student()
        {

        }
        public Student(string name,int age,float Fsc_marks,float Ecat_marks,string discipline,float merit,List<string> preferances, List<string> registered_Subjects)
        {
            this.name = name;
            this.age = age;
            this.Fsc_marks = Fsc_marks;
            this.Ecat_marks = Ecat_marks;
            this.discipline = discipline;
            this.merit = merit;
            this.prefrences = preferances;
            this.registered_Subjects = registered_Subjects;
        }
        public void AddPreferances(List<string> preferances)
        {
            prefrences = preferances;
        }
        public void CalculateMerit()
        {
            merit = ((Fsc_marks * 100 / 1100) * 0.6F + (Ecat_marks * 100 / 400) * 0.4F);
        }
        public void AsignDisicipline(List<Degree> degrees, int preference_no)
        {
            foreach (Degree degree in degrees)
            {
                if (prefrences[preference_no] == degree.degree_title)
                {
                    if (merit >= 60.00)
                    {
                        if (degree.seats > 0)
                        {
                            discipline = degree.degree_title;
                            degree.SeatBook();
                           
                        }
                    }

                }
            }
        }
        public void Show()
        {
            if (discipline == null)
            {
                Console.WriteLine(name + "  did not found himself able to get  admission in UET,Lahore ");
            }
            else
            {
                Console.WriteLine(name + "  got admission in " + discipline);
            }
        }
        public void DisplayStudent()
        {
            if (discipline != "")
            {
                Console.WriteLine(name + "                          " + Fsc_marks + "                         " + Ecat_marks + "                        " + age);
            }
        }
        public  bool Check(string subject)
        {
            foreach (string registeredSubject in registered_Subjects)
            {
                if (registeredSubject == subject)
                {
                    return false;
                }
            }
            return true;
        }
        public  void AddSubject(string Subject)
        {
            registered_Subjects.Add(Subject);
        }
        public int fee()
        {
            int fees = 0;
            foreach (Degree degree in DegreeCrud.degrees)
            {
                if (discipline == degree.degree_title)
                {
                    foreach (string RegisteredSubjects in registered_Subjects)
                    {
                        foreach (Subject subject in degree.subjects)
                        {
                            if (RegisteredSubjects == subject.Subject_Name)
                            {
                                fees = fees + subject.Subject_Fee;
                            }
                        }
                    }

                }
            }
            return fees;
        }
       /* public void WriteFile(StreamWriter file1)
        {
            file1.Write(name + "," + age + "," + Fsc_marks + "," + Ecat_marks + ","+discipline+","+merit+",");
            foreach(string preferance in prefrences)
            {
                file1.Write(preferance + ";");
            }
            foreach (string registered_subjects in registered_Subjects)
            {
                file1.Write(registered_subjects + ";");
            }
            file1.WriteLine();
        }*/
    }
}

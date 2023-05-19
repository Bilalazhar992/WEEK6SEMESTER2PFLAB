using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week6FinalLab.BL
{
    public class Degree
    {
        public string degree_title;
        public int degree_time;
        public int seats;
       
        public List<Subject> subjects = new List<Subject>();
        public Degree(string degree_name, int degree_duration, int degree_seats, List<Subject> subject)
        {
            degree_title = degree_name;
            degree_time = degree_duration;
            seats = degree_seats;
            subjects = subject;
        }
        public Degree (string degree_name, int degree_duration, int degree_seats)
        {
            degree_title = degree_name;
            degree_time = degree_duration;
            seats = degree_seats;
        }
        public void SeatBook()
        {
            seats--;
        }
        public string ReturnSubject(Student student, int code)
        {
            int flag = 0;
            if (degree_title == student.discipline)
            {
                for (int i = 0; i < subjects.Count; i++)
                {
                    if (subjects[i].Subject_Code == code)
                    {
                        flag++;
                        return subjects[i].Subject_Name;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("This Course is not available in " + student.discipline);
                }
                else
                {
                    Console.WriteLine("Your Course is Registered ");
                }
            }
            return null;
        }
        /*public void Write(StreamWriter file3)
        {
            file3.Write(degree_title + "," + degree_time + "," + seats + ",");
            foreach(Subject subject in  subjects)
            {
                file3.Write(subject.Subject_Name + ";");
            }
            file3.WriteLine();
        }*/
    }
}

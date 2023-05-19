using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.BL;
using System.IO;

namespace Week6FinalLab.DL
{
    public class SubjectCrud
    {
        public static List<Subject> subjects = new List<Subject>();
        public static void  AddInList(Subject subject)
        {
            subjects.Add(subject);
        }
        public static void StoreInFile2(string subject_path)
        {
            StreamWriter file2 = new StreamWriter(subject_path, false);
            foreach (Subject subject in subjects)
            {
                file2.WriteLine(subject.Subject_Code + "," +subject.Subject_Name + "," +subject.Subject_Credit + "," +subject.Subject_Fee);
            }
            file2.Flush();
            file2.Close();
        }
        public static void readSubjectFile(string subject_path)
        {
            StreamReader file2 = new StreamReader(subject_path);
            string record;
            if(File.Exists(subject_path))
            {
                while((record=file2.ReadLine())!=null)
                {
                    string[] credentials = record.Split(',');
                    int subjectCode = int.Parse(credentials[0]);
                    string subjectName = credentials[1];
                    int subjectCredit = int.Parse(credentials[2]);
                    int subjectFee = int.Parse(credentials[3]);
                    Subject subject = new Subject(subjectCode, subjectName, subjectCredit, subjectFee);
                    SubjectCrud.AddInList(subject);

                }
                file2.Close();
            }
            else
            {
                Console.WriteLine("File Does not Exists ");
            }
        }
        public static Subject ReturnSubject(string subject)
        {
            foreach(Subject subject1 in subjects)
            {
                if(subject1.Subject_Name==subject)
                {
                    return subject1;
                }
            }
            return null;
        }
    }
}

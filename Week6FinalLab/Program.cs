using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6FinalLab.UI;
using Week6FinalLab.DL;
using Week6FinalLab.BL;


namespace Week6FinalLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string student_path = "Studentfile.txt";
            string degree_path = "Degreefile.txt";
            string subject_path = "Subjectfile.txt";
            SubjectCrud.readSubjectFile(subject_path);
            DegreeCrud.readDegreeFile(degree_path);
            StudentCrud.readStudentFile(student_path);
            while (true)
            {
                MenuUI.logo();
                string choice=MenuUI.menu();
                if (choice == "1")
                {
                    Student student = StudentUI.InputStudent();
                    List<string> preferances=StudentUI.TakePreferances();
                    student.AddPreferances(preferances);   
                    StudentCrud.AddInList(student);

                }
                else if (choice == "2")
                {
                    Degree degree = DegreeUI.InputDetailsOfDegree();
                    DegreeCrud.AddInList(degree);
                }
                else if (choice == "3")
                {
                    StudentCrud.MeritCalculator();
                    StudentCrud.Sorting();
                    StudentCrud.GenerateMerit();
                    StudentCrud.ShowMeritList();
                }
                else if (choice == "4")
                {
                    StudentUI.Header();
                    StudentCrud.ShowRegisteredStudents();
                }
                else if (choice == "5")
                {
                    StudentUI.Demand();
                    string Degree_Name = Console.ReadLine();
                    StudentUI.Header();
                    StudentCrud.ShowSpecificDegreeStudents(Degree_Name);
                }
                else if (choice == "6")
                {

                    string Subject = "";
                    StudentUI.Demand1();
                    string name = Console.ReadLine();
                    Student student = StudentCrud.ReturnStudent(name);
                    if (student != null)
                    {
                        if (student.discipline != null)
                        {
                            int noOfSubjects = DegreeUI.AskaboutSubjects();
                            for (int i = 0; i < noOfSubjects; i++)
                            {
                                int code = DegreeUI.AskCode();
                                Subject = DegreeCrud.RegisterSubject(student, code);
                                if (student.Check(Subject))
                                {
                                    student.AddSubject(Subject);
                                }
                                else
                                {
                                    StudentUI.Message();
                                }
                            }
                        }
                        else
                        {
                            StudentUI.Danger();
                        }
                    }
                    else
                    {
                        StudentUI.Danger();
                    }

                }
                else if (choice == "7")
                {
                    int fee;
                    StudentUI.Demand1();
                    string name = Console.ReadLine();
                    Student student = StudentCrud.ReturnStudent(name);
                    if (student == null)
                    {
                        StudentUI.Danger();
                    }
                    else
                    {
                        fee = student.fee();
                        if (fee == 0)
                        {
                            StudentUI.NoRegisteredSubjects(name);
                        }
                        else
                        {
                            StudentUI.ShowFee(fee, name);
                        }
                    }
                }
                else if (choice == "8")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Entery by user ");

                }

                MenuUI.GoBack();
            }
            StudentCrud.StoreInFile1(student_path);
            SubjectCrud.StoreInFile2(subject_path);
            DegreeCrud.StoreInFile3(degree_path);
        }
    }
}

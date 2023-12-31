﻿using System.Text;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Controller
{
    public class ManageStudent
    {
        public static readonly List<Student> Students = new List<Student>();
        
        public void AddStudent()
        {
            var student = new Student
            {
                Id = Person.GenerateId(),
                Name = GetInput.GetName(),
                DateOfBirth = GetInput.GetDateTime(),
                Address = GetInput.GetAddress(),
                Height = GetInput.GetHeight(),
                Weight = GetInput.GetWeight(),
                SchoolName = GetInput.GetSchoolName(),
                YearOfAdmission = GetInput.GetYearOfAdmission(),
                Gpa = GetInput.GetGpa()
            };
            student.Rank = Student.SetRank(student.Gpa);
            student.StudentCode = GetInput.GenerateStudentCode(student.Id + 1);

            Console.WriteLine("Add Student: ");
            ShowStudent(student);
            Students.Add(student);
            Console.WriteLine("\nAdd successfully!");
        }
        
        public void ShowStudent(Student? student)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid");
                return;
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine(student.ToString());
            Console.WriteLine("----------------------------------");
        }

        public void ShowStudents()  
        {
            Students.ForEach(ShowStudent);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }

        public Student? FindById(int id)
        {
            return Students.FirstOrDefault(x => x.Id == id);
        }
        
        public void UpdateStudent(int id)
        {
            var student = FindById(id);
            if (student == null)
            {
                Console.WriteLine($"Invalid ID");
                return;
            }
            
            ShowStudent(student);
            Menus.Menu.UpdateMenu();

            var key = GetInput.GetOption();
            switch (key)
            {
                case 0:
                    return;
                
                case 1:
                    student.Name = GetInput.GetName();
                    break;

                case 2:
                    student.DateOfBirth = GetInput.GetDateTime();
                    break;

                case 3:
                    student.Address = GetInput.GetAddress();
                    break;

                case 4:
                    student.Height = GetInput.GetHeight();
                    break;

                case 5:
                    student.Weight = GetInput.GetWeight();
                    break;

                case 6:
                    student.SchoolName = GetInput.GetSchoolName();
                    break;

                case 7:
                    student.YearOfAdmission = GetInput.GetYearOfAdmission();
                    break;

                case 8:
                    student.Gpa = GetInput.GetGpa();
                    student.Rank = Student.SetRank(student.Gpa);
                    break;

                default:
                    Console.WriteLine("INVALID!");
                    return;
            }
            
            ShowStudent(student);
            Console.WriteLine("Update Successfully");
        }

        public void DeleteStudent(int id)
        {
            var student = FindById(id);
            if (student == null) 
            {
                Console.WriteLine("INVALID");
                return;
            }

            var isDelete = Students.Remove(student);
            if (isDelete)
            {
                Console.WriteLine("Delete Successfully");
            }
        }

        public void DisplayByRank()
        {
            var rankFromInput = from student in Students             
                                group student by student.Rank into gr 
                                orderby gr.Key descending           
                                select gr;
            rankFromInput = rankFromInput.OrderByDescending(s => s.Count());
            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-10}   {1,5}%", gr.Key, 100 * gr.Count() / Students.Count);
            }
        }

        public void DisplayByGpa()
        {
            var rankFromInput = from student in Students              
                                group student by student.Gpa into gr 
                                orderby gr.Key descending
                                select gr;

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-5}  {1,5}%", gr.Key, 100 * gr.Count() / Students.Count);
            }
        }
        
        public void ShowStudentByRank()
        {
            Rank rank;
            Menus.Menu.RankMenu();
            switch (GetInput.GetOption())
            {
                case 0:
                    return;
                
                case 1:
                    rank = Rank.Excellent;
                    break;
                
                case 2:
                    rank = Rank.VeryGood;
                    break;
                
                case 3:
                    rank = Rank.Good;
                    break;
                
                case 4:
                    rank = Rank.Average;
                    break;
                
                case 5:
                    rank = Rank.Weak;
                    break;
                
                case 6:
                    rank = Rank.Poor;
                    break;
                
                default:
                    Console.WriteLine("INVALID!");
                    return;
            }
            var result = from student in Students 
                         where student.Rank == rank
                         select student;
            var enumerable = result.ToList();
            
            if (!enumerable.Any())
            {
                Console.WriteLine($"No student has rank {rank}");
                return;
            }
            enumerable.ForEach(ShowStudent);
        }

        public void SaveFile(List<Student> students, string path)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));
            try
            {
                using var sw = new StreamWriter(path, false, Encoding.UTF8);
                foreach (var line in students.Select(item => (item.Id + 1) + "\n" + 
                                                             item.Name + "\n" +
                                                             item.DateOfBirth.ToString(Validation.DateTimeFormat[0]) + "\n" +
                                                             item.Address + "\n" + 
                                                             item.Height + "\n" +
                                                             item.Weight + "\n" + 
                                                             item.StudentCode + "\n" +
                                                             item.SchoolName + "\n" + 
                                                             item.YearOfAdmission + "\n" + 
                                                             item.Gpa))
                {
                    sw.WriteLine(line);
                } 
                Console.WriteLine("Write Successfully");
                Console.WriteLine("--------------------------------");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadFromFile(string path)
        {
            try
            {
                using var sr = new StreamReader(path, Encoding.UTF8);
                var line = sr.ReadLine();
                while (line != null)
                {
                    var student = new Student
                    {
                        Id = int.Parse(line) - 1,
                        Name = sr.ReadLine(),
                        DateOfBirth = GetInput.FormatDateTime(sr.ReadLine()),
                        Address = sr.ReadLine(),
                        Height = double.Parse(sr.ReadLine() ?? string.Empty),
                        Weight = double.Parse(sr.ReadLine() ?? string.Empty),
                        StudentCode = sr.ReadLine(),
                        SchoolName = sr.ReadLine(),
                        YearOfAdmission = int.Parse(sr.ReadLine() ?? string.Empty),
                        Gpa = double.Parse(sr.ReadLine() ?? string.Empty)
                    };
                    student.Rank = Student.SetRank(student.Gpa);
                    Person.IndexId = student.Id+1;
                    Students.Add(student);
                    line = sr.ReadLine();
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BTL0.Models;
using BTL0.Constant;
using BTL0.Util;

namespace BTL0.Controller
{
    public class ManageStudent
    {
        /*public static Student[] studentsList;*/

        public static List<Student> students;
        public ManageStudent()
        {
            students = new List<Student>();
            // students = new Student[100];
        }

        public int GenerateID()
        {
            int max = 0;

            if (students != null && students.Count() > 0)
            {
                max = students[0].ID;
                foreach (Student student in students)
                {
                    if (max < student.ID)
                    {
                        max = student.ID;
                    }
                }
                max++;
            }
            return max;
        }
        public int CountStudent()
        {
            int count = 0;
            if (students != null)
            {
                count = students.Count();
            }
            return count;
        }



        public void AddStudent()
        {
            Student student = new Student();
            student.ID = GenerateID();

            bool checkNull = true;
            bool checkDateTime = true;
			double inputNumberDouble;
			int inputNumberInt;


			Console.Write("Enter Student Name: ");
            student.Name = GetInput.GetName();

            Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
			student.DateOfBirth = GetInput.GetDateTime();

            Console.Write("Enter Address: ");
            student.Address = GetInput.GetAdress();

            Console.Write("Enter Height: ");
            student.Height = GetInput.GetHeight();

            Console.Write("Enter Weight: ");
            student.Weight = GetInput.GetWeight();

            Console.Write("Enter Student ID: ");
            while (true)
            {
				string inputStudentCode = GetInput.GetStudentID();
				List<Student> searchResult = FindByStudentID(inputStudentCode);
				if (searchResult.Count > 0)
				{
					Console.Write("Input is existed! Enter again: ");
                    continue;
				}else
                {
					student.StudentCode = inputStudentCode;
					break;
                }
			}

            Console.Write("Enter name of School: ");
            student.SchoolName = GetInput.GetSchoolName();

            Console.Write("Enter year of addmission: ");
            student.YearOfAdmission = GetInput.GetYearOfAdmission();

            Console.Write("Enter GPA: ");
            student.GPA = GetInput.GetGPA();

            Console.WriteLine("Add Student: ");
            ShowStudent(student);
            students.Add(student);
        }

        public List<Student> FindByStudentID(string studentID)
        {
            List<Student> searchResult = new List<Student>();
            if (students != null && students.Count > 0)
            {
                foreach (Student student in students)
                {
                    if (student.StudentCode.ToUpper().Contains(studentID.ToUpper()))
                    {
                        searchResult.Add(student);
                    }
                }
            }
            return searchResult;
        }

        public void ShowStudent(Student student)
        {
            Console.WriteLine("*********************************");

            Console.WriteLine("ID: " + (student.ID + 1));
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Date Of Birth: {student.DateOfBirth}");
            Console.WriteLine($"Address: {student.Address}");
            Console.WriteLine($"Height: {student.Height}");
            Console.WriteLine($"Weight: {student.Weight}");
            Console.WriteLine($"StudentID: {student.StudentCode}");
            Console.WriteLine($"Name of School: {student.SchoolName}");
            Console.WriteLine($"Year of Admission: {student.YearOfAdmission}");
            Console.WriteLine($"GPA: {student.GPA}");
            student.rank = student.setRank(student.GPA);
            Console.WriteLine($"Rank: {student.rank}");

            Console.WriteLine("*********************************");
        }

        public void ShowStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                ShowStudent(student);
            }
        }
        /*public Student[] getStudents()
		{
			return students;
		}*/

        public List<Student> getStudents()
        {
            return students;
        }

        public Student FindByID(int id)
        {
            Student searchResult = null;
            if (students != null && students.Count > 0)
            {
                foreach (Student student in students)
                {
                    if (student.ID == id)
                    {
                        searchResult = student;
                        return searchResult;
                    }
                }
            }
            return searchResult;
        }

        public void UpdateStudent(int id)
        {
            bool checkNull = true;
            double inputNumberDouble = 0;
            Student student = FindByID(id);
            if (student != null)
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------");
                Console.WriteLine("|1.Name             |");
                Console.WriteLine("|2.Date Of Birth    |");
                Console.WriteLine("|3.Address          |");
                Console.WriteLine("|4.Height           |");
                Console.WriteLine("|5.Weight           |");
                Console.WriteLine("|6.StudentID        |");
                Console.WriteLine("|7.SchoolName       |");
                Console.WriteLine("|8.Year of Admission|");
                Console.WriteLine("|9.GPA              |");
                Console.WriteLine("---------------------");
                Console.WriteLine("");
                Console.Write("Choose option: ");
                int choice;
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student Name: ");
						student.Name = GetInput.GetName();
                        break;

					case 2:
                        Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
						student.DateOfBirth = GetInput.GetDateTime();
						break;

                    case 3:
						Console.Write("Enter Address: ");
						student.Address = GetInput.GetAdress();
						break;

                    case 4:
                        Console.Write("Enter Height: ");
						student.Height = GetInput.GetHeight();
						break;

                    case 5:
                        Console.Write("Enter Weight: ");
						student.Weight = GetInput.GetWeight();
						break;

                    case 6:
                        Console.Write("Enter Student Code: ");
						while (true)
						{
							string inputStudentCode = GetInput.GetStudentID();
							List<Student> searchResult = FindByStudentID(inputStudentCode);
							if (searchResult.Count > 0)
							{
								Console.Write("Input is existed! Enter again: ");
								continue;
							}
							else
							{
								student.StudentCode = inputStudentCode;
								break;
							}
						}
						break;

                    case 7:
                        Console.Write("Enter Name of School: ");
						student.SchoolName = GetInput.GetSchoolName();
						break;

                    case 8:
						Console.Write("Enter year of addmission: ");
						student.YearOfAdmission = GetInput.GetYearOfAdmission();
						break;

                    case 9:
						Console.Write("Enter GPA: ");
						student.GPA = GetInput.GetGPA();
						break;
                }
            }
            else
            {
                Console.WriteLine($"Invalid ID");
            }
        }

        public bool DeleteStudent(int id)
        {
            bool IsDeleted = false;
            Student student = FindByID(id);
            if (student != null)
            {
                IsDeleted = students.Remove(student);
                for (int i = id; i < students.Count; i++)
                {
                    students[i].ID--;
                }
            }
            return IsDeleted;
        }

        public void DisplayByRank()
        {
            int countStudent = CountStudent();
            List<string> listRank = new List<string>() {
                "POOR",
                "WEAK",
                "AVERAGE",
                "GOOD",
                "VERY_GOOD",
                "EXCELLENT"
            };
            List<string> rankOutOfInput = new List<string>();

            var rankFromInput = from student in students
                                group student by student.rank into gr
                                orderby gr.Key descending
                                select gr;
            rankFromInput = rankFromInput.OrderByDescending(s => s.Count());

            foreach (var gr in rankFromInput)
            {
                rankOutOfInput.Add(Convert.ToString(gr.Key));
            }

            var result = listRank.Except(rankOutOfInput).ToList();

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-10}   {1,5}%", gr.Key, 100 * gr.Count() / countStudent);
            }

            foreach (var i in result)
            {
                Console.WriteLine("{0,-10}       0%", i);
            }

        }
        public void DisplayByGPA()
        {
            int countStudent = CountStudent();
            var rankFromInput = from student in students
                                group student by student.GPA into gr
                                orderby gr.Key descending
                                select gr;

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-5}  {1,5}%", gr.Key, 100 * gr.Count() / countStudent);
            }
        }
        public void ShowStudenByRank(Rank rank)
        {
            var result = from student in students
                         where student.rank == rank
                         select student;
            if (result != null && result.Count() > 0)
            {
                foreach (var student in result)
                {
                    ShowStudent(student);
                }
            }
            else
            {
                Console.WriteLine($"No student has rank {rank}");
            }
        }

        public bool SaveFile(List<Student> students, string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8);
                foreach (Student item in students)
                {
                    string line = item.ID + 1 + "\n" + item.Name + "\n" +
                                    item.DateOfBirth.ToString("MM/dd/yyyy") + "\n" +
                                    item.Address + "\n" + item.Height.ToString() + "\n" +
                                    item.Weight.ToString() + "\n" + item.StudentCode + "\n" +
                                    item.SchoolName + "\n" + item.YearOfAdmission.ToString()
                                    + "\n" + item.GPA.ToString();
                    sw.WriteLine(line);
                }
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadFromFile(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string line = sr.ReadLine();
                while (line != null)
                {
                    Student student = new Student();
                    student.ID = int.Parse(line) - 1;
                    student.Name = sr.ReadLine().ToString();
                    student.DateOfBirth = DateTime.Parse(sr.ReadLine());
                    student.Address = sr.ReadLine().ToString();
                    student.Height = double.Parse(sr.ReadLine());
                    student.Weight = double.Parse(sr.ReadLine());
                    student.StudentCode = sr.ReadLine().ToString();
                    student.SchoolName = sr.ReadLine().ToString();
                    student.YearOfAdmission = int.Parse(sr.ReadLine());
                    student.GPA = double.Parse(sr.ReadLine());
                    students.Add(student);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

using System.Text;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Controller
{
    public class ManageStudent
    {
        public static List<Student> students = new List<Student>();
        public ManageStudent() { }

        public int CountStudent()
        {
            return students?.Count ?? 0;
        }

        /*public String GetStudentCode()
        {
            while (true)
            {
                string studentCode = GetInput.InputStudentCode();
                if (ExistByStudentCode(studentCode))
                {
                    Console.Write("Input is existed! Enter again: ");
                    continue;
                }
                return studentCode;
            }
        }*/

        public void AddStudent()
        {
            Student student = new Student
            {
                Id = Person.GenerateId(),
                Name = GetInput.GetName(),
                DateOfBirth = GetInput.GetDateTime(),
                Address = GetInput.GetAddress(),
                Height = GetInput.GetHeight(),
                Weight = GetInput.GetWeight(),
                // StudentCode = GetInput.GenerateStudentCode(student.Id+1),
                // StudentCode = GetStudentCode(),
                SchoolName = GetInput.GetSchoolName(),
                YearOfAdmission = GetInput.GetYearOfAdmission(),
                GPA = GetInput.GetGPA()
            };
            student.StudentCode = GetInput.GenerateStudentCode(student.Id + 1);

            Console.WriteLine("Add Student: ");
            ShowStudent(student);
            students.Add(student);
            Console.WriteLine("\nAdd successfully");
        }

        /*public bool ExistByStudentCode(string studentCode)
        {
            return students.Select(student => student.StudentCode.ToUpper())
                .Contains(studentCode.ToUpper());
        }*/

        public void ShowStudent(Student? student)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid");
                return;
            }
            Person.IndexId = student.Id+1;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("ID: " + (student.Id + 1));
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Date Of Birth: {student.DateOfBirth}");
            Console.WriteLine($"Address: {student.Address}");
            Console.WriteLine($"Height: {student.Height}");
            Console.WriteLine($"Weight: {student.Weight}");
            Console.WriteLine($"StudentCode: {student.StudentCode}");
            Console.WriteLine($"Name of School: {student.SchoolName}");
            Console.WriteLine($"Year of Admission: {student.YearOfAdmission}");
            Console.WriteLine($"GPA: {student.GPA}");
            student.Rank = student.setRank(student.GPA);
            Console.WriteLine($"Rank: {student.Rank}");
            Console.WriteLine("----------------------------------");
        }

        public void ShowStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                ShowStudent(student);
            }
        }

        public List<Student> getStudents()
        {
            return students;
        }

        public Student? FindByID(int id)
        {
            if (id < 0 || id >= students.Count)
            {
                return null;
            }
            return students.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(int id)
        {
            Student? student = FindByID(id);
            if (student == null)
            {
                Console.WriteLine($"Invalid ID");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------");
            Console.WriteLine("|1.Name             |");
            Console.WriteLine("|2.Date Of Birth    |");
            Console.WriteLine("|3.Address          |");
            Console.WriteLine("|4.Height           |");
            Console.WriteLine("|5.Weight           |");
            Console.WriteLine("|6.SchoolName       |");
            Console.WriteLine("|7.Year of Admission|");
            Console.WriteLine("|8.GPA              |");
            Console.WriteLine("---------------------");
            Console.WriteLine("");
            Console.Write("Choose option: ");

            int key = GetInput.GetOption();
            switch (key)
            {
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
                    student.GPA = GetInput.GetGPA();
                    break;
                default:
                    Console.WriteLine("INVALID!");
                    break;
            }
            ShowStudent(students[id]);
        }

        public void DeleteStudent(int id)
        {
            bool isDelete = false;
            Student? student = FindByID(id);
            if (student == null) 
            {
                Console.WriteLine("INVALID");
            }
            else
            {
                isDelete = students.Remove(student);
                if (isDelete)
                {
                    Console.WriteLine("Delete Succesfully");
                }
            }
        }

        public void DisplayByRank()
        {
            var rankFromInput = from student in students             
                                group student by student.Rank into gr 
                                orderby gr.Key descending           
                                select gr;
            rankFromInput = rankFromInput.OrderByDescending(s => s.Count());
            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-10}   {1,5}%", gr.Key, 100 * gr.Count() / students.Count());
            }
            
        }

        public void DisplayByGPA()
        {
            int countStudent = students.Count();
            var rankFromInput = from student in students              
                                group student by student.GPA into gr 
                                orderby gr.Key descending
                                select gr;

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-5}  {1,5}%", gr.Key, 100 * gr.Count() / countStudent);
            }
        }

        public void RankOption()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. EXCELLENT");
            Console.WriteLine("2. VERY_GOOD");
            Console.WriteLine("3. GOOD");
            Console.WriteLine("4. AVERAGE");
            Console.WriteLine("5. WEAK");
            Console.WriteLine("6. POOR");
            Console.WriteLine("---------------------------");
        }

        public void ShowStudenByRank()
        {
            Rank rank = new Rank();
            RankOption();
            switch (GetInput.GetOption())
            {
                case 1:
                    rank = Rank.EXCELLENT;
                    break;
                case 2:
                    rank = Rank.VERY_GOOD;
                    break;
                case 3:
                    rank = Rank.GOOD;
                    break;
                case 4:
                    rank = Rank.AVERAGE;
                    break;
                case 5:
                    rank = Rank.WEAK;
                    break;
                case 6:
                    rank = Rank.POOR;
                    break;
                default:
                    Console.WriteLine("MUST FROM 1 to 6!");
                    return;
            }
            var result = from student in students 
                         where student.Rank == rank
                         select student;
            if (result.Any())
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

        public void SaveFile(List<Student> students, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    foreach (Student item in students)
                    {
                        string line = (item.Id + 1) + "\n" + 
                                       item.Name + "\n" +
                                       item.DateOfBirth.ToString("MM/dd/yyyy") + "\n" +
                                       item.Address + "\n" + 
                                       item.Height + "\n" +
                                       item.Weight + "\n" + 
                                       item.StudentCode + "\n" +
                                       item.SchoolName + "\n" + 
                                       item.YearOfAdmission + "\n" + 
                                       item.GPA;
                        sw.WriteLine(line);
                    }
                    Console.WriteLine("Write Successfully");
                    Console.WriteLine("--------------------------------");
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
            
        }

        public void ReadFromFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
                {
                    string? line = sr.ReadLine();
                    while (line != null)
                    {
                        Student student = new Student
                        {
                            Id = int.Parse(line) - 1,
                            Name = sr.ReadLine(),
                            DateOfBirth = DateTime.Parse(sr.ReadLine()),
                            Address = sr.ReadLine(),
                            Height = double.Parse(sr.ReadLine()),
                            Weight = double.Parse(sr.ReadLine()),
                            StudentCode = sr.ReadLine(),
                            SchoolName = sr.ReadLine(),
                            YearOfAdmission = int.Parse(sr.ReadLine()),
                            GPA = double.Parse(sr.ReadLine())
                        };
                        students.Add(student);
                        line = sr.ReadLine();
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Error");
            }
            
        }
    }
}

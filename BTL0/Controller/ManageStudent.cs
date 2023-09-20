using System.Text;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Controller
{
    public class ManageStudent
    {
        private static readonly List<Student> Students = new List<Student>();
        public ManageStudent() { }

        public static int CountStudent()
        {
            return Students?.Count ?? 0;
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

        /*public bool ExistByStudentCode(string studentCode)
        {
            return students.Select(student => student.StudentCode.ToUpper())
                .Contains(studentCode.ToUpper());
        }*/
        
        public virtual void AddStudent()
        {
            var student = new Student
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
                Gpa = GetInput.GetGpa()
            };
            student.StudentCode = GetInput.GenerateStudentCode(student.Id + 1);

            Console.WriteLine("Add Student: ");
            ShowStudent(student);
            Students.Add(student);
            Console.WriteLine("\nAdd successfully");
        }
        public static void ShowStudent(Student? student)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid");
                return;
            }
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
            Console.WriteLine($"GPA: {student.Gpa}");
            student.Rank = Student.SetRank(student.Gpa);
            Console.WriteLine($"Rank: {student.Rank}");
            Console.WriteLine("----------------------------------");
        }

        public virtual void ShowStudents()
        {
            foreach (var student in Students)
            {
                ShowStudent(student);
            }
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }

        public virtual Student? FindById(int id)
        {
            if (id < 0 || id >= Students.Count)
            {
                return null;
            }
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

            var key = GetInput.GetOption();
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
                    student.Gpa = GetInput.GetGpa();
                    break;
                default:
                    Console.WriteLine("INVALID!");
                    break;
            }
            ShowStudent(Students[id]);
        }

        public void DeleteStudent(int id)
        {
            var student = FindById(id);
            if (student == null) 
            {
                Console.WriteLine("INVALID");
            }
            else
            {
                var isDelete = Students.Remove(student);
                if (isDelete)
                {
                    Console.WriteLine("Delete Successfully");
                }
            }
        }

        public static void DisplayByRank()
        {
            var rankFromInput = from student in Students             
                                group student by student.Rank into gr 
                                orderby gr.Key descending           
                                select gr;
            rankFromInput = rankFromInput.OrderByDescending(s => s.Count());
            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-10}   {1,5}%", gr.Key, 100 * gr.Count() / Students.Count());
            }
            
        }

        public static void DisplayByGpa()
        {
            int countStudent = Students.Count();
            var rankFromInput = from student in Students              
                                group student by student.Gpa into gr 
                                orderby gr.Key descending
                                select gr;

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-5}  {1,5}%", gr.Key, 100 * gr.Count() / countStudent);
            }
        }

        protected virtual void RankOption()
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

        public void ShowStudentByRank()
        {
            var rank = new Rank();
            RankOption();
            switch (GetInput.GetOption())
            {
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
                    Console.WriteLine("MUST FROM 1 to 6!");
                    return;
            }
            var result = from student in Students 
                         where student.Rank == rank
                         select student;
            var enumerable = result as Student[] ?? result.ToArray();
            if (enumerable.Any())
            {
                foreach (var student in enumerable)
                {
                    ShowStudent(student);
                }
            }
            else
            {
                Console.WriteLine($"No student has rank {rank}");
            }
        }

        public virtual void SaveFile(List<Student> students, string path)
        {
            if (students == null) throw new ArgumentNullException(nameof(students));
            try
            {
                using var sw = new StreamWriter(path, false, Encoding.UTF8);
                foreach (var line in students.Select(item => (item.Id + 1) + "\n" + 
                                                             item.Name + "\n" +
                                                             item.DateOfBirth.ToString("MM/dd/yyyy") + "\n" +
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

        public virtual void ReadFromFile(string path)
        {
            try
            {
                using var sr = new StreamReader(path, Encoding.UTF8);
                string? line = sr.ReadLine();
                while (line != null)
                {
                    var student = new Student
                    {
                        Id = int.Parse(line) - 1,
                        Name = sr.ReadLine(),
                        DateOfBirth = DateTime.Parse(sr.ReadLine() ?? string.Empty),
                        Address = sr.ReadLine(),
                        Height = double.Parse(sr.ReadLine() ?? string.Empty),
                        Weight = double.Parse(sr.ReadLine() ?? string.Empty),
                        StudentCode = sr.ReadLine(),
                        SchoolName = sr.ReadLine(),
                        YearOfAdmission = int.Parse(sr.ReadLine() ?? string.Empty),
                        Gpa = double.Parse(sr.ReadLine() ?? string.Empty)
                    };
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

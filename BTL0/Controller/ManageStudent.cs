using System.Text;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Controller
{
    public class ManageStudent
    {
        public static List<Student> students = new List<Student>();
        public ManageStudent()
        {
        }

        public int GenerateID()
        {
            int max = 0;
            if (students.Any())
            {
                max = students[0].Id;
                max = students.Select(student => student.Id).Prepend(max).Max();
                max++;
            }
            return max;
        }

        public int CountStudent()
        {
            return students?.Count ?? 0;
        }

        public String CheckStudentCode()
        {
            while (true)
            {
                string studentCode = GetInput.GetStudentCode();
                if (ExistByStudentCode(studentCode))
                {
                    Console.Write("Input is existed! Enter again: ");
                    continue;
                }
                return studentCode;
            }
        }

        public void AddStudent()
        {
            Student student = new Student
            {
                Id = GenerateID(),
                Name = GetInput.GetName(),
                DateOfBirth = GetInput.GetDateTime(),
                Address = GetInput.GetAdress(),
                Height = GetInput.GetHeight(),
                Weight = GetInput.GetWeight(),
                StudentCode = CheckStudentCode(),
                SchoolName = GetInput.GetSchoolName(),
                YearOfAdmission = GetInput.GetYearOfAdmission(),
                GPA = GetInput.GetGPA()
            };

            Console.WriteLine("Add Student: ");
            ShowStudent(student);
            students.Add(student);
        }

        public bool ExistByStudentCode(string studentCode)
        {
            return students.Select(student => student.StudentCode.ToUpper())
                .Contains(studentCode.ToUpper());
        }

        public void ShowStudent(Student student)
        {
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
            student.rank = student.setRank(student.GPA);
            Console.WriteLine($"Rank: {student.rank}");
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
            return students.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(int id)
        {
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
                        student.Address = GetInput.GetAdress();
                        break;

                    case 4:
                        student.Height = GetInput.GetHeight();
                        break;

                    case 5:
                        student.Weight = GetInput.GetWeight();
                        break;

                    case 6:
                        student.StudentCode = CheckStudentCode();
                        break;

                    case 7:
                        student.SchoolName = GetInput.GetSchoolName();
                        break;

                    case 8:
                        student.YearOfAdmission = GetInput.GetYearOfAdmission();
                        break;

                    case 9:
                        student.GPA = GetInput.GetGPA();
                        break;
                    default:
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
            bool isDelete = false;
            Student student = FindByID(id);
            if (student == null)
            {
                return isDelete;
            }
            isDelete = students.Remove(student);
            for (int i = id; i < students.Count; i++)
            {
                students[i].Id--;
            }
            return isDelete;
        }

        public void DisplayByRank()
        {
            int countStudent = students.Count();
            List<string> listRank = new List<string>() {
                "POOR",
                "WEAK",
                "AVERAGE",
                "GOOD",
                "VERY_GOOD",
                "EXCELLENT"
            };
            List<string> rankKey = new List<string>();

            var rankFromInput = from student in students              // group student
                                group student by student.rank into gr // by rank
                                orderby gr.Key descending             // in students
                                select gr;

            rankFromInput = rankFromInput.OrderByDescending(s => s.Count()); // sort rank descending
                                                                             // by number of elements
                                                                             // in rank

            foreach (var gr in rankFromInput)
            {
                rankKey.Add(Convert.ToString(gr.Key));
            }
            var result = listRank.Except(rankKey).ToList();

            // Print rank that order by descending
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
            int countStudent = students.Count();
            var rankFromInput = from student in students             // sort rank 
                                group student by student.GPA into gr // by GPA
                                orderby gr.Key descending
                                select gr;

            foreach (var gr in rankFromInput)
            {
                Console.WriteLine("{0,-5}  {1,5}%", gr.Key, 100 * gr.Count() / countStudent);
            }
        }

        public void ShowStudenByRank(Rank rank)
        {
            var result = from student in students   // find students by rank
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
                    string line = (item.Id + 1) + "\n" + item.Name + "\n" +
                                    item.DateOfBirth.ToString("MM/dd/yyyy") + "\n" +
                                    item.Address + "\n" + item.Height + "\n" +
                                    item.Weight + "\n" + item.StudentCode + "\n" +
                                    item.SchoolName + "\n" + item.YearOfAdmission
                                    + "\n" + item.GPA;
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
                    student.Id = int.Parse(line) - 1;
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

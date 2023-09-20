using BTL0.Controller;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var manageStudent = new ManageStudent();

            // path current
            var directory = AppContext.BaseDirectory.Split(Path.DirectorySeparatorChar);
            var slice = new ArraySegment<string>(directory, 0, directory.Length - 4);
            var path = Path.Combine(slice.ToArray()) + "\\StudentData.txt";

            manageStudent.ReadFromFile(path);
            manageStudent.ShowStudents();
            // Person.IndexId = manageStudent.getStudents().FindLast()
            // Person.IndexId = manageStudent.CountStudent();

            if (ManageStudent.CountStudent() == 0)
            {
                Console.WriteLine("NO DATA!!!");
                Console.WriteLine("Add Student!");
                manageStudent.AddStudent();
            } else
            {
                Console.WriteLine("Read data successfully");
                Console.WriteLine("------------------------------------------------");
            }

            while (true)
            {
                MenuOptions();

                var key = GetInput.GetOption();
                switch (key)
                {
                    case 0:
                        manageStudent.SaveFile(ManageStudent.GetStudents(), path);
                        return;

                    case 1:
                        manageStudent.AddStudent();
                        break;

                    case 2:
                        ManageStudent.ShowStudent(manageStudent.FindById(GetInput.GetId()));
                        break;

                    case 3:
                        manageStudent.UpdateStudent(GetInput.GetId());
                        break;

                    case 4:
                        manageStudent.DeleteStudent(GetInput.GetId());
                        break;

                    case 5:
                        ManageStudent.DisplayByRank();
                        break;

                    case 6:
                        ManageStudent.DisplayByGpa();
                        break;

                    case 7:
                        manageStudent.ShowStudentByRank();
                        break;

                    case 8:
                        manageStudent.ShowStudents();
                        break;

                    default:
                        Console.WriteLine("Enter number from 0 to 8");
                        break;
                }
            }
        }

        private static void MenuOptions()
        {
            Console.WriteLine("\nMANAGE STUDENT C#");
            Console.WriteLine("+-----------------MENU----------------------+");
            Console.WriteLine("| 1. Add Student                            |");
            Console.WriteLine("| 2. Find Student By ID                     |");
            Console.WriteLine("| 3. Update Student                         |");
            Console.WriteLine("| 4. Delete Student                         |");
            Console.WriteLine("| 5. Display by rank                        |");
            Console.WriteLine("| 6. Display by GPA                         |");
            Console.WriteLine("| 7. Show Student by Rank                    |");
            Console.WriteLine("| 8. Show Students                          |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| 0. Exit                                   |");
            Console.WriteLine("+-------------------------------------------+");
        }
    }
}
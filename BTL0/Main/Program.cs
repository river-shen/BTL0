using BTL0.Controller;
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

            if (!ManageStudent.Students.Any())
            {
                Console.WriteLine("NO DATA!!!");
                Console.WriteLine("Add Student!");
                manageStudent.AddStudent();
            } else
            {
                manageStudent.ShowStudents();
                Console.WriteLine("Read data successfully");
                Console.WriteLine("------------------------------------------------");
            }

            while (true)
            {
                Menus.Menu.MainMenu();

                var key = GetInput.GetOption();
                switch (key)
                {
                    case 0:
                        manageStudent.SaveFile(manageStudent.GetStudents(), path);
                        return;

                    case 1:
                        manageStudent.AddStudent();
                        break;

                    case 2:
                        manageStudent.ShowStudent(manageStudent.FindById(GetInput.GetId()));
                        break;

                    case 3:
                        manageStudent.UpdateStudent(GetInput.GetId());
                        break;

                    case 4:
                        manageStudent.DeleteStudent(GetInput.GetId());
                        break;

                    case 5:
                        manageStudent.DisplayByRank();
                        break;

                    case 6:
                        manageStudent.DisplayByGpa();
                        break;

                    case 7:
                        manageStudent.ShowStudentByRank();
                        break;

                    case 8:
                        manageStudent.ShowStudents();
                        break;

                    default:
                        Console.WriteLine("INVALID!");
                        break;
                }
            }
        }
    }
}
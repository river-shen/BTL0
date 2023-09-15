using BTL0.Controller;
using BTL0.Models;
using BTL0.Util;

namespace BTL0.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ManageStudent manageStudent = new ManageStudent();

            // path current
            var directory = AppContext.BaseDirectory.Split(Path.DirectorySeparatorChar);
            var slice = new ArraySegment<string>(directory, 0, directory.Length - 4);
            var path = Path.Combine(slice.ToArray()) + "\\StudentData.txt";

            manageStudent.ReadFromFile(path);

            manageStudent.ShowStudents(manageStudent.getStudents());
            Console.WriteLine("Read data successfully");
            Console.WriteLine("------------------------------------------------");

            if (manageStudent.CountStudent() > 0)
            {
                while (true)
                {
                    DisplayMenu();

                    int key = GetInput.GetOption();
                    switch (key)
                    {
                        case 0:
                            manageStudent.SaveFile(manageStudent.getStudents(), path);
                            return;

                        case 1:
                            manageStudent.AddStudent();
                            break;

                        case 2:
                            manageStudent.ShowStudent(manageStudent.FindByID(GetInput.GetID()));
                            break;

                        case 3:
                            manageStudent.UpdateStudent(GetInput.GetID());
                            break;

                        case 4:
                            manageStudent.DeleteStudent(GetInput.GetID());
                            break;

                        case 5:
                            manageStudent.DisplayByRank();
                            break;

                        case 6:
                            manageStudent.DisplayByGPA();
                            break;

                        case 7:
                            manageStudent.ShowStudenByRank();
                            break;

                        case 8:
                            manageStudent.ShowStudents(manageStudent.getStudents());
                            break;

                        default:
                            Console.WriteLine("Enter number from 0 to 8");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("NO DATA!!!");
            }

        }
        static void DisplayMenu()
        {
            Console.WriteLine("\nMANAGE STUDENT C#");
            Console.WriteLine("+-----------------MENU----------------------+");
            Console.WriteLine("| 1. Add Student                            |");
            Console.WriteLine("| 2. Find Student By ID                     |");
            Console.WriteLine("| 3. Update Student                         |");
            Console.WriteLine("| 4. Delete Student                         |");
            Console.WriteLine("| 5. Display by rank                        |");
            Console.WriteLine("| 6. Display by GPA                         |");
            Console.WriteLine("| 7. Show Studen by Rank                    |");
            Console.WriteLine("| 8. Show Students                          |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| 0. Exit                                   |");
            Console.WriteLine("+-------------------------------------------+");
        }
    }
}
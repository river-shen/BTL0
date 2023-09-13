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

			while (true)
            {
                DisplayMenu();
                int key = GetInput.GetOption();
                switch (key)
                {
                    case 0:
                        bool test = manageStudent.SaveFile(manageStudent.getStudents(), path);
                        if (test)
                        {
                            Console.WriteLine("Write Successfully");
                            Console.WriteLine("--------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        return;

                    case 1:
                        Console.WriteLine("\n1. Add Student");
                        manageStudent.AddStudent();
                        Console.WriteLine("\nAdd successfully");
                        break;

                    case 2:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n2. Find Student by ID");
                            Console.Write("Enter ID: ");
                            int id = GetInput.GetInt();
                            if (id - 1 < manageStudent.CountStudent() && id - 1 >= 0)
                            {
                                manageStudent.ShowStudent(manageStudent.getStudents()[id - 1]);
                                Console.WriteLine("\nFind successfully");
                            }
                            else
                            {
                                Console.WriteLine("Invalid");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;

                    case 3:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n3. Update Student by ID");
                            Console.Write("Enter ID: ");
							int id = GetInput.GetInt();
							if (id - 1 < manageStudent.CountStudent() && id - 1 >= 0)
                            {
                                manageStudent.UpdateStudent(id - 1);
                                manageStudent.ShowStudent(manageStudent.getStudents()[id - 1]);
                                Console.WriteLine("\nUpdate successfully");
                            }
                            else
                            {
                                Console.WriteLine("Invalid");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }

                        break;

                    case 4:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n3. Delete Student by ID");
                            Console.Write("Enter ID: "); 
                            int id = GetInput.GetInt();
							if (id - 1 < manageStudent.CountStudent() && id - 1 >= 0)
                            {
                                if (manageStudent.DeleteStudent(id - 1))
                                {
                                    Console.WriteLine("\nDelete successfully");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;

                    case 5:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n5. Display by rank");
                            manageStudent.DisplayByRank();
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;

                    case 6:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n6. Display by GPA");
                            manageStudent.DisplayByGPA();
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;

                    case 7:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n7. Show Student By Rank");
                            Console.WriteLine("");
                            Console.WriteLine("1. EXCELLENT");
                            Console.WriteLine("2. VERY_GOOD");
                            Console.WriteLine("3. GOOD");
                            Console.WriteLine("4. AVERAGE");
                            Console.WriteLine("5. WEAK");
                            Console.WriteLine("6. POOR");
                            Console.WriteLine("---------------------------");

							Console.Write("\nEnter your option: ");
                            int optionInput = GetInput.GetInt();
							switch (optionInput)
                            {
                                case 1:
                                    manageStudent.ShowStudenByRank(Rank.EXCELLENT);
                                    break;
                                case 2:
                                    manageStudent.ShowStudenByRank(Rank.VERY_GOOD);
                                    break;
                                case 3:
                                    manageStudent.ShowStudenByRank(Rank.GOOD);
                                    break;
                                case 4:
                                    manageStudent.ShowStudenByRank(Rank.AVERAGE);
                                    break;
                                case 5:
                                    manageStudent.ShowStudenByRank(Rank.WEAK);
                                    break;
                                case 6:
                                    manageStudent.ShowStudenByRank(Rank.POOR);
                                    break;
                                default:
                                    Console.WriteLine("MUST FROM 1 to 6!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;

                    case 8:
                        if (manageStudent.CountStudent() > 0)
                        {
                            Console.WriteLine("\n8. Show Students");
                            manageStudent.ShowStudents(manageStudent.getStudents());
                        }
                        else
                        {
                            Console.WriteLine("Khong co du lieu phu hop");
                        }
                        break;
                    default:
                        Console.WriteLine("Enter number from 0 to 8");
                        break;
                }
            }
        }
        static void DisplayMenu()
        {
			Console.WriteLine("\nMANAGE STUDENT C#");
			Console.WriteLine("*********************************************");
			Console.WriteLine("** 1. Add Student                          **");
			Console.WriteLine("** 2. Find Student By ID                   **");
			Console.WriteLine("** 3. Update Student                       **");
			Console.WriteLine("** 4. Delete Student                       **");
			Console.WriteLine("** 5. Display by rank                      **");
			Console.WriteLine("** 6. Display by GPA                       **");
			Console.WriteLine("** 7. Show Studen by Rank                  **");
			Console.WriteLine("** 8. Show Students                        **");
			Console.WriteLine("*********************************************");
			Console.WriteLine("** 0. Exit                                  **");
		}
    }
}
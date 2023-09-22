
namespace BTL0.Menus
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.WriteLine("\nMANAGE STUDENT C#");
            Console.WriteLine("+-----------------MENU----------------------+");
            Console.WriteLine("| 1. Add Student                            |");
            Console.WriteLine("| 2. Find Student By ID                     |");
            Console.WriteLine("| 3. Update Student                         |");
            Console.WriteLine("| 4. Delete Student                         |");
            Console.WriteLine("| 5. Display by rank                        |");
            Console.WriteLine("| 6. Display by GPA                         |");
            Console.WriteLine("| 7. Show Student by Rank                   |");
            Console.WriteLine("| 8. Show Students                          |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| 0. Exit                                   |");
            Console.WriteLine("+-------------------------------------------+");
        } 

        public static void RankMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("|1. EXCELLENT             |");
            Console.WriteLine("|2. VERY_GOOD             |");
            Console.WriteLine("|3. GOOD                  |");
            Console.WriteLine("|4. AVERAGE               |");
            Console.WriteLine("|5. WEAK                  |");
            Console.WriteLine("|6. POOR                  |");
            Console.WriteLine("---------------------------");
            Console.WriteLine("|0. EXIT                  |");
            Console.WriteLine("---------------------------");
        }

        public static void UpdateMenu()
        {
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
            Console.WriteLine("|0.EXIT             |");
            Console.WriteLine("---------------------");
            Console.WriteLine("");
        }
    }
}

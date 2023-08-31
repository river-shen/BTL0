namespace BTL0
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ManageStudent manageStudent = new ManageStudent();
			while(true)
			{
				Console.WriteLine("\nMANAGE STUDENT C#");
				Console.WriteLine("*********************************************");

				// Options in here
				Console.WriteLine("** 1. Add Student                          **");
				Console.WriteLine("** 2. Find Student By ID                   **");
				Console.WriteLine("** 3. Update Student                       **");
				Console.WriteLine("** 4. Delete Student                       **");
                Console.WriteLine("** 5. Display by rank                      **");
                Console.WriteLine("** 9. Show Students                        **");
				//
				
				Console.WriteLine("*********************************************");
				Console.WriteLine("** 0. Exit                                  **");
				Console.Write("\nEnter your option: ");
				int key = Convert.ToInt32(Console.ReadLine());
				switch (key)
				{
					case 0:
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
							int id = Convert.ToInt32(Console.ReadLine());
							if ((id-1) < manageStudent.CountStudent() && (id-1) >= 0)
							{
								manageStudent.ShowStudent(manageStudent.getStudents()[id - 1]);
								Console.WriteLine("\nFind successfully");
							} else
							{
								Console.WriteLine("Invalid");
							}
						} else
						{
							Console.WriteLine("Khong co du lieu phu hop");
						}

						break;

					case 3:
						if (manageStudent.CountStudent() > 0)
						{
							Console.WriteLine("\n3. Update Student by ID");
							Console.Write("Enter ID: ");
							int id = Convert.ToInt32(Console.ReadLine());
							if ((id - 1) < manageStudent.CountStudent() && (id - 1) >= 0)
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
							int id = Convert.ToInt32(Console.ReadLine());
							if ((id - 1) < manageStudent.CountStudent() && (id - 1) >= 0)
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
							int countStudent = manageStudent.CountStudent();
							manageStudent.DisplayByRank();
						}
						else
						{
							Console.WriteLine("Khong co du lieu phu hop");
						}
						break;

					case 9:
						if (manageStudent.CountStudent() > 0)
						{
							Console.WriteLine("\n9. Show Students");
							manageStudent.ShowStudents(manageStudent.getStudents());
						}
						else
						{
							Console.WriteLine("Khong co du lieu phu hop");
						}
						break;
				}
			}
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace BTL0
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
			Console.WriteLine(students.Count);

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

		public bool IsValiDate(string date)
		{
			DateTime tempObject;
			return DateTime.TryParse(date, out tempObject);
		}

		public bool checkTextNull(string input)
		{
			if (input.Length == 0)
			{
				return false;
			} else
			{
				return true;
			}
		}

		public bool checkIsNumberDouble(string input)
		{
			double numericValue;
			return double.TryParse(input, out numericValue);
		}
		public bool checkIsNumberInt(string input)
		{
			int numericValue;
			return int.TryParse(input, out numericValue);
		}

		public void AddStudent()
		{
			Student student = new Student();
			student.ID = GenerateID();

			Console.Write("Enter Student Name: ");
			bool checkNull = true;
			while(checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_NAME)
				{
					checkNull = false;
					student.Name = Convert.ToString(input);
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
			bool checkDateTime = true;
			while(checkDateTime)
			{
				string input = Console.ReadLine();
				if (IsValiDate(input)) {
					checkDateTime = false;
					student.DateOfBirth = DateTime.Parse(input);
				}
				else
				{
					Console.Write("Invalid input! Enter again: ");
				}
			}
			checkDateTime = true;

			Console.Write("Enter Address: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_ADDRESS)
				{
					checkNull = false;
					student.Address = Convert.ToString(input);
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			double inputNumberDouble;
			Console.Write("Enter Height: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input))
				{
					if (checkIsNumberDouble(input)){
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble < StudentConstant.MAX_HEIGHT && inputNumberDouble > StudentConstant.MIN_HEIGHT)
						{
							checkNull = false;
							student.Height = inputNumberDouble;
						} else
						{
							Console.Write("Must from 50cm to 300cm! Enter again: ");
						}
					} else
					{
						Console.Write("Not a number! Enter again: ");
					}
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			Console.Write("Enter Weight: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input))
				{
					if (checkIsNumberDouble(input))
					{
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble < StudentConstant.MAX_WEIGHT && inputNumberDouble > StudentConstant.MIN_WEIGHT)
						{
							checkNull = false;
							student.Weight = inputNumberDouble;
						}
						else
						{
							Console.Write("Must from 5kg to 1000kg! Enter again: ");
						}
					}
					else
					{
						Console.Write("Not a number! Enter again: ");
					}
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			Console.Write("Enter Student ID: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_STUDENTID)
				{
					checkNull = false;
					student.StudentID = Convert.ToString(input);
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			Console.Write("Enter name of School: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_SCHOOL_NAME)
				{
					checkNull = false;
					student.SchoolName = Convert.ToString(input);
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			int inputNumberInt;
			Console.Write("Enter year of addmission: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input))
				{
					if (checkIsNumberInt(input))
					{
						inputNumberInt = Convert.ToInt32(input);
						if (inputNumberInt > StudentConstant.MIN_YEAR && inputNumberInt <= DateTime.Now.Year)
						{
							checkNull = false;
							student.YearOfAdmission = inputNumberInt;
						}
						else
						{
							Console.Write($"Must from 1900 to {DateTime.Now.Year}! Enter again: ");
						}
					}
					else
					{
						Console.Write("Not a number! Enter again: ");
					}
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;

			Console.Write("Enter GPA: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (checkTextNull(input))
				{
					if (checkIsNumberDouble(input))
					{
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble < StudentConstant.MAX_GPA && inputNumberDouble > StudentConstant.MIN_GPA)
						{
							checkNull = false;
							student.GPA = inputNumberDouble;
						}
						else
						{
							Console.Write("Must from 0.0 to 10.0! Enter again: ");
						}
					}
					else
					{
						Console.Write("Not a number! Enter again: ");
					}
				}
				else
				{
					Console.Write("Invalid Input! Enter again: ");
				}
			}
			checkNull = true;
			Console.WriteLine("Add Student: ");
			ShowStudent(student);
			students.Add(student);
		}

		public void ShowStudent(Student student)
		{
			Console.WriteLine("*********************************");

			Console.WriteLine("ID: " + (student.ID+1));
			Console.WriteLine($"Name: {student.Name}");
			Console.WriteLine($"Date Of Birth: {student.DateOfBirth}");
			Console.WriteLine($"Address: {student.Address}");
			Console.WriteLine($"Height: {student.Height}");
			Console.WriteLine($"Weight: {student.Weight}");
			Console.WriteLine($"StudentID: {student.StudentID}");
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
				foreach(Student student in students)
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
				switch(choice)
				{
					case 1:
						Console.Write("Enter Student Name: ");
						bool checkNull = true;
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_NAME)
							{
								checkNull = false;
								student.Name = Convert.ToString(input);
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 2:
						Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
						bool checkDateTime = true;
						while (checkDateTime)
						{
							string input = Console.ReadLine();
							if (IsValiDate(input))
							{
								checkDateTime = false;
								student.DateOfBirth = DateTime.Parse(input);
							}
							else
							{
								Console.Write("Invalid input! Enter again: ");
							}
						}
						checkDateTime = true;
						break;

					case 3:
						checkNull = true;
						Console.Write("Enter Address: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_ADDRESS)
							{
								checkNull = false;
								student.Address = Convert.ToString(input);
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 4:
						checkNull = true;

						double inputNumberDouble;
						Console.Write("Enter Height: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input))
							{
								if (checkIsNumberDouble(input))
								{
									inputNumberDouble = Convert.ToDouble(input);
									if (inputNumberDouble < StudentConstant.MAX_HEIGHT && inputNumberDouble > StudentConstant.MIN_HEIGHT)
									{
										checkNull = false;
										student.Height = inputNumberDouble;
									}
									else
									{
										Console.Write("Must from 50cm to 300cm! Enter again: ");
									}
								}
								else
								{
									Console.Write("Not a number! Enter again: ");
								}
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 5:
						checkNull = true;

						Console.Write("Enter Weight: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input))
							{
								if (checkIsNumberDouble(input))
								{
									inputNumberDouble = Convert.ToDouble(input);
									if (inputNumberDouble < StudentConstant.MAX_WEIGHT && inputNumberDouble > StudentConstant.MIN_WEIGHT)
									{
										checkNull = false;
										student.Weight = inputNumberDouble;
									}
									else
									{
										Console.Write("Must from 5kg to 1000kg! Enter again: ");
									}
								}
								else
								{
									Console.Write("Not a number! Enter again: ");
								}
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 6:
						checkNull = true;

						Console.Write("Enter Student ID: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_STUDENTID)
							{
								checkNull = false;
								student.StudentID = Convert.ToString(input);
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 7:
						checkNull = true;

						Console.Write("Enter name of School: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_SCHOOL_NAME)
							{
								checkNull = false;
								student.SchoolName = Convert.ToString(input);
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 8:
						checkNull = true;

						int inputNumberInt;
						Console.Write("Enter year of addmission: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input))
							{
								if (checkIsNumberInt(input))
								{
									inputNumberInt = Convert.ToInt32(input);
									if (inputNumberInt > StudentConstant.MIN_YEAR && inputNumberInt <= DateTime.Now.Year)
									{
										checkNull = false;
										student.YearOfAdmission = inputNumberInt;
									}
									else
									{
										Console.Write($"Must from 1900 to {DateTime.Now.Year}! Enter again: ");
									}
								}
								else
								{
									Console.Write("Not a number! Enter again: ");
								}
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;

					case 9:
						checkNull = true;

						Console.Write("Enter GPA: ");
						while (checkNull)
						{
							string input = Console.ReadLine();
							if (checkTextNull(input))
							{
								if (checkIsNumberDouble(input))
								{
									inputNumberDouble = Convert.ToDouble(input);
									if (inputNumberDouble < StudentConstant.MAX_GPA && inputNumberDouble > StudentConstant.MIN_GPA)
									{
										checkNull = false;
										student.GPA = inputNumberDouble;
									}
									else
									{
										Console.Write("Must from 0.0 to 10.0! Enter again: ");
									}
								}
								else
								{
									Console.Write("Not a number! Enter again: ");
								}
							}
							else
							{
								Console.Write("Invalid Input! Enter again: ");
							}
						}
						checkNull = true;
						break;
				}
			} else
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
				for (int i=id; i<students.Count; i++)
				{
					students[i].ID --;
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
                Console.WriteLine("{0,-10}   {1,5}%", gr.Key, (100 * gr.Count() / countStudent));
			}

			foreach (var i in result)
			{
				Console.WriteLine("{0,-10}       0%",i);
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
				Console.WriteLine("{0,-5}  {1,5}%" , gr.Key, 100*gr.Count()/countStudent);
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
			} else
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
					string line = (item.ID+1) + "\n" + item.Name + "\n" +
									item.DateOfBirth.ToString("MM/dd/yyyy") + "\n" +
									item.Address + "\n" + item.Height.ToString() + "\n" +
									item.Weight.ToString() + "\n" + item.StudentID + "\n" +
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
				while (line !=null)
				{
					Student student = new Student();
					student.ID = int.Parse(line) -1;
					student.Name = sr.ReadLine().ToString();
					student.DateOfBirth = DateTime.Parse(sr.ReadLine());
					student.Address = sr.ReadLine().ToString();
					student.Height = double.Parse(sr.ReadLine());
					student.Weight = double.Parse(sr.ReadLine());
					student.StudentID = sr.ReadLine().ToString();
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

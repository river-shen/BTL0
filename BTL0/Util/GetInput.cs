using BTL0.Constant;
using BTL0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTL0.Controller;

namespace BTL0.Util
{
	public class GetInput
	{
		public static string GetName()
		{
			string? input = null;
			bool checkNull = true;

			Console.Write("Enter Student Name: ");
			while (checkNull)
			{
				input = Console.ReadLine();
				if (Validation.checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_NAME)
				{
					checkNull = false;
					input = Convert.ToString(input);
				}
				else
				{
					Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_NAME} characters and not null! Enter again: ");
				}
			}
			return input;
		}
		public static DateTime GetDateTime()
		{
			DateTime inputDateTime = DateTime.Now;
			bool checkDateTime = true;

			Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
			while (checkDateTime)
			{
				string input = Console.ReadLine();
				if (Validation.IsValiDate(input))
				{
					checkDateTime = false;
					inputDateTime = DateTime.Parse(input);
				}
				else
				{
					Console.Write("Invalid input! Enter again: ");
				}
			}
			return inputDateTime;
		}
		public static string GetAdress()
		{
			string input = null;
			bool checkNull = true;

			Console.Write("Enter Address: ");
			while (checkNull)
			{
				input = Console.ReadLine();
				if (Validation.checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_ADDRESS)
				{
					checkNull = false;
					input = Convert.ToString(input);
				}
				else
				{
					Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_ADDRESS} characters and not null! Enter again: ");
				}
			}
			return input;
		}
		public static double GetHeight()
		{
			double inputNumberDouble = 0;
			bool checkNull = true;

			Console.Write("Enter Height: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (Validation.checkTextNull(input))
				{
					if (Validation.checkIsNumberDouble(input))
					{
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble <= StudentConstant.MAX_HEIGHT && inputNumberDouble >= StudentConstant.MIN_HEIGHT)
						{
							checkNull = false;
						}
						else
						{
							Console.Write($"Must from {StudentConstant.MIN_HEIGHT}cm to {StudentConstant.MAX_HEIGHT}cm! Enter again: ");
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
			return inputNumberDouble;
		}
		public static double GetWeight()
		{
			double inputNumberDouble = 0;
			bool checkNull = true;

			Console.Write("Enter Weight: ");
			while (checkNull)
			{
				string input = Console.ReadLine();
				if (Validation.checkTextNull(input))
				{
					if (Validation.checkIsNumberDouble(input))
					{
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble <= StudentConstant.MAX_HEIGHT && inputNumberDouble >= StudentConstant.MIN_WEIGHT)
						{
							checkNull = false;
						}
						else
						{
							Console.Write($"Must from {StudentConstant.MIN_WEIGHT}kg to {StudentConstant.MAX_HEIGHT}kg! Enter again: ");
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
			return inputNumberDouble;
		}
		public static string GetStudentCode()
		{
			string input = null;
			bool checkNull = true;

			Console.Write("Enter Student ID: ");
			while (checkNull)
			{
				input = Console.ReadLine();
				if (Validation.checkTextNull(input) && input.Length == StudentConstant.LENGTH_STUDENTCODE)
				{
					checkNull = false;
					input = Convert.ToString(input);
				}
				else
				{
					Console.Write($"Must have {StudentConstant.LENGTH_STUDENTCODE} characters! Enter again: ");
				}
			}
			return input;
		}
		public static string GetSchoolName()
		{
			string input = null;
			bool checkNull = true;

			Console.Write("Enter name of School: ");
			while (checkNull)
			{
				input = Console.ReadLine();
				if (Validation.checkTextNull(input) && input.Length < StudentConstant.MAX_LENGTH_SCHOOL_NAME)
				{
					checkNull = false;
					input = Convert.ToString(input);
				}
				else
				{
					Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_SCHOOL_NAME} characters! Enter again: ");
				}
			}
			return input;
		}
		public static int GetYearOfAdmission()
		{
			string input = null;
			int inputNumberInt = 0;
			bool checkNull = true;

			Console.Write("Enter year of addmission: ");
			while (checkNull)
			{
				input = Console.ReadLine();
				if (Validation.checkTextNull(input))
				{
					if (Validation.checkIsNumberInt(input))
					{
						inputNumberInt = Convert.ToInt32(input);
						if (inputNumberInt >= StudentConstant.MIN_YEAR && inputNumberInt <= DateTime.Now.Year)
						{
							checkNull = false;
						}
						else
						{
							Console.Write($"Must from {StudentConstant.MIN_YEAR} to {DateTime.Now.Year}! Enter again: ");
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
			return inputNumberInt;
		}
		public static double GetGPA()
		{
			double inputNumberDouble = 0;
			bool checkNull = true;

			Console.Write("Enter GPA: ");
			while (checkNull)
			{
				string? input = Console.ReadLine();
				if (Validation.checkTextNull(input))
				{
					if (Validation.checkIsNumberDouble(input))
					{
						inputNumberDouble = Convert.ToDouble(input);
						if (inputNumberDouble <= StudentConstant.MAX_GPA && inputNumberDouble >= StudentConstant.MIN_GPA)
						{
							checkNull = false;
						}
						else
						{
							Console.Write($"Must from {StudentConstant.MIN_GPA} to {StudentConstant.MAX_GPA}! Enter again: ");
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
			return inputNumberDouble;
		}
	}
}

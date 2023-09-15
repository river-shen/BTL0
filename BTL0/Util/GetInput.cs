using BTL0.Constant;
using BTL0.Controller;

namespace BTL0.Util
{
    public class GetInput
    {
        public static string GetName()
        {
            string? input = null;

            Console.Write("Enter Student Name: ");
            while (true)
            {
                input = GetString();
                if (input.Length < StudentConstant.MAX_LENGTH_NAME)
                {
                    break;
                }
                else
                {
                    Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_NAME} " +
                                  $"characters and not null! Enter again: ");
                }
            }
            return input;
        }

        public static DateTime GetDateTime()
        {
            DateTime inputDateTime = DateTime.Now;
            bool check = true;

            Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
            while (check)
            {
                string? input = Console.ReadLine();
                if (Validation.IsValiDate(input))
                {
                    check = false;
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
            string? input = null;

            Console.Write("Enter Address: ");
            while (true)
            {
                input = GetString();
                if (input.Length < StudentConstant.MAX_LENGTH_ADDRESS)
                {
                    break;
                }
                else
                {
                    Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_ADDRESS} " +
                                  $"characters and not null! Enter again: ");
                }
            }
            return input;
        }

        public static double GetHeight()
        {
            double inputNumberDouble = 0;
            bool check = true;

            Console.Write("Enter Height: ");
            while (check)
            {
                inputNumberDouble = GetDouble();
                if (inputNumberDouble <= StudentConstant.MAX_HEIGHT && inputNumberDouble >= StudentConstant.MIN_HEIGHT)
                {
                    check = false;
                }
                else
                {
                    Console.Write($"Must from {StudentConstant.MIN_HEIGHT}cm to {StudentConstant.MAX_HEIGHT}cm! Enter again: ");
                }
            }
            return inputNumberDouble;
        }

        public static double GetWeight()
        {
            double inputNumberDouble = 0;
            bool check = true;

            Console.Write("Enter Weight: ");
            while (check)
            {
                inputNumberDouble = GetDouble();
                if (inputNumberDouble <= StudentConstant.MAX_HEIGHT && inputNumberDouble >= StudentConstant.MIN_WEIGHT)
                {
                    check = false;
                }
                else
                {
                    Console.Write($"Must from {StudentConstant.MIN_WEIGHT}kg to {StudentConstant.MAX_HEIGHT}kg! Enter again: ");
                }
            }
            return inputNumberDouble;
        }

        public static string InputStudentCode()
        {
            string input = null;

            Console.Write("Enter Student ID: ");
            while (true)
            {
                input = GetString();
                if (input.Length == StudentConstant.LENGTH_STUDENTCODE)
                {
                    break;
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

            Console.Write("Enter name of School: ");
            while (true)
            {
                input = GetString();
                if (input.Length < StudentConstant.MAX_LENGTH_SCHOOL_NAME)
                {
                    break;
                }
                else
                {
                    Console.Write($"Must smaller than {StudentConstant.MAX_LENGTH_SCHOOL_NAME} characters and not null! Enter again: ");
                }
            }
            return input;
        }

        public static int GetYearOfAdmission()
        {
            int inputNumberInt = 0;
            bool check = true;

            Console.Write("Enter year of addmission: ");
            while (check)
            {
                inputNumberInt = GetInt();
                if (inputNumberInt >= StudentConstant.MIN_YEAR && inputNumberInt <= DateTime.Now.Year)
                {
                    check = false;
                }
                else
                {
                    Console.Write($"Must from {StudentConstant.MIN_YEAR} to {DateTime.Now.Year}! Enter again: ");
                }
            }
            return inputNumberInt;
        }

        public static double GetGPA()
        {
            double inputNumberDouble = 0;
            bool check = true;

            Console.Write("Enter GPA: ");
            while (check)
            {
                inputNumberDouble = GetDouble();
                if (inputNumberDouble <= StudentConstant.MAX_GPA && inputNumberDouble >= StudentConstant.MIN_GPA)
                {
                    check = false;
                }
                else
                {
                    Console.Write($"Must from {StudentConstant.MIN_GPA} to {StudentConstant.MAX_GPA}! Enter again: ");
                }
            }
            return inputNumberDouble;
        }

        public static int GetInt()
        {
            string? input = null;
            int inputNumberInt = 0;
            while (true)
            {
                input = Console.ReadLine();
                if (Validation.IsTextNull(input))
                {
                    if (Validation.IsNumberInt(input))
                    {
                        inputNumberInt = Convert.ToInt32(input);
                        break;
                    }
                    else
                    {
                        Console.Write("Enter a number: ");
                    }
                }
                else
                {
                    Console.Write("Enter again: ");
                }
            }
            return inputNumberInt;
        }

        public static int GetOption()
        {
            Console.Write("Enter Option: ");
            int key = GetInt();
            return key;
        }

        public static double GetDouble()
        {
            double inputNumberDouble = 0;
            while (true)
            {
                string? input = Console.ReadLine();
                if (Validation.IsTextNull(input))
                {
                    if (Validation.IsNumberDouble(input))
                    {
                        inputNumberDouble = Convert.ToDouble(input);
                        break;
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

        public static string GetString()
        {
            string? input = null;
            while (true)
            {
                input = Console.ReadLine();
                if (Validation.IsTextNull(input))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid Input! Enter again: ");
                }
            }
            return input;

        }

        public static int GetID()
        {
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter ID: ");
            return (GetInt() - 1);
        }
    }
}

namespace BTL0.Util
{
    public class GetInput
    {
        public static string GetName()
        {
            string? input = null;
            bool check = false;

            Console.Write("Enter Student Name: ");
            while (!check)
            {
                input = GetString();
                check = Validation.CheckPropertyCondition(input,
                                            Constant.Constant.MaxLengthName);
            }
            return input;
        }

        public static DateTime GetDateTime()
        {
            DateTime inputDateTime = DateTime.Now;
            bool check = false;

            Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
            while (!check)
            {
                string? input = Console.ReadLine();
                if (Validation.IsValiDate(input))
                {
                    inputDateTime = DateTime.Parse(input);
                    check = Validation.CheckPropertyCondition(inputDateTime.Year,
                                            Constant.Constant.MinYear, DateTime.Now.Year);
                }
                else
                {
                    Console.Write("Invalid input! Enter again: ");
                }
            }
            return inputDateTime;
        }

        public static string GetAddress()
        {
            string? input = null;
            bool check = false;

            Console.Write("Enter Address: ");
            while (!check)
            {
                input = GetString();
                check = Validation.CheckPropertyCondition(input,
                                            Constant.Constant.MaxLengthAddress);
            }
            return input;
        }

        public static double GetHeight()
        {
            double inputNumberDouble = 0;
            bool check = false;

            Console.Write("Enter Height: ");
            while (!check)
            {
                inputNumberDouble = GetDouble();
                check = Validation.CheckPropertyCondition(inputNumberDouble,
                    Constant.Constant.MinHeight, Constant.Constant.MaxHeight);
            }
            return inputNumberDouble;
        }

        public static double GetWeight()
        {
            double inputNumberDouble = 0;
            bool check = false;

            Console.Write("Enter Weight: ");
            while (!check)
            {
                inputNumberDouble = GetDouble();
                check = Validation.CheckPropertyCondition(inputNumberDouble,
                                    Constant.Constant.MinWeight, Constant.Constant.MaxWeight);
            }
            return inputNumberDouble;
        }

        public static string GenerateStudentCode(int id)
        {
            int key = id.ToString().Length;
            switch(key)
            {
                case 1:
                    return $"OCEANTECH00{id}";
                case 2:
                    return $"OCEANTECH0{id}";
                default:
                    return $"OCEANTECH{id}";
            }
        }

        /*public static string InputStudentCode()
        {
            string? input = null;

            Console.Write("Enter Student ID: ");
            while (true)
            {
                input = GetString();
                if (input.Length == Constant.Constant.LengthStudentCode)
                {
                    break;
                }
                Console.Write($"Must have {Constant.Constant.LengthStudentCode} " +
                              $"characters! Enter again: ");

            }
            return input;
        }*/

        public static string GetSchoolName()
        {
            string? input = null;
            bool check = false;

            Console.Write("Enter name of School: ");
            while (!check)
            {
                input = GetString();
                check = Validation.CheckPropertyCondition(input,
                                                Constant.Constant.MaxLengthSchoolName);
            }
            return input;
        }

        public static int GetYearOfAdmission()
        {
            int inputNumberInt = 0;
            bool check = false;

            Console.Write("Enter year of admission: ");
            while (!check)
            {
                inputNumberInt = GetInt();
                check = Validation.CheckPropertyCondition(inputNumberInt,
                                        Constant.Constant.MinYear, DateTime.Now.Year);
            }
            return inputNumberInt;
        }

        public static double GetGPA()
        {
            double inputNumberDouble = 0;
            bool check = false;

            Console.Write("Enter GPA: ");
            while (!check)
            {
                inputNumberDouble = GetDouble();
                check = Validation.CheckPropertyCondition(inputNumberDouble,
                                    Constant.Constant.MinGpa, Constant.Constant.MaxGpa);
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
                    Console.Write("Enter a number: ");
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
            return GetInt();
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
                    Console.Write("Not a number! Enter again: ");
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
                Console.Write("Invalid Input! Enter again: ");
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

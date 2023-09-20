namespace BTL0.Util
{
    public abstract class GetInput
    {
        public static DateTime GetDateTime()
        {
            var inputDateTime = DateTime.Now;
            var check = false;

            Console.Write("Enter student's birth date (as mm/dd/yyyy): ");
            while (!check)
            {
                var input = Console.ReadLine();
                if (input != null && Validation.IsValiDate(input))
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
        
        public static string? GetName()
        {
            return GetData("Enter Student Name", Constant.Constant.MaxLengthName);
        }

        public static string? GetAddress()
        {
            return GetData("Enter Address", Constant.Constant.MaxLengthAddress);
        }

        public static double GetHeight()
        {
            return GetData("Enter Height", Constant.Constant.MinHeight, Constant.Constant.MaxHeight);
        }

        public static double GetWeight()
        {
            return GetData("Enter Weight", Constant.Constant.MinWeight, Constant.Constant.MaxWeight);
        }

        

        public static string? GenerateStudentCode(int id)
        {
            var key = id.ToString().Length;
            return key switch
            {
                1 => Constant.Constant.Code + $"00{id}",
                2 => Constant.Constant.Code + $"0{id}",
                _ => Constant.Constant.Code + $"{id}"
            };
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

        public static string? GetSchoolName()
        {
            return GetData("Enter name of School", Constant.Constant.MaxLengthSchoolName);
        }

        public static int GetYearOfAdmission()
        {
            return GetData("Enter year of admission", Constant.Constant.MinYear, DateTime.Now.Year);
        }

        public static double GetGpa()
        {
            return GetData("Enter GPA", Constant.Constant.MinGpa, Constant.Constant.MaxGpa);
        }
        
        private static string? GetData(string type, int maxLength)
        {
            string? input = null;
            var check = false;

            Console.Write(type + ": ");
            while (!check)
            {
                input = GetString();
                check = Validation.CheckPropertyCondition(input, maxLength);
            }
            return input;
        }
        
        private static double GetData(string type, double min, double max)
        {
            double inputNumberDouble = 0;
            var check = false;

            Console.Write(type + ": ");
            while (!check)
            {
                inputNumberDouble = GetDouble();
                check = Validation.CheckPropertyCondition(inputNumberDouble,
                    min, max);
            }
            return inputNumberDouble;
        }
        
        private static int GetData(string type, int min, int max)
        {
            var inputNumberDouble = 0;
            var check = false;

            Console.Write(type + ": ");
            while (!check)
            {
                inputNumberDouble = GetInt();
                check = Validation.CheckPropertyCondition(inputNumberDouble,
                    min, max);
            }
            return inputNumberDouble;
        }
        

        private static int GetInt()
        {
            var inputNumberInt = 0;
            while (true)
            {
                var input = Console.ReadLine();
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
        
        private static double GetDouble()
        {
            double inputNumberDouble = 0;
            while (true)
            {
                var input = Console.ReadLine();
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

        private static string GetString()
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

        public static int GetId()
        {
            Console.WriteLine("----------------------------------------");
            Console.Write("Enter ID: ");
            return (GetInt() - 1);
        }
        
        public static int GetOption()
        {
            Console.Write("Enter Option: ");
            return GetInt();
        }
    }
}

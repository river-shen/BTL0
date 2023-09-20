using BTL0.Controller;

namespace BTL0.Util
{
    public abstract class Validation
    {
        public static bool IsValiDate(string date)
        {
            DateTime tempObject;
            return DateTime.TryParse(date, out tempObject);
        }

        public static bool IsNumberDouble(string input)
        {
            double numericValue;
            return double.TryParse(input, out numericValue);
        }

        public static bool IsNumberInt(string input)
        {
            int numericValue;
            return int.TryParse(input, out numericValue);
        }

        public static bool IsTextNull(string input)
        {
            return input.Length != 0;
        }

        public static bool CheckPropertyCondition(double input, double min, double max)
        {
            if (input <= max && input >= min)
            {
                return true;
            }
            Console.Write($"Must from {min} to " +
                              $"{max}! Enter again: ");
            return false;
        }
        
        public static bool CheckPropertyCondition(int input, int min, int max)
        {
            if (input <= max && input >= min)
            {
                return true;
            }
            Console.Write($"Must from {min} to " +
                              $"{max}! Enter again: ");
            return false;
        }

        public static bool CheckPropertyCondition(string input,int maxLength)
        {
            if (input.Length < maxLength)
            {
                return true;
            }
            Console.Write($"Must smaller than {maxLength} " +
                            $"characters and not null! Enter again: ");
            return false;
        }
    }
}

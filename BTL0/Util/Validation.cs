namespace BTL0.Util
{
    public abstract class Validation
    {
        public static bool IsDateTime(string date)
        {
            return DateTime.TryParse(date, out _);
        }

        public static bool IsNumberDouble(string input)
        {
            return double.TryParse(input, out _);
        }

        public static bool IsNumberInt(string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool IsTextNull(string input)
        {
            return input.Length != 0;
        }

        public static bool CheckPropertyCondition(double input, double min, double max)
        {
            if (input <= max && input >= min) return true;
            
            Console.Write($"Must from {min} to " +
                          $"{max}! Enter again: ");
            return false;
        }
        
        public static bool CheckPropertyCondition(int input, int min, int max)
        {
            if (input <= max && input >= min) return true;
            
            Console.Write($"Must from {min} to " +
                          $"{max}! Enter again: ");
            return false;
        }

        public static bool CheckPropertyCondition(string input,int maxLength)
        {
            if (input.Length < maxLength) return true;
            
            Console.Write($"Must smaller than {maxLength} " +
                          $"characters and not null! Enter again: ");
            return false;
        }
    }
}

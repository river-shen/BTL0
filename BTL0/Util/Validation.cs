namespace BTL0.Util
{
	public class Validation
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
		public static bool isTextNull(string input)
		{
			return input.Length != 0;
		}
		
	}
}

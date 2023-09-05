using BTL0.Constant;
using BTL0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL0.Util
{
	public class Validation
	{
		public static bool IsValiDate(string date)
		{
			DateTime tempObject;
			return DateTime.TryParse(date, out tempObject);
		}
		public static bool checkIsNumberDouble(string input)
		{
			double numericValue;
			return double.TryParse(input, out numericValue);
		}
		public static bool checkIsNumberInt(string input)
		{
			int numericValue;
			return int.TryParse(input, out numericValue);
		}
		public static bool checkTextNull(string input)
		{
			if (input.Length == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
	}
}

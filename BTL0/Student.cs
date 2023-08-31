using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL0
{
	public class Student : Person
	{
		public string StudentID { get; set; }
		public string SchoolName { get; set; }
		public int YearOfAdmission { get;set; }
		public double GPA { get; set; }
		public Student() { }
		public Student(int id, string name, DateTime dateOfBirth, string address, double height, double weight,string studentID, string schoolName, int yearOfAdmission, double gpa) : base(id,name, dateOfBirth, address, height, weight)
		{
			StudentID = studentID;
			SchoolName = schoolName;
			YearOfAdmission = yearOfAdmission;
			GPA = gpa;
		}

		public override string ToString()
		{
			return $"{base.ToString()}\nStudent ID: {StudentID}\nSchool Name: {SchoolName}\nYear Of Addmission: {YearOfAdmission}\nGPA: {GPA}";
		}
	}
}

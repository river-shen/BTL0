namespace BTL0.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public string SchoolName { get; set; }
        public int YearOfAdmission { get; set; }
        public double GPA { get; set; }
        public Rank Rank { get; set; }

        public Student() { }

        public Student(string name, DateTime dateOfBirth, string address, double height,
            double weight, string studentId, string schoolName, int yearOfAdmission, double gpa)
            : base(name, dateOfBirth, address, height, weight)
        {
            StudentCode = studentId;
            SchoolName = schoolName;
            YearOfAdmission = yearOfAdmission;
            GPA = gpa;
            Rank = setRank(gpa);
        } 

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                   $"Student ID: {StudentCode}\n" +
                   $"School Name: {SchoolName}\n" +
                   $"Year Of Addmission: {YearOfAdmission}\n" +
                   $"GPA: {GPA}";
        }

        public Rank setRank(double gpa)
        {
            if (gpa >= 9) return Rank.EXCELLENT;
            if (gpa >= 7.5) return Rank.VERY_GOOD;
            if (gpa >= 6.5) return Rank.GOOD;
            if (gpa >= 5) return Rank.AVERAGE;
            return gpa >= 3 ? Rank.WEAK : Rank.POOR;
        }
    }
}

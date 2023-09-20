namespace BTL0.Models
{
    public class Student : Person
    {
        public string? StudentCode { get; set; }
        public string? SchoolName { get; set; }
        public int YearOfAdmission { get; set; }
        public double Gpa { get; set; }
        public Rank Rank { get; set; }

        public Student() { }

        public Student(string? name, DateTime dateOfBirth, string? address, double height,
            double weight, string? studentId, string? schoolName, int yearOfAdmission, double gpa)
            : base(name, dateOfBirth, address, height, weight)
        {
            StudentCode = studentId;
            SchoolName = schoolName;
            YearOfAdmission = yearOfAdmission;
            Gpa = gpa;
            Rank = SetRank(gpa);
        } 

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                   $"Student ID: {StudentCode}\n" +
                   $"School Name: {SchoolName}\n" +
                   $"Year Of Admission: {YearOfAdmission}\n" +
                   $"GPA: {Gpa}";
        }

        public static Rank SetRank(double gpa)
        {
            if (gpa >= 9) return Rank.Excellent;
            if (gpa >= 7.5) return Rank.VeryGood;
            if (gpa >= 6.5) return Rank.Good;
            if (gpa >= 5) return Rank.Average;
            return gpa >= 3 ? Rank.Weak : Rank.Poor;
        }
    }
}

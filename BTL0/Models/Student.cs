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
            Rank = SetRank(Gpa);
            return $"{base.ToString()}\n" +
                   $"Student ID: {StudentCode}\n" +
                   $"School Name: {SchoolName}\n" +
                   $"Year Of Admission: {YearOfAdmission}\n" +
                   $"GPA: {Gpa}\n" +
                   $"Rank: {Rank}";
        }

        public static Rank SetRank(double gpa)
        {
            return gpa switch
            {
                >= 9 => Rank.Excellent,
                >= 7.5 => Rank.VeryGood,
                >= 6.5 => Rank.Good,
                >= 5 => Rank.Average,
                _ => gpa >= 3 ? Rank.Weak : Rank.Poor   
            };
        }
    }
}

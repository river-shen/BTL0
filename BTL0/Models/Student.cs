namespace BTL0.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public string SchoolName { get; set; }
        public int YearOfAdmission { get; set; }
        public double GPA { get; set; }
        public Rank rank { get; set; }
        public Student() { }
        public Student(int id, string name, DateTime dateOfBirth, string address, double height, double weight, string studentID, string schoolName, int yearOfAdmission, double gpa) : base(id, name, dateOfBirth, address, height, weight)
        {
            StudentCode = studentID;
            SchoolName = schoolName;
            YearOfAdmission = yearOfAdmission;
            GPA = gpa;
            rank = setRank(gpa);
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nStudent ID: {StudentCode}\nSchool Name: {SchoolName}\nYear Of Addmission: {YearOfAdmission}\nGPA: {GPA}";
        }

        public Rank setRank(double gpa)
        {
            Rank rank = new Rank();
            if (gpa < 3)
            {
                rank = Rank.POOR;
            }
            else if (gpa >= 3 && gpa < 5)
            {
                rank = Rank.WEAK;
            }
            else if (gpa >= 5 && gpa < 6.5)
            {
                rank = Rank.AVERAGE;
            }
            else if (gpa >= 6.5 && gpa < 7.5)
            {
                rank = Rank.GOOD;
            }
            else if (gpa >= 7.5 && gpa < 9)
            {
                rank = Rank.VERY_GOOD;
            }
            else if (gpa >= 9)
            {
                rank = Rank.EXCELLENT;
            }
            return rank;
        }
    }
}

﻿namespace BTL0.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public string SchoolName { get; set; }
        public int YearOfAdmission { get; set; }
        public double GPA { get; set; }
        public Rank Rank { get; set; }
        public Student() { }
        public Student(int id, string name, DateTime dateOfBirth, string address, double height, double weight, string studentID, string schoolName, int yearOfAdmission, double gpa) : base(id, name, dateOfBirth, address, height, weight)
        {
            StudentCode = studentID;
            SchoolName = schoolName;
            YearOfAdmission = yearOfAdmission;
            GPA = gpa;
            Rank = setRank(gpa);
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nStudent ID: {StudentCode}\nSchool Name: {SchoolName}\nYear Of Addmission: {YearOfAdmission}\nGPA: {GPA}";
        }

        public Rank setRank(double gpa)
        {
            if (gpa >= 9) return Rank.EXCELLENT;
            if (gpa >= 7.5) return Rank.VERY_GOOD;
            if (gpa >= 6.5) return Rank.GOOD;
            if (gpa >= 5) return Rank.AVERAGE;
            if (gpa >= 3) return Rank.WEAK;
            return Rank.POOR;
        }
    }
}

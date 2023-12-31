﻿using BTL0.Util;

namespace BTL0.Models
{
    public class Person
    {
        public static int IndexId;
        public int Id { get; init; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        protected Person() { }

        protected Person(string? name, DateTime dateOfBirth, string? address, 
                        double height, double weight)
        {
            Id = GenerateId();
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }

        public static int GenerateId()
        {
            return IndexId++;
        }

        public override string ToString()
        {
            return $"Id: {Id+1}\n" +
                   $"Name: {Name}\n" +
                   $"Date Of Birth: {DateOfBirth.ToString(Validation.DateTimeFormat[0])}\n" +
                   $"Address: {Address}\n" +
                   $"Height: {Height} cm\n" +
                   $"Weight: {Weight} kg";
        }
    }
}

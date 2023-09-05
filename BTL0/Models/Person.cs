using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL0.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public Person()
        {

        }
        public Person(int id, string name, DateTime dateOfBirth, string address, double height, double weight)
        {
            ID = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            Height = height;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"Id: {ID}\nName: {Name}\nDate Of Birth: {DateOfBirth}\nAddress: {Address}\nHeight: {Height} cm\nWeigth: {Weight} kg";
        }
    }
}

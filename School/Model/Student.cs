using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public enum Visit
    {
        Visited, Unvisited, Late
    }
    public class Student:Person
    {
        public int id;
        public Student() : base()
        {
        }
        public Student(string name, string fname, DateTime birthDate, string telephoneNumber, string address,string login, string password, string classOfStudent, string IIN) : base(name, fname, birthDate, telephoneNumber, address, login, password)
        {
            this.classOfStudent = classOfStudent;
            this.IIN = IIN;
        }
        public string classOfStudent { get; set; }
        public string IIN { get; set; }
        public Visit Visit { get; set; }
    }
}

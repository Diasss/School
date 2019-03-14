using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public enum Lesson
    {
        Physics, Math, RussianLanguage, KazakhLanguage, HistoryOfKazakhstan, Chemistry, Biology 
    }
    public class Teacher: Person
    {
        public int id;
        public Teacher()
        {
        }
        public Teacher(string name, string fname, DateTime birthDate, string telephoneNumber, string address, string login, string password) : base(name, fname, birthDate, telephoneNumber, address, login, password)
        {
        }
        public string IIN { get; set; }
        public Lesson Lesson { get; set; }
    }
}

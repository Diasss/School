using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public enum TypeOfAdmin
    {
        HeadTeacher=1, Director
    }
    public class Administration:Person
    {
        public int id;
        public Administration():base()
        {
        }
        public Administration(string name, string fname, DateTime birthDate, string telephoneNumber, string address, string login, string password) : base(name, fname, birthDate, telephoneNumber, address, login, password)
        {
        }
        public TypeOfAdmin TypeOfAdmin { get; set; }        
    }
}

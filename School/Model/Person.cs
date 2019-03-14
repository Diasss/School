using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public abstract class Person
    {
        public Person()
        {

        }
        public Person(string name, string fname, DateTime birthDate, string telephoneNumber, string address, string login, string password)
        {
            this.name = name;
            this.fname = fname;
            this.birthDate = birthDate;
            this.telephoneNumber = telephoneNumber;
            this.address = address;
            this.login = login;
            this.password = password;
        }
        public string login { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string fname { get; set; }
        public DateTime birthDate { get; set; }
        public string telephoneNumber { get; set; }
        public string address { get; set; }
    }
}

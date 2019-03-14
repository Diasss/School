using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class StudentService
    {
        public static void PrintStudent(Student st)
        {
            Console.WriteLine("Имя ученика: ", st.name);
            Console.WriteLine("Фамилия ученика: ", st.fname);
            Console.WriteLine("Дата рождения ученика: ", st.birthDate);
            Console.WriteLine("Номер телефона ученика: ", st.telephoneNumber);
            Console.WriteLine("Адрес ученика: ", st.address);
            Console.WriteLine("Логин ученика: ", st.login);
            Console.WriteLine("Класс ученика: ", st.classOfStudent);
            Console.WriteLine("ИИН ученика: ", st.IIN);
        }
    }
}

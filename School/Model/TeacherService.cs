using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Model
{
    public class TeacherService
    {
        public static void PrintTeacher(Teacher t)
        {
            Console.WriteLine("Имя учителя: ", t.name);
            Console.WriteLine("Фамилия учителя: ", t.fname);
            Console.WriteLine("Дата рождения учителя: ", t.birthDate);
            Console.WriteLine("Номер телефона учителя: ", t.telephoneNumber);
            Console.WriteLine("Адрес учителя: ", t.address);
            Console.WriteLine("Логин учителя: ", t.login);
            Console.WriteLine("ИИН учителя: ",t.IIN);
            Console.WriteLine("Предмет, который ведет учитель: ", t.Lesson);
        }
    }
}

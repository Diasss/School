using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using System.Threading;

namespace School.Model
{
    public class AdminService
    {
        public void CreateStudent()
        {
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Student>(@"Students");

                Student student = new Student();
                Console.WriteLine("Введите имя Ученика: ");
                student.name = Console.ReadLine();
                Console.WriteLine("Введите фамилию Ученика: ");
                student.name = Console.ReadLine();
                while (student.login == null)
                {
                    Console.WriteLine("Введите логин ученика: ");
                    string tempLogin = Console.ReadLine();
                    Student st = col.FindAll().FirstOrDefault(s => s.login == tempLogin);
                    if (st == null)
                    {
                        student.login = tempLogin;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Данный логин уже занят!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                    }
                }
                Console.WriteLine("Введите пароль ученика: ");
                student.password = Console.ReadLine();
                Console.WriteLine("Введите дату рождения ученика (формат дд/мм/гг): ");
                student.birthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите телефон ученика: ");
                student.telephoneNumber = Console.ReadLine();
                Console.WriteLine("Введите адрес ученика: ");
                student.address = Console.ReadLine();
                Console.WriteLine("Введите класс ученика (формат класс и буква): ");
                student.classOfStudent = Console.ReadLine();
                while (student.IIN == null)
                {
                    Console.WriteLine("Введите ИИН ученика (12 цифр): ");

                    string IINtemp = Console.ReadLine();
                    if (IINtemp.Length == 12)
                    {
                        student.IIN = IINtemp;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ИИН не соответствеут длине для физических лиц!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(3000);
                    }
                }
                col.Insert(student);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ученик успешно добавлен в школу!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
        public void CreateTeacher()
        {
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Teacher>(@"Teachers");
                Teacher teacher = new Teacher();
                Console.WriteLine("Введите имя учителя: ");
                teacher.name = Console.ReadLine();
                Console.WriteLine("Введите фамилию учителя: ");
                teacher.fname = Console.ReadLine();
                while (teacher.login == null)
                {
                    Console.WriteLine("Введите логин учителя:");
                    string tempLogin = Console.ReadLine();
                    Teacher te = col.FindAll().FirstOrDefault(t => t.login == tempLogin);
                    if (te == null)
                    {
                        teacher.login = tempLogin;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Данный логин уже занят!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                    }
                }
                Console.WriteLine("Введите пароль учителя: ");
                teacher.password = Console.ReadLine();
                Console.WriteLine("Введите дату рождения учителя (формат дд/мм/год): ");
                teacher.birthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Введите телефон учителя: ");
                teacher.telephoneNumber = Console.ReadLine();
                Console.WriteLine("Введите адрес учителя: ");
                teacher.address = Console.ReadLine();
                while (teacher.IIN == null)
                {
                    Console.WriteLine("Введите ИИН ученика (12 цифр): ");

                    string IINtemp = Console.ReadLine();
                    if (IINtemp.Length == 12)
                    {
                        teacher.IIN = IINtemp;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ИИН не соответствеут длине для физических лиц!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(2000);
                    }
                }
                col.Insert(teacher);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Учитель успешно добавлен в школу!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
        public void InfoAboutStudents()
        {
            int k = 0;
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Student>(@"Students");
                var result = col.FindAll();
                Console.WriteLine("Информацию о каком классе вы бы хотели увидеть: ");

                string tempClass = Console.ReadLine();
                if (tempClass.Length == 3 && Int32.Parse(tempClass.Substring(0, 2)) > 0
                    || Int32.Parse(tempClass.Substring(0, 2)) < 12 ||
                    tempClass.Length == 2 && Int32.Parse(tempClass.Substring(0, 1)) > 0
                    || Int32.Parse(tempClass.Substring(0, 1)) < 12)
                {
                    foreach (Student s in result)
                    {
                        if (s.classOfStudent == tempClass)
                        {
                            Console.WriteLine("{0}) {1} {2}", k++, s.name, s.fname);
                        }
                    }

                    Console.WriteLine("Информацию о каком студенте из класса {0} вы бы хотели узнать?", tempClass);
                    Console.WriteLine("Имя: ");
                    string tempName = Console.ReadLine();
                    Console.WriteLine("Фамилия: ");
                    string tempFname = Console.ReadLine();
                    Student st1 = col.FindAll().FirstOrDefault(s => s.name == tempName);
                    Student st2 = col.FindAll().FirstOrDefault(s => s.fname == tempFname);
                    if (st1 != null && st2 != null)
                    {
                        //ОБРАТИ ВНИМАНИЕ ДИАС!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        StudentService.PrintStudent(st1);
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введена фамилия или имя ученика");
                    }
                }
                else
                {
                    Console.WriteLine("Неверно введен класс");
                }
            }
        }
        public void InfoAboutTeachers()
        {
            int k = 0;
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Teacher>(@"Teachers");
                var result = col.FindAll();
                foreach (Teacher t in result)
                {
                    Console.WriteLine("{0}) {1} {2}", k++, t.name, t.fname);
                }
                Console.WriteLine("О каком учителе вы бы хотели получить информацию?\nИмя:");
                string tempName = Console.ReadLine();
                Console.WriteLine("Фамилия: ");
                string tempFname = Console.ReadLine();
                Teacher t1 = col.FindAll().FirstOrDefault(t => t.name == tempName);
                Teacher t2 = col.FindAll().FirstOrDefault(t => t.fname == tempFname);
                if (t1 != null && t2 != null)
                {
                    //ОБРАТИ ВНИМАНИЕ ДИАС!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    TeacherService.PrintTeacher(t1);
                }
                else
                {
                    Console.WriteLine("Неправильно введена фамилия или имя учителя");
                }
            }
        }
        public void DeleteStudent()
        {
            int k = 0;
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Student>(@"Students");
                var result = col.FindAll();
                Console.WriteLine("Введите класс ученика, которого хотите выгнать со школы: ");

                string tempClass = Console.ReadLine();
                if (tempClass.Length == 3 && Int32.Parse(tempClass.Substring(0, 2)) > 0
                    || Int32.Parse(tempClass.Substring(0, 2)) < 12 ||
                    tempClass.Length == 2 && Int32.Parse(tempClass.Substring(0, 1)) > 0
                    || Int32.Parse(tempClass.Substring(0, 1)) < 12)
                {
                    foreach (Student s in result)
                    {
                        if (s.classOfStudent == tempClass)
                        {
                            Console.WriteLine("{0}) {1} {2}", k++, s.name, s.fname);
                        }
                    }

                    Console.WriteLine("Какого ученика из класса {0} вы бы хотели выгнать со школы?", tempClass);
                    Console.WriteLine("Имя: ");
                    string tempName = Console.ReadLine();
                    Console.WriteLine("Фамилия: ");
                    string tempFname = Console.ReadLine();
                    Student st1 = col.FindAll().FirstOrDefault(s => s.name == tempName);
                    Student st2 = col.FindAll().FirstOrDefault(s => s.fname == tempFname);
                    if (st1 != null && st2 != null)
                    {
                        //ОБРАТИ ВНИМАНИЕ ДИАС!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        col.Delete(s => s.name.Equals(st1));
                    }
                    else
                    {
                        Console.WriteLine("Неправильно введена фамилия или имя ученика");
                    }
                }
            }
        }
        public void DeleteTeacher()
        {
            int k = 0;
            using (var db = new LiteDatabase(@"School"))
            {
                var col = db.GetCollection<Teacher>(@"Teachers");
                var result = col.FindAll();
                foreach (Teacher t in result)
                {
                    Console.WriteLine("{0}) {1} {2}", k++, t.name, t.fname);
                }
                Console.WriteLine("Какого учителя вы бы хотели уволить?\nИмя:");
                string tempName = Console.ReadLine();
                Console.WriteLine("Фамилия: ");
                string tempFname = Console.ReadLine();
                Teacher t1 = col.FindAll().FirstOrDefault(t => t.name == tempName);
                Teacher t2 = col.FindAll().FirstOrDefault(t => t.fname == tempFname);
                if (t1 != null && t2 != null)
                {
                    //ОБРАТИ ВНИМАНИЕ ДИАС!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    col.Delete(t => t.name.Equals("t1"));
                }
                else
                {
                    Console.WriteLine("Неправильно введена фамилия или имя учителя");
                }
            }
        }
    }
}

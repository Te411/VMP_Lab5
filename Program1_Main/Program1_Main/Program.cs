using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program1_Person;
using Program1_Student;
using Program1_StudentWithAdvisor;
using Program1_Teacher;

namespace Program1_Main
{
    internal class Program
    {
        static void CountOfArray(Person[] ArrayOne)
        {
            for (int i = 0; i < ArrayOne.Length; i++)
                Console.WriteLine(ArrayOne[i]);
            Console.WriteLine();

            int countPerson = 0, countStudent = 0, countTeacher = 0, countStudentWithAdvisor = 0;
            for (int i = 0; i < ArrayOne.Length; i++)
            {
                if (ArrayOne[i].GetType() == typeof(Student))
                {
                    countStudent++;
                }
                else if (ArrayOne[i].GetType() == typeof(Teacher))
                {
                    countTeacher++;
                }
                else if (ArrayOne[i].GetType() == typeof(StudentWithAdvisor))
                {
                    countStudentWithAdvisor++;
                }
                else if (ArrayOne[i].GetType() == typeof(Person))
                {
                    countPerson++;
                }
            }
            Console.WriteLine("Количество");
            Console.WriteLine($"Persons: {countPerson}\nStudents: {countStudent}\nTeachers: {countTeacher}\nStudentWithAdvisor: {countStudentWithAdvisor}\n");

            for (int i = 0; i < ArrayOne.Length; i++)
            {
                if (ArrayOne[i] as Student != null)
                    ((Student)ArrayOne[i]).Course = ((Student)ArrayOne[i]).Course + 1;
            }
            Console.WriteLine("Студенты переведены на следующий курс");
            Console.WriteLine();

            for (int i = 0; i < ArrayOne.Length; i++)
                Console.WriteLine(ArrayOne[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Person[] ArrayOne = new Person[] {
                Person.RandomPerson(),
                Student.RandomStudent(),
                Teacher.RandomTeacher(),
                StudentWithAdvisor.RandomStudentWithAdvisor(),
            };

            Person[] ArrayTwo = new Person[] {
                Person.RandomPerson(),
                Student.RandomStudent(),
                Teacher.RandomTeacher(),
                StudentWithAdvisor.RandomStudentWithAdvisor(),
            };

            CountOfArray(ArrayOne);
            CountOfArray(ArrayTwo);
            Console.ReadLine();
        }
    }
}

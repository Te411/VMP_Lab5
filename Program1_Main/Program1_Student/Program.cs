using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program1_Person;

namespace Program1_Student
{

    public class Student : Person, ICloneable
    {
        private int course;
        private static readonly Random rnd = new Random();

        public int Course
        {
            get => course;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    course = value;
                }
            }
        }

        public Student(string _name, int _age, int _course) : base(_name, _age)
        {
            Course = _course;
        }

        public override string ToString()
        {
            return $"Студент: {Name}, возраст: {Age}, курс: {Course}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Student))
            {
                return false;
            }
            Student student = (Student)obj;
            return student.Name == Name && student.Age == Age;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Student RandomStudent()
        {
            Student[] arr = new Student[] {
                new Student("Student_1", 1, 1),
                new Student("Student_2", 2, 2),
                new Student("Student_3", 3, 3),
                new Student("Student_4", 4, 4),
                new Student("Student_5", 5, 5),
                new Student("Student_6", 6, 6),
            };
            int r = rnd.Next(arr.Length);
            return arr[r];
        }

        public virtual object Clone()
        {
            return new Student(this.Name, this.Age, this.Course);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

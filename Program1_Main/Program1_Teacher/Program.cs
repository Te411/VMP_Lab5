using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program1_Person;
using Program1_Student;

namespace Program1_Teacher
{
    public class Teacher : Person, ICloneable
    {
        private static readonly Random rnd = new Random();
        private Student[] arrayStudent;
        public Student[] ArrayStudent
        {
            get => arrayStudent;
            set
            {
                arrayStudent = new Student[value.Length];
                for (int i = 0; i < arrayStudent.Length; i++)
                    arrayStudent[i] = (Student)value[i].Clone();
            }
        }

        public Teacher(string _name, int _age, Student[] _arrayStudent) : base(_name, _age)
        {
            ArrayStudent = (Student[])_arrayStudent.Clone();
        }

        public override string ToString()
        {
            string students = "";

            foreach (Student student in ArrayStudent)
            {
                students += $"{student} ";
            }

            return $"Преподаватель: {Name}, возраст: {Age}, студенты: {students}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Teacher))
            {
                return false;
            }
            Teacher teacher = (Teacher)obj;
            if (teacher.Name != Name || teacher.Age != Age)
                return false;
            for(int i = 0;i < ArrayStudent.Length;i++)
            {
                if (!teacher.ArrayStudent[i].Equals(ArrayStudent[i]))
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static Teacher RandomTeacher()
        {
            Teacher[] arr = new Teacher[] {
                new Teacher("Teacher_1", 1, new Student[] { Student.RandomStudent() }),
                new Teacher("Teacher_2", 2, new Student[] { Student.RandomStudent() }),
            };
            int r = rnd.Next(arr.Length);
            return arr[r];
        }

        public override object Clone()
        {
            return new Teacher(Name, Age, (Student[])ArrayStudent.Clone());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

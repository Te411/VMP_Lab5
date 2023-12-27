using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program1_Student;
using Program1_Teacher;

namespace Program1_StudentWithAdvisor
{
    public class StudentWithAdvisor : Student, ICloneable
    {
        private static readonly Random rnd = new Random();
        private Teacher teach;

        public Teacher Teach
        {
            get => teach;
            set => teach = (Teacher)value.Clone();
        }

        public StudentWithAdvisor(string _name, int _age, int _course, Teacher _teach) : base (_name, _age, _course)
        {
            teach = (Teacher)_teach.Clone();
        }

        public override string ToString()
        {
            return $"Студент: {Name}, возраст: {Age}, курс: {Course}, Преподаватель {teach}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StudentWithAdvisor))
            {
                return false;
            }
            StudentWithAdvisor studentWithAdvisor = (StudentWithAdvisor)obj;
            return studentWithAdvisor.Name == Name && studentWithAdvisor.Age == Age && studentWithAdvisor.Course == Course && (!studentWithAdvisor.Teach.Equals(Teach));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override object Clone()
        {
            return new StudentWithAdvisor(Name, Age, Course, new Teacher(teach.Name, teach.Age, teach.ArrayStudent));
        }

        public static StudentWithAdvisor RandomStudentWithAdvisor()
        {
            StudentWithAdvisor[] arr = new StudentWithAdvisor[] 
            {
                new StudentWithAdvisor("Student_1", 1, 1, Teacher.RandomTeacher()),
                new StudentWithAdvisor("Student_2", 2, 2, Teacher.RandomTeacher()),
                new StudentWithAdvisor("Student_3", 3, 3, Teacher.RandomTeacher()),
                new StudentWithAdvisor("Student_4", 4, 4, Teacher.RandomTeacher()),
                new StudentWithAdvisor("Student_5", 5, 5, Teacher.RandomTeacher()),
                new StudentWithAdvisor("Student_6", 6, 6, Teacher.RandomTeacher()),
            };
            int r = rnd.Next(arr.Length);
            return arr[r];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

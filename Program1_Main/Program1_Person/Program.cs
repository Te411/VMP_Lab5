using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Program1_Person
{
    public class Person : ICloneable
    {
        private static readonly Random rnd = new Random();
        private string name;
        private int age;

        public int Age
        {
            get => age;
            set
            {
                if(value < 0)
                {
                    value = 0;
                }
                else
                {
                    age = value;
                }
            }
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Person(string _name, int _age)
        {
            Name = _name;
            Age = _age;
        }

        public override string ToString()
        {
            return $"Имя: {name}, возраст: {age}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Person))
            {
                return false;
            }
            Person person = (Person)obj;
            return person.Name == Name && person.Age == Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age;
        }

        public static Person RandomPerson()
        {
            Person[] arr = new Person[] {
                new Person("Name_1", 1),
                new Person("Name_2", 2),
                new Person("Name_3", 3),
                new Person("Name_4", 4),
                new Person("Name_5", 5),
                new Person("Name_6", 6),
            };
            int r = rnd.Next(arr.Length);
            return arr[r];
        }

        public virtual object Clone()
        {
            return new Person(this.Name, this.Age);
        }

        public virtual void Print()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

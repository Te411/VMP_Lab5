//Разработать абстрактный класс Figure, в котором нужно реализовать следующие элементы:
//•	скрытое внутреннее поле name (название фигуры);
//•	конструктор с 1 параметром, инициализирующий поле name заданным значением;
//•	свойство Name для доступа к внутреннему полю name;
//•	абстрактное свойство Area2, предназначенное для получения площади фигуры;
//•	абстрактный метод Area(), предназначенный для получения площади фигуры;
//•	виртуальный метод Print(), который выводит название фигуры.

//Разработать класс Triangle, который наследует (расширяет) возможности класса Figure. В классе нужно реализовать следующие элементы:
//•	скрытые внутренние поля a, b, c (стороны треугольника);
//•	конструктор с 4 параметрами;
//•	методы доступа к полям класса SetABC(), GetABC().Каждый метод получает 3 параметра – длины сторон треугольника;
//•	свойство Area2, которое определяет площадь треугольника на основании его сторон a, b, c;
//•	метод Area(), возвращающий площадь треугольника по его сторонам;
//•	виртуальный метод Print() для вывода внутренних полей класса. Метод обращается к одноименному методу базового класса.

//Разработать класс TriangleColor, который наследует (расширяет) возможности класса Triangle. В классе реализовать следующие элементы:
//•	скрытое внутреннее поле color (цвет фона треугольника);
//•	конструктор с 5 параметрами, вызывающий конструктор базового класса;
//•	свойство Color, которое предназначено для доступа к внутреннему полю color;
//•	свойство Area2, вызывающее одноименное свойство базового класса для вычисления площади треугольника;
//•	метод Area(), возвращающий площадь треугольника по его сторонам;
//•	виртуальный метод Print() для вывода внутренних полей класса. Метод обращается к одноименному методу базового класса.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Program_3
{
    public abstract class Figure
    {
        private string name;
        public abstract double area2 { get; }
        public abstract double Area();

        public Figure(string _name)
        {
            name = _name;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public virtual void Print() => Console.WriteLine($"Фигура: {name}");
    }

    public class Triangle : Figure
    {
        private double a, b, c;

        public Triangle(string _name, double _a, double _b, double _c) : base(_name)
        {
            a = _a;
            b = _b;
            c = _c;
        }

        public void SetABC(double _a, double _b, double _c)
        {
            a = _a;
            b = _b;
            c = _c;
        }

        public void GetABC(out double _a, out double _b, out double _c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public override double area2
        {
            get => Area();
        }

        public override double Area()
        {
            double p = (a + b + c) / 2;
            double result = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return result;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"a: {a}\nb: {b}\nc: {c}");
        }
    }

    public class TriangleColor : Triangle
    {
        private string color;

        public string Color
        {
            get => color;
        }

        public TriangleColor(string _name, double _a, double _b, double _c, string _color) : base(_name, _a, _b, _c)
        {
            color = _color;
        }

        public override double area2
        {
            get => base.Area();
        }

        public override double Area()
        {
            return base.Area();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Color: {color}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TriangleColor triangleColor = new TriangleColor("name", 6, 4, 8, "color");
            triangleColor.Print();
            Console.Write($"\nS: {triangleColor.Area()}");
            double area = triangleColor.area2;
            Console.Write($" <=> Area: {area}");
            Console.ReadLine();
        }
    }
}

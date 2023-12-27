//Задан класс Book, который описывает книгу. Класс содержит следующие элементы:
//•	название книги;
//•	фамилия и имя автора;
//•	стоимость книги.
//В классе Book нужно реализовать следующие методы:
//•	конструктор с 3 параметрами;
//•	свойства get/set для доступа к полям класса;
//•	метод Print(), который выводит информацию о книге.
//Разработать класс BookGenre, который наследует возможности класса Book и добавляет поле жанра (genre).
//В классе BookGenre реализовать следующие элементы:
//•	конструктор с 4 параметрами – реализует вызов конструктора базового класса;
//•	свойство get/set доступа к внутреннему полю класса;
//•	метод Print(), который обращается к методу Print() базового класса Book для вывода информации о всех полях класса.
//  Разработать класс BookGenrePubl, который унаследован от класса BookGenre.
//  Данный класс добавляет поле, которое содержит информацию об издателе. В классе BookGenrePubl реализовать следующие элементы:
//•	конструктор с 5 параметрами;
//•	свойство get/set для доступа к внутреннему полю класса;
//•	метод Print(), который вызывает одноименный метод базового класса и выводит на экран информацию об издателе.
//•	Класс BookGenrePubl сделать таким, что не может быть унаследован.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_2
{
    public class Book
    {
        private string nameBook;
        private string author;
        private int price;

        public string NameBook
        {
            get => nameBook;
            set => nameBook = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public Book(string _nameBook, string _author, int _price)
        {
            nameBook = _nameBook;
            author = _author;
            price = _price;
        }

        public virtual void Print() => Console.WriteLine($"Название книги: {nameBook}\nАвтор: {author} \nЦена книги: {price}");

    }

    public class BookGenre : Book
    {
        private string genre;

        public string Genre
        {
            get => genre;
            set => genre = value;
        }

        public BookGenre(string _nameBook, string _author, int _price, string _genre) : base(_nameBook, _author, _price)
        {
            genre = _genre;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Жанр {genre}");
        }
    }

    public sealed class BookGenrePubl : BookGenre
    {
        private string publ;

        public string Publ
        {
            get => publ;
            set => publ = value;
        }

        public BookGenrePubl(string _nameBook, string _author, int _price, string _genre, string _publ) : base(_nameBook, _author, _price, _genre)
        {
            publ = _publ;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Издатель: {publ}\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Name", "Author", 1);
            book.Print();
            Console.WriteLine();
            BookGenre bookGenre = new BookGenre("Name", "Author", 1, "Genre");
            bookGenre.Print();
            Console.WriteLine();
            BookGenrePubl bookGenrePubl = new BookGenrePubl("Name", "Author", 1, "Genre", "Publ");
            bookGenrePubl.Print();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

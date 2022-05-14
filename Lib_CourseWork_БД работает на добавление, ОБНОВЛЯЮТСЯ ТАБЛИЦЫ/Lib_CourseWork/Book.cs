using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_CourseWork
{
    public class Book
    {
        public Reader Reader { get; private set; }
        public int BookId { get; private set; }
        public string Title { get; private set; }

        public string Author { get; private set; }

        public string Publisher { get; private set; }

        public int Price { get; private set; }

        public int Year { get; private set; }

        public int ReaderId { get; private set; }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Book()
        {
            Title = "Неизвестно";
            Author = "Неизвестно";
            Publisher = "Неизвестно";
            Price = 0;
            Year = 0;
            //ReaderId = 1; // 0?
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publisher"></param>
        /// <param name="price"></param>
        /// <param name="year"></param>
        public Book(string title, string author, string publisher, int price, int year)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Price = price;
            Year = year;
            //ReaderId = readerId;            
        }
    }
}
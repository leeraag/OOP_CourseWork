using System;
using System.Collections.Generic;

namespace Lib_CourseWork
{
    public partial class Book
    {
        public Reader Reader { get; private set; }

        public long BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public long Price { get; set; }
        public long Year { get; set; }
        public long ReaderId { get; set; }
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
        public Book(string title, string author, string publisher, int price, int year, long readerId)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            Price = price;
            Year = year;
            ReaderId = readerId;            
        }
    }
}


using System;
using System.Collections.Generic;

namespace Lib_CourseWork
{
    public partial class Reader
    {
        public long ReaderId { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public List<Book> listBooks { get; private set; }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Reader()
        {
            Name = "Неизвестно";
            Phone = "Неизвестно";
            //ReaderId = 1; // 0?
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">ФИО читателя</param>
        /// <param name="phone">Номер телефона</param>
        public Reader(string name, string phone)
        {
            Name = name;
            Phone = phone;
            //ReaderId = readerId;
        }
        /*public static Reader operator +(Reader reader, Book book)
        {
            if (!reader.listBooks.Any(b => b.Title == book.Title
            && b.Publisher == book.Publisher))
            {
                reader.listBooks.Add(book);
            }
            else
            {
                MessageBox.Show(
                    "Книга уже существует. Нельзя добавлять одну и ту же книгу дважды",
                    "Ошибка добавления книги",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            return reader;
        }
        public static Reader operator -(Reader reader, Book book)
        {
            reader.listBooks.Remove(book);
            return reader;
        }*/
    }
}
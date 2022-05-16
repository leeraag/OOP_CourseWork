using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_CourseWork
{
    public class Reader
    {
        public int ReaderId { get; private set; }

        public string? Name { get; set; }

        public string? Phone { get; set; }

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
    }
}
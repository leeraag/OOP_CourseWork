using System;
using System.Collections.Generic;

namespace Lib_CourseWork
{
    public partial class Reader
    {
        public long ReaderId { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Reader()
        {
            Name = "Неизвестно";
            Phone = "Неизвестно";
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
        }
    }
}
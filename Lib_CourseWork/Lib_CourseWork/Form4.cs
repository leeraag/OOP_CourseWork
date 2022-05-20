using System.Data;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label1.ForeColor = Color.Red;
            }
            int selected = comboBox1.SelectedIndex; // 0-фио, 1-номер, 2-название, 3-автор, 4-издательство, 5-стоимость, 6-год
            string filter = textBox1.Text;

            string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$";
            string patternPhone = @"^((\+7|7|8)+([0-9]){10})$";
            string patternTitle = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            string patternPublisher = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            string patternNumeric = @"^[0-9]+$";

            using (libraryContext db = new libraryContext())
            {
                switch (selected)
                {
                    // Фио читателя
                    case 0:
                        if (Regex.IsMatch(filter, patternName))
                        {
                            var existNameReaders = (from reader in db.Readers
                                                      where reader.Name == filter
                                                      select reader).FirstOrDefault();
                            if (existNameReaders != null)
                            {
                                var readerNameFilter = (from reader in db.Readers
                                                        where reader.Name == filter
                                                        select reader).ToList();
                                foreach (Reader reader in readerNameFilter)
                                {
                                    Program.f1.dataGridView1.DataSource = readerNameFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите ФИО читателя в формате: Фамилия Имя Отчество");
                        }
                        return;
                    // Номер телефона
                    case 1:
                        if (Regex.IsMatch(filter, patternPhone)) {
                            var existPhoneReaders = (from reader in db.Readers
                                                      where reader.Phone == filter
                                                      select reader).FirstOrDefault();
                            if (existPhoneReaders != null)
                            {
                                var readerPhoneFilter = (from reader in db.Readers
                                                         where reader.Phone == filter
                                                         select reader).ToList();
                                foreach (Reader reader in readerPhoneFilter)
                                {
                                    Program.f1.dataGridView1.DataSource = readerPhoneFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите номер телефона в формате: +71112223344");
                        }
                        return;
                    // Название книги
                    case 2:
                        if (Regex.IsMatch(filter, patternTitle))
                        {
                            var existTitleBooks = (from book in db.Books
                                                      where book.Title == filter
                                                      select book).FirstOrDefault();
                            if (existTitleBooks != null)
                            {
                                var bookTitleFilter = (from book in db.Books
                                                       where book.Title == filter
                                                       select book).ToList();
                                foreach (Book book in bookTitleFilter)
                                {
                                    Program.f1.dataGridView2.DataSource = bookTitleFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное название книги");
                        }
                        return;
                    // Автор
                    case 3:
                        if (Regex.IsMatch(filter, patternName))
                        {
                            var existAuthorBooks = (from book in db.Books
                                                    where book.Author == filter
                                                    select book).FirstOrDefault();
                            if (existAuthorBooks != null)
                            {
                                var bookAuthorFilter = (from book in db.Books
                                                        where book.Author == filter
                                                        select book).ToList();
                                foreach (Book book in bookAuthorFilter)
                                {
                                    Program.f1.dataGridView2.DataSource = bookAuthorFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите ФИО автора в формате: Фамилия Имя Отчество");
                        }
                        return;
                    // Издательство
                    case 4:
                        if (Regex.IsMatch(filter, patternPublisher))
                        {
                            var existPublisherBooks = (from book in db.Books
                                                    where book.Publisher == filter
                                                    select book).FirstOrDefault();
                            if (existPublisherBooks != null)
                            {
                                var bookPublisherFilter = (from book in db.Books
                                                           where book.Publisher == filter
                                                           select book).ToList();
                                foreach (Book book in bookPublisherFilter)
                                {
                                    Program.f1.dataGridView2.DataSource = bookPublisherFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное название издательства");
                        }
                        return;
                    // Стоимость
                    case 5:
                        int filterPrice = Convert.ToInt32(filter);
                        if (Regex.IsMatch(filter, patternNumeric) && filterPrice > 0)
                        {
                            var existPriceBooks = (from book in db.Books
                                                       where book.Price == filterPrice
                                                       select book).FirstOrDefault();
                            if (existPriceBooks != null)
                            {
                                var bookPriceFilter = (from book in db.Books
                                                       where book.Price == filterPrice
                                                       select book).ToList();
                                foreach (Book book in bookPriceFilter)
                                {
                                    Program.f1.dataGridView2.DataSource = bookPriceFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное целочисленное значение стоимости");
                        }
                        return;
                    // Год издания
                    case 6:
                        int filterYear = Convert.ToInt32(filter);
                        if (Regex.IsMatch(filter, patternNumeric) && filterYear > 1799)
                        {
                            var existYearBooks = (from book in db.Books
                                                   where book.Year == filterYear
                                                   select book).FirstOrDefault();
                            if (existYearBooks != null)
                            {
                                var bookYearFilter = (from book in db.Books
                                                      where book.Year == filterYear
                                                      select book).ToList();
                                foreach (Book book in bookYearFilter)
                                {
                                    Program.f1.dataGridView2.DataSource = bookYearFilter;
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректный год");
                        }
                        return;
                }
            }
        }
    }
}
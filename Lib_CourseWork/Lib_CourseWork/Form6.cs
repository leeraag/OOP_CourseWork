using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form6 : Form
    {
        public Form6()
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
            int selected = comboBox1.SelectedIndex; // 0-читатели, 1-книги
            string search = textBox1.Text;
            using (libraryContext db = new libraryContext())
            {
                //SQLiteCommand commandReaders = new SQLiteCommand();
                //commandReaders.CommandText = "SELECT * FROM Readers WHERE Name != search AND Phone != search";
                //var conn = new SQLiteConnection("Data Source=library.db");
                //conn.Open();


                //SQLiteDataReader dataReader = commandReaders.ExecuteReader();
                //if (dataReader.HasRows)
                //{
                //   MessageBox.Show("Значение не найдено");
                //}
                //Regex regexText = new Regex(@"\w,[А-Я],[а-я],^\s");
                string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$"; // ????
                string patternPhone = @"^((\+7|7|8)+([0-9]){10})$";
                string patternTitle = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
                string patternPublisher = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
                string patternNumeric = @"^[0-9]+$";
                //try {
                switch (selected)
                {
                    case 0:
                        if (Regex.IsMatch(search, patternName) || Regex.IsMatch(search, patternPhone))
                        {
                            //int searchNumeric = Convert.ToInt32(search);
                            var existRecordReaders = (from reader in db.Readers
                                                      where reader.Name == search || reader.Phone == search
                                                      select reader).FirstOrDefault();
                            if (existRecordReaders != null)
                            {
                                var readerSearch = (from reader in db.Readers
                                                    where reader.Name == search || reader.Phone == search
                                                    select reader).ToList();
                                
                                    foreach (Reader reader in readerSearch)
                                    {
                                        Program.f1.dataGridView1.DataSource = readerSearch;
                                    }
                                
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else if (Regex.IsMatch(search, patternNumeric))
                        {
                            int searchNumeric = Convert.ToInt32(search);
                            var existRecordReaders = (from reader in db.Readers
                                                      where reader.ReaderId == searchNumeric
                                                      select reader).FirstOrDefault();
                            if (existRecordReaders != null)
                            {
                                var readerSearch = (from reader in db.Readers
                                                    where reader.ReaderId == searchNumeric
                                                    select reader).ToList();

                                foreach (Reader reader in readerSearch)
                                {
                                    Program.f1.dataGridView1.DataSource = readerSearch;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное значение");
                        }
                        return;

                    case 1:
                        if (Regex.IsMatch(search, patternNumeric))
                        {
                            int searchNumeric = Convert.ToInt32(search);
                            var existRecordBooks_numeric = (from book in db.Books
                                                               where book.Price == searchNumeric || book.Year == searchNumeric
                                                                 || book.ReaderId == searchNumeric || book.BookId == searchNumeric
                                                               select book).FirstOrDefault();
                            if (existRecordBooks_numeric != null)
                            {

                                var bookSearchNumeric = (from book in db.Books
                                                         where (book.Price == searchNumeric || book.Year == searchNumeric
                                                         || book.ReaderId == searchNumeric || book.BookId == searchNumeric)
                                                         select book).ToList();
                                foreach (Book book in bookSearchNumeric)
                                {
                                    Program.f1.dataGridView2.DataSource = bookSearchNumeric;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else if (Regex.IsMatch(search, patternTitle) || Regex.IsMatch(search, patternName)
                            || Regex.IsMatch(search, patternPublisher))
                        {
                            var notExistRecordBooks_text = (from book in db.Books
                                                            where book.Title == search || book.Author == search
                                                            || book.Publisher == search
                                                            select book).FirstOrDefault();
                            if (notExistRecordBooks_text != null)
                            {
                                var bookSearchText = (from book in db.Books
                                                         where book.Title == search || book.Author == search
                                                         || book.Publisher == search
                                                         select book).ToList();
                                foreach (Book book in bookSearchText)
                                {
                                    Program.f1.dataGridView2.DataSource = bookSearchText;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Запись не найдена");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное значение");
                        }
                            return;
                }
            }
            //this.Close();
        }
    }
}

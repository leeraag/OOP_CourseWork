using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string phone = textBox2.Text;
            string title = textBox3.Text;
            string author = textBox4.Text;
            string publisher = textBox5.Text;
            int price = (int)numericUpDown1.Value;
            int year = (int)numericUpDown2.Value;
            
                addRecord(name, phone, title, author, publisher, price, year);
        
                this.Close();
            //}
        }
        private void addRecord(string name, string phone, string title, string author,
            string publisher, int price, int year)
        {
            string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$";
            string patternPhone = @"^((\+7|7|8)+([0-9]){10})$";
            string patternTitle = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            string patternPublisher = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            using (libraryContext db = new libraryContext()) //Создание подключения 
            {
                // Добавление информации о читателе, обновление таблицы на главной форме
                if (!Regex.IsMatch(name, patternName))
                {
                    MessageBox.Show("Введите ФИО читателя в формате: Фамилия Имя Отчество");
                }
                else if (!Regex.IsMatch(phone, patternPhone))
                {
                    MessageBox.Show("Введите номер телефона в формате: +71112223344");
                }
                else if (!Regex.IsMatch(title, patternTitle))
                {
                    MessageBox.Show("Введите корректное название книги");
                }
                else if (!Regex.IsMatch(author, patternName))
                {
                    MessageBox.Show("Введите ФИО автора в формате: Фамилия Имя Отчество");
                }
                else if (!Regex.IsMatch(publisher, patternPublisher))
                {
                    MessageBox.Show("Введите корректное название издательства");
                }
                else if (name == "" || title == "" || phone == "" ||
                    author == "" || publisher == "" || price < 0 || year < 1800)
                {
                    MessageBox.Show(
                        "Заполните информацию",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    var conn = new SQLiteConnection("Data Source=library.db");
                    DataSet dsReaders = new DataSet();
                    string sqlReaders = "SELECT * FROM Readers";
                    DataSet dsBooks = new DataSet();
                    string sqlBooks = "SELECT * FROM Books";

                    SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn);
                    SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn);
                    try
                    {
                        Reader addingReader = new Reader(name, phone);
                        var existReader = (from reader in db.Readers
                                           where reader.Name == name && reader.Phone == phone
                                           select reader).FirstOrDefault();
                        if (existReader == null)
                        {
                            db.Readers.Add(addingReader);
                            db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                            long readerId = addingReader.ReaderId;
                            daReaders.Fill(dsReaders);
                            daReaders.Update(dsReaders);
                            Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;

                            Book book = new Book(title, author, publisher, price, year, readerId);
                            db.Books.Add(book);
                            db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                            daBooks.Fill(dsBooks);
                            daBooks.Update(dsBooks);
                            //addingReader += book; // добавляем книгу в список книг
                            Program.f1.dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                            //addingReader.listBooks.Add(book);
                        }
                        else
                        {
                            var existBook = (from book in db.Books
                                             where book.Title == title && book.Author == author
                                             && book.Publisher == publisher && book.Price == price
                                             && book.Year == year
                                             select book).FirstOrDefault();
                            if (existBook == null)
                            {
                                long readerId = existReader.ReaderId;
                                Book book = new Book(title, author, publisher, price, year, readerId);
                                db.Books.Add(book);
                                db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                                daBooks.Fill(dsBooks);
                                daBooks.Update(dsBooks);
                                //addingReader += book; // добавляем книгу в список книг
                                Program.f1.dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                                //addingReader.listBooks.Add(book);
                            }
                            else
                            {
                                MessageBox.Show("У читателя уже есть данная книга");
                            }
                        }
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException err)
                    {
                        //MessageBox.Show($"Error: {Microsoft.EntityFrameworkCore.DbUpdateException.Message}");
                    }
                }
            }
        }
    }
}

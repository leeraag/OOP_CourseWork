using System.Data;
using System.Data.SQLite;

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
            string name = textBox4.Text;
            string phone = maskedTextBox1.Text;
            string title = textBox1.Text;
            string author = textBox2.Text;
            string publisher = textBox3.Text;
            int price = (int)numericUpDown1.Value;
            int year = (int)numericUpDown2.Value;
            //string.IsNullOrEmpty()
            if (title == "" || author == "" || publisher == "" ||
                price < 0 || year < 1800 || name == "" || phone == "")
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
                addRecord(name, phone, title, author, publisher, price, year);
                MessageBox.Show(
                    "Информация добавлена",
                    "ОК",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
            }
        }
        private void addRecord(string name, string phone, string title, string author,
            string publisher, int price, int year)
        {
            using (libraryContext db = new libraryContext()) //Создание подключения 
            {
                // Добавление информации о читателе, обновление таблицы на главной форме

                var conn = new SQLiteConnection("Data Source=library.db"); DataSet dsReaders = new DataSet();
                string sqlReaders = "SELECT * FROM Readers";
                DataSet dsBooks = new DataSet();
                string sqlBooks = "SELECT * FROM Books";

                SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn);
                SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn);
                try
                {
                    Reader reader = new Reader(name, phone);

                    db.Readers.Add(reader);
                    db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                    long readerId = reader.ReaderId;
                    daReaders.Fill(dsReaders);
                    daReaders.Update(dsReaders);
                    //dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                    Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;

                    Book book = new Book(title, author, publisher, price, year, readerId);
                    db.Books.Add(book);
                    db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                    daBooks.Fill(dsBooks);
                    daBooks.Update(dsBooks);
                    Program.f1.dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                    //reader.listBooks.Add(book);
                    //reader += book;
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException err)
                {
                    //MessageBox.Show($"Error: {Microsoft.EntityFrameworkCore.DbUpdateException.Message}");
                }
            }
        }
    }
}

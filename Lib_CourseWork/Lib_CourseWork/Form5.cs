using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            Program.f5 = this; // Ссылка на форму Form5
            InitializeComponent();
        }
        private void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                label2.Visible = true;
                label5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                label5.Visible = true;
                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                label8.Visible = true;
                label11.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                label11.Visible = true;
                label14.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                label14.Visible = true;
            }
        }

        // заполнение таблицы при загрузке
        private void Form5_Load(object sender, EventArgs e)
        {
                DataSet dsBooks = new DataSet();
                string sqlBooks = "SELECT * FROM Books";
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=library.db"))
                    {

                        using (SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn))
                        {
                            daBooks.Fill(dsBooks);
                            dataGridView1.DataSource = dsBooks.Tables[0].DefaultView;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$";
            string patternTitle = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            string patternPublisher = @"^[а-яА-ЯёЁa-zA-Z0-9]+( [а-яА-ЯёЁa-zA-Z0-9]+)*$";
            using (libraryContext db = new libraryContext())
            {
                DataSet dsBooks = new DataSet();
                string sqlBooks = "SELECT * FROM Books";

                try
                {
                    using (var conn = new SQLiteConnection("Data Source=library.db"))
                    {

                        using (SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn))
                        {
                            Book? book = db.Books.FirstOrDefault(book => (book.Title == label2.Text &&
                            book.Author == label5.Text && book.Publisher == label8.Text
                            && book.Price == Convert.ToInt32(label11.Text) &&
                            book.Year == Convert.ToInt32(label14.Text)));
                            if (book != null)
                            {
                                book.Title = textBox1.Text;
                                book.Author = textBox2.Text;
                                book.Publisher = textBox3.Text;
                                book.Price = (int)numericUpDown1.Value;
                                book.Year = (int)numericUpDown2.Value;
                                if (!Regex.IsMatch(book.Title, patternTitle))
                                {
                                    MessageBox.Show("Введите корректное название книги");
                                }
                                else if (!Regex.IsMatch(book.Author, patternName))
                                {
                                    MessageBox.Show("Введите ФИО автора в формате: Фамилия Имя Отчество");
                                }
                                else if (!Regex.IsMatch(book.Publisher, patternPublisher))
                                {
                                    MessageBox.Show("Введите корректное название издательства");
                                }
                                else if (book.Title != "" && book.Title != label2.Text ||
                                    book.Author != "" && book.Author != label5.Text ||
                                    book.Publisher != "" && book.Publisher != label8.Text ||
                                    book.Price >= 0 && book.Price != Convert.ToInt32(label11.Text) ||
                                    book.Year >= 1800 && book.Year != Convert.ToInt32(label14.Text))
                                {
                                    //обновляем объект
                                    db.Books.Update(book);
                                    db.SaveChanges();
                                    daBooks.Fill(dsBooks);
                                    daBooks.Update(dsBooks);
                                    Program.f1.dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                                }
                                else
                                {
                                    MessageBox.Show("Измените информацию!");
                                }
                                Thread.Sleep(3000);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
    }
}

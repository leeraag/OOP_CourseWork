using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_CourseWork
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            Program.f5 = this; // теперь f5 будет ссылкой на форму Form5
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
                catch (Exception err)
                {
                }
            }

        private void button1_Click(object sender, EventArgs e)
        {
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
                                if (book.Title != "" && book.Title != label2.Text &&
                                    book.Author != "" && book.Author != label5.Text &&
                                    book.Publisher != "" && book.Publisher != label8.Text &&
                                    book.Price >= 0 && book.Price != Convert.ToInt32(label11.Text) &&
                                    book.Year >= 1800 && book.Year != Convert.ToInt32(label14.Text))
                                {
                                    //обновляем объект
                                    db.Books.Update(book);
                                    db.SaveChanges();
                                    daBooks.Fill(dsBooks);
                                    daBooks.Update(dsBooks);
                                    dataGridView1.DataSource = dsBooks.Tables[0].DefaultView;
                                    Program.f1.dataGridView1.DataSource = dsBooks.Tables[0].DefaultView;
                                }
                                else
                                {
                                    MessageBox.Show("Измените информацию!");
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                }
            }
            //button1.Text = "Сохранено";
        }
        // Кнопка закрыть
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

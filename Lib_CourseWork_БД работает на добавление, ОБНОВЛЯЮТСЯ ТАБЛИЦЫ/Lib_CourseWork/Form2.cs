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
                price == 0 || year == 0 || name == "" || phone == "")
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
                //label10.Visible = true;
                MessageBox.Show(
                    "Информация добавлена",
                    "ОК",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
            }
            using (ApplicationContext db = new ApplicationContext()) //Создание подключения 
            {
                DataSet dsReaders = new DataSet();
                string sqlReaders = "SELECT * FROM Readers";
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=libs.db"))
                    {

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(sqlReaders, conn))
                        {
                            Reader reader = new Reader(name, phone);
                            
                            db.Readers.Add(reader);
                            
                            db.SaveChanges(); //Чтобы добавленные объекты отправились в базу данных, нужно вызвать метод, сохраняющий изменения
                            da.Fill(dsReaders);
                            da.Update(dsReaders);
                            Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;  
                        }
                    }
                }
                catch (Exception err)
                {
                }

                Book book = new Book(title, author, publisher, price, year);
                db.Books.Add(book);
            }



        }
    }
}

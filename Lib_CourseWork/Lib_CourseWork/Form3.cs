using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            Program.f3 = this; // Cсылка на форму Form3
            InitializeComponent();
        }

        private void OnRowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                label1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                label1.Visible = true;
                label2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                label2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$"; // ????
            string patternPhone = @"^((\+7|7|8)+([0-9]){10})$";
            using (libraryContext db = new libraryContext())
            {
                DataSet dsReaders = new DataSet();
                string sqlReaders = "SELECT * FROM Readers";
                
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=library.db"))
                    {

                        using (SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn))
                        {
                            Reader? reader = db.Readers.FirstOrDefault(reader => (reader.Name == label1.Text
                            && reader.Phone == label2.Text));
                            if (reader != null)
                            {
                                reader.Name = textBox1.Text;
                                reader.Phone = textBox2.Text;
                                if (!Regex.IsMatch(reader.Name, patternName))
                                {
                                    MessageBox.Show("Введите ФИО читателя в формате: Фамилия Имя Отчество");
                                }
                                else if (!Regex.IsMatch(reader.Phone, patternPhone))
                                {
                                    MessageBox.Show("Введите номер телефона в формате: +71112223344");
                                }
                                else if (reader.Name != "" && reader.Name != label1.Text ||
                                        reader.Phone != "" && reader.Phone != label2.Text)
                                {
                                    //обновляем объект
                                    db.Readers.Update(reader);
                                    db.SaveChanges();
                                    daReaders.Fill(dsReaders);
                                    daReaders.Update(dsReaders);
                                    Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                                }
                                else
                                {
                                    MessageBox.Show("Измените информацию");
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

        private void Form3_Load(object sender, EventArgs e)
        {
            DataSet dsReaders = new DataSet();
            string sqlReaders = "SELECT * FROM Readers";
            try
            {
                using (var conn = new SQLiteConnection("Data Source=library.db"))
                {

                    using (SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn))
                    {
                        daReaders.Fill(dsReaders);
                        dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
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
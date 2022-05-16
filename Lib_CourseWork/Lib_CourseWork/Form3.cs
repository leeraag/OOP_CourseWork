using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;

namespace Lib_CourseWork
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            Program.f3 = this; // теперь f3 будет ссылкой на форму Form3
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
            using (ApplicationContext db = new ApplicationContext())
            {
                DataSet dsReaders = new DataSet();
                string sqlReaders = "SELECT * FROM Readers";
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=libs.db"))
                    {

                        using (SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn))
                        {
                            Reader? reader = db.Readers.FirstOrDefault(reader => (reader.Name == label1.Text &&
                            reader.Phone == label2.Text));
                            if (reader != null)
                            {
                                reader.Name = textBox1.Text;
                                reader.Phone = maskedTextBox1.Text;
                                //обновляем объект
                                db.Readers.Update(reader);
                                db.SaveChanges();
                                daReaders.Fill(dsReaders);
                                daReaders.Update(dsReaders);
                                dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                                Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;

                            }
                            else
                            {
                                MessageBox.Show("Clicked RowHeader!");
                            }
                            //daReaders.Update(dsReaders);
                            //dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                            //Program.f1.dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                        }
                        }
                        }
                    
                catch (Exception err)
                {
                }
            }
            button1.Text = "Сохранено";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DataSet dsReaders = new DataSet();
            string sqlReaders = "SELECT * FROM Readers";
            try
            {
                using (var conn = new SQLiteConnection("Data Source=libs.db"))
                {

                    using (SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn))
                    {
                        daReaders.Fill(dsReaders);
                        dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                    }
                }
            }
            catch (Exception err)
            {
            }
        }
    }
}

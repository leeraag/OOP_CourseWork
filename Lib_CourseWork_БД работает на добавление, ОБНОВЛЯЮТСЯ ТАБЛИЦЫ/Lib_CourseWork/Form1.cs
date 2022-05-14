using System;
using System.Windows.Forms;

//using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace Lib_CourseWork
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            Program.f1 = this; // ������ f1 ����� ������� �� ����� Form1
            InitializeComponent();
            MessageBox.Show(
                "�������� ������ '����������'\n������� �.�. 20��1",
                "�����������",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        // ������ "��������"
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        // ������ "�������������"
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            //form3.Show(this);
            form3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                DataSet dsReaders = new DataSet();
                string sqlReaders = "SELECT * FROM Readers";
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=libs.db"))
                    {

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(sqlReaders, conn))
                        {
                            da.Fill(dsReaders);
                            dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                        }
                    }
                }
                catch (Exception err)
                {
                }
                DataSet dsBooks = new DataSet();
                string sqlBooks = "SELECT * FROM Books";
                try
                {
                    using (var conn = new SQLiteConnection("Data Source=libs.db"))
                    {

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(sqlBooks, conn))
                        {
                            da.Fill(dsBooks);
                            dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                        }
                    }
                }
                catch (Exception err)
                {
                }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext()) //�������� ����������� 
            {
                /*Reader? reader = db.Readers.FirstOrDefault();
                if (reader != null)
                {
                    //������� ������
                    db.Readers.Remove(reader);
                    db.SaveChanges();
                }*/
            }
        }
    }
}
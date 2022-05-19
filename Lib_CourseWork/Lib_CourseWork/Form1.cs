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
            /*MessageBox.Show(
                "�������� ������ '����������'\n������� �.�. 20��1",
                "�����������",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);*/
        }
        // ��������
        private void OnRowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "�������?",
                "�������� ������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                //MessageBox.Show("������ �������?");
                using (libraryContext db = new libraryContext())
                {
                    DataSet dsReaders = new DataSet();
                    string sqlReaders = "SELECT * FROM Readers";
                    DataSet dsBooks = new DataSet();
                    string sqlBooks = "SELECT * FROM Books";
                    var conn = new SQLiteConnection("Data Source=library.db");
                    SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn);
                    SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn);
                    try
                    {
                        string deletingName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string deletingPhone = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        string deletingTitle = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        string deletingAuthor = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                        string deletingPublisher = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                        int deletingPrice = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value);
                        int deletingYear = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[5].Value);

                        Reader? deletingReader = db.Readers.FirstOrDefault(dReader => (dReader.Name == deletingName &&
                            dReader.Phone == deletingPhone));
                        if (deletingReader != null)
                        {
                            long readerId = deletingReader.ReaderId;
                            var deletingBooks = (from book in db.Books
                                                 where book.ReaderId == readerId
                                                 select book).ToList();
                            //if (deletingBooks != null)
                            //{
                            // var lib in libraries
                            foreach (var delBook in deletingBooks)
                            {
                                db.Books.Remove(delBook);
                                db.SaveChanges();
                                daBooks.Fill(dsBooks);
                                daBooks.Update(dsBooks);
                                dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                            }
                            db.Readers.Remove(deletingReader);
                            db.SaveChanges();
                            daReaders.Fill(dsReaders);
                            daReaders.Update(dsReaders);
                            dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                            //deletingReader.listBooks.Clear();
                            //}
                        }
                        

                        Book? deletingBook = db.Books.FirstOrDefault(dBook => (dBook.Title == deletingTitle &&
                            dBook.Author == deletingAuthor && dBook.Publisher == deletingPublisher
                            && dBook.Price == deletingPrice && dBook.Year == deletingYear));
                        if (deletingBook != null)
                        {
                            db.Books.Remove(deletingBook);
                            db.SaveChanges();
                            daBooks.Fill(dsBooks);
                            daBooks.Update(dsBooks);
                            dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                            //deletingBook -= book
                            //if (reader)
                            /*
                             if (demoLibrary.Books.All(b => b.Title != name))
            {
                MessageBox.Show(
                    "����� �� �������! �������� �� ������� �������� � ��������",
                    "������ �������� �����",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            demoLibrary -= demoLibrary.Books.Single(b => b.Title == name);
                             */
                        }
                    }
                    catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                    //catch (Exception err)
                    {
                        MessageBox.Show($"Error: {argumentOutOfRangeException.Message}");
                    }
                }
            }
        }
        
        // ������ "��������"
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // ������ "������������� ������ ��������"
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            //form3.Show(this);
            form3.ShowDialog();
        }
        
        // ������ "�����������"
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (libraryContext db = new libraryContext()) //�������� ����������� 
            {
                /*Reader? reader = db.Readers.FirstOrDefault();
                if (reader != null)
                {
                    //������� ������
                    db.Readers.Remove(reader);
                    db.SaveChanges();
                }*/
                DialogResult exit = MessageBox.Show(
                "�����?",
                "�����",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
                if (exit == DialogResult.No) //???
                {
                    this.Close();
                }
                else
                {
                    // ��� ������� messagebox?
                }
            }
        }

        // ������ "������������� ������ �����"
        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        // ������ �������� ������
        private void button4_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        // ������ �����
        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        // ���������� ������
        private void fillDataGrid()
        {
            DataSet dsReaders = new DataSet();
            string sqlReaders = "SELECT * FROM Readers";
            DataSet dsBooks = new DataSet();
            string sqlBooks = "SELECT * FROM Books";
            var conn = new SQLiteConnection("Data Source=library.db");
            SQLiteDataAdapter daReaders = new SQLiteDataAdapter(sqlReaders, conn);
            SQLiteDataAdapter daBooks = new SQLiteDataAdapter(sqlBooks, conn);
                try
                {
                    daReaders.Fill(dsReaders);
                    dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                    daBooks.Fill(dsBooks);
                    dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                }
                catch (Exception err)
                {
                }
            }
        // ������ �������� �����
        private void button7_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }
        // ���������� �� ����������� ����
        private void button8_Click(object sender, EventArgs e)
        {
            using (libraryContext db = new libraryContext()) //�������� ����������� 
            {
                var bookPriceSort = (from book in db.Books
                                     orderby book.Price ascending
                                     select book).ToList();
                foreach (Book book in bookPriceSort)
                {
                    dataGridView2.DataSource = bookPriceSort;
                }
            }
        }
        // ���������� �� �������� ����
        private void button9_Click(object sender, EventArgs e)
        {
            using (libraryContext db = new libraryContext()) //�������� ����������� 
            {
                var bookPriceSort = (from book in db.Books
                                     orderby book.Price descending
                                     select book).ToList();
                foreach (Book book in bookPriceSort)
                {
                    dataGridView2.DataSource = bookPriceSort;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }
    }
}
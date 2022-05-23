using System.Data;
using System.Data.SQLite;

namespace Lib_CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Program.f1 = this; // ������ �� ����� Form1
            InitializeComponent();
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

        // ����� - ������� �� �������
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("������ �����?", "�����",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
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

        /// <summary>
        /// ����� ��� ���������� ������
        /// </summary>
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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
        /// <summary>
        /// ������� �� �������� ����� ����� ��������� ������ ������� "��������"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteReader(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "�������?",
                "�������� ������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                using (libraryContext db = new libraryContext())
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
                        long deletingReaderId = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        var deletingReader = db.Readers.Find(deletingReaderId);
                        // ���� �������� ����������
                        if (deletingReader != null)
                        {
                            long readerId = deletingReader.ReaderId;
                            var readersBooks = db.Books.Where(book => book.ReaderId == readerId).ToList();
                            // ���� � �������� ���� �����
                            if (readersBooks.Count > 0)
                            {
                                // ������� ��� ��� �����
                                foreach (var delBook in readersBooks)
                                {
                                    db.Books.Remove(delBook);
                                    db.SaveChanges();
                                    daBooks.Fill(dsBooks);
                                    daBooks.Update(dsBooks);
                                }
                            }
                            // ������� ��������
                            db.Readers.Remove(deletingReader);
                            db.SaveChanges();
                            daReaders.Fill(dsReaders);
                            daReaders.Update(dsReaders);
                            dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                            dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("�������� �� ����������");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// ������� �� �������� ����� ����� ��������� ������ ������� "�����"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBook(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "�������?",
                "�������� ������",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                using (libraryContext db = new libraryContext())
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
                        long deletingBookId = Convert.ToInt64(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                        var deletingBook = db.Books.Find(deletingBookId);
                        // ���� ��������� ����� ����������
                        if (deletingBook != null)
                        {
                            // ���� �� �������� � �����
                            var readerDelBook = db.Readers.Find(deletingBook.ReaderId);
                            if (readerDelBook != null && readerDelBook != default)
                            {
                                //readerDelBook.listBooks.Remove(deletingBook);
                                db.Books.Remove(deletingBook);
                                db.SaveChanges();
                                daBooks.Fill(dsBooks);
                                daBooks.Update(dsBooks);
                            }
                            dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("����� �� ����������");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}, {ex.StackTrace}");
                    }
                }
            }
        }
    }
}
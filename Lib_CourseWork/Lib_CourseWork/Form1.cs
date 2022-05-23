using System.Data;
using System.Data.SQLite;

namespace Lib_CourseWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Program.f1 = this; // ссылка на форму Form1
            InitializeComponent();
        }

        // Кнопка "Добавить"
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        // Кнопка "Редактировать данные читателя"
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            //form3.Show(this);
            form3.ShowDialog();
        }

        // Кнопка "Фильтровать"
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        // Выход - нажатие на крестик
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Хотите выйти?", "Выход",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
        }

        // Кнопка "Редактировать данные книги"
        private void button5_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        // кнопка сбросить фильтр
        private void button4_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        // Кнопка поиск
        private void button6_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        /// <summary>
        /// Метод для заполнения таблиц
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

        // кнопка сбросить поиск
        private void button7_Click(object sender, EventArgs e)
        {
            fillDataGrid();
        }

        // Сортировка по возрастанию цены
        private void button8_Click(object sender, EventArgs e)
        {
            using (libraryContext db = new libraryContext()) //Создание подключения 
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

        // Сортировка по убыванию цены
        private void button9_Click(object sender, EventArgs e)
        {
            using (libraryContext db = new libraryContext()) //Создание подключения 
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
        /// Событие по двойному клику около заголовка строки таблицы "Читатели"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteReader(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Удалить?",
                "Удаление записи",
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
                        // если читатель существует
                        if (deletingReader != null)
                        {
                            long readerId = deletingReader.ReaderId;
                            var readersBooks = db.Books.Where(book => book.ReaderId == readerId).ToList();
                            // если у читателя есть книги
                            if (readersBooks.Count > 0)
                            {
                                // удаляем все его книги
                                foreach (var delBook in readersBooks)
                                {
                                    db.Books.Remove(delBook);
                                    db.SaveChanges();
                                    daBooks.Fill(dsBooks);
                                    daBooks.Update(dsBooks);
                                }
                            }
                            // удаляем читателя
                            db.Readers.Remove(deletingReader);
                            db.SaveChanges();
                            daReaders.Fill(dsReaders);
                            daReaders.Update(dsReaders);
                            dataGridView1.DataSource = dsReaders.Tables[0].DefaultView;
                            dataGridView2.DataSource = dsBooks.Tables[0].DefaultView;
                        }
                        else
                        {
                            MessageBox.Show("Читателя не существует");
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
        /// Событие по двойному клику около заголовка строки таблицы "Книги"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBook(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialog = MessageBox.Show(
                "Удалить?",
                "Удаление записи",
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
                        // если удаляемая книга существует
                        if (deletingBook != null)
                        {
                            // есть ли читатель у книги
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
                            MessageBox.Show("Книга не существует");
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
using System.Data;

namespace Lib_CourseWork
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label2.ForeColor = Color.Red;
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label1.ForeColor = Color.Red;
            }
            
            int selected = comboBox1.SelectedIndex; // 0-фио, 1-номер, 2-название, 3-автор, 4-издательство, 5-стоимость, 6-год
            string filter = textBox1.Text;
            using (ApplicationContext db = new ApplicationContext())
            {
                switch (selected)
                {
                    // Фио читателя
                    case 0:
                        var readerNameFilter = (from reader in db.Readers
                                          where reader.Name == filter
                                          select reader).ToList();
                        foreach (Reader reader in readerNameFilter)
                        {
                            Program.f1.dataGridView1.DataSource = readerNameFilter;
                        }
                        return;
                    // Номер телефона
                    case 1:
                        var readerPhoneFilter = (from reader in db.Readers
                                           where reader.Phone == filter
                                           select reader).ToList();
                        foreach (Reader reader in readerPhoneFilter)
                        {
                            Program.f1.dataGridView1.DataSource = readerPhoneFilter;
                        }
                        return;
                    // Название книги
                    case 2:
                        var bookTitleFilter = (from book in db.Books
                                         where book.Title == filter
                                         select book).ToList();
                        foreach (Book book in bookTitleFilter)
                        {
                            Program.f1.dataGridView2.DataSource = bookTitleFilter;
                        }
                        return;
                    // Автор
                    case 3:
                        var bookAuthorFilter = (from book in db.Books
                                          where book.Author == filter
                                          select book).ToList();
                        foreach (Book book in bookAuthorFilter)
                        {
                            Program.f1.dataGridView2.DataSource = bookAuthorFilter;
                        }
                        return;
                    // Издательство
                    case 4:
                        var bookPublisherFilter = (from book in db.Books
                                             where book.Publisher == filter
                                             select book).ToList();
                        foreach (Book book in bookPublisherFilter)
                        {
                            Program.f1.dataGridView2.DataSource = bookPublisherFilter;
                        }
                        return;
                    // Стоимость
                    case 5:
                        int filterPrice = Convert.ToInt32(filter);
                        var bookPriceFilter = (from book in db.Books
                                             where book.Price == filterPrice
                                             select book).ToList();
                        foreach (Book book in bookPriceFilter)
                        {
                            Program.f1.dataGridView2.DataSource = bookPriceFilter;
                        }
                        return;
                    // Год издания
                    case 6:
                        int filterYear = Convert.ToInt32(filter);
                        var bookYearFilter = (from book in db.Books
                                        where book.Price == filterYear
                                        select book).ToList();
                        foreach (Book book in bookYearFilter)
                        {
                            Program.f1.dataGridView2.DataSource = bookYearFilter;
                        }
                        return;
                }
            }
            //this.Close();
        }
    }
    //this.Close();
}
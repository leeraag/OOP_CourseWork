using System.Data;
using System.Text.RegularExpressions;

namespace Lib_CourseWork
{
    public partial class Form6 : Form
    {
        public Form6()
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
            int selected = comboBox1.SelectedIndex; // 0-читатели, 1-книги
            string search = textBox1.Text;
            using (libraryContext db = new libraryContext())
            {
                //Regex regexText = new Regex(@"\w,[А-Я],[а-я],^\s");
                string patternName = @"^[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+ ?[а-яА-ЯёЁa-zA-Z]+$"; // ????
                string patternPhone = @"^((\+7|7|8)+([0-9]){10})$";
                string patternNumber = @"\d";
                switch (selected)
                {
                    case 0:
                        if (Regex.IsMatch(search, patternName))
                        {
                            var readerSearch = (from reader in db.Readers
                                                where reader.Name == search
                                                select reader).ToList();
                            foreach (Reader reader in readerSearch)
                            {
                                Program.f1.dataGridView1.DataSource = readerSearch;
                            }
                        }
                        else if (Regex.IsMatch(search, patternPhone))
                        {
                            var readerSearch = (from reader in db.Readers
                                                where reader.Phone == search
                                                select reader).ToList();
                            foreach (Reader reader in readerSearch)
                            {
                                Program.f1.dataGridView1.DataSource = readerSearch;
                            }
                        }
                        return;
                            
                    case 1:
                        if (Regex.IsMatch(search, patternNumber)) {
                            int searchNumeric = Convert.ToInt32(search);
                            var bookSearchNumeric = (from book in db.Books
                                                     where (book.Price == searchNumeric || book.Year == searchNumeric
                                                     || book.ReaderId == searchNumeric || book.BookId == searchNumeric)
                                                     select book).ToList();
                            foreach (Book book in bookSearchNumeric)
                            {
                                Program.f1.dataGridView2.DataSource = bookSearchNumeric;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное значение");
                        }
                        /*bool numericResult = int.TryParse(search, out var numericSearch);
                        if (numericResult == true)
                        {
                            var bookSearchNumeric = (from book in db.Books
                                                     where (book.Price == numericSearch ||
                                                     book.Year == numericSearch || book.ReaderId == numericSearch ||
                                                     book.BookId == numericSearch)
                                                     select book).ToList();
                            foreach (Book book in bookSearchNumeric)
                            {
                                Program.f1.dataGridView2.DataSource = bookSearchNumeric;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное значение");
                        }*/
                        /*if (Regex.IsMatch(search, patternText))
                        {
                            var bookSearchString = (from book in db.Books
                                                    where (book.Title == search || book.Author == search ||
                                                    book.Publisher == search)
                                                    select book).ToList();
                            foreach (Book book in bookSearchString)
                            {
                                Program.f1.dataGridView2.DataSource = bookSearchString;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректное значение");
                        }*/
                        return;
                }
            }
            //this.Close();
        }
        public static bool OnlyLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}

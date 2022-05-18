using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                label1.ForeColor = Color.Red;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                label2.ForeColor = Color.Red;
            }
            int selected = comboBox1.SelectedIndex; // 0-читатели, 1-книги
            string search = textBox1.Text;
            using (libraryContext db = new libraryContext())
            { 
                switch(selected)
                {
                    case 0:
                        var readerSearch = (from reader in db.Readers
                                                where (reader.Name == search ||
                                                reader.Phone == search)
                                                select reader).ToList();
                        foreach (Reader reader in readerSearch)
                        {
                            Program.f1.dataGridView1.DataSource = readerSearch;
                        }
                        return;
                    /*case 1:
                        int searchPrice = Convert.ToInt32(search);
                        int searchYear = Convert.ToInt32(search);
                        var bookSearch = (from book in db.Books
                                          where (book.Title == search || book.Author == search ||
                                          book.Publisher == search || book.Price == searchPrice ||
                                          book.Year == searchYear)
                                          select book).ToList();
                        foreach (Book book in bookSearch)
                        {
                            Program.f1.dataGridView2.DataSource = bookSearch;
                        }
                        return;*/
                }
            }
            //this.Close();
        }
    }
}

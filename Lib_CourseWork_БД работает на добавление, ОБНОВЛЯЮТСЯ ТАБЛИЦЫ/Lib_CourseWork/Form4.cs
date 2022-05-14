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
                    case 0:
                    //var reader = db.Readers.Where(r => r.Name == filter);
                    var readerName = from reader in db.Readers
                                     where reader.Name == filter
                                     select reader;
                        // сделать коллекцию из этих объектов??
                    //foreach (var reader in readers)
                    return;
                    case 1:
                        var readerPhone = (from reader in db.Readers
                                       where reader.Phone == filter
                                       select reader).ToList();
                        //foreach(var reader in readerPhone)
                        return;
                    case 2:
                        var bookTitle = (from book in db.Books
                                           where book.Title == filter
                                           select book).ToList();
                        return;
                    case 3:
                        var bookAuthor = (from book in db.Books
                                         where book.Author == filter
                                         select book).ToList();
                        return;
                    case 4:
                        var bookPublisher = (from book in db.Books
                                          where book.Publisher == filter
                                          select book).ToList();
                        return;
                    /*case 5:
                        int filterPrice = Convert.ToInt32(filter);
                        var bookPrice = (from book in db.Books
                                             where book.Price == filterPrice
                                             select book).ToList();
                        return;*/
                    case 6:
                        int filterYear = Convert.ToInt32(filter);
                        var bookYear = (from book in db.Books
                                         where book.Price == filterYear
                                         select book).ToList();
                        return;
                }
            }
        }
    }
}

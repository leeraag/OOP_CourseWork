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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form3 form2 = (Form3)Owner;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                numericUpDown1.Value == 0 || numericUpDown2.Value == 0 || textBox4.Text == "" ||
                maskedTextBox1.Text == "")
            {
                MessageBox.Show(
                    "Заполните информацию",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
            /*else if (textBox1.Text == form2.textBox1.Text || textBox2.Text == form2.textBox2.Text ||
                textBox3.Text == form2.textBox3.Text || numericUpDown1.Value == form2.numericUpDown1.Value ||
                numericUpDown2.Value == form2.numericUpDown2.Value || textBox4.Text == form2.textBox4.Text ||
                maskedTextBox1.Text == form2.maskedTextBox1.Text)
            {
                MessageBox.Show(
                    "Измените информацию",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }*/
            else
            {
                //label10.Visible = true;
                MessageBox.Show(
                    "Информация изменена",
                    "ОК",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                this.Close();
            }
        }
    }
}

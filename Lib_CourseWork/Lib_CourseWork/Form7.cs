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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer1.Interval = 5000;
            
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            closingBox();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            closingBox();
        }

        /// <summary>
        /// Метод для закрытия окна приветствия
        /// </summary>
        private void closingBox()
        {
            timer1.Enabled = false;
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}

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
            timer1.Interval = 10000;
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

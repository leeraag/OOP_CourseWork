namespace Lib_CourseWork
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReaderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(227, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 31);
            this.textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookID,
            this.BookTitle,
            this.BookAuthor,
            this.BookPublisher,
            this.BookPrice,
            this.BookYear,
            this.ReaderID});
            this.dataGridView1.Location = new System.Drawing.Point(444, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 364);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnRowHeaderMouseClick);
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Новое название:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Автор:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Новый автор:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Издательство:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(227, 172);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 31);
            this.textBox2.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "label8";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 25);
            this.label9.TabIndex = 12;
            this.label9.Text = "Новое издательство:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(227, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(150, 31);
            this.textBox3.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 25);
            this.label10.TabIndex = 14;
            this.label10.Text = "Цена:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(236, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "label11";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 366);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 25);
            this.label12.TabIndex = 16;
            this.label12.Text = "Новая цена:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 418);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 25);
            this.label13.TabIndex = 18;
            this.label13.Text = "Год издания:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(236, 418);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 25);
            this.label14.TabIndex = 19;
            this.label14.Text = "label14";
            this.label14.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 461);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(177, 25);
            this.label15.TabIndex = 20;
            this.label15.Text = "Новый год издания:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(444, 427);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 65);
            this.button1.TabIndex = 22;
            this.button1.Text = "Сохранить изменения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 427);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 65);
            this.button2.TabIndex = 23;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(227, 366);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(150, 31);
            this.numericUpDown1.TabIndex = 24;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(227, 461);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(150, 31);
            this.numericUpDown2.TabIndex = 25;
            this.numericUpDown2.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // BookID
            // 
            this.BookID.DataPropertyName = "BookId";
            this.BookID.Frozen = true;
            this.BookID.HeaderText = "ID книги";
            this.BookID.MinimumWidth = 8;
            this.BookID.Name = "BookID";
            this.BookID.ReadOnly = true;
            this.BookID.Width = 130;
            // 
            // BookTitle
            // 
            this.BookTitle.DataPropertyName = "Title";
            this.BookTitle.Frozen = true;
            this.BookTitle.HeaderText = "Название";
            this.BookTitle.MinimumWidth = 8;
            this.BookTitle.Name = "BookTitle";
            this.BookTitle.ReadOnly = true;
            this.BookTitle.Width = 190;
            // 
            // BookAuthor
            // 
            this.BookAuthor.DataPropertyName = "Author";
            this.BookAuthor.Frozen = true;
            this.BookAuthor.HeaderText = "Автор";
            this.BookAuthor.MinimumWidth = 8;
            this.BookAuthor.Name = "BookAuthor";
            this.BookAuthor.ReadOnly = true;
            this.BookAuthor.Width = 190;
            // 
            // BookPublisher
            // 
            this.BookPublisher.DataPropertyName = "Publisher";
            this.BookPublisher.Frozen = true;
            this.BookPublisher.HeaderText = "Издательство";
            this.BookPublisher.MinimumWidth = 8;
            this.BookPublisher.Name = "BookPublisher";
            this.BookPublisher.ReadOnly = true;
            this.BookPublisher.Width = 180;
            // 
            // BookPrice
            // 
            this.BookPrice.DataPropertyName = "Price";
            this.BookPrice.Frozen = true;
            this.BookPrice.HeaderText = "Стоимость";
            this.BookPrice.MinimumWidth = 8;
            this.BookPrice.Name = "BookPrice";
            this.BookPrice.ReadOnly = true;
            this.BookPrice.Width = 130;
            // 
            // BookYear
            // 
            this.BookYear.DataPropertyName = "Year";
            this.BookYear.Frozen = true;
            this.BookYear.HeaderText = "Год издания";
            this.BookYear.MinimumWidth = 8;
            this.BookYear.Name = "BookYear";
            this.BookYear.ReadOnly = true;
            this.BookYear.Width = 130;
            // 
            // ReaderID
            // 
            this.ReaderID.DataPropertyName = "ReaderId";
            this.ReaderID.Frozen = true;
            this.ReaderID.HeaderText = "ID читателя";
            this.ReaderID.MinimumWidth = 8;
            this.ReaderID.Name = "ReaderID";
            this.ReaderID.ReadOnly = true;
            this.ReaderID.Width = 130;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1627, 513);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Редактировать данные книги";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        public TextBox textBox1;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private Label label8;
        private Label label9;
        private TextBox textBox3;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Button button1;
        private Button button2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private DataGridViewTextBoxColumn BookID;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn BookAuthor;
        private DataGridViewTextBoxColumn BookPublisher;
        private DataGridViewTextBoxColumn BookPrice;
        private DataGridViewTextBoxColumn BookYear;
        private DataGridViewTextBoxColumn ReaderID;
    }
}
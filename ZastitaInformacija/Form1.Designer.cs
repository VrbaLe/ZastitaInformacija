namespace ZastitaInformacija
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            txtKey2 = new TextBox();
            txtKey1 = new TextBox();
            groupBox3 = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            textBox3 = new TextBox();
            label1 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            txtLea = new TextBox();
            button4 = new Button();
            groupBox4 = new GroupBox();
            button8 = new Button();
            btnStopWatching = new Button();
            btnStartWatching = new Button();
            button5 = new Button();
            listBox1 = new ListBox();
            txtOutputDir = new TextBox();
            txtTargetDir = new TextBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            groupBox5 = new GroupBox();
            button6 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(23, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 80);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Izaberite algoritam";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(263, 38);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(101, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "LEA+PCBC";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(171, 38);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(56, 24);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "LEA";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 38);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(149, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Foursquare chiper";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(txtKey2);
            groupBox2.Controls.Add(txtKey1);
            groupBox2.Location = new Point(23, 98);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(337, 113);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Generisi kljuc za Foursquare";
            // 
            // button1
            // 
            button1.Location = new Point(240, 53);
            button1.Name = "button1";
            button1.Size = new Size(81, 28);
            button1.TabIndex = 2;
            button1.Text = "Generisi";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtKey2
            // 
            txtKey2.Location = new Point(6, 70);
            txtKey2.Name = "txtKey2";
            txtKey2.Size = new Size(221, 27);
            txtKey2.TabIndex = 1;
            // 
            // txtKey1
            // 
            txtKey1.Location = new Point(6, 37);
            txtKey1.Name = "txtKey1";
            txtKey1.Size = new Size(221, 27);
            txtKey1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(textBox3);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(radioButton2);
            groupBox3.Controls.Add(radioButton1);
            groupBox3.Location = new Point(23, 217);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(385, 240);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Klasicno kodiranje";
            // 
            // button3
            // 
            button3.Location = new Point(39, 177);
            button3.Name = "button3";
            button3.Size = new Size(138, 31);
            button3.TabIndex = 5;
            button3.Text = "Kodiraj/Dekodiraj";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(263, 127);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Browse";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(27, 127);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(221, 27);
            textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 93);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(92, 20);
            label1.TabIndex = 2;
            label1.Text = "Izaberite fajl";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(150, 41);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(111, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Dekodiranje";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(27, 41);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(94, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Kodiranje";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtLea
            // 
            txtLea.Location = new Point(6, 53);
            txtLea.Name = "txtLea";
            txtLea.Size = new Size(242, 27);
            txtLea.TabIndex = 3;
            // 
            // button4
            // 
            button4.Location = new Point(254, 54);
            button4.Name = "button4";
            button4.Size = new Size(81, 27);
            button4.TabIndex = 4;
            button4.Text = "Generisi";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(btnStopWatching);
            groupBox4.Controls.Add(btnStartWatching);
            groupBox4.Controls.Add(button5);
            groupBox4.Controls.Add(listBox1);
            groupBox4.Controls.Add(txtOutputDir);
            groupBox4.Controls.Add(txtTargetDir);
            groupBox4.Controls.Add(radioButton4);
            groupBox4.Controls.Add(radioButton3);
            groupBox4.Location = new Point(502, 217);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(484, 356);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "FSW";
            // 
            // button8
            // 
            button8.Location = new Point(325, 315);
            button8.Name = "button8";
            button8.Size = new Size(94, 27);
            button8.TabIndex = 8;
            button8.Text = "Browse";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // btnStopWatching
            // 
            btnStopWatching.Location = new Point(325, 236);
            btnStopWatching.Name = "btnStopWatching";
            btnStopWatching.Size = new Size(94, 27);
            btnStopWatching.TabIndex = 7;
            btnStopWatching.Text = "Stop";
            btnStopWatching.UseVisualStyleBackColor = true;
            btnStopWatching.Click += btnStopWatching_Click;
            // 
            // btnStartWatching
            // 
            btnStartWatching.Location = new Point(325, 180);
            btnStartWatching.Name = "btnStartWatching";
            btnStartWatching.Size = new Size(94, 27);
            btnStartWatching.TabIndex = 6;
            btnStartWatching.Text = "Nadgledaj";
            btnStartWatching.UseVisualStyleBackColor = true;
            btnStartWatching.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(325, 98);
            button5.Name = "button5";
            button5.Size = new Size(94, 27);
            button5.TabIndex = 5;
            button5.Text = "Browse";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(31, 139);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(243, 164);
            listBox1.TabIndex = 4;
            // 
            // txtOutputDir
            // 
            txtOutputDir.Location = new Point(31, 315);
            txtOutputDir.Name = "txtOutputDir";
            txtOutputDir.Size = new Size(243, 27);
            txtOutputDir.TabIndex = 3;
            // 
            // txtTargetDir
            // 
            txtTargetDir.Location = new Point(31, 98);
            txtTargetDir.Name = "txtTargetDir";
            txtTargetDir.Size = new Size(243, 27);
            txtTargetDir.TabIndex = 2;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(163, 53);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(111, 24);
            radioButton4.TabIndex = 1;
            radioButton4.TabStop = true;
            radioButton4.Text = "Dekodiranje";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(31, 53);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(94, 24);
            radioButton3.TabIndex = 0;
            radioButton3.TabStop = true;
            radioButton3.Text = "Kodiranje";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtLea);
            groupBox5.Controls.Add(button4);
            groupBox5.Location = new Point(412, 98);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(355, 113);
            groupBox5.TabIndex = 6;
            groupBox5.TabStop = false;
            groupBox5.Text = "Generisite kljuc za LEA";
            // 
            // button6
            // 
            button6.Location = new Point(429, 28);
            button6.Name = "button6";
            button6.Size = new Size(119, 46);
            button6.TabIndex = 7;
            button6.Text = "Socket";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 602);
            Controls.Add(button6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private GroupBox groupBox2;
        private TextBox txtKey2;
        private TextBox txtKey1;
        private GroupBox groupBox3;
        private Button button1;
        private Button button3;
        private Button button2;
        private TextBox textBox3;
        private Label label1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox txtLea;
        private Button button4;
        private GroupBox groupBox4;
        private TextBox txtOutputDir;
        private TextBox txtTargetDir;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private GroupBox groupBox5;
        private ListBox listBox1;
        private Button button8;
        private Button btnStopWatching;
        private Button btnStartWatching;
        private Button button5;
        private Button button6;
    }
}

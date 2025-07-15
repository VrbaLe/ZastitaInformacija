namespace ZastitaInformacija
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            openFileDialog1 = new OpenFileDialog();
            tabControl1 = new TabControl();
            Server = new TabPage();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            Client = new TabPage();
            groupBox1 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            textBox4 = new TextBox();
            button3 = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            bindingSource1 = new BindingSource(components);
            tabControl1.SuspendLayout();
            Server.SuspendLayout();
            Client.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Server);
            tabControl1.Controls.Add(Client);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(545, 481);
            tabControl1.TabIndex = 0;
            // 
            // Server
            // 
            Server.Controls.Add(button2);
            Server.Controls.Add(button1);
            Server.Controls.Add(label1);
            Server.Controls.Add(textBox1);
            Server.Location = new Point(4, 29);
            Server.Name = "Server";
            Server.Padding = new Padding(3);
            Server.Size = new Size(537, 448);
            Server.TabIndex = 0;
            Server.Text = "Server";
            Server.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(322, 264);
            button2.Name = "button2";
            button2.Size = new Size(100, 55);
            button2.TabIndex = 3;
            button2.Text = "Prekini osluskivanje";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(96, 264);
            button1.Name = "button1";
            button1.Size = new Size(102, 55);
            button1.TabIndex = 2;
            button1.Text = "Pokreni osluskivanje";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 113);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 1;
            label1.Text = "Port:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(197, 110);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 27);
            textBox1.TabIndex = 0;
            // 
            // Client
            // 
            Client.Controls.Add(groupBox1);
            Client.Controls.Add(button5);
            Client.Controls.Add(button4);
            Client.Controls.Add(textBox4);
            Client.Controls.Add(button3);
            Client.Controls.Add(textBox3);
            Client.Controls.Add(textBox2);
            Client.Controls.Add(label3);
            Client.Controls.Add(label2);
            Client.Location = new Point(4, 29);
            Client.Name = "Client";
            Client.Padding = new Padding(3);
            Client.Size = new Size(537, 448);
            Client.TabIndex = 1;
            Client.Text = "Client";
            Client.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Location = new Point(13, 275);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(288, 125);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // button6
            // 
            button6.Location = new Point(6, 26);
            button6.Name = "button6";
            button6.Size = new Size(106, 29);
            button6.TabIndex = 0;
            button6.Text = "Verifikuj";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(406, 387);
            button5.Name = "button5";
            button5.Size = new Size(110, 39);
            button5.TabIndex = 7;
            button5.Text = "Posalji fajl";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(319, 227);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 6;
            button4.Text = "Browse";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(108, 227);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(193, 27);
            textBox4.TabIndex = 5;
            // 
            // button3
            // 
            button3.Location = new Point(108, 161);
            button3.Name = "button3";
            button3.Size = new Size(193, 33);
            button3.TabIndex = 4;
            button3.Text = "Konektuj se na server";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(108, 114);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(193, 27);
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(108, 52);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(193, 27);
            textBox2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 117);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 1;
            label3.Text = "Port:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 0;
            label2.Text = "IP adresa:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 543);
            Controls.Add(tabControl1);
            Name = "Form2";
            Text = "Form2";
            tabControl1.ResumeLayout(false);
            Server.ResumeLayout(false);
            Server.PerformLayout();
            Client.ResumeLayout(false);
            Client.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TabControl tabControl1;
        private TabPage Server;
        private TabPage Client;
        private Button button2;
        private Button button1;
        private Label label1;
        private TextBox textBox1;
        private Button button3;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private BindingSource bindingSource1;
        private Button button5;
        private Button button4;
        private TextBox textBox4;
        private GroupBox groupBox1;
        private Button button6;
    }
}
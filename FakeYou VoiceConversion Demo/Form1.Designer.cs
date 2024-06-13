namespace FakeYou_VoiceConversion_Demo
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
            panel1 = new Panel();
            SelectFiles_button = new Button();
            SetDestinationFolder_button = new Button();
            Start_button = new Button();
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            Login_button = new Button();
            Logout_button = new Button();
            label3 = new Label();
            label4 = new Label();
            Username_textBox = new TextBox();
            Password_textBox = new TextBox();
            Log_textBox = new TextBox();
            Files_listView = new ListView();
            Destination_label = new Label();
            panel2 = new Panel();
            Voices_listView = new ListView();
            TItle = new ColumnHeader();
            Creator = new ColumnHeader();
            Token = new ColumnHeader();
            label5 = new Label();
            SelectedVoiceToken_textBox = new TextBox();
            label6 = new Label();
            label7 = new Label();
            Search_textBox = new TextBox();
            label8 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(181, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1, 510);
            panel1.TabIndex = 0;
            // 
            // SelectFiles_button
            // 
            SelectFiles_button.Location = new Point(681, 215);
            SelectFiles_button.Name = "SelectFiles_button";
            SelectFiles_button.Size = new Size(75, 23);
            SelectFiles_button.TabIndex = 1;
            SelectFiles_button.Text = "Select Files";
            SelectFiles_button.UseVisualStyleBackColor = true;
            // 
            // SetDestinationFolder_button
            // 
            SetDestinationFolder_button.Location = new Point(762, 215);
            SetDestinationFolder_button.Name = "SetDestinationFolder_button";
            SetDestinationFolder_button.Size = new Size(139, 23);
            SetDestinationFolder_button.TabIndex = 2;
            SetDestinationFolder_button.Text = "Set Destination Folder";
            SetDestinationFolder_button.UseVisualStyleBackColor = true;
            // 
            // Start_button
            // 
            Start_button.Location = new Point(907, 215);
            Start_button.Name = "Start_button";
            Start_button.Size = new Size(75, 23);
            Start_button.TabIndex = 3;
            Start_button.Text = "Start";
            Start_button.UseVisualStyleBackColor = true;
            Start_button.Click += Start_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(678, 248);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 4;
            label1.Text = "Pause after each conversion:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(912, 248);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 5;
            label2.Text = "seconds.";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(841, 246);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(65, 23);
            numericUpDown1.TabIndex = 6;
            // 
            // Login_button
            // 
            Login_button.Location = new Point(12, 215);
            Login_button.Name = "Login_button";
            Login_button.Size = new Size(163, 23);
            Login_button.TabIndex = 7;
            Login_button.Text = "Login";
            Login_button.UseVisualStyleBackColor = true;
            // 
            // Logout_button
            // 
            Logout_button.Location = new Point(12, 244);
            Logout_button.Name = "Logout_button";
            Logout_button.Size = new Size(163, 23);
            Logout_button.TabIndex = 8;
            Logout_button.Text = "Logout";
            Logout_button.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 83);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 9;
            label3.Text = "Username:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 133);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 10;
            label4.Text = "Password:";
            // 
            // Username_textBox
            // 
            Username_textBox.Location = new Point(12, 101);
            Username_textBox.Name = "Username_textBox";
            Username_textBox.Size = new Size(163, 23);
            Username_textBox.TabIndex = 11;
            // 
            // Password_textBox
            // 
            Password_textBox.Location = new Point(12, 151);
            Password_textBox.Name = "Password_textBox";
            Password_textBox.Size = new Size(163, 23);
            Password_textBox.TabIndex = 12;
            // 
            // Log_textBox
            // 
            Log_textBox.AcceptsReturn = true;
            Log_textBox.Location = new Point(681, 304);
            Log_textBox.Multiline = true;
            Log_textBox.Name = "Log_textBox";
            Log_textBox.Size = new Size(301, 218);
            Log_textBox.TabIndex = 13;
            // 
            // Files_listView
            // 
            Files_listView.Location = new Point(681, 30);
            Files_listView.Name = "Files_listView";
            Files_listView.Size = new Size(301, 162);
            Files_listView.TabIndex = 14;
            Files_listView.UseCompatibleStateImageBehavior = false;
            // 
            // Destination_label
            // 
            Destination_label.AutoSize = true;
            Destination_label.Location = new Point(681, 195);
            Destination_label.Name = "Destination_label";
            Destination_label.Size = new Size(70, 15);
            Destination_label.TabIndex = 15;
            Destination_label.Text = "Destination:";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(674, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1, 510);
            panel2.TabIndex = 1;
            // 
            // Voices_listView
            // 
            Voices_listView.Columns.AddRange(new ColumnHeader[] { TItle, Creator, Token });
            Voices_listView.FullRowSelect = true;
            Voices_listView.GridLines = true;
            Voices_listView.Location = new Point(188, 83);
            Voices_listView.Name = "Voices_listView";
            Voices_listView.Size = new Size(480, 388);
            Voices_listView.TabIndex = 16;
            Voices_listView.UseCompatibleStateImageBehavior = false;
            Voices_listView.View = View.Details;
            Voices_listView.MouseDoubleClick += Voices_listView_MouseDoubleClick;
            // 
            // TItle
            // 
            TItle.Text = "Title";
            TItle.Width = 250;
            // 
            // Creator
            // 
            Creator.Text = "Creator";
            Creator.Width = 100;
            // 
            // Token
            // 
            Token.Text = "Token";
            Token.Width = 120;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(188, 65);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 17;
            label5.Text = "Voices:";
            // 
            // SelectedVoiceToken_textBox
            // 
            SelectedVoiceToken_textBox.Location = new Point(188, 499);
            SelectedVoiceToken_textBox.Name = "SelectedVoiceToken_textBox";
            SelectedVoiceToken_textBox.Size = new Size(480, 23);
            SelectedVoiceToken_textBox.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(188, 481);
            label6.Name = "label6";
            label6.Size = new Size(119, 15);
            label6.TabIndex = 18;
            label6.Text = "Selected Voice Token:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(681, 12);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 20;
            label7.Text = "Files:";
            // 
            // Search_textBox
            // 
            Search_textBox.Location = new Point(188, 30);
            Search_textBox.Name = "Search_textBox";
            Search_textBox.Size = new Size(480, 23);
            Search_textBox.TabIndex = 22;
            Search_textBox.TextChanged += Search_textBox_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(188, 12);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 21;
            label8.Text = "Search:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(861, 275);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 23;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(724, 275);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(74, 23);
            textBox1.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(681, 279);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 25;
            label9.Text = "Pitch:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 534);
            Controls.Add(label9);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(Search_textBox);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(SelectedVoiceToken_textBox);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Voices_listView);
            Controls.Add(panel2);
            Controls.Add(Destination_label);
            Controls.Add(Files_listView);
            Controls.Add(Log_textBox);
            Controls.Add(Password_textBox);
            Controls.Add(Username_textBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Logout_button);
            Controls.Add(Login_button);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Start_button);
            Controls.Add(SetDestinationFolder_button);
            Controls.Add(SelectFiles_button);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button SelectFiles_button;
        private Button SetDestinationFolder_button;
        private Button Start_button;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button Login_button;
        private Button Logout_button;
        private Label label3;
        private Label label4;
        private TextBox Username_textBox;
        private TextBox Password_textBox;
        private TextBox Log_textBox;
        private ListView Files_listView;
        private Label Destination_label;
        private Panel panel2;
        private ListView Voices_listView;
        private Label label5;
        private TextBox SelectedVoiceToken_textBox;
        private Label label6;
        private Label label7;
        private TextBox Search_textBox;
        private Label label8;
        private ColumnHeader TItle;
        private ColumnHeader Creator;
        private ColumnHeader Token;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private Label label9;
    }
}

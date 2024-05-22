namespace EmailManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ToField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ContactsList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SubjectField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MessageField = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CopiesList = new System.Windows.Forms.ListBox();
            this.PreFilesList = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SelFilesList = new System.Windows.Forms.ListBox();
            this.SelectButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(153, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manager of Email Lists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(154, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Program of Sending of Emails For Corporate Clients";
            // 
            // ToField
            // 
            this.ToField.Location = new System.Drawing.Point(12, 100);
            this.ToField.Name = "ToField";
            this.ToField.Size = new System.Drawing.Size(129, 20);
            this.ToField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Who:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacts:";
            // 
            // ContactsList
            // 
            this.ContactsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ContactsList.FormattingEnabled = true;
            this.ContactsList.Location = new System.Drawing.Point(157, 98);
            this.ContactsList.Name = "ContactsList";
            this.ContactsList.Size = new System.Drawing.Size(129, 21);
            this.ContactsList.TabIndex = 7;
            this.ContactsList.SelectedIndexChanged += new System.EventHandler(this.ContactsList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subject:";
            // 
            // SubjectField
            // 
            this.SubjectField.Location = new System.Drawing.Point(12, 143);
            this.SubjectField.Name = "SubjectField";
            this.SubjectField.Size = new System.Drawing.Size(129, 20);
            this.SubjectField.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Massege:";
            // 
            // MessageField
            // 
            this.MessageField.Location = new System.Drawing.Point(12, 191);
            this.MessageField.Multiline = true;
            this.MessageField.Name = "MessageField";
            this.MessageField.Size = new System.Drawing.Size(139, 141);
            this.MessageField.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Copies:";
            // 
            // CopiesList
            // 
            this.CopiesList.FormattingEnabled = true;
            this.CopiesList.Location = new System.Drawing.Point(157, 143);
            this.CopiesList.Name = "CopiesList";
            this.CopiesList.Size = new System.Drawing.Size(129, 186);
            this.CopiesList.TabIndex = 14;
            // 
            // PreFilesList
            // 
            this.PreFilesList.FormattingEnabled = true;
            this.PreFilesList.Location = new System.Drawing.Point(292, 100);
            this.PreFilesList.Name = "PreFilesList";
            this.PreFilesList.Size = new System.Drawing.Size(129, 82);
            this.PreFilesList.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Files:";
            // 
            // SelFilesList
            // 
            this.SelFilesList.FormattingEnabled = true;
            this.SelFilesList.Location = new System.Drawing.Point(292, 221);
            this.SelFilesList.Name = "SelFilesList";
            this.SelFilesList.Size = new System.Drawing.Size(129, 82);
            this.SelFilesList.TabIndex = 17;
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(296, 188);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(55, 23);
            this.SelectButton.TabIndex = 18;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(357, 188);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(55, 23);
            this.AddButton.TabIndex = 19;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(296, 306);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(55, 23);
            this.ClearButton.TabIndex = 21;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(357, 306);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(55, 23);
            this.SendButton.TabIndex = 20;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 341);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.SelFilesList);
            this.Controls.Add(this.PreFilesList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CopiesList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MessageField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SubjectField);
            this.Controls.Add(this.ContactsList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ToField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manager of Email Lists";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ToField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ContactsList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SubjectField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MessageField;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox CopiesList;
        private System.Windows.Forms.ListBox PreFilesList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox SelFilesList;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SendButton;
    }
}


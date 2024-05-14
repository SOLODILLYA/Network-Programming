namespace App_Client
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TasksList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.RegistrationButton = new System.Windows.Forms.Button();
            this.GetTasksButton = new System.Windows.Forms.Button();
            this.NewTaskButton = new System.Windows.Forms.Button();
            this.EditTaskButton = new System.Windows.Forms.Button();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AboutTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusField = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FinishDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteTaskButton);
            this.groupBox1.Controls.Add(this.EditTaskButton);
            this.groupBox1.Controls.Add(this.NewTaskButton);
            this.groupBox1.Controls.Add(this.GetTasksButton);
            this.groupBox1.Controls.Add(this.RegistrationButton);
            this.groupBox1.Controls.Add(this.ConnectButton);
            this.groupBox1.Controls.Add(this.PasswordTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LoginTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartDatePicker);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.FinishDatePicker);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.StatusField);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.AboutTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TitleTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(698, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 437);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TasksList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(200, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 437);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "List of Tasks";
            // 
            // TasksList
            // 
            this.TasksList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksList.FormattingEnabled = true;
            this.TasksList.ItemHeight = 16;
            this.TasksList.Location = new System.Drawing.Point(3, 18);
            this.TasksList.Name = "TasksList";
            this.TasksList.ScrollAlwaysVisible = true;
            this.TasksList.Size = new System.Drawing.Size(492, 416);
            this.TasksList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login:";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(7, 42);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(187, 22);
            this.LoginTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(7, 90);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(187, 22);
            this.PasswordTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(10, 118);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(184, 36);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // RegistrationButton
            // 
            this.RegistrationButton.Location = new System.Drawing.Point(10, 160);
            this.RegistrationButton.Name = "RegistrationButton";
            this.RegistrationButton.Size = new System.Drawing.Size(184, 36);
            this.RegistrationButton.TabIndex = 5;
            this.RegistrationButton.Text = "Registration";
            this.RegistrationButton.UseVisualStyleBackColor = true;
            // 
            // GetTasksButton
            // 
            this.GetTasksButton.Location = new System.Drawing.Point(10, 263);
            this.GetTasksButton.Name = "GetTasksButton";
            this.GetTasksButton.Size = new System.Drawing.Size(184, 36);
            this.GetTasksButton.TabIndex = 6;
            this.GetTasksButton.Text = "My Tasks";
            this.GetTasksButton.UseVisualStyleBackColor = true;
            // 
            // NewTaskButton
            // 
            this.NewTaskButton.Location = new System.Drawing.Point(10, 305);
            this.NewTaskButton.Name = "NewTaskButton";
            this.NewTaskButton.Size = new System.Drawing.Size(184, 36);
            this.NewTaskButton.TabIndex = 7;
            this.NewTaskButton.Text = "New Task";
            this.NewTaskButton.UseVisualStyleBackColor = true;
            // 
            // EditTaskButton
            // 
            this.EditTaskButton.Location = new System.Drawing.Point(10, 347);
            this.EditTaskButton.Name = "EditTaskButton";
            this.EditTaskButton.Size = new System.Drawing.Size(184, 36);
            this.EditTaskButton.TabIndex = 8;
            this.EditTaskButton.Text = "Edit Task";
            this.EditTaskButton.UseVisualStyleBackColor = true;
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.Location = new System.Drawing.Point(11, 389);
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(184, 36);
            this.DeleteTaskButton.TabIndex = 9;
            this.DeleteTaskButton.Text = "Delete Task";
            this.DeleteTaskButton.UseVisualStyleBackColor = true;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(6, 42);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(187, 22);
            this.TitleTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Task:";
            // 
            // AboutTextBox
            // 
            this.AboutTextBox.Location = new System.Drawing.Point(6, 90);
            this.AboutTextBox.Multiline = true;
            this.AboutTextBox.Name = "AboutTextBox";
            this.AboutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AboutTextBox.Size = new System.Drawing.Size(187, 206);
            this.AboutTextBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "About:";
            // 
            // StatusField
            // 
            this.StatusField.Location = new System.Drawing.Point(6, 409);
            this.StatusField.Name = "StatusField";
            this.StatusField.Size = new System.Drawing.Size(187, 22);
            this.StatusField.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "End Date:";
            // 
            // FinishDatePicker
            // 
            this.FinishDatePicker.Location = new System.Drawing.Point(3, 364);
            this.FinishDatePicker.Name = "FinishDatePicker";
            this.FinishDatePicker.Size = new System.Drawing.Size(190, 22);
            this.FinishDatePicker.TabIndex = 19;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(3, 319);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(190, 22);
            this.StartDatePicker.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Start Date:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 437);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskApp Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox TasksList;
        private System.Windows.Forms.Button DeleteTaskButton;
        private System.Windows.Forms.Button EditTaskButton;
        private System.Windows.Forms.Button NewTaskButton;
        private System.Windows.Forms.Button GetTasksButton;
        private System.Windows.Forms.Button RegistrationButton;
        private System.Windows.Forms.TextBox StatusField;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AboutTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker FinishDatePicker;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label label6;
    }
}


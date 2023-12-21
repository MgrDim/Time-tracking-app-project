namespace TimeTrackingApp
{
    partial class RegisterForm
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
            LoginBox = new TextBox();
            PassBox = new TextBox();
            RegisterButton = new Button();
            RepPassBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // LoginBox
            // 
            LoginBox.Location = new Point(258, 94);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(267, 27);
            LoginBox.TabIndex = 1;
            LoginBox.Enter += LoginBox_Enter;
            LoginBox.Leave += LoginBox_Leave;
            // 
            // PassBox
            // 
            PassBox.Location = new Point(258, 152);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(267, 27);
            PassBox.TabIndex = 2;
            PassBox.Enter += PassBox_Enter;
            PassBox.Leave += PassBox_Leave;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(303, 259);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(175, 29);
            RegisterButton.TabIndex = 0;
            RegisterButton.Text = "Регистрация";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // RepPassBox
            // 
            RepPassBox.Location = new Point(258, 208);
            RepPassBox.Name = "RepPassBox";
            RepPassBox.Size = new Size(267, 27);
            RepPassBox.TabIndex = 3;
            RepPassBox.Enter += RepPassBox_Enter;
            RepPassBox.Leave += RepPassBox_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 71);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(258, 129);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 5;
            label2.Text = "Пароль:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(258, 185);
            label3.Name = "label3";
            label3.Size = new Size(142, 20);
            label3.TabIndex = 6;
            label3.Text = "Повторите пароль:";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RepPassBox);
            Controls.Add(RegisterButton);
            Controls.Add(PassBox);
            Controls.Add(LoginBox);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginBox;
        private TextBox PassBox;
        private Button RegisterButton;
        private TextBox RepPassBox;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
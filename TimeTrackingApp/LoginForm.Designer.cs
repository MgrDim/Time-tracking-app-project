namespace TimeTrackingApp
{
    partial class LoginForm
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
            AuthButton = new Button();
            RegisterButton = new Button();
            WarnBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // LoginBox
            // 
            LoginBox.Location = new Point(263, 111);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(285, 27);
            LoginBox.TabIndex = 1;
            LoginBox.Enter += LoginBox_Enter;
            LoginBox.Leave += LoginBox_Leave;
            // 
            // PassBox
            // 
            PassBox.Location = new Point(263, 179);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(285, 27);
            PassBox.TabIndex = 2;
            PassBox.Enter += PassBox_Enter;
            PassBox.Leave += PassBox_Leave;
            // 
            // AuthButton
            // 
            AuthButton.Location = new Point(308, 234);
            AuthButton.Name = "AuthButton";
            AuthButton.Size = new Size(189, 29);
            AuthButton.TabIndex = 0;
            AuthButton.Text = "Вход";
            AuthButton.UseVisualStyleBackColor = true;
            AuthButton.Click += AuthButton_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(623, 12);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(165, 29);
            RegisterButton.TabIndex = 2;
            RegisterButton.Text = "Регистрация";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // WarnBox
            // 
            WarnBox.BackColor = SystemColors.Menu;
            WarnBox.BorderStyle = BorderStyle.None;
            WarnBox.Location = new Point(226, 278);
            WarnBox.Name = "WarnBox";
            WarnBox.Size = new Size(348, 20);
            WarnBox.TabIndex = 3;
            WarnBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(263, 88);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 156);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 5;
            label2.Text = "Пароль:";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(WarnBox);
            Controls.Add(RegisterButton);
            Controls.Add(AuthButton);
            Controls.Add(PassBox);
            Controls.Add(LoginBox);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosed += LoginForm_FormClosed;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginBox;
        private TextBox PassBox;
        private Button AuthButton;
        private Button RegisterButton;
        private TextBox WarnBox;
        private Label label1;
        private Label label2;
    }
}
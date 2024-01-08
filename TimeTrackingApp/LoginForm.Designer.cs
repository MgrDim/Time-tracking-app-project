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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LoginBox = new TextBox();
            PassBox = new TextBox();
            AuthButton = new Button();
            RegisterButton = new Button();
            label1 = new Label();
            label2 = new Label();
            WarnMessage = new Label();
            SuspendLayout();
            // 
            // LoginBox
            // 
            LoginBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBox.Location = new Point(264, 140);
            LoginBox.MaxLength = 255;
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(285, 27);
            LoginBox.TabIndex = 1;
            LoginBox.Enter += LoginBox_Enter;
            LoginBox.Leave += LoginBox_Leave;
            // 
            // PassBox
            // 
            PassBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PassBox.Location = new Point(264, 208);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(285, 27);
            PassBox.TabIndex = 2;
            PassBox.Enter += PassBox_Enter;
            PassBox.Leave += PassBox_Leave;
            // 
            // AuthButton
            // 
            AuthButton.BackgroundImageLayout = ImageLayout.Stretch;
            AuthButton.FlatStyle = FlatStyle.System;
            AuthButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AuthButton.Location = new Point(309, 263);
            AuthButton.MaximumSize = new Size(189, 29);
            AuthButton.MinimumSize = new Size(189, 29);
            AuthButton.Name = "AuthButton";
            AuthButton.Size = new Size(189, 29);
            AuthButton.TabIndex = 0;
            AuthButton.Text = "Вход";
            AuthButton.UseVisualStyleBackColor = true;
            AuthButton.Click += AuthButton_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.FlatStyle = FlatStyle.System;
            RegisterButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterButton.Location = new Point(623, 12);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(165, 29);
            RegisterButton.TabIndex = 2;
            RegisterButton.Text = "Регистрация";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(264, 117);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 4;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(264, 185);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 5;
            label2.Text = "Пароль:";
            // 
            // WarnMessage
            // 
            WarnMessage.AutoSize = true;
            WarnMessage.BackColor = Color.Transparent;
            WarnMessage.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            WarnMessage.ForeColor = Color.Red;
            WarnMessage.Location = new Point(329, 305);
            WarnMessage.Name = "WarnMessage";
            WarnMessage.Size = new Size(0, 20);
            WarnMessage.TabIndex = 6;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(WarnMessage);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(RegisterButton);
            Controls.Add(AuthButton);
            Controls.Add(PassBox);
            Controls.Add(LoginBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeTrackingApp";
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
        private Label label1;
        private Label label2;
        private Label WarnMessage;
    }
}
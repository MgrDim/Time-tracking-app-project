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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            LoginBox = new TextBox();
            PassBox = new TextBox();
            RegisterButton = new Button();
            RepPassBox = new TextBox();
            SuspendLayout();
            // 
            // LoginBox
            // 
            LoginBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            LoginBox.Location = new Point(276, 95);
            LoginBox.Name = "LoginBox";
            LoginBox.Size = new Size(267, 27);
            LoginBox.TabIndex = 1;
            LoginBox.Enter += LoginBox_Enter;
            LoginBox.Leave += LoginBox_Leave;
            // 
            // PassBox
            // 
            PassBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PassBox.Location = new Point(276, 153);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(267, 27);
            PassBox.TabIndex = 2;
            PassBox.Enter += PassBox_Enter;
            PassBox.Leave += PassBox_Leave;
            // 
            // RegisterButton
            // 
            RegisterButton.FlatStyle = FlatStyle.System;
            RegisterButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RegisterButton.Location = new Point(321, 260);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(175, 29);
            RegisterButton.TabIndex = 0;
            RegisterButton.Text = "Регистрация";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // RepPassBox
            // 
            RepPassBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RepPassBox.Location = new Point(276, 209);
            RepPassBox.Name = "RepPassBox";
            RepPassBox.Size = new Size(267, 27);
            RepPassBox.TabIndex = 3;
            RepPassBox.Enter += RepPassBox_Enter;
            RepPassBox.Leave += RepPassBox_Leave;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(RepPassBox);
            Controls.Add(RegisterButton);
            Controls.Add(PassBox);
            Controls.Add(LoginBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeTrackingApp";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LoginBox;
        private TextBox PassBox;
        private Button RegisterButton;
        private TextBox RepPassBox;
    }
}
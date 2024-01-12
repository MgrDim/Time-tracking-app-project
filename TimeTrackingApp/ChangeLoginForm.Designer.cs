namespace TimeTrackingApp
{
    partial class ChangeLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLoginForm));
            NewLoginBox = new TextBox();
            ChangeLoginButton = new Button();
            SuspendLayout();
            // 
            // NewLoginBox
            // 
            NewLoginBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NewLoginBox.Location = new Point(132, 60);
            NewLoginBox.MaxLength = 255;
            NewLoginBox.Name = "NewLoginBox";
            NewLoginBox.Size = new Size(268, 27);
            NewLoginBox.TabIndex = 1;
            NewLoginBox.Enter += NewLoginBox_Enter;
            NewLoginBox.Leave += NewLoginBox_Leave;
            // 
            // ChangeLoginButton
            // 
            ChangeLoginButton.FlatStyle = FlatStyle.System;
            ChangeLoginButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ChangeLoginButton.Location = new Point(193, 105);
            ChangeLoginButton.Name = "ChangeLoginButton";
            ChangeLoginButton.Size = new Size(138, 29);
            ChangeLoginButton.TabIndex = 0;
            ChangeLoginButton.Text = "Изменить имя";
            ChangeLoginButton.UseVisualStyleBackColor = true;
            ChangeLoginButton.Click += ChangeLoginButton_Click;
            // 
            // ChangeLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(525, 178);
            Controls.Add(ChangeLoginButton);
            Controls.Add(NewLoginBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(543, 225);
            MinimumSize = new Size(543, 225);
            Name = "ChangeLoginForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "TimeTrackingApp";
            Load += ChangeNameForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NewLoginBox;
        private Button ChangeLoginButton;
    }
}
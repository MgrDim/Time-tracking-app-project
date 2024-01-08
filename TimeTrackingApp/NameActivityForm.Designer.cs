namespace TimeTrackingApp
{
    partial class NameActivityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NameActivityForm));
            ActivityNameBox = new TextBox();
            ChooseButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // ActivityNameBox
            // 
            ActivityNameBox.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ActivityNameBox.Location = new Point(138, 109);
            ActivityNameBox.Name = "ActivityNameBox";
            ActivityNameBox.Size = new Size(278, 27);
            ActivityNameBox.TabIndex = 0;
            // 
            // ChooseButton
            // 
            ChooseButton.FlatStyle = FlatStyle.System;
            ChooseButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ChooseButton.Location = new Point(203, 159);
            ChooseButton.Name = "ChooseButton";
            ChooseButton.Size = new Size(122, 29);
            ChooseButton.TabIndex = 2;
            ChooseButton.Text = "Выбрать";
            ChooseButton.UseVisualStyleBackColor = true;
            ChooseButton.Click += ChooseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(138, 86);
            label1.Name = "label1";
            label1.Size = new Size(178, 20);
            label1.TabIndex = 3;
            label1.Text = "Сформулируйте задачу:";
            // 
            // NameActivityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(552, 284);
            Controls.Add(label1);
            Controls.Add(ChooseButton);
            Controls.Add(ActivityNameBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(570, 331);
            MinimumSize = new Size(570, 331);
            Name = "NameActivityForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeTrackingApp";
            FormClosing += NameActivityForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ActivityNameBox;
        private Button ChooseButton;
        private Label label1;
    }
}
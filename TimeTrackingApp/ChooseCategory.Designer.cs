﻿namespace TimeTrackingApp
{
    partial class ChooseCategory
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
            categoryNameBox = new ComboBox();
            chooseButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // categoryNameBox
            // 
            categoryNameBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryNameBox.Location = new Point(242, 89);
            categoryNameBox.MaxDropDownItems = 10;
            categoryNameBox.Name = "categoryNameBox";
            categoryNameBox.Size = new Size(245, 28);
            categoryNameBox.TabIndex = 1;
            categoryNameBox.Enter += categoryNameBox_Enter;
            // 
            // chooseButton
            // 
            chooseButton.Location = new Point(198, 191);
            chooseButton.Name = "chooseButton";
            chooseButton.Size = new Size(146, 29);
            chooseButton.TabIndex = 0;
            chooseButton.Text = "Выбрать";
            chooseButton.UseVisualStyleBackColor = true;
            chooseButton.Click += chooseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 89);
            label1.Name = "label1";
            label1.Size = new Size(218, 21);
            label1.TabIndex = 2;
            label1.Text = "Выберите категорию задачи:";
            // 
            // ChooseCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 284);
            Controls.Add(label1);
            Controls.Add(chooseButton);
            Controls.Add(categoryNameBox);
            Name = "ChooseCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChooseCategory";
            FormClosing += ChooseCategory_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox categoryNameBox;
        private Button chooseButton;
        private Label label1;
    }
}
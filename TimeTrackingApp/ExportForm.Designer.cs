namespace TimeTrackingApp
{
    partial class ExportForm
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
            fileNameBox = new TextBox();
            label1 = new Label();
            monthCalendar = new MonthCalendar();
            firstDateBox = new TextBox();
            secondDateBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            saveButton = new Button();
            SuspendLayout();
            // 
            // fileNameBox
            // 
            fileNameBox.Location = new Point(142, 71);
            fileNameBox.Name = "fileNameBox";
            fileNameBox.Size = new Size(269, 27);
            fileNameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 48);
            label1.Name = "label1";
            label1.Size = new Size(147, 20);
            label1.TabIndex = 2;
            label1.Text = "Введите имя файла:";
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(453, 48);
            monthCalendar.MaxSelectionCount = 31;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 3;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // firstDateBox
            // 
            firstDateBox.BackColor = SystemColors.Window;
            firstDateBox.Location = new Point(142, 135);
            firstDateBox.Name = "firstDateBox";
            firstDateBox.ReadOnly = true;
            firstDateBox.Size = new Size(269, 27);
            firstDateBox.TabIndex = 4;
            // 
            // secondDateBox
            // 
            secondDateBox.BackColor = SystemColors.Window;
            secondDateBox.Location = new Point(142, 200);
            secondDateBox.Name = "secondDateBox";
            secondDateBox.ReadOnly = true;
            secondDateBox.Size = new Size(269, 27);
            secondDateBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 112);
            label2.Name = "label2";
            label2.Size = new Size(128, 20);
            label2.TabIndex = 6;
            label2.Text = "Начало периода:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(142, 177);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 7;
            label3.Text = "Конец периода";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(211, 248);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(105, 34);
            saveButton.TabIndex = 8;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 364);
            Controls.Add(saveButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(secondDateBox);
            Controls.Add(firstDateBox);
            Controls.Add(monthCalendar);
            Controls.Add(label1);
            Controls.Add(fileNameBox);
            Name = "ExportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Export";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox fileNameBox;
        private Label label1;
        private MonthCalendar monthCalendar;
        private TextBox firstDateBox;
        private TextBox secondDateBox;
        private Label label2;
        private Label label3;
        private Button saveButton;
    }
}
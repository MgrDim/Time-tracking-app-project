namespace TimeTrackingApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            timer = new System.Windows.Forms.Timer(components);
            TimerBox = new TextBox();
            StartTimerButton = new Button();
            StopTimerButton = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            bindingSource = new BindingSource(components);
            refreshButton = new Button();
            exportButton = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            // 
            // TimerBox
            // 
            TimerBox.BackColor = SystemColors.Menu;
            TimerBox.BorderStyle = BorderStyle.None;
            TimerBox.ForeColor = Color.Black;
            TimerBox.Location = new Point(608, 75);
            TimerBox.Name = "TimerBox";
            TimerBox.ReadOnly = true;
            TimerBox.Size = new Size(120, 20);
            TimerBox.TabIndex = 2;
            TimerBox.Text = "00:00:00";
            TimerBox.TextAlign = HorizontalAlignment.Center;
            // 
            // StartTimerButton
            // 
            StartTimerButton.Location = new Point(746, 71);
            StartTimerButton.Name = "StartTimerButton";
            StartTimerButton.Size = new Size(71, 29);
            StartTimerButton.TabIndex = 0;
            StartTimerButton.Text = "Старт";
            StartTimerButton.UseVisualStyleBackColor = true;
            StartTimerButton.Click += StartTimerButton_Click;
            // 
            // StopTimerButton
            // 
            StopTimerButton.Location = new Point(834, 71);
            StopTimerButton.Name = "StopTimerButton";
            StopTimerButton.Size = new Size(73, 29);
            StopTimerButton.TabIndex = 1;
            StopTimerButton.Text = "Стоп";
            StopTimerButton.UseVisualStyleBackColor = true;
            StopTimerButton.Click += StopTimerButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(944, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(112, 24);
            toolStripMenuItem1.Text = "Мой Аккаунт";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 26);
            toolStripMenuItem2.Text = "Сменить имя";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView.Location = new Point(0, 160);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 4;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(728, 378);
            dataGridView.TabIndex = 5;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(12, 129);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(89, 25);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Обновить";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // exportButton
            // 
            exportButton.Location = new Point(746, 475);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(161, 51);
            exportButton.TabIndex = 7;
            exportButton.Text = "Экспорт в Excel";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 538);
            Controls.Add(exportButton);
            Controls.Add(refreshButton);
            Controls.Add(dataGridView);
            Controls.Add(StopTimerButton);
            Controls.Add(StartTimerButton);
            Controls.Add(TimerBox);
            Controls.Add(menuStrip1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeTrackingApp";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private TextBox TimerBox;
        private Button StartTimerButton;
        private Button StopTimerButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private DataGridView dataGridView;
        private BindingSource bindingSource;
        private Button refreshButton;
        private Button exportButton;
    }
}
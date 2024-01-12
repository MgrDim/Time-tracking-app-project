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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox1 = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            StartTimerButton = new Button();
            StopTimerButton = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ChangeLogin = new ToolStripMenuItem();
            Exit = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            refreshButton = new Button();
            exportButton = new Button();
            TimerLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.clock;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.ErrorImage = null;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(534, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(78, 66);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            // 
            // StartTimerButton
            // 
            StartTimerButton.FlatStyle = FlatStyle.System;
            StartTimerButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            StopTimerButton.FlatStyle = FlatStyle.System;
            StopTimerButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(920, 28);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ChangeLogin, Exit });
            toolStripMenuItem1.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(112, 24);
            toolStripMenuItem1.Text = "Мой Аккаунт";
            // 
            // ChangeLogin
            // 
            ChangeLogin.Name = "ChangeLogin";
            ChangeLogin.Size = new Size(197, 26);
            ChangeLogin.Text = "Сменить логин";
            ChangeLogin.Click += ChangeLogin_Click;
            // 
            // Exit
            // 
            Exit.Name = "Exit";
            Exit.Size = new Size(197, 26);
            Exit.Text = "Выйти";
            Exit.Click += Exit_Click;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = Color.DarkBlue;
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
            refreshButton.FlatStyle = FlatStyle.System;
            refreshButton.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            exportButton.FlatStyle = FlatStyle.System;
            exportButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            exportButton.Location = new Point(746, 475);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(161, 51);
            exportButton.TabIndex = 7;
            exportButton.Text = "Экспорт в Excel";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // TimerLabel
            // 
            TimerLabel.AutoSize = true;
            TimerLabel.BackColor = Color.Transparent;
            TimerLabel.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            TimerLabel.ForeColor = SystemColors.Control;
            TimerLabel.Location = new Point(633, 71);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(80, 25);
            TimerLabel.TabIndex = 8;
            TimerLabel.Text = "00:00:00";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(920, 538);
            Controls.Add(pictureBox1);
            Controls.Add(TimerLabel);
            Controls.Add(exportButton);
            Controls.Add(refreshButton);
            Controls.Add(dataGridView);
            Controls.Add(StopTimerButton);
            Controls.Add(StartTimerButton);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(938, 585);
            MinimumSize = new Size(938, 585);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TimeTrackingApp";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private Button StartTimerButton;
        private Button StopTimerButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem ChangeLogin;
        private DataGridView dataGridView;
        private Button refreshButton;
        private Button exportButton;
        private ToolStripMenuItem Exit;
        private Label TimerLabel;
        private PictureBox pictureBox1;
    }
}
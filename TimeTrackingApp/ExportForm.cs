using Aspose.Cells;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrackingApp
{
    public partial class ExportForm : Form
    {
        public Users User { get; set; }
        public ExportForm(Users user)
        {
            User = user;
            InitializeComponent();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            firstDateBox.Text = monthCalendar.SelectionStart.ToShortDateString();
            secondDateBox.Text = monthCalendar.SelectionEnd.ToShortDateString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (IsFileNameBoxEmpty()) return;
            if (!IsFileNameValid(fileNameBox.Text)) return;
            if (AreDateBoxesEmpty()) return;

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{fileNameBox.Text}.xlsx");

            var startdate = DateOnly.Parse(firstDateBox.Text);
            var enddate = DateOnly.Parse(secondDateBox.Text);
            var datatable = GetData(startdate, enddate);
            var workbook = CreateWorkbook(datatable);

            if (datatable.Rows.Count > 0)
            {
                try
                {
                    workbook.Save(path);
                    MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var dialogresult = MessageBox.Show("За данный промежуток времени не было выполнено никаких задач. " +
                    "Хотите ли вы создать Excel-файл?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogresult == DialogResult.Yes)
                {
                    try
                    {
                        workbook.Save(path);
                        MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private Workbook CreateWorkbook(DataTable datatable)
        {
            var workbook = new Workbook();
            var worksheet = workbook.Worksheets[0];
            worksheet.Name = "Отчет";

            var tableoptions = new ImportTableOptions { IsFieldNameShown = true };

            worksheet.Cells.ImportData(datatable, 0, 0, tableoptions);

            worksheet.Cells.Columns[0].Width = 40;
            worksheet.Cells.Columns[1].Width = 40;
            worksheet.Cells.Columns[2].Width = 40;

            return workbook;
        }

        private DataTable GetData(DateOnly startdate, DateOnly enddate)
        {
            var table = new DataTable();
            var firstColumnName = "Задача";
            var secondColumnName = "Категория";
            var thirdColumnName = "Время выполнения";
            var DB = new DataBase();
            var command = new NpgsqlCommand("SELECT * FROM " +
                "get_activities_info_for_export(@userid, @startdate, @enddate)", DB.Connection);

            command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = User.Id;
            command.Parameters.Add("@startdate", NpgsqlTypes.NpgsqlDbType.Date).Value = startdate;
            command.Parameters.Add("@enddate", NpgsqlTypes.NpgsqlDbType.Date).Value = enddate;

            var adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = command;

            adapter.Fill(table);
            table.Columns[0].ColumnName = firstColumnName;
            table.Columns[1].ColumnName = secondColumnName;
            table.Columns[2].ColumnName = thirdColumnName;

            return table;
        }

        private bool IsFileNameBoxEmpty()
        {
            if (fileNameBox.Text == string.Empty)
            {
                MessageBox.Show("Введите имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private bool AreDateBoxesEmpty()
        {
            if (firstDateBox.Text == string.Empty && secondDateBox.Text == string.Empty)
            {
                MessageBox.Show("Временной промежуток не указан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private bool IsFileNameValid(string filename)
        {
            string[] illegalFileNames = { "CON", "PRN", "AUX", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4", "COM5", 
            "COM5", "COM6", "COM7", "COM8", "COM9", "COMSCSI", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6",
            "LPT7", "LPT8", "LPT9", "LPTSCSI"};

            foreach (var chr in Path.GetInvalidFileNameChars())
            {
                if (filename.Contains(chr))
                {
                    MessageBox.Show($"Имя файла содержит запрещенные символы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            foreach (var fname in illegalFileNames)
            {
                if (filename == fname)
                {
                    MessageBox.Show($"Недопустимое имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}

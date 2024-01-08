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
        User _user { get; set; }
        public ExportForm(User user)
        {
            _user = user;
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
            if (AreDateBoxesEmpty()) return;

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"{fileNameBox.Text}.xlsx");
            var workbook = CreateWorkbook();

            try
            {
                workbook.Save(path);
                MessageBox.Show("Файл сохранен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private Workbook CreateWorkbook()
        {
            var startdate = DateOnly.Parse(firstDateBox.Text);
            var enddate = DateOnly.Parse(secondDateBox.Text);

            var workbook = new Workbook();
            var worksheet = workbook.Worksheets[0];
            worksheet.Name = "Отчет";
            var datatable = GetData(startdate, enddate);
            var tableoptions = new ImportTableOptions { IsFieldNameShown = true };

            worksheet.Cells.ImportData(datatable, 0, 0, tableoptions);

            worksheet.Cells.Columns[0].Width = 30;
            worksheet.Cells.Columns[1].Width = 30;
            worksheet.Cells.Columns[2].Width = 30;

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

            command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = _user.Id;
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
    }
}

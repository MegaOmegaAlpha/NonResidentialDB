using NonResidentialDB.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonResidentialDB.catalogs
{
    public partial class AuctionTypeForm : Form
    {

        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private static String query = @"SELECT* FROM Auction_type";
        private List<DataGridViewRow> modifiedRows;
        private bool isEdited;

        public AuctionTypeForm()
        {
            InitializeComponent();
        }

        private void addPlaceBtn_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.Add(newRow);
            modifiedRows.Add(dataGridView.Rows[dataGridView.Rows.Count - 1]);
            //newRows.Add(newRow);
            isEdited = true;
        }

        private void AuctionTypeForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = ConnectionCreator.GetConnection())
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            dataGridView.DataSource = dataSet.Tables[0];
            SetNormalAttributes();
            modifiedRows = new List<DataGridViewRow>();
        }

        private void SetNormalAttributes()
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Название";
            dataGridView.Columns[2].HeaderText = "Описание";
            dataGridView.Columns[2].Width = 600;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
                using (SqlConnection connection = ConnectionCreator.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        adapter = new SqlDataAdapter(query, connection);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet);
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 2627)
                        {
                            MessageBox.Show("Нарушено ограничение целостности данных. Названия не должны повторяться",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (exception.Number == 515)
                        {
                            MessageBox.Show("Не должно быть пустых строк",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (exception.Number == 8152)
                        {
                            MessageBox.Show("Превышен лимит символов",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (exception.Number == 547)
                        {
                            dataSet.Clear();
                            adapter.Fill(dataSet);
                            MessageBox.Show("В базе имеются записи, ссылающиеся на удаляемую. Операция невозможна.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                isEdited = false;
            modifiedRows.Clear();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                int currentCell = e.ColumnIndex;
                if (e.RowIndex > -1)
                {
                    DataGridViewRow currentRow = dataGridView.Rows[e.RowIndex];
                    if (!modifiedRows.Contains(currentRow))
                    {
                        modifiedRows.Add(currentRow);
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(row);
            }
            isEdited = true;
        }

        private void AuctionTypeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isEdited)
            {
                DialogResult result = MessageBox.Show("Изменения не сохранены. Вы точно хотите закрыть окно?",
                    "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

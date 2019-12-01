using NonResidentialDB.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonResidentialDB.catalogs
{
    public partial class AuctionPlaceForm : Form
    {

        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private static String query = @"SELECT* FROM Auction_place";
        private List<DataGridViewRow> modifiedRows; 
        private bool isEdited;

        public AuctionPlaceForm()
        {
            InitializeComponent();
        }

        private void AuctionPlaceForm_Load(object sender, EventArgs e)
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
            dataGridView.Columns[1].HeaderText = "Район";
            dataGridView.Columns[2].HeaderText = "Улица";
            dataGridView.Columns[3].HeaderText = "Дом";
            dataGridView.Columns[4].HeaderText = "Индекс";
        }

        private void addPlaceBtn_Click(object sender, EventArgs e)
        {
            DataRow newRow = dataSet.Tables[0].NewRow();
            dataSet.Tables[0].Rows.Add(newRow);
            modifiedRows.Add(dataGridView.Rows[dataGridView.Rows.Count - 1]);
            //newRows.Add(newRow);
            isEdited = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (AreNewRowsValid())
            {
                using (SqlConnection connection = ConnectionCreator.GetConnection())
                {
                    try
                    {
                        connection.Open();
                        adapter = new SqlDataAdapter(query, connection);
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                        adapter.Update(dataSet);
                        dataSet.Clear();
                        adapter.Fill(dataSet);
                    }
                    catch(SqlException exception)
                    {
                        if (exception.Number == 2627)
                        {
                            MessageBox.Show("Нарушено ограничение целостности данных. Комбинация улицы и номера дома не должна повторяться",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (exception.Number == 515)
                        {
                            MessageBox.Show("Не должно быть пустых строк",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                isEdited = false;
            }
            else
            {
                MessageBox.Show("Индекс должен содержать 6 цифр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AuctionPlaceForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private bool AreNewRowsValid()
        {
            bool isOk = true;
            foreach (DataGridViewRow row in modifiedRows)
            {                
                String actualIndex = row.Cells[4].Value.ToString();
                if (!IsStringMatch(actualIndex) && !ContainEmptyColumn(row))
                {
                    row.Selected = true;
                    isOk = false;
                }
            }
            return isOk;
        }

        private bool ContainEmptyColumn(DataGridViewRow row)
        {
            return row.Cells[1].Value.ToString().Equals("") || row.Cells[2].Value.ToString().Equals("") ||
                row.Cells[3].Value.ToString().Equals("") || row.Cells[4].Value.ToString().Equals("");
        }

        private bool IsStringMatch(String actualValue)
        {
            Regex regex = new Regex(@"^[1-9]{1}[0-9]{5}$");
            return regex.IsMatch(actualValue);
        }

        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }
    }
}

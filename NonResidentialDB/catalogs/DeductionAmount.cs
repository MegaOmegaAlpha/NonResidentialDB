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
    public partial class DeductionAmount : Form
    {

        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private static String query = @"SELECT* FROM Deduction_amount";
        private List<DataGridViewRow> modifiedRows;
        private bool isEdited;

        public DeductionAmount()
        {
            InitializeComponent();
        }

        private void DeductionAmount_Load(object sender, EventArgs e)
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
            dataGridView.Columns[0].HeaderText = "Номер записи";
            dataGridView.Columns[1].HeaderText = "Нижняя граница";
            dataGridView.Columns[2].HeaderText = "Верхняя граница";
            dataGridView.Columns[3].HeaderText = "Процент отчисления";
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
                        modifiedRows.Clear();
                    }
                    catch (SqlException exception)
                    {
                        if (exception.Number == 2627)
                        {
                            MessageBox.Show(exception.Message,
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
                            MessageBox.Show("В базе имеются записи, ссылающиеся на данную. Операция невозможна.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                isEdited = false;
            }
        }

        private bool AreNewRowsValid()
        {
            bool isOk = true;
            /*for (int i = 0; i < modifiedRows.Count; i++)
            {
                DataGridViewRow row = modifiedRows.ElementAt(i);
                if (row.Cells[0].Value.ToString().Equals("1") && !(double.Parse(row.Cells[1].Value.ToString()) == 0))
                {
                    isOk = false;
                    MessageBox.Show("Нижняя граница первой записи должна быть равна 0",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (row.Cells[0].Value.ToString().Equals("4") && !row.Cells[2].Value.ToString().Equals(""))
                {
                    isOk = false;
                    MessageBox.Show("Верхняя граница последней записи должна быть пустой",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }*/
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView.Rows[i];
                if (row.Cells[0].Value.ToString().Equals("1") && !(double.Parse(row.Cells[1].Value.ToString()) == 0))
                {
                    isOk = false;
                    MessageBox.Show("Нижняя граница первой записи должна быть равна 0",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (row.Cells[0].Value.ToString().Equals("4") && !row.Cells[2].Value.ToString().Equals(""))
                {
                    isOk = false;
                    MessageBox.Show("Верхняя граница последней записи должна быть пустой",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (0 < i && i < dataGridView.Rows.Count - 1)
                {
                    double topPrev = double.Parse(dataGridView.Rows[i - 1].Cells[2].Value.ToString());
                    double botCurrent = double.Parse(dataGridView.Rows[i].Cells[1].Value.ToString());
                    double topCurrent = double.Parse(dataGridView.Rows[i].Cells[2].Value.ToString());
                    double botNext = double.Parse(dataGridView.Rows[i + 1].Cells[1].Value.ToString());
                    int prevPerc = int.Parse(dataGridView.Rows[i - 1].Cells[3].Value.ToString());
                    int currentPerc = int.Parse(dataGridView.Rows[i].Cells[3].Value.ToString());
                    int nextPerc = int.Parse(dataGridView.Rows[i + 1].Cells[3].Value.ToString());
                    if (topPrev != botCurrent || topCurrent != botNext)
                    {
                        isOk = false;
                        MessageBox.Show("Не выполняется условие: нижняя граница i-й записи должна быть равна значению верхней границы записи под номером i-1.",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (!(prevPerc < currentPerc && currentPerc < nextPerc))
                    {
                        isOk = false;
                        MessageBox.Show("Значения процентов должны увеличиваться с увеличением номера записи",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (prevPerc > 15 || currentPerc > 15 || nextPerc > 15)
                    {
                        isOk = false;
                        MessageBox.Show("Значение процента не должно превышать 15",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            return isOk;
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

        private void DeductionAmount_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Введены некорректные данные",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }
}

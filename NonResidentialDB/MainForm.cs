using NonResidentialDB.catalogs;
using NonResidentialDB.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonResidentialDB
{
    public partial class MainForm : Form
    {

        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private static String query = @"SELECT*  
                                        FROM BuildingView";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
        }

        private void SetNormalAttributes()
        {
            dataGridView.Columns[0].HeaderText = "Кадастровый номер";
            dataGridView.Columns[1].HeaderText = "Начальная стоимость";
            dataGridView.Columns[2].HeaderText = "Конечная стоимость";
            dataGridView.Columns[3].HeaderText = "Покупатель";
            numericUpDown1.Maximum = 100_000_000;
            numericUpDown1.Minimum = 0;
        }

        private void auctionPlace_Click(object sender, EventArgs e)
        {
            new AuctionPlaceForm().Show();
        }

        private void auctionType_Click(object sender, EventArgs e)
        {
            new AuctionTypeForm().Show();
        }

        private void auctionOrganizer_Click(object sender, EventArgs e)
        {
            new OrganizerForm().Show();
        }

        private void building_Click(object sender, EventArgs e)
        {
            new BuildingForm().Show();
        }

        private void размерОтчисленийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DeductionAmount().Show();
        }

        private void param_exec_Click(object sender, EventArgs e)
        {
            int inputValue = int.Parse(numericUpDown1.Value.ToString());
            if (inputValue > 0)
            {
                String parametrizedQuery = @"SELECT*  
                                             FROM BuildingView
                                             WHERE initial_cost > @cost";
                dataSet.Clear();
                using (SqlConnection connection = ConnectionCreator.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(parametrizedQuery, connection);
                    command.Parameters.Add(new SqlParameter("@cost", inputValue));
                    adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                }
            }
            else
            {
                MessageBox.Show("Введите корректное число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            dataSet.Clear();
            using (SqlConnection connection = ConnectionCreator.GetConnection())
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataSet);
            }
        }

        private void buyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BuyerForm().Show();
        }
    }
}

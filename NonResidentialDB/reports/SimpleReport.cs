using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NonResidentialDB.reports
{
    public partial class SimpleReport : Form
    {



        public SimpleReport()
        {
            InitializeComponent();
        }

        private void SimpleReport_Load(object sender, EventArgs e)
        {
            string simpleReportQuery = @"SELECT i.personal_account_id, i.full_name, s.cadastral_number, s.final_cost
                                         FROM Buyer i join Sold_Building s on i.personal_account_id = s.personal_account_id
                                         ORDER BY i.full_name";
            using (OleDbConnection oleDbConnection = new OleDbConnection("Provider=sqloledb;Data Source=MSI;Initial Catalog=NON-RESIDENTIAL_DB;Integrated Security = SSPI;"))
            {
                oleDbConnection.Open();
                OleDbCommand oleDbCommand = new OleDbCommand(simpleReportQuery, oleDbConnection);
                DataSet simpleReportSet = new DataSet();
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
                oleDbDataAdapter.Fill(simpleReportSet);
                CrystalReportSimple crystalReport = new CrystalReportSimple();
                crystalReport.SetDataSource(simpleReportSet);
                crystalReportViewer1.ReportSource = crystalReport;
                crystalReport.Refresh();
            }
        }
    }
}

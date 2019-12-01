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
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void auctionPlace_Click(object sender, EventArgs e)
        {
            new AuctionPlaceForm().Show();
        }
    }
}

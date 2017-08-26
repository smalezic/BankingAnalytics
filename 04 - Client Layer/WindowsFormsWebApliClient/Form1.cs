using ADS.BankingAnalytics.Client.WebApiClientHandler;
using ADS.BankingAnalytics.DataEntities.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient
{
    public partial class Form1 : Form
    {
        #region Fields

        private ImporterClient _importerClient;

        #endregion Fields

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _importerClient = new ImporterClient("http://localhost:8081");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            int unitId = 1;

            var unit = _importerClient.GetUnit(unitId);
            MessageBox.Show(unit.ToString());
        }
    }
}

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

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            _importerClient = new ImporterClient("http://localhost:8081");

            GetAllOrganizations();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Event Handlers

        #region Private Methods

        private void GetAllOrganizations()
        {
            var organizations = _importerClient.GetAllOrganizations();

            cmbOrganizations.Items.Clear();
            cmbOrganizations.Items.AddRange(organizations.ToArray());
        }

        #endregion Private Methods

        private void cmbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var org = (Organization) cmbOrganizations.SelectedItem;

            if (org != null)
            {
                var units = _importerClient.GetUnits(org.Id);

                cmbUnits.Items.Clear();
                cmbUnits.Items.AddRange(units.ToArray());
            }
            else
            {
                MessageBox.Show("There is no any organization selected");
            }
        }
    }
}

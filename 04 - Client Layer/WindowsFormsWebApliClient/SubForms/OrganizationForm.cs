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

namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient.SubForms
{
    public partial class OrganizationForm : Form
    {
        private ImporterClient _importerClient;

        public OrganizationForm(ImporterClient importerClient)
        {
            InitializeComponent();

            _importerClient = importerClient;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtOrganizationName.Text) == false)
            {
                var org = new Organization()
                {
                    Name = txtOrganizationName.Text
                };

                var savedOrg = _importerClient.SaveOrganization(org);

                if (savedOrg.Id > 0)
                {
                    MessageBox.Show("New organization is successfully saved.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong...");
                }
            }
            else
            {
                MessageBox.Show("Please enter the name of the organization.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

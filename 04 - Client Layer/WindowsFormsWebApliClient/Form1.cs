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
using static ADS.BankingAnalytics.DataEntities.Enumerations.CommonEnumerations;

namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient
{
    public partial class Form1 : Form
    {
        #region Fields

        private ImporterClient _importerClient;
        private Organization _selectedOrganization;
        private Unit _selectedUnit;

        private List<Unit> _units;

        #endregion Fields

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            _units = new List<Unit>();
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

        private void cmbOrganizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOrganization = (Organization)cmbOrganizations.SelectedItem;

            if (_selectedOrganization != null)
            {
                var units = _importerClient.GetUnits(_selectedOrganization.Id);

                cmbUnits.Items.Clear();
                cmbUnits.Items.AddRange(units.ToArray());

                lblOrganizationName.Text = _selectedOrganization.Name;
            }
            else
            {
                lblOrganizationName.Text = String.Empty;
                MessageBox.Show("There is no any organization selected!");
            }
        }

        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedUnit = (Unit)cmbUnits.SelectedItem;

            if (_selectedUnit != null)
            {
                lblUnitName.Text = _selectedUnit.Name;

                lblSelectedUnitId.Text = _selectedUnit.Id.ToString();
                lblSelectedUnitName.Text = _selectedUnit.Name;
                lblSelectedUnitParentName.Text = _selectedUnit.ParentUnit != null ? _selectedUnit.ParentUnit.Name : String.Empty;

                rchAdditionalFields.Clear();

                var expandedUnit = _importerClient.GetUnit(_selectedUnit.Id);

                if (expandedUnit.Expansion != null)
                {
                    foreach (var field in ((ExpandableEntity)expandedUnit.Expansion).AdditionalFields)
                    {
                        String name = field.AdditionalFieldDefinition.Name;
                        object value;

                        switch(field.AdditionalFieldDefinition.FieldValueType)
                        {
                            case FieldType.String:
                                value = field.StringValue;
                                break;

                            case FieldType.Int:
                                value = field.IntValue;
                                break;

                            case FieldType.Decimal:
                                value = field.DecimalValue;
                                break;

                            case FieldType.DateTime:
                                value = field.DateTimeValue;
                                break;

                            case FieldType.Bool:
                                value = field.BooleanValue;
                                break;

                            default:
                                value = null;
                                break;
                        }

                        rchAdditionalFields.AppendText(String.Format("Field name - {0}, has value - {1}{2}", name, value, Environment.NewLine));
                    }
                }
            }
            else
            {
                lblUnitName.Text = String.Empty;
                MessageBox.Show("There is no any unit selected!");
            }
        }

        private void btnAddOrganization_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtOrganizationName.Text) == false)
            {
                var org = new Organization()
                {
                    Name = txtOrganizationName.Text
                };

                var x = _importerClient.SaveSimpleEntity(org);

                GetAllOrganizations();
            }
            else
            {
                MessageBox.Show("Please enter the name of the organization!");
            }
        }

        private void btnAddUnitToList_Click(object sender, EventArgs e)
        {
            if(_selectedOrganization != null)
            {
                if (String.IsNullOrWhiteSpace(txtUnitName.Text) == false)
                {
                    var unit = new Unit()
                    {
                        Name = txtUnitName.Text,
                        OrganizationId = _selectedOrganization.Id
                    };

                    if (chkHasParent.Checked)
                    {
                        unit.ParentUnit = _selectedUnit;
                    }

                    _units.Add(unit);
                    cmbUnits.Items.Add(unit);
                }
                else
                {
                    MessageBox.Show("Please enter the name of the unit!");
                }
            }
            else
            {
                MessageBox.Show("You must provide an organization to the new unit!");
            }
        }

        private void btnSaveUnitList_Click(object sender, EventArgs e)
        {
            var units = new List<Unit>();

            var board = new Unit()
            {
                Name = "Board of directors",
                OrganizationId = _selectedOrganization.Id
            };

            units.Add(board);

            var operations = new Unit()
            {
                Name = "Operations",
                OrganizationId = _selectedOrganization.Id,
                ParentUnit = board
            };

            units.Add(operations);

            var hr = new Unit()
            {
                Name = "HR",
                OrganizationId = _selectedOrganization.Id,
                ParentUnit = board
            };

            units.Add(hr);

            var claims = new Unit()
            {
                Name = "Claims",
                OrganizationId = _selectedOrganization.Id,
                ParentUnit = operations
            };

            units.Add(claims);

            var branches = new Unit()
            {
                Name = "Branches",
                OrganizationId = _selectedOrganization.Id,
                ParentUnit = claims
            };

            units.Add(branches);

            var x = _importerClient.SaveUnits(units);

            //if (_units.Count() > 0)
            //{
            //    var x = _importerClient.SaveUnits(_units);

            //    if(x == true)
            //    {
            //        _units.Clear();
            //        MessageBox.Show("Ok");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Not Ok");
            //    }
            //}
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
    }
}

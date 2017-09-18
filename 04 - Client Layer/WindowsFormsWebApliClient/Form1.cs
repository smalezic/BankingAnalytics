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
using System.IO;
using ADS.BankingAnalytics.Client.WindowsFormsWebApliClient.SubForms;

namespace ADS.BankingAnalytics.Client.WindowsFormsWebApliClient
{
    public partial class Form1 : Form
    {
        #region Fields

        private ImporterClient _importerClient;
        private Organization _selectedOrganization;
        private UnitCategory _selectedUnitCategory;
        private Unit _selectedUnit;

        private List<Unit> _units;
        private List<AdditionalField> _additionalFields;

        #endregion Fields

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            _units = new List<Unit>();
            _additionalFields = new List<AdditionalField>();

            lblParenUnitName.Text = String.Empty;
        }

        #endregion Constructor

        #region Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            _importerClient = new ImporterClient("http://localhost:8081");

            GetAllOrganizationsAndUnitCategories();
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
                var categories = _importerClient.GetUnitCategories(_selectedOrganization.Id);

                cmbUnitCategories.Items.Clear();
                cmbUnitCategories.Items.AddRange(categories.ToArray());

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

        private void cmbUnitCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedUnitCategory = (UnitCategory)cmbUnitCategories.SelectedItem;

            if (_selectedUnitCategory != null)
            {
                var addFieldsDefinitions = _importerClient.GetAdditionalFieldDefinitions(_selectedUnitCategory.Id);

                cmbAdditionalFields.Items.Clear();
                cmbAdditionalFields.Items.AddRange(addFieldsDefinitions.ToArray());
            }
            else
            {
                MessageBox.Show("There is no any category selected!");
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

                if (_selectedUnit.Id > 0)
                {
                    var expandedUnit = _importerClient.GetUnit(_selectedUnit.Id);

                    if (expandedUnit.Expansion != null)
                    {
                        foreach (var field in ((ExpandableEntity)expandedUnit.Expansion).AdditionalFields)
                        {
                            String name = field.AdditionalFieldDefinition.Name;
                            object value;

                            switch (field.AdditionalFieldDefinition.FieldValueType)
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
            }
            else
            {
                lblUnitName.Text = String.Empty;
                MessageBox.Show("There is no any unit selected!");
            }
        }

        private void btnAddOrganization_Click(object sender, EventArgs e)
        {
            OrganizationForm orgForm = new OrganizationForm(_importerClient);
            orgForm.ShowDialog();

            GetAllOrganizationsAndUnitCategories();
        }

        private void btnAddUnitCategory_Click(object sender, EventArgs e)
        {
            if (_selectedOrganization != null)
            {
                UnitCategoryForm unitCategoryForm = new UnitCategoryForm(_importerClient, _selectedOrganization);
                unitCategoryForm.ShowDialog();

                GetAllOrganizationsAndUnitCategories();
            }
            else
            {
                MessageBox.Show("An organization must be selected!");
            }
        }
        
        private void btnAddUnitToList_Click(object sender, EventArgs e)
        {
            if(_selectedOrganization != null && _selectedUnitCategory != null)
            {
                if (String.IsNullOrWhiteSpace(txtUnitName.Text) == false)
                {
                    var unit = new Unit()
                    {
                        Name = txtUnitName.Text,
                        OrganizationId = _selectedOrganization.Id,
                        UnitCategoryId = _selectedUnitCategory.Id
                    };

                    if (chkHasParent.Checked)
                    {
                        unit.ParentUnitId = _selectedUnit.Id;
                    }

                    if(_additionalFields.Count() > 0)
                    {
                        var expandable = new ExpandableEntity();

                        _additionalFields.ForEach(it =>
                        {
                            expandable.AdditionalFields.Add(it);
                        });

                        _additionalFields.Clear();

                        unit.Expansion = expandable;
                    }

                    _units.Add(unit);
                    //cmbUnits.Items.Add(unit);
                }
                else
                {
                    MessageBox.Show("Please enter the name of the unit!");
                }
            }
            else
            {
                MessageBox.Show("You must provide an organization and unit category to the new unit!");
            }
        }

        private void btnAddAdditionalFieldValue_Click(object sender, EventArgs e)
        {
            var additionalFieldDefinition = (AdditionalFieldDefinition)cmbAdditionalFields.SelectedItem;

            if (additionalFieldDefinition != null)
            {
                var additionalField = new AdditionalField()
                {
                    AdditionalFieldDefinitionId = additionalFieldDefinition.Id,
                };
                String name = additionalFieldDefinition.Name;

                switch (additionalFieldDefinition.FieldValueType)
                {
                    case FieldType.String:
                        additionalField.StringValue = txtAdditionalFieldValue.Text;
                        break;

                    case FieldType.Int:
                        additionalField.IntValue = int.Parse(txtAdditionalFieldValue.Text);
                        break;

                    case FieldType.Decimal:
                        additionalField.DecimalValue = decimal.Parse(txtAdditionalFieldValue.Text);
                        break;

                    case FieldType.DateTime:
                        additionalField.DateTimeValue = DateTime.Parse(txtAdditionalFieldValue.Text);
                        break;

                    case FieldType.Bool:
                        additionalField.BooleanValue = txtAdditionalFieldValue.Text.ToLower() == "true" ? true : false;
                        break;

                    default:
                        break;
                }
                
                _additionalFields.Add(additionalField);

                cmbAdditionalFields.SelectedItem = null;
                txtAdditionalFieldValue.Text = String.Empty;
            }
        }

        private void btnSaveUnitList_Click(object sender, EventArgs e)
        {
            //var units = new List<Unit>();

            //var board = new Unit()
            //{
            //    Name = "Board of directors",
            //    OrganizationId = _selectedOrganization.Id,
            //    UnitCategoryId = 1
            //};

            //units.Add(board);

            //var operations = new Unit()
            //{
            //    Name = "Operations",
            //    OrganizationId = _selectedOrganization.Id,
            //    UnitCategoryId = 2,
            //    ParentUnit = board
            //};

            //units.Add(operations);

            //var hr = new Unit()
            //{
            //    Name = "HR",
            //    OrganizationId = _selectedOrganization.Id,
            //    UnitCategoryId = 2,
            //    ParentUnit = board
            //};

            //units.Add(hr);

            //var claims = new Unit()
            //{
            //    Name = "Claims",
            //    OrganizationId = _selectedOrganization.Id,
            //    UnitCategoryId = 3,
            //    ParentUnit = operations
            //};

            //units.Add(claims);

            //var branches = new Unit()
            //{
            //    Name = "Branches",
            //    OrganizationId = _selectedOrganization.Id,
            //    UnitCategoryId = 3,
            //    ParentUnit = claims
            //};

            //units.Add(branches);

            //var x = _importerClient.SaveUnits(units);


            if (_units.Count() > 0)
            {
                var x = _importerClient.SaveUnits(_units);

                if (x == true)
                {
                    _units.Clear();
                    MessageBox.Show("Ok");

                    var units = _importerClient.GetUnits(_selectedOrganization.Id);

                    cmbUnits.Items.Clear();
                    cmbUnits.Items.AddRange(units.ToArray());
                }
                else
                {
                    MessageBox.Show("Not Ok");
                }
            }
        }

        private void chkHasParent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHasParent.Checked)
            {
                if (_selectedUnit != null)
                {
                    lblParenUnitName.Text = "--> " + _selectedUnit.Name;
                }
                else
                {
                    MessageBox.Show("Parent unit must be selected!");
                }
            }
            else
            {
                lblParenUnitName.Text = String.Empty;
            }
        }
        
        #endregion Event Handlers

        #region Private Methods

        private void GetAllOrganizationsAndUnitCategories()
        {
            try
            {
                var organizations = _importerClient.GetAllOrganizations();

                cmbOrganizations.Items.Clear();
                cmbOrganizations.Items.AddRange(organizations.ToArray());

                if (_selectedOrganization != null)
                {
                    var categories = _importerClient.GetUnitCategories(_selectedOrganization.Id);

                    cmbUnitCategories.Items.Clear();
                    cmbUnitCategories.Items.AddRange(categories.ToArray());
                }
            }
            catch
            {

            }
        }

        #endregion Private Methods

        private void btnTemp_Click(object sender, EventArgs e)
        {
            var jsonFile = new StreamReader("..\\..\\JsonTest.txt");
            var json = jsonFile.ReadToEnd();

            _importerClient.SaveUnits(json);
        }
    }
}

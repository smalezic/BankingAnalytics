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
    public partial class UnitCategoryForm : Form
    {
        private ImporterClient _importerClient;
        private Organization _organization;
        private UnitCategory _selectedUnitCategory;
        private AdditionalFieldDefinition _selectedAdditionalFieldDefinition;
        private List<AdditionalFieldDefinition> _definedFields;

        public UnitCategoryForm(ImporterClient importerClient, Organization organization)
        {
            InitializeComponent();

            _importerClient = importerClient;
            _organization = organization;

            _definedFields = new List<AdditionalFieldDefinition>();

            lblOrganization.Text = organization.Name;

            GetUnitCategories();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUnitCategoryName.Text) == false)
            {
                var unitCategory = new UnitCategory
                {
                    Name = txtUnitCategoryName.Text,
                    OrganizationId = _organization.Id
                };

                var savedCategory = _importerClient.SaveUnitCategory(unitCategory);

                if (savedCategory.Id > 0)
                {
                    MessageBox.Show("New organization is successfully saved.");

                    // Populate combo box
                    var categories = _importerClient.GetUnitCategories(_organization.Id);

                    cmbUnitCategories.Items.Clear();
                    cmbUnitCategories.Items.AddRange(categories.ToArray());
                }
                else
                {
                    MessageBox.Show("Something went wrong...");
                }
            }
            else
            {
                MessageBox.Show("Please enter the name of the unit category.");
            }

            txtUnitCategoryName.Text = String.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUnitCategoryName.Text = String.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbUnitCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedUnitCategory = (UnitCategory)cmbUnitCategories.SelectedItem;

            if (_selectedUnitCategory != null)
            {
                GetAdditionalFieldDefinitions();
            }
            else
            {
                MessageBox.Show("There is no any category selected!");
            }
        }

        private void GetUnitCategories()
        {
            try
            {
                var categories = _importerClient.GetUnitCategories(_organization.Id);

                cmbUnitCategories.Items.Clear();
                cmbUnitCategories.Items.AddRange(categories.ToArray());
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void GetAdditionalFieldDefinitions()
        {
            cmbAdditionalFields.Items.Clear();
            _definedFields.Clear();

            var addFieldsDefinitions = _importerClient.GetAdditionalFieldDefinitions(_selectedUnitCategory.Id);

            if (addFieldsDefinitions != null)
            {
                cmbAdditionalFields.Items.AddRange(addFieldsDefinitions.ToArray());

                _definedFields.AddRange(addFieldsDefinitions);
            }
        }

        private void cmbAdditionalFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAdditionalFieldDefinition = (AdditionalFieldDefinition)cmbAdditionalFields.SelectedItem;

            if (_selectedAdditionalFieldDefinition != null)
            {
                txtAdditionalFieldName.Text = _selectedAdditionalFieldDefinition.Name;
                txtAdditionalFieldDescription.Text = _selectedAdditionalFieldDefinition.Description;
                txtAdditionalFieldBusinessMeaning.Text = _selectedAdditionalFieldDefinition.BusinessMeaning;
                chkIsMandatory.Checked = _selectedAdditionalFieldDefinition.IsMandatory;

                switch (_selectedAdditionalFieldDefinition.FieldValueType)
                {
                    case DataEntities.Enumerations.CommonEnumerations.FieldType.String:
                        rbString.Checked = true;
                        break;

                    case DataEntities.Enumerations.CommonEnumerations.FieldType.Int:
                        rbInteger.Checked = true;
                        break;

                    case DataEntities.Enumerations.CommonEnumerations.FieldType.Decimal:
                        rbDecimal.Checked = true;
                        break;

                    case DataEntities.Enumerations.CommonEnumerations.FieldType.DateTime:
                        rbDateTime.Checked = true;
                        break;

                    case DataEntities.Enumerations.CommonEnumerations.FieldType.Bool:
                        rbBoolean.Checked = true;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("There is no any category selected!");
            }
        }

        private void btnClearField_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtAdditionalFieldName.Text = String.Empty;
            txtAdditionalFieldDescription.Text = String.Empty;
            txtAdditionalFieldBusinessMeaning.Text = String.Empty;
            chkIsMandatory.Checked = false;
            rbString.Checked = false;
            rbInteger.Checked = false;
            rbDecimal.Checked = false;
            rbDateTime.Checked = false;
            rbBoolean.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbAdditionalFields.SelectedItem != null)
            {
                var additionalFieldDefinition = (AdditionalFieldDefinition)cmbAdditionalFields.SelectedItem;
                additionalFieldDefinition.DeletedAt = DateTime.Now;

                ClearFields();
            }
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            var additionalFieldDefinition = CreateAdditionalFieldDefinition(new AdditionalFieldDefinition());
            _definedFields.Add(additionalFieldDefinition);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(cmbAdditionalFields.SelectedItem != null)
            {
                var additionalFieldDefinition = (AdditionalFieldDefinition) cmbAdditionalFields.SelectedItem;
                CreateAdditionalFieldDefinition(additionalFieldDefinition);
            }
        }

        private void btnSaveDefinitions_Click(object sender, EventArgs e)
        {
            var expandableEntityType = new ExpandableEntityType()
            {
                MetaEntityId = _selectedUnitCategory.Id,
                MetaEntityType = _selectedUnitCategory.TypeName,
                AdditionalFieldDefinitions = _definedFields
            };

            var retVal = _importerClient.SaveAdditionalFieldDefinitions(expandableEntityType);

            if (retVal)
            {
                GetAdditionalFieldDefinitions();
            }
            else
            {
                MessageBox.Show("Something went wrong...");
            }
        }

        private AdditionalFieldDefinition CreateAdditionalFieldDefinition(AdditionalFieldDefinition additionalFieldDefinition)
        {
            additionalFieldDefinition.Name = txtAdditionalFieldName.Text;
            additionalFieldDefinition.Description = txtAdditionalFieldDescription.Text;
            additionalFieldDefinition.BusinessMeaning = txtAdditionalFieldBusinessMeaning.Text;
            additionalFieldDefinition.IsMandatory = chkIsMandatory.Checked;

            if (rbString.Checked)
            {
                additionalFieldDefinition.FieldValueType = DataEntities.Enumerations.CommonEnumerations.FieldType.String;
            }
            else if (rbInteger.Checked)
            {
                additionalFieldDefinition.FieldValueType = DataEntities.Enumerations.CommonEnumerations.FieldType.Int;
            }
            else if (rbDecimal.Checked)
            {
                additionalFieldDefinition.FieldValueType = DataEntities.Enumerations.CommonEnumerations.FieldType.Decimal;
            }
            else if (rbDateTime.Checked)
            {
                additionalFieldDefinition.FieldValueType = DataEntities.Enumerations.CommonEnumerations.FieldType.DateTime;
            }
            else
            {
                additionalFieldDefinition.FieldValueType = DataEntities.Enumerations.CommonEnumerations.FieldType.Bool;
            }
            
            ClearFields();

            return additionalFieldDefinition;
        }
    }
}

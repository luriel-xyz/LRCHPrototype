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

namespace LRCHPrototype
{
    /**
     * This form shows the information about the physician along with its patients.
     */
    public partial class PhysicianPatientDisplay : Form
    {
        private string connectionString;
        private SqlConnection connection;

        private PhysicianTagData data;

        public PhysicianPatientDisplay()
        {
            InitializeComponent();

            // Set the start position to center screen (Position this window in the center of the screen.)
            this.StartPosition = FormStartPosition.CenterScreen;

            this.connectionString = ConfigurationManager.ConnectionStrings["LRCHConnectionString"].ConnectionString;
            this.connection = new SqlConnection(this.connectionString);
        }

        /**
         * Handle Go back button click.
         * 
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void GoBack(object sender, EventArgs e)
        {
            GoBack();
        }

        /**
         * Go back to the Physician list window.
         */
        private void GoBack()
        {
            this.Hide();

            PhysicianPatientDashboard ppd = new PhysicianPatientDashboard();

            ppd.ShowDialog();
        }

        /**
         * Fill in the physician patient data grid with information
         */
        private void PhysicianPatientDisplay_Load(object sender, EventArgs e)
        {
            // Get the physician number that was passed to this form.
            this.data = (PhysicianTagData)this.Tag;
            PhysicianTagData physician = this.data;

            // Set physician no, name, and date.
            SetReportHeader();

            // Display all patients belonging to the current physician.
            string storedProcedureName = "dbo.sp_Get_Patients_By_Physician_No";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PhysicianNo", physician.PhysicianNo);

                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                SqlDataReader reader = command.ExecuteReader();

                // Add columns to the DataGridView control
                dgvPhysicianPatient.Columns.Add("Patient number", "PATIENT-NO");
                dgvPhysicianPatient.Columns.Add("Patient name", "PATIENT-NAME");
                dgvPhysicianPatient.Columns.Add("Location", "LOCATION");
                dgvPhysicianPatient.Columns.Add("Date admitted", "DATE-ADMITTED");
                dgvPhysicianPatient.Columns.Add("View patient info", "Action");

                // Check if this physician has no patient.
                if (!reader.Read())
                {
                    MessageBox.Show(physician.PhysicianName + " has no patients.");
                }

                // Loop over the rows and add each row to the DataGridView
                while (reader.Read())
                {
                    // Retrieve row data
                    int patientNo = reader.GetInt32(0);
                    string patientName = reader.GetString(1);
                    string bedLocation = reader.GetString(2);
                    DateTime admittedDate = reader.GetDateTime(3);

                    // Create a new view patient button
                    DataGridViewButtonColumn btnViewPatientInfo = new DataGridViewButtonColumn();
                    //btnViewPatientInfo.Tag = physician.physicianNo;
                    btnViewPatientInfo.HeaderText = "";
                    btnViewPatientInfo.Name = "viewPatientInfoColumn";
                    btnViewPatientInfo.Text = "View patient info";
                    btnViewPatientInfo.UseColumnTextForButtonValue = true;

                    dgvPhysicianPatient.AutoGenerateColumns = false;

                    // Create a new row and set the values of its cells
                    DataGridViewRow row = new DataGridViewRow();

                    DataGridViewTextBoxCell patientNoCell = new DataGridViewTextBoxCell();
                    // Set the value of the patient number cell
                    patientNoCell.Value = patientNo;
                    DataGridViewTextBoxCell patientNameCell = new DataGridViewTextBoxCell();
                    // Set the value of the patient name cell
                    patientNameCell.Value = patientName;
                    DataGridViewTextBoxCell locationCell = new DataGridViewTextBoxCell();
                    // Set the value of the location cell
                    locationCell.Value = bedLocation;
                    DataGridViewTextBoxCell dateAdmittedCell = new DataGridViewTextBoxCell();
                    // Set the value of the date admitted cell
                    dateAdmittedCell.Value = admittedDate.ToString();
                    DataGridViewButtonCell btnViewPatientInfoCell = new DataGridViewButtonCell();
                    // Set the value of the button cell
                    btnViewPatientInfoCell.Tag = new PhysicianPatientTagData(physician.PhysicianNo, patientNo);
                    btnViewPatientInfoCell.Value = "View patient info";

                    row.Cells.Add(patientNoCell);
                    row.Cells.Add(patientNameCell);
                    row.Cells.Add(locationCell);
                    row.Cells.Add(dateAdmittedCell);
                    row.Cells.Add(btnViewPatientInfoCell);

                    // Add the row to the DataGridView
                    dgvPhysicianPatient.Rows.Add(row);
                }

                // Close the SqlDataReader and database connection
                reader.Close();

                this.connection.Close();
            }
        }

        private void SetReportHeader()
        {
            lblPhysicianNo.Text = this.data.PhysicianNo.ToString(); // Set the physician number
            lblPhysicianName.Text = this.data.PhysicianName.ToString(); // Set the physician name

            DateTime currentDate = DateTime.Today; // Get the current date
            lblDate.Text = currentDate.ToString("MM/dd/yyyy"); // Set the current date
        }

        /**
          * Open the patient information window.
          */
        private void dgvPhysicianPatient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPhysicianPatient.Columns["View patient info"].Index)
            {
                // Get the tag value of the button
                PhysicianPatientTagData phyPatTag = 
                    (PhysicianPatientTagData)dgvPhysicianPatient.Rows[e.RowIndex].Cells["View patient info"].Tag;

                PatientInformation patientInformation = new PatientInformation();
                patientInformation.Tag = phyPatTag;
                patientInformation.Show();
            }
        }
    }
}

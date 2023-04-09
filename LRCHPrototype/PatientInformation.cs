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
    public partial class PatientInformation : Form
    {
        private string connectionString;
        private SqlConnection connection;

        private PhysicianPatientTagData physicianPatientTagData;

        public PatientInformation()
        {
            InitializeComponent();

            // Set the start position to center screen (Position this window in the center of the screen.)
            this.StartPosition = FormStartPosition.CenterScreen;

            this.connectionString = ConfigurationManager.ConnectionStrings["LRCHConnectionString"].ConnectionString;
            this.connection = new SqlConnection(this.connectionString);
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            // Set the tag data
            this.physicianPatientTagData = (PhysicianPatientTagData)this.Tag;

            // Show the patient's information.
            ShowPatientInfo();

            // Show the treatments of the patient.
            ShowTreatments();

            // Show the notes about the patient.
            ShowNotes();

            // Show the laboratory dates for the patient.
            ShowLaboratories();

            // Show total appointments
            ShowAppointmentTotal();
        }

        /*
         * Display the patient information.
         */
        private void ShowPatientInfo()
        {
            string storedProcedureName = "dbo.sp_Get_Patient_Info";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);

                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                SqlDataReader reader = command.ExecuteReader();

                // read the first row of the results and retrieve the values
                if (reader.Read())
                {
                    int patientNo = reader.GetInt32(0);
                    string patientName = reader.GetString(1);
                    string patientAddress = reader.GetString(2);
                    string cityProvPc = reader.GetString(3);
                    string telephone = reader.GetString(4);
                    string sex = reader.GetString(5);
                    string hcn = reader.GetString(6);
                    string location = reader.GetString(7);
                    string extension = reader.GetString(8);
                    string dateAdmitted = reader.GetDateTime(9).ToString("MM/dd/yyyy");
                    string financialStatus = reader.GetString(10);
                    string dateDischarged = reader.GetDateTime(11) == null ? "" : reader.GetDateTime(11).ToString("MM/dd/yyyy");

                    lblPatientNo.Text = Convert.ToString(patientNo);
                    lblPatientName.Text = patientName;
                    lblAddress.Text = patientAddress;
                    lblCityProvPc.Text = cityProvPc;
                    lblTelephone.Text = telephone;
                    lblSex.Text = sex;
                    lblHCN.Text = hcn;
                    lblLocation.Text = location;
                    lblExtension.Text = Convert.ToString(extension);
                    lblDateAdmitted.Text = dateAdmitted;
                    lblFinStatus.Text = financialStatus;
                    lblDateDischarged.Text = dateDischarged;
                }


                // Close the SqlDataReader and database connection
                reader.Close();

                this.connection.Close();
            }
        }

        /**
         * Show the treatments for the patient.
         */
        private void ShowTreatments()
        {
            string storedProcedureName = "dbo.sp_Get_Treatments_By_Physician_And_Patient";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PhysicianNo", this.physicianPatientTagData.PhysicianNo);
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);

                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                SqlDataReader reader = command.ExecuteReader();

                dgvTreatments.Columns.Clear(); // Remove all columns.

                dgvTreatments.Rows.Clear(); // Remove all elements.

                dgvTreatments.AutoGenerateColumns = false;

                // Set the only one column header
                dgvTreatments.Columns.Add("Treatments", "TREATMENTS");

                // Loop over the rows and add each row to the DataGridView
                while (reader.Read())
                {
                    string treatment = reader.GetString(1); // Get the treatment description

                    // Create a new row and set the values of its cells
                    DataGridViewRow row = new DataGridViewRow();

                    // Create a column cell for the treatment
                    DataGridViewTextBoxCell treatmentCell = new DataGridViewTextBoxCell();
                    // Set the value of the treatment cell
                    treatmentCell.Value = treatment;
                    // Add the cell
                    row.Cells.Add(treatmentCell);

                    // Add the row to the DataGridView
                    dgvTreatments.Rows.Add(row);
                }


                // Close the SqlDataReader and database connection
                reader.Close();

                this.connection.Close();
            }
        }

        /**
         * Show the note for the patient.
         */
        private void ShowNotes()
        {
            string storedProcedureName = "dbo.sp_Get_Patient_Notes";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PhysicianNo", this.physicianPatientTagData.PhysicianNo);
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);

                txtBoxNote.Text = String.Empty;

                // Open the connection
                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                object result = command.ExecuteScalar();

                string note = result.ToString(); // Get the note content

                txtBoxNote.Text = note;


                // Close the database connection
                this.connection.Close();
            }
        }

        /**
         * Show the laboratory records for the patient.
         */
        private void ShowLaboratories()
        {
            string storedProcedureName = "dbo.sp_Get_Patient_Labs";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);

                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                SqlDataReader reader = command.ExecuteReader();

                dgvLaboratory.Columns.Clear(); // Remove all columns.

                dgvLaboratory.Rows.Clear(); // Remove all elements.

                dgvLaboratory.AutoGenerateColumns = false;

                // Set the only one column header
                dgvLaboratory.Columns.Add("Laboratories", "LABORATORIES");

                // Loop over the rows and add each row to the DataGridView
                while (reader.Read())
                {
                    string sampleDate = reader.GetDateTime(0).ToString("MM/dd/yyyy"); // Get the laboratory date

                    // Create a new row and set the values of its cells
                    DataGridViewRow row = new DataGridViewRow();

                    // Create a column cell for the sample date
                    DataGridViewTextBoxCell sampleDateCell = new DataGridViewTextBoxCell();
                    // Set the value of the sample date cell
                    sampleDateCell.Value = sampleDate;
                    // Add the cell
                    row.Cells.Add(sampleDateCell);

                    // Add the row to the DataGridView
                    dgvLaboratory.Rows.Add(row);
                }


                // Close the SqlDataReader and database connection
                reader.Close();

                this.connection.Close();
            }
        }

        /**
         * Go back to the Physician patient report window.
         * 
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void GoBack(object sender, EventArgs e)
        {
            this.Hide();
        }

        /**
         * Add treatment to the patient
         * 
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void AddTreatment(object sender, EventArgs e)
        {
            // Don't do anything if the treatment textbox is empty.
            if (string.IsNullOrEmpty(txtBxTreatment.Text)) return;

            string storedProcedureName = "dbo.sp_Insert_Treatment_To_Patient";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PhysicianNo", this.physicianPatientTagData.PhysicianNo);
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);
                command.Parameters.AddWithValue("@Treatment", txtBxTreatment.Text);

                // Open the connection
                this.connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                // check if the insert was successful
                if (rowsAffected > 0)
                {
                    this.connection.Close(); // Close the database connection

                    MessageBox.Show("Treatment added succesfully.");

                    txtBxTreatment.Text = String.Empty;

                    ShowTreatments(); // Update the treatment data grid view
                }
                else
                {
                    MessageBox.Show("Cannot add treatment because the physician has no appointment with this patient.");

                    // Close the database connection
                    this.connection.Close();
                }
            }
        }

        /**
         * Updates the note of the patient.
         */
        private void AddNote(object sender, EventArgs e)
        {
            // Don't do anything if the note textbox is empty.
            if (txtBxNote.Text.Equals("")) return;

            string storedProcedureName = "dbo.sp_Insert_Patient_Note";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PhysicianNo", this.physicianPatientTagData.PhysicianNo);
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);
                command.Parameters.AddWithValue("@Note", txtBxNote.Text);

                // Open the connection
                this.connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                // check if the insert was successful
                if (rowsAffected > 0)
                {
                    txtBoxNote.Text = String.Empty;

                    this.connection.Close(); // Close the database connection

                    ShowNotes(); // Update the note text box value
                }
                else
                {
                    // Close the database connection
                    this.connection.Close();
                }
            }
        }

        /**
         * Create a new laboratory record for the patient.
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void AddLaboratory(object sender, EventArgs e)
        {
            string storedProcedureName = "dbo.sp_Insert_Patient_Lab";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);

                // Open the connection
                this.connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                // check if the insert was successful
                if (rowsAffected > 0)
                {
                    this.connection.Close(); // Close the database connection

                    MessageBox.Show("Laboratory record added succesfully.");

                    txtBxTreatment.Text = String.Empty;

                    ShowLaboratories(); // Update the laboratory data grid view
                }
                else
                {
                    MessageBox.Show("Lab record was not added due to an error");

                    // Close the database connection
                    this.connection.Close();
                }
            }
        }

        private void ShowAppointmentTotal()
        {
            string storedProcedureName = "dbo.sp_Count_Appointments_By_Physician_Patient";
            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientNo", this.physicianPatientTagData.PatientNo);
                command.Parameters.AddWithValue("@PhysicianNo", this.physicianPatientTagData.PhysicianNo);

                // Open the connection
                this.connection.Open();

                // execute the T-SQL query and get the result as a scalar value
                int totalAppointments = (int)command.ExecuteScalar();

                // Set the value of the total appointments label
                lblTotalAppointments.Text = totalAppointments.ToString();

                // Close the database connection
                this.connection.Close();
            }
        }
    }
}

using System;
using System.Collections;
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
    public partial class PhysicianPatientDashboard : Form
    {
        private string connectionString;
        private SqlConnection connection;

        public PhysicianPatientDashboard()
        {
            InitializeComponent();

            // Set the start position to center screen (Position this window in the center of the screen.)
            this.StartPosition = FormStartPosition.CenterScreen;

            this.connectionString = ConfigurationManager.ConnectionStrings["LRCHConnectionString"].ConnectionString;
            this.connection = new SqlConnection(this.connectionString);
        }

        /**
         * Fill in the physician data grid with information
         */
        private void PhysicianPatientDashboard_Load(object sender, EventArgs e)
        {
            ShowPhysicianList();
        }

        /**
         * Display the list of physicians.
         */
        private void ShowPhysicianList()
        {
            string storedProcedureName = "dbo.sp_Get_Physicians";

            using (SqlCommand command = new SqlCommand(storedProcedureName, this.connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                this.connection.Open();

                // Create a new SqlDataReader to read the rows from the query result
                SqlDataReader reader = command.ExecuteReader();

                // Add columns to the DataGridView control
                dgvPhysicians.Columns.Add("Physician number", "PHYSICIAN NO.");
                dgvPhysicians.Columns.Add("Physician name", "NAME");
                dgvPhysicians.Columns.Add("View patient", "Action");

                // Loop over the rows and add each row to the DataGridView
                while (reader.Read())
                {
                    // Retrieve row data
                    int physicianNo = reader.GetInt32(0);
                    string physicianName = reader.GetString(1);

                    // Create a new view patient button
                    DataGridViewButtonColumn btnViewPatients = new DataGridViewButtonColumn();
                    btnViewPatients.Tag = physicianNo;
                    btnViewPatients.HeaderText = "";
                    btnViewPatients.Name = "viewPatientsColumn";
                    btnViewPatients.Text = "View patient";
                    btnViewPatients.UseColumnTextForButtonValue = true;

                    dgvPhysicians.AutoGenerateColumns = false;

                    // Create a new row and set the values of its cells
                    DataGridViewRow row = new DataGridViewRow();

                    DataGridViewTextBoxCell physicianNoCell = new DataGridViewTextBoxCell();
                    // Set the value of the physician number cell
                    physicianNoCell.Value = physicianNo;
                    DataGridViewTextBoxCell physicianNameCell = new DataGridViewTextBoxCell();
                    // Set the value of the physician name cell
                    physicianNameCell.Value = physicianName;
                    DataGridViewButtonCell btnViewPatientCell = new DataGridViewButtonCell();
                    // Set the value of the button cell
                    btnViewPatientCell.Tag = new PhysicianTagData(physicianNo, physicianName);
                    btnViewPatientCell.Value = "View patient";

                    row.Cells.Add(physicianNoCell);
                    row.Cells.Add(physicianNameCell);
                    row.Cells.Add(btnViewPatientCell);

                    // Add the row to the DataGridView
                    dgvPhysicians.Rows.Add(row);
                }

                // Close the SqlDataReader and database connection
                reader.Close();

                this.connection.Close();
            }
        }

        /**
         * Go back to the main menu
         * 
         * <param name="e"></param>
         * <param name="sender"></param>
         */
        private void GoBack(object sender, EventArgs e)
        {
            PhysicianPatientDashboard physicianPatientDashboard = this;
            MainMenu mainMenu = new MainMenu();

            physicianPatientDashboard.Hide();

            mainMenu.ShowDialog();
        }

        /**
         * Open the physician patient report window
         * 
         */
        private void dgvPhysicians_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvPhysicians.Columns["View patient"].Index)
            {
                // Get the tag value of the button
                PhysicianTagData physicianTag = (PhysicianTagData) dgvPhysicians.Rows[e.RowIndex].Cells["View patient"].Tag;

                PhysicianPatientDisplay physicianPatientDisplay = new PhysicianPatientDisplay();
                physicianPatientDisplay.Tag = physicianTag;
                physicianPatientDisplay.Show();

                this.Hide();
            }
        }
    }
}

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
    public partial class RoomUtilizationDashboard : Form
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["LRCHConnectionString"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        const string PRIVATE = "PR";
        const string SEMI_PRIVATE = "SP";
        const string INTENSIVE_CARE = "IC";
        const string WARD_3 = "W3";
        const string WARD_4 = "W4";

        public RoomUtilizationDashboard()
        {
            InitializeComponent();

            // Set the start position to center screen (Position this window in the center of the screen.)
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /**
         * Displays the information of the Room Utilization Dashboard.
         * 
         * <param name="sender"></param>
         * <param name="e"></param>
         */
        private void RoomUtilizationDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                {
                    // Fill in the text boxes
                    OverallOccupancyByRooms(connection);
                    OverallOccupancyByBeds(connection);
                    NumOfBedsDischarging(connection);


                    // Show total beds per room type
                    ShowTotalBedsPerRoomType(connection, PRIVATE);
                    ShowTotalBedsPerRoomType(connection, SEMI_PRIVATE);
                    ShowTotalBedsPerRoomType(connection, INTENSIVE_CARE);
                    ShowTotalBedsPerRoomType(connection, WARD_3);
                    ShowTotalBedsPerRoomType(connection, WARD_4);


                    // Show total empty beds per room type
                    ShowTotalEmptyBedsPerRoomType(connection, PRIVATE);
                    ShowTotalEmptyBedsPerRoomType(connection, SEMI_PRIVATE);
                    ShowTotalEmptyBedsPerRoomType(connection, INTENSIVE_CARE);
                    ShowTotalEmptyBedsPerRoomType(connection, WARD_3);
                    ShowTotalEmptyBedsPerRoomType(connection, WARD_4);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnUnassignBed_Click(object sender, EventArgs e)
        {
            try
            {
                int stayId = Int32.Parse(txtStayId.Text);

                UnassignBed(connection, stayId);
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR: Please input number only");
            }
        }









        /* ************************************ Mthods ************************************ */
        private void OverallOccupancyByRooms(SqlConnection connection)
        {
            string storedProcedureName = "dbo.sp_Overall_Occupancy_By_Rooms";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    txtOverallOccupancyByRooms.Text = result.ToString();
                }

                connection.Close();
            }
        }


        private void OverallOccupancyByBeds(SqlConnection connection)
        {
            string storedProcedureName = "dbo.sp_Overall_Occupancy_By_Beds";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    txtOverallOccupancyByBeds.Text = result.ToString();
                }

                connection.Close();
            }
        }


        private void NumOfBedsDischarging(SqlConnection connection)
        {
            string storedProcedureName = "sp_Num_Of_Beds_Discharging_Patients_Today";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    txtNumOfBedsDischarging.Text = result.ToString();
                }

                connection.Close();
            }
        }



        /**
         * Displays the information about the total number of beds for the specified room type
         * 
         * <param name="connection"></param>
         * <param name="roomType"></param>
         */
        private void ShowTotalBedsPerRoomType(SqlConnection connection, string roomType)
        {
            string storedProcedureName = "dbo.sp_Occupancy_By_Room_Type";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RoomType", roomType);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    switch (roomType)
                    {
                        case PRIVATE:
                            txtOccupiedPR.Text = result.ToString();
                            break;
                        case SEMI_PRIVATE:
                            txtOccupiedSP.Text = result.ToString();
                            break;
                        case INTENSIVE_CARE:
                            txtOccupiedIC.Text = result.ToString();
                            break;
                        case WARD_3:
                            txtOccupiedW3.Text = result.ToString();
                            break;
                        case WARD_4:
                            txtOccupiedW4.Text = result.ToString();
                            break;
                    }
                }


                connection.Close();
            }
        }

        /**
         * Displays the information about the total number of empty beds for the specified room type
         * 
         * <param name="connection"></param>
         * <param name="roomType"></param>
         */
        private void ShowTotalEmptyBedsPerRoomType(SqlConnection connection, string roomType)
        {
            string storedProcedureName = "dbo.sp_Empty_Rooms_By_Room_Type";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RoomType", roomType);

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    switch (roomType)
                    {
                        case PRIVATE:
                            txtEmptyPR.Text = result.ToString();
                            break;
                        case SEMI_PRIVATE:
                            txtEmptySP.Text = result.ToString();
                            break;
                        case INTENSIVE_CARE:
                            txtEmptyIC.Text = result.ToString();
                            break;
                        case WARD_3:
                            txtEmptyW3.Text = result.ToString();
                            break;
                        case WARD_4:
                            txtEmptyW4.Text = result.ToString();
                            break;
                    }
                }

                connection.Close();
            }
        }


        private void UnassignBed(SqlConnection connection, int stayId)
        {
            string storedProcedureName = "dbo.sp_Unassign_Bed";

            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Patient_Stay_Id", stayId);

                connection.Open();

                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    MessageBox.Show("Bed successfully unassigned");
                }
                else
                {
                    MessageBox.Show("ERROR: The ID does not exist");
                }

                connection.Close();
            }
        }


        



        private void ShowMenu(object sender, EventArgs e)
        {
            RoomUtilizationDashboard roomUtilizationDashboard = this;
            MainMenu mainMenu = new MainMenu();

            
            roomUtilizationDashboard.Hide();
            mainMenu.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ShowMenu(sender, e);
        }
    }
}

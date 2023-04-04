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
        const string PRIVATE = "PR";
        const string SEMI_PRIVATE = "SP";
        const string INTENSIVE_CARE = "IC";
        const string WARD_3 = "W3";
        const string WARD_4 = "W4";

        public RoomUtilizationDashboard()
        {
            InitializeComponent();
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
                string connectionString = ConfigurationManager.ConnectionStrings["LRCHConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
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

        /**
         * Displays the information about the total number of beds for the specified room type
         * 
         * <param name="connection"></param>
         * <param name="roomType"></param>
         */
        private void ShowTotalBedsPerRoomType(SqlConnection connection, string roomType)
        {
            string storedProcedureName = "dbo.sp_Count_Total_Beds_Per_Room_Type";

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
                            lblPRTotalBeds.Text = result.ToString();
                            break;
                        case SEMI_PRIVATE:
                            lblSPTotalBeds.Text = result.ToString();
                            break;
                        case INTENSIVE_CARE:
                            lblICTotalBeds.Text = result.ToString();
                            break;
                        case WARD_3:
                            lblW3TotalBeds.Text = result.ToString();
                            break;
                        case WARD_4:
                            lblW4TotalBeds.Text = result.ToString();
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
            string storedProcedureName = "dbo.sp_Count_Empty_Beds_Per_Room_Type";

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
                            lblPRTotalEmptyBeds.Text = result.ToString();
                            break;
                        case SEMI_PRIVATE:
                            lblSPTotalEmptyBeds.Text = result.ToString();
                            break;
                        case INTENSIVE_CARE:
                            lblICTotalEmptyBeds.Text = result.ToString();
                            break;
                        case WARD_3:
                            lblW3TotalEmptyBeds.Text = result.ToString();
                            break;
                        case WARD_4:
                            lblW4TotalEmptyBeds.Text = result.ToString();
                            break;
                    }
                }

                connection.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRCHPrototype
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        /**
         * Shows the Room Utilization Dashboard window
         * <param name="sender"></param>
         * <param name="e"></param>
         */
        private void ShowRoomUtilizationAsync(object sender, EventArgs e)
        {
            MainMenu mainMenu = this;

            RoomUtilizationDashboard roomUtilizationDashboard = new RoomUtilizationDashboard();

            mainMenu.Hide();

            roomUtilizationDashboard.ShowDialog();
        }

        /**
         * Shows the Physician Patient Dashboard window
         * <param name="sender"></param>
         * <param name="e"></param>
         */
        private void ShowPhysicianPatient(object sender, EventArgs e)
        {
            MainMenu mainMenu = this;

            PhysicianPatientDashboard physicianPatientDashboard = new PhysicianPatientDashboard();

            mainMenu.Hide();

            physicianPatientDashboard.ShowDialog();
        }
    }
}

﻿using System;
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

            // Set the start position to center screen (Position this window in the center of the screen.)
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /**
         * Shows the Room Utilization Dashboard window
         * <param name="sender"></param>
         * <param name="e"></param>
         */
        private void ShowRoomUtilization(object sender, EventArgs e)
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

        /**
         * Close the application.
         * <param name="sender"></param>
         * <param name="e"></param>
         */
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LRCHPrototype
{
    public partial class PhysicianPatientDashboard : Form
    {
        public PhysicianPatientDashboard()
        {
            InitializeComponent();
        }

        /**
         * Fill in the physician patient data grid with information
         */
        private void PhysicianPatientDashboard_Load(object sender, EventArgs e)
        {
            // create a new DataTable
            DataTable dt = new DataTable();

            // add columns to the DataTable
            dt.Columns.Add("PATIENT-NO");
            dt.Columns.Add("PATIENT-NAME");
            dt.Columns.Add("LOCATION");
            dt.Columns.Add("DATE-ADMITTED");

            // add rows to the DataTable
            dt.Rows.Add("12870", "Gonzalez, P. T.", "103A", "01/02/2023");
            dt.Rows.Add("23819", "Thomas, Marie ", "214C", "01/03/2023");
            dt.Rows.Add("61431", "Cuadra, L. R.", "281B", "02/04/2023");

            // create a new DataGridViewButtonColumn
            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
            viewButtonColumn.HeaderText = "";
            viewButtonColumn.Name = "viewButtonColumn";
            viewButtonColumn.Text = "View info";
            viewButtonColumn.UseColumnTextForButtonValue = true;

            // create a new DataGridViewButtonColumn
            DataGridViewButtonColumn addNoteButtonColumn = new DataGridViewButtonColumn();
            addNoteButtonColumn.HeaderText = "";
            addNoteButtonColumn.Name = "addNoteButtonColumn";
            addNoteButtonColumn.Text = "Add note";
            addNoteButtonColumn.UseColumnTextForButtonValue = true;

            // add the DataGridViewButtonColumn to the DataGridView
            dgvPhyPtReport.Columns.Add(viewButtonColumn);
            dgvPhyPtReport.Columns.Add(addNoteButtonColumn);

            // set rows
            dgvPhyPtReport.DataSource = dt;
        }
    }
}

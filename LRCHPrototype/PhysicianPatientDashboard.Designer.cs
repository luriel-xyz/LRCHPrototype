namespace LRCHPrototype
{
    partial class PhysicianPatientDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPhysicians = new System.Windows.Forms.DataGridView();
            this.btnGoBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicians)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhysicians
            // 
            this.dgvPhysicians.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhysicians.Location = new System.Drawing.Point(31, 61);
            this.dgvPhysicians.Name = "dgvPhysicians";
            this.dgvPhysicians.RowHeadersWidth = 51;
            this.dgvPhysicians.RowTemplate.Height = 24;
            this.dgvPhysicians.Size = new System.Drawing.Size(483, 441);
            this.dgvPhysicians.TabIndex = 3;
            this.dgvPhysicians.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhysicians_CellContentClick);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(31, 13);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 4;
            this.btnGoBack.Text = "Go back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.GoBack);
            // 
            // PhysicianPatientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 525);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.dgvPhysicians);
            this.Name = "PhysicianPatientDashboard";
            this.Text = "PhysicianPatientDashboard";
            this.Load += new System.EventHandler(this.PhysicianPatientDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicians)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhysicians;
        private System.Windows.Forms.Button btnGoBack;
    }
}
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
            this.dgvPhyPtReport = new System.Windows.Forms.DataGridView();
            this.lblPhyNo = new System.Windows.Forms.Label();
            this.lblPhyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhyPtReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhyPtReport
            // 
            this.dgvPhyPtReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhyPtReport.Location = new System.Drawing.Point(31, 92);
            this.dgvPhyPtReport.Name = "dgvPhyPtReport";
            this.dgvPhyPtReport.RowHeadersWidth = 51;
            this.dgvPhyPtReport.RowTemplate.Height = 24;
            this.dgvPhyPtReport.Size = new System.Drawing.Size(873, 410);
            this.dgvPhyPtReport.TabIndex = 3;
            // 
            // lblPhyNo
            // 
            this.lblPhyNo.AutoSize = true;
            this.lblPhyNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPhyNo.Location = new System.Drawing.Point(28, 29);
            this.lblPhyNo.Name = "lblPhyNo";
            this.lblPhyNo.Size = new System.Drawing.Size(153, 18);
            this.lblPhyNo.TabIndex = 4;
            this.lblPhyNo.Text = "PHYSICIAN-NO: 1000";
            // 
            // lblPhyName
            // 
            this.lblPhyName.AutoSize = true;
            this.lblPhyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblPhyName.Location = new System.Drawing.Point(28, 57);
            this.lblPhyName.Name = "lblPhyName";
            this.lblPhyName.Size = new System.Drawing.Size(233, 18);
            this.lblPhyName.TabIndex = 5;
            this.lblPhyName.Text = "PHYSICIAN-NAME: Messi, Leonel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(777, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "DATE: 04/03/2024";
            // 
            // PhysicianPatientDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPhyName);
            this.Controls.Add(this.lblPhyNo);
            this.Controls.Add(this.dgvPhyPtReport);
            this.Name = "PhysicianPatientDashboard";
            this.Text = "PhysicianPatientDashboard";
            this.Load += new System.EventHandler(this.PhysicianPatientDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhyPtReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhyPtReport;
        private System.Windows.Forms.Label lblPhyNo;
        private System.Windows.Forms.Label lblPhyName;
        private System.Windows.Forms.Label label1;
    }
}
namespace LRCHPrototype
{
    partial class PhysicianPatientDisplay
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
            this.btnGoBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhysicianPatient = new System.Windows.Forms.DataGridView();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPhysicianNo = new System.Windows.Forms.Label();
            this.lblPhysicianName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicianPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(29, 12);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(75, 23);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "Go back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.GoBack);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPhysicianName);
            this.groupBox1.Controls.Add(this.lblPhysicianNo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Controls.Add(this.dgvPhysicianPatient);
            this.groupBox1.Location = new System.Drawing.Point(29, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 408);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Physician Patient";
            // 
            // dgvPhysicianPatient
            // 
            this.dgvPhysicianPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhysicianPatient.Location = new System.Drawing.Point(6, 81);
            this.dgvPhysicianPatient.Name = "dgvPhysicianPatient";
            this.dgvPhysicianPatient.RowHeadersWidth = 51;
            this.dgvPhysicianPatient.RowTemplate.Height = 24;
            this.dgvPhysicianPatient.Size = new System.Drawing.Size(902, 321);
            this.dgvPhysicianPatient.TabIndex = 0;
            this.dgvPhysicianPatient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhysicianPatient_CellContentClick);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(7, 36);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(108, 16);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "PHYSICIAN-NO: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "PHYSICIAN-NAME: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "DATE: ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(833, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 16);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "10/04/2014";
            // 
            // lblPhysicianNo
            // 
            this.lblPhysicianNo.AutoSize = true;
            this.lblPhysicianNo.Location = new System.Drawing.Point(116, 36);
            this.lblPhysicianNo.Name = "lblPhysicianNo";
            this.lblPhysicianNo.Size = new System.Drawing.Size(71, 16);
            this.lblPhysicianNo.TabIndex = 5;
            this.lblPhysicianNo.Text = "10/04/2014";
            // 
            // lblPhysicianName
            // 
            this.lblPhysicianName.AutoSize = true;
            this.lblPhysicianName.Location = new System.Drawing.Point(136, 62);
            this.lblPhysicianName.Name = "lblPhysicianName";
            this.lblPhysicianName.Size = new System.Drawing.Size(71, 16);
            this.lblPhysicianName.TabIndex = 6;
            this.lblPhysicianName.Text = "10/04/2014";
            // 
            // PhysicianPatientDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 475);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGoBack);
            this.Name = "PhysicianPatientDisplay";
            this.Text = "PhysicianPatientDisplay";
            this.Load += new System.EventHandler(this.PhysicianPatientDisplay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhysicianPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPhysicianName;
        private System.Windows.Forms.Label lblPhysicianNo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DataGridView dgvPhysicianPatient;
    }
}
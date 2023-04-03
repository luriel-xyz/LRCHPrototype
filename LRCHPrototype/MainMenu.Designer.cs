namespace LRCHPrototype
{
    partial class MainMenu
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
            this.btnRoomUtilization = new System.Windows.Forms.Button();
            this.btnPhyPt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoomUtilization
            // 
            this.btnRoomUtilization.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRoomUtilization.Location = new System.Drawing.Point(26, 73);
            this.btnRoomUtilization.Name = "btnRoomUtilization";
            this.btnRoomUtilization.Size = new System.Drawing.Size(152, 44);
            this.btnRoomUtilization.TabIndex = 0;
            this.btnRoomUtilization.Text = "Room Utilization";
            this.btnRoomUtilization.UseVisualStyleBackColor = true;
            this.btnRoomUtilization.Click += new System.EventHandler(this.ShowRoomUtilizationAsync);
            // 
            // btnPhyPt
            // 
            this.btnPhyPt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnPhyPt.Location = new System.Drawing.Point(199, 73);
            this.btnPhyPt.Name = "btnPhyPt";
            this.btnPhyPt.Size = new System.Drawing.Size(152, 44);
            this.btnPhyPt.TabIndex = 1;
            this.btnPhyPt.Text = "Physician-Patient";
            this.btnPhyPt.UseVisualStyleBackColor = true;
            this.btnPhyPt.Click += new System.EventHandler(this.ShowPhysicianPatient);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 212);
            this.Controls.Add(this.btnPhyPt);
            this.Controls.Add(this.btnRoomUtilization);
            this.Name = "MainMenu";
            this.Text = "Lake Ridge Community Hospital";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRoomUtilization;
        private System.Windows.Forms.Button btnPhyPt;
    }
}


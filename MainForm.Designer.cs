namespace dcit318_assignment4_11357610
{
    partial class MainForm
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
            this.Header = new System.Windows.Forms.LinkLabel();
            this.buttonViewDoctors = new System.Windows.Forms.Button();
            this.buttonBookAppointment = new System.Windows.Forms.Button();
            this.buttonManageAppointments = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Header.AutoSize = true;
            this.Header.Location = new System.Drawing.Point(3, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(181, 16);
            this.Header.TabIndex = 0;
            this.Header.TabStop = true;
            this.Header.Text = "Medical Appointment System";
            this.Header.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Header_LinkClicked);
            // 
            // buttonViewDoctors
            // 
            this.buttonViewDoctors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewDoctors.AutoSize = true;
            this.buttonViewDoctors.Location = new System.Drawing.Point(3, 85);
            this.buttonViewDoctors.Name = "buttonViewDoctors";
            this.buttonViewDoctors.Size = new System.Drawing.Size(240, 27);
            this.buttonViewDoctors.TabIndex = 1;
            this.buttonViewDoctors.Text = "View the doctors";
            this.buttonViewDoctors.UseVisualStyleBackColor = true;
            this.buttonViewDoctors.Click += new System.EventHandler(this.buttonViewDoctors_Click);
            // 
            // buttonBookAppointment
            // 
            this.buttonBookAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBookAppointment.AutoSize = true;
            this.buttonBookAppointment.Location = new System.Drawing.Point(3, 19);
            this.buttonBookAppointment.Name = "buttonBookAppointment";
            this.buttonBookAppointment.Size = new System.Drawing.Size(240, 27);
            this.buttonBookAppointment.TabIndex = 2;
            this.buttonBookAppointment.Text = "Book an appointment";
            this.buttonBookAppointment.UseVisualStyleBackColor = true;
            this.buttonBookAppointment.Click += new System.EventHandler(this.buttonBookAppointment_Click);
            // 
            // buttonManageAppointments
            // 
            this.buttonManageAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonManageAppointments.AutoSize = true;
            this.buttonManageAppointments.Location = new System.Drawing.Point(3, 52);
            this.buttonManageAppointments.Name = "buttonManageAppointments";
            this.buttonManageAppointments.Size = new System.Drawing.Size(240, 27);
            this.buttonManageAppointments.TabIndex = 3;
            this.buttonManageAppointments.Text = "Manage Appointment";
            this.buttonManageAppointments.UseVisualStyleBackColor = true;
            this.buttonManageAppointments.Click += new System.EventHandler(this.buttonManageAppointments_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Header);
            this.flowLayoutPanel1.Controls.Add(this.buttonBookAppointment);
            this.flowLayoutPanel1.Controls.Add(this.buttonManageAppointments);
            this.flowLayoutPanel1.Controls.Add(this.buttonViewDoctors);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(266, 153);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(251, 123);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel Header;
        private System.Windows.Forms.Button buttonViewDoctors;
        private System.Windows.Forms.Button buttonBookAppointment;
        private System.Windows.Forms.Button buttonManageAppointments;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
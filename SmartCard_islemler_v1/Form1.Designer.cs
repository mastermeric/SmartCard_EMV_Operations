namespace SmartCard_islemler_v1
{
    partial class Form1
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
            this.btnConenct = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSendAPDU = new System.Windows.Forms.Button();
            this.btnATR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConenct
            // 
            this.btnConenct.Location = new System.Drawing.Point(2, 6);
            this.btnConenct.Name = "btnConenct";
            this.btnConenct.Size = new System.Drawing.Size(159, 23);
            this.btnConenct.TabIndex = 0;
            this.btnConenct.Text = "Conenct";
            this.btnConenct.UseVisualStyleBackColor = true;
            this.btnConenct.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(167, 6);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(69, 23);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSendAPDU
            // 
            this.btnSendAPDU.Location = new System.Drawing.Point(2, 112);
            this.btnSendAPDU.Name = "btnSendAPDU";
            this.btnSendAPDU.Size = new System.Drawing.Size(75, 23);
            this.btnSendAPDU.TabIndex = 2;
            this.btnSendAPDU.Text = "Send APDU";
            this.btnSendAPDU.UseVisualStyleBackColor = true;
            this.btnSendAPDU.Click += new System.EventHandler(this.btnSendAPDU_Click);
            // 
            // btnATR
            // 
            this.btnATR.Location = new System.Drawing.Point(2, 35);
            this.btnATR.Name = "btnATR";
            this.btnATR.Size = new System.Drawing.Size(234, 23);
            this.btnATR.TabIndex = 3;
            this.btnATR.Text = "ATR";
            this.btnATR.UseVisualStyleBackColor = true;
            this.btnATR.Click += new System.EventHandler(this.btnATR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Conenction :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Card ATR :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 20);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 225);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnATR);
            this.Controls.Add(this.btnSendAPDU);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConenct);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConenct;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSendAPDU;
        private System.Windows.Forms.Button btnATR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}


namespace Client
{
    partial class ConnectionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UI_Bttn_Connect = new System.Windows.Forms.Button();
            this.UI_TxBx_Address = new System.Windows.Forms.TextBox();
            this.UI_TxBx_Port = new System.Windows.Forms.TextBox();
            this.UI_PrBr_Progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // UI_Bttn_Connect
            // 
            this.UI_Bttn_Connect.Location = new System.Drawing.Point(67, 65);
            this.UI_Bttn_Connect.Name = "UI_Bttn_Connect";
            this.UI_Bttn_Connect.Size = new System.Drawing.Size(100, 23);
            this.UI_Bttn_Connect.TabIndex = 1;
            this.UI_Bttn_Connect.Text = "Connect";
            this.UI_Bttn_Connect.UseVisualStyleBackColor = true;
            this.UI_Bttn_Connect.Click += new System.EventHandler(this.UI_Bttn_Connect_Click);
            // 
            // UI_TxBx_Address
            // 
            this.UI_TxBx_Address.Location = new System.Drawing.Point(67, 13);
            this.UI_TxBx_Address.Name = "UI_TxBx_Address";
            this.UI_TxBx_Address.Size = new System.Drawing.Size(100, 20);
            this.UI_TxBx_Address.TabIndex = 0;
            // 
            // UI_TxBx_Port
            // 
            this.UI_TxBx_Port.Location = new System.Drawing.Point(67, 39);
            this.UI_TxBx_Port.Name = "UI_TxBx_Port";
            this.UI_TxBx_Port.Size = new System.Drawing.Size(100, 20);
            this.UI_TxBx_Port.TabIndex = 4;
            this.UI_TxBx_Port.Text = "1666";
            // 
            // UI_PrBr_Progress
            // 
            this.UI_PrBr_Progress.Location = new System.Drawing.Point(12, 94);
            this.UI_PrBr_Progress.Name = "UI_PrBr_Progress";
            this.UI_PrBr_Progress.Size = new System.Drawing.Size(155, 23);
            this.UI_PrBr_Progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.UI_PrBr_Progress.TabIndex = 5;
            // 
            // ConnectionDialog
            // 
            this.AcceptButton = this.UI_Bttn_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 129);
            this.Controls.Add(this.UI_PrBr_Progress);
            this.Controls.Add(this.UI_TxBx_Port);
            this.Controls.Add(this.UI_TxBx_Address);
            this.Controls.Add(this.UI_Bttn_Connect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialog";
            this.Text = "Connect to Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button UI_Bttn_Connect;
        private System.Windows.Forms.TextBox UI_TxBx_Address;
        private System.Windows.Forms.TextBox UI_TxBx_Port;
        private System.Windows.Forms.ProgressBar UI_PrBr_Progress;
    }
}
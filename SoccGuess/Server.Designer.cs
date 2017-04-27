namespace SoccGuess
{
    partial class Server
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
            this.UI_Lbl_ServerGuess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UI_Lbl_ServerGuess
            // 
            this.UI_Lbl_ServerGuess.AutoSize = true;
            this.UI_Lbl_ServerGuess.Location = new System.Drawing.Point(76, 24);
            this.UI_Lbl_ServerGuess.Name = "UI_Lbl_ServerGuess";
            this.UI_Lbl_ServerGuess.Size = new System.Drawing.Size(19, 13);
            this.UI_Lbl_ServerGuess.TabIndex = 0;
            this.UI_Lbl_ServerGuess.Text = "42";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(179, 63);
            this.Controls.Add(this.UI_Lbl_ServerGuess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.From1Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_Lbl_ServerGuess;
    }
}


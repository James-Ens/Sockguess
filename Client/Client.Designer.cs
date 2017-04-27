namespace Client
{
    partial class Client
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
            this.UI_Lbl_Messages = new System.Windows.Forms.Label();
            this.UI_Lbl_Min = new System.Windows.Forms.Label();
            this.UI_Lbl_Max = new System.Windows.Forms.Label();
            this.UI_TrBr_GuessValue = new System.Windows.Forms.TrackBar();
            this.UI_Bttn_Connect = new System.Windows.Forms.Button();
            this.UI_Bttn_Guess = new System.Windows.Forms.Button();
            this.UI_TxBx_GuessNum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrBr_GuessValue)).BeginInit();
            this.SuspendLayout();
            // 
            // UI_Lbl_Messages
            // 
            this.UI_Lbl_Messages.AutoSize = true;
            this.UI_Lbl_Messages.Location = new System.Drawing.Point(13, 13);
            this.UI_Lbl_Messages.Name = "UI_Lbl_Messages";
            this.UI_Lbl_Messages.Size = new System.Drawing.Size(163, 13);
            this.UI_Lbl_Messages.TabIndex = 0;
            this.UI_Lbl_Messages.Text = "Welcome to the Guessing Game!";
            // 
            // UI_Lbl_Min
            // 
            this.UI_Lbl_Min.AutoSize = true;
            this.UI_Lbl_Min.Location = new System.Drawing.Point(13, 97);
            this.UI_Lbl_Min.Name = "UI_Lbl_Min";
            this.UI_Lbl_Min.Size = new System.Drawing.Size(13, 13);
            this.UI_Lbl_Min.TabIndex = 1;
            this.UI_Lbl_Min.Text = "1";
            // 
            // UI_Lbl_Max
            // 
            this.UI_Lbl_Max.AutoSize = true;
            this.UI_Lbl_Max.Location = new System.Drawing.Point(337, 97);
            this.UI_Lbl_Max.Name = "UI_Lbl_Max";
            this.UI_Lbl_Max.Size = new System.Drawing.Size(31, 13);
            this.UI_Lbl_Max.TabIndex = 2;
            this.UI_Lbl_Max.Text = "1000";
            // 
            // UI_TrBr_GuessValue
            // 
            this.UI_TrBr_GuessValue.Location = new System.Drawing.Point(12, 49);
            this.UI_TrBr_GuessValue.Maximum = 1000;
            this.UI_TrBr_GuessValue.Minimum = 1;
            this.UI_TrBr_GuessValue.Name = "UI_TrBr_GuessValue";
            this.UI_TrBr_GuessValue.Size = new System.Drawing.Size(360, 45);
            this.UI_TrBr_GuessValue.TabIndex = 1;
            this.UI_TrBr_GuessValue.TickFrequency = 50;
            this.UI_TrBr_GuessValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.UI_TrBr_GuessValue.Value = 2;
            this.UI_TrBr_GuessValue.Scroll += new System.EventHandler(this.UI_TrBr_GuessValue_Scroll);
            // 
            // UI_Bttn_Connect
            // 
            this.UI_Bttn_Connect.Location = new System.Drawing.Point(12, 145);
            this.UI_Bttn_Connect.Name = "UI_Bttn_Connect";
            this.UI_Bttn_Connect.Size = new System.Drawing.Size(75, 23);
            this.UI_Bttn_Connect.TabIndex = 0;
            this.UI_Bttn_Connect.Text = "Connect";
            this.UI_Bttn_Connect.UseVisualStyleBackColor = true;
            this.UI_Bttn_Connect.Click += new System.EventHandler(this.UI_Bttn_Connect_Click);
            // 
            // UI_Bttn_Guess
            // 
            this.UI_Bttn_Guess.Enabled = false;
            this.UI_Bttn_Guess.Location = new System.Drawing.Point(293, 145);
            this.UI_Bttn_Guess.Name = "UI_Bttn_Guess";
            this.UI_Bttn_Guess.Size = new System.Drawing.Size(75, 23);
            this.UI_Bttn_Guess.TabIndex = 2;
            this.UI_Bttn_Guess.Text = "Guess";
            this.UI_Bttn_Guess.UseVisualStyleBackColor = true;
            this.UI_Bttn_Guess.Click += new System.EventHandler(this.UI_Bttn_Guess_Click);
            // 
            // UI_TxBx_GuessNum
            // 
            this.UI_TxBx_GuessNum.Location = new System.Drawing.Point(160, 94);
            this.UI_TxBx_GuessNum.Name = "UI_TxBx_GuessNum";
            this.UI_TxBx_GuessNum.Size = new System.Drawing.Size(47, 20);
            this.UI_TxBx_GuessNum.TabIndex = 4;
            this.UI_TxBx_GuessNum.Text = "1";
            // 
            // From1Client
            // 
            this.AcceptButton = this.UI_Bttn_Guess;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 180);
            this.Controls.Add(this.UI_TxBx_GuessNum);
            this.Controls.Add(this.UI_Bttn_Guess);
            this.Controls.Add(this.UI_Bttn_Connect);
            this.Controls.Add(this.UI_TrBr_GuessValue);
            this.Controls.Add(this.UI_Lbl_Max);
            this.Controls.Add(this.UI_Lbl_Min);
            this.Controls.Add(this.UI_Lbl_Messages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "From1Client";
            this.Text = "Gueesing Game";
            ((System.ComponentModel.ISupportInitialize)(this.UI_TrBr_GuessValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UI_Lbl_Messages;
        private System.Windows.Forms.Label UI_Lbl_Min;
        private System.Windows.Forms.Label UI_Lbl_Max;
        private System.Windows.Forms.TrackBar UI_TrBr_GuessValue;
        private System.Windows.Forms.Button UI_Bttn_Connect;
        private System.Windows.Forms.Button UI_Bttn_Guess;
        private System.Windows.Forms.TextBox UI_TxBx_GuessNum;
    }
}


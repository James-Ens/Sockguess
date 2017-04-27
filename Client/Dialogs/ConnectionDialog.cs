using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Client
{
    public partial class ConnectionDialog : Form
    {
        // Delegate for socket
        public delegate void delVoidSocket(Socket _);
        private delegate void delVoidVoid();
        public delVoidSocket _socketPass = null;
        Socket _sokTalk = null;
        public ConnectionDialog()
        {
            InitializeComponent();
        }

        private void UI_Bttn_Connect_Click(object sender, EventArgs e)
        {
            // Initialize the socket
            _sokTalk = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            try
            {
                _sokTalk.BeginConnect(
                    UI_TxBx_Address.Text,
                    int.Parse(UI_TxBx_Port.Text),
                    ConnectComplete,
                    _sokTalk);
                UI_PrBr_Progress.Style = ProgressBarStyle.Marquee;
                UI_PrBr_Progress.MarqueeAnimationSpeed = 100;
                Text = "Connecting...";
                UI_Bttn_Connect.Enabled = false;
            }
            catch (Exception err)
            {
                Console.WriteLine("Failed connect");
                Console.WriteLine(err.Message);
            }
        }
        private void ConnectComplete(IAsyncResult ar)
        {
            Socket tempSok = (Socket)(ar.AsyncState);

            // See if connection complete
            try
            {
                tempSok.EndConnect(ar);
                _socketPass(tempSok);
                DialogResult = DialogResult.OK;
            }
            catch (Exception err)
            {
                try
                {
                    Invoke(new Action(FailedConnect));
                }
                catch(Exception er)
                {
                    Console.WriteLine(er.Message);
                }
                Console.WriteLine(err.Message);
            }
        }
        private void FailedConnect()
        {
            UI_PrBr_Progress.Style = ProgressBarStyle.Continuous;
            UI_PrBr_Progress.MarqueeAnimationSpeed = 0;
            UI_Bttn_Connect.Enabled = true;
            Text = "Connect to Server";
            MessageBox.Show("Failed to connect", "Error");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Net;
using SocketGuessTrany2017;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Client
{
    public partial class Client : Form
    {
        private Socket _sokTalk;
        // Bool to control connect button state
        private bool _disconnect = false;        
        Thread _socketThread;
        ConnectionDialog dlg = new ConnectionDialog();
        public Client()
        {
            InitializeComponent();
        }
        private void UI_TrBr_GuessValue_Scroll(object sender, EventArgs e)
        {
            UI_TxBx_GuessNum.Text = UI_TrBr_GuessValue.Value.ToString();
        }
        private void UI_Bttn_Connect_Click(object sender, EventArgs e)
        {
            if (!_disconnect)
            {
                dlg = new ConnectionDialog();
                dlg._socketPass = new ConnectionDialog.delVoidSocket(ConnectResult);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Change connect to disconnect
                    UI_Bttn_Connect.Text = "Disconnect";
                    _disconnect = true;
                    // Enable gameplay
                    UI_Bttn_Guess.Enabled = true;
                    dlg = null;
                }
            }
            else
            {
                DisconnectButton();        
            }
        }

        private void UI_Bttn_Guess_Click(object sender, EventArgs e)
        {
            int guessVal;
            // Validate text is a number
            if (!int.TryParse(UI_TxBx_GuessNum.Text, out guessVal))
            {
                MessageBox.Show("Guess must be a number", "Input Error");
                UI_TxBx_GuessNum.Text = UI_TrBr_GuessValue.Minimum.ToString();
                guessVal = UI_TrBr_GuessValue.Minimum;
            }
            // Validate number is less than max
            if (guessVal > UI_TrBr_GuessValue.Maximum)
            {
                guessVal = UI_TrBr_GuessValue.Maximum;
                UI_TxBx_GuessNum.Text = UI_TrBr_GuessValue.Maximum.ToString();
            }
            // Validate number is greater than min
            else if (guessVal < UI_TrBr_GuessValue.Minimum)
            {
                guessVal = UI_TrBr_GuessValue.Minimum;
                UI_TxBx_GuessNum.Text = UI_TrBr_GuessValue.Minimum.ToString();
            }
            UI_TrBr_GuessValue.Value = guessVal;
            // New guessframe
            GuessFrame frame = new GuessFrame(guessVal);
            // Memorystream to serialize to
            MemoryStream ms = new MemoryStream();
            // Need to know how to serialize
            BinaryFormatter bf = new BinaryFormatter();
            //serialize
            bf.Serialize(ms,frame);
            // Send the serialized guessframe
            try
            {
                _sokTalk.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
            }
            catch
            {
                Console.WriteLine("failed sending the guess");
            }
        }
        private void ConnectResult(Socket connectedSok)
        {
            _sokTalk = connectedSok;
            // Start the manual thread
            _socketThread = new Thread(new ParameterizedThreadStart(Th_SocketThread));
            _socketThread.IsBackground = true;
            _socketThread.Start(_sokTalk);
        }

        private void Th_SocketThread(object obj)
        {
            // Socket is connected
            // The socket
            Socket sock = (Socket)obj;
            //byte array for data
            byte[] buff = new byte[2000];
            // Receive calls shouldn't time out
            sock.ReceiveTimeout = 0;
            Invoke(new Action(() =>
            {
                UI_Lbl_Messages.Text = "Connected. Please guess a number";
            }));
            while (true)
            {
                // store received bytes
                int bytesReceived = 0;

                try
                {
                    // Throws on a hard disconnect
                    bytesReceived = sock.Receive(buff);
                }
                catch (Exception err)
                {
                    // Hard disconnect occurred
                    Console.WriteLine("SocketThread: " + err.Message);

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            NewGame();
                            DisconnectButton();
                            UI_Lbl_Messages.Text = "Server disconnected. Please reconnect to play a new game.";
                        }));
                    }
                    catch(Exception erry)
                    {
                        Console.WriteLine(erry.Message);
                    }
                    
                    
                    return;
                }

                if(bytesReceived == 0)
                {
                    // Soft disconnect occurred
                    Console.WriteLine("SocketThread: socket disconnect detected");

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            NewGame();
                            DisconnectButton();
                            UI_Lbl_Messages.Text = "Server disconnected. Please reconnect to play a new game.";
                        }));
                    }
                    catch (Exception erry)
                    {
                        Console.WriteLine(erry.Message);
                    }

                    return;
                }
                // Deserialize data from buffer
                BinaryFormatter bf = new BinaryFormatter();

                GuessFrame guess = null;

                try
                {
                    guess = (GuessFrame)bf.Deserialize(new MemoryStream(buff));
                }
                catch(Exception err)
                {
                    // bad info given - unexpected data
                    Console.WriteLine("SocketThread: " + err.Message);

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            NewGame();
                            DisconnectButton();
                            UI_Lbl_Messages.Text = "Disconnected from server. Stop hacking my microwave! Please reconnect to play again.";
                        }));
                    }
                    catch(Exception erry)
                    {
                        Console.WriteLine(erry.Message);
                    }
                    
                    return;
                }
                
                string guessResponse = "";
                if (guess._GuessOrResponse < 0)
                {
                    guessResponse = "Guess was too low!";
                    // Make the lowest value on the trackbar the guess as the number cannot be any lower
                    // Update the minimum label

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            UI_TrBr_GuessValue.Minimum = UI_TrBr_GuessValue.Value + 1;
                            UI_Lbl_Min.Text = UI_TrBr_GuessValue.Minimum.ToString();
                        }));
                    }
                    catch(Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                    
                }
                else if(guess._GuessOrResponse>0)
                {
                    guessResponse = "Guess was too high!";
                    // Make the highest value on the trackbar the guess as the number cannot be any higher
                    // Update the maximum label

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            UI_TrBr_GuessValue.Maximum = UI_TrBr_GuessValue.Value - 1;
                            UI_Lbl_Max.Text = UI_TrBr_GuessValue.Maximum.ToString();
                        }));
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message);
                    }
                    
                }
                else
                {
                    guessResponse = "Correct! Enter another guess to start a new game...";
                    // Reset controls
                    Invoke(new Action(() => NewGame()));
                }
                // Now update the UI based on guess
                Invoke(new Action(() => UI_Lbl_Messages.Text = guessResponse));
                
            }
        }
        /// <summary>
        /// Helper method to reset controls
        /// </summary>
        private void NewGame()
        {
            UI_TrBr_GuessValue.Maximum = 1000;
            UI_TrBr_GuessValue.Minimum = 1;
            UI_Lbl_Min.Text = "1";
            UI_Lbl_Max.Text = "1000";
        }


        private void DisconnectButton()
        {
            // Shut down connection
            // Change connect to disconnect
            UI_Bttn_Connect.Text = "Connect";
            _disconnect = false;
            // Disable gameplay
            UI_Bttn_Guess.Enabled = false;
            // Close the socket
            _sokTalk.Close();
        }

    }
}

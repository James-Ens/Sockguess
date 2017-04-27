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
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SocketGuessTrany2017;

namespace SoccGuess
{
    public partial class Server : Form
    {
        // Class instances
        private BinaryFormatter _bf = new BinaryFormatter();
        private static Random _rnd = new Random();
        // Delegates
        private delegate void delVoidString(string error);
        private delegate void delVoidInt(int data);
        // Socket
        private Socket _sockListen;
        // Secret number to be guessed
        private  int _secretNum;


        public Server()
        {
            InitializeComponent();
        }

        private void From1Server_Load(object sender, EventArgs e)
        {
            GetNewNum();
            UI_Lbl_ServerGuess.Text = _secretNum.ToString();
            InitSokcet();
        }
        private void Accept(IAsyncResult ar)
        {
            // Pull in listening socket
            Socket sock = (Socket)ar.AsyncState;
            try
            {
                // End accept, connection made
                Socket connsock = sock.EndAccept(ar);
                // Close socket, only accept once
                _sockListen.Close();
                // Send off connected socket
                Thread t = new Thread(MainRXThread);
                t.IsBackground = true;
                t.Start(connsock);
            }
            catch(SocketException err)
            {
                Invoke(new delVoidString(Error), err.Message);
            }
        }
        /// <summary>
        /// Main receiving thread
        /// </summary>
        /// <param name="sok"></param>
        private void MainRXThread(object obj)
        {
            byte[] buffer = new byte[2000];
            Socket sok = (Socket)obj;
            sok.ReceiveTimeout = 0;
            while (true)
            {
                int bytes = 0;
                try
                {
                    bytes = sok.Receive(buffer);
                }
                catch (Exception err)
                {
                    Console.WriteLine("RXthread : " + err.Message);

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            GetNewNum();
                            UI_Lbl_ServerGuess.Text = _secretNum.ToString();
                        }));
                    }
                    catch(Exception erry)
                    {
                        Console.WriteLine(erry.Message);
                    }
                    

                    // Start listener again since disconnect
                    InitSokcet();              
                    return;
                }
                if (bytes == 0)
                {
                    Console.WriteLine("RXthread : soft disconnect");

                    try
                    {
                        Invoke(new Action(() =>
                        {
                            GetNewNum();
                            UI_Lbl_ServerGuess.Text = _secretNum.ToString();
                        }));
                    }
                    catch (Exception erry)
                    {
                        Console.WriteLine(erry.Message);
                    }

                    // Start listener again since disconnect
                    InitSokcet();
                    return;
                }


                // Process data

                GuessFrame gf = null;

                try
                {
                    gf = (GuessFrame)_bf.Deserialize(new MemoryStream(buffer));
                }
                catch (Exception err)
                {
                    // bad info given - unexpected data
                    Console.WriteLine("SocketThread: " + err.Message);
                    //MessageBox.Show("Stop hacking my microwave!", "Data Error");

                    sok.Close();
                    InitSokcet();

                    Invoke(new Action(() =>
                    {
                        GetNewNum();
                        UI_Lbl_ServerGuess.Text = _secretNum.ToString();
                    }));

                    return;
                }
                
                Console.WriteLine(gf._GuessOrResponse);
                int howClose = gf._GuessOrResponse.CompareTo(_secretNum);
                MemoryStream ms = new MemoryStream();
                _bf.Serialize(ms, new GuessFrame(howClose));
                // Too low
                if (howClose < 0)
                {
                    try
                    {
                        sok.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                    }
                    catch
                    {
                        Console.WriteLine("Failed send");
                    }
                }
                // Too high 
                else if (howClose > 0)
                {
                    try
                    {
                        sok.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                    }
                    catch
                    {
                        Console.WriteLine("Failed send");
                    }
                }
                // Correct guess
                else
                {
                    try
                    {
                        sok.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                        // Get new number and update UI
                        GetNewNum();

                        try
                        {
                            Invoke(new Action(() => UI_Lbl_ServerGuess.Text = _secretNum.ToString()));
                        }
                        catch(Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }
                        
                    }
                    catch
                    {
                        Console.WriteLine("Failed send");
                    }
                }
            }
        }
        private void Error(string error)
        {
            Console.WriteLine(error);
            Console.WriteLine("Failed connection");
        }
        /// <summary>
        /// Generate new number
        /// </summary>
        private void GetNewNum()
        {
            _secretNum = _rnd.Next(1, 1001);            
        }
        /// <summary>
        ///Method to initialize socket 
        /// </summary>
        private void InitSokcet()
        {
            try
            {
                // Initializing socket
                _sockListen = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                    );
            }
            catch
            {
                Console.WriteLine("Failed initializing socket");
            }        
            try
            {
                // Bind the socket
                _sockListen.Bind(new IPEndPoint(IPAddress.Any, 1666));
            }
            catch
            {
                Console.WriteLine("Failed binding socket to port");
                MessageBox.Show("Someone is already on your port!", "Port Error");
                Close();
            }
            try
            {
                // Start listening
                // The one limits the server to one connection
                _sockListen.Listen(5);
            }
            catch
            {
                Console.WriteLine("Failed Listen");
            }
            try
            {
                // Wait for connection (asynchronous)
                _sockListen.BeginAccept(Accept, _sockListen);
            }
            catch
            {
                Console.WriteLine("Failed async accept");
            }
        }

    }
}

using System;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Collections;
using System.Net;
using log4net;


namespace VIKGroundStation
{
    public class MySocket
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private TcpListener server;
        public TcpClient client;
        public Thread readClientThread;
        private NetworkStream netstream;

        int client_num = 0;
        private Hashtable hb;

        /// <summary>
        /// TCP_Server接到新连接之后的处理线程，专门接收新连接发来的数据
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadFunc(object obj)
        {
            //通过hash表hb得到client的socket
            Socket s = hb[obj] as Socket;

            while (true)
            {
                try
                {
                    int len = s.Available;
                    if (len > 0)
                    {
                        byte[] recv_buf = new byte[128];
                        s.Receive(recv_buf);
                        string str_recv = Encoding.GetEncoding("gb2312").GetString(recv_buf);
                        string buf = string.Format("recv from{0}:{1}", obj, str_recv);
                    }
                }
                catch (SocketException)
                {
                    hb.Remove(obj);
                    Thread.CurrentThread.Abort();
                    client_num -= 1;
                }
            }
        }

        /// <summary>
        /// 启动TCP_Server，监听连接；
        /// </summary>
        /// <param name="_addr"></param>
        /// <param name="_port"></param>
        public void ServerStart(IPAddress _ipAddr, int _port)
        {
            hb = new Hashtable();
            server = new TcpListener(_ipAddr, _port);
            server.Start();
            //tb3.AppendText(string.Format("TCP_Server已启动，IP:{0}\tport:{1}\n", _ipAddr, _port));
            client_num = 0;

            while (true)
            {
                if (server.Pending())
                {
                    Socket newclient = server.AcceptSocket();
                    String clientName = string.Format("{0}:{1}", ((IPEndPoint)newclient.RemoteEndPoint).Address.ToString(),
                       ((IPEndPoint)newclient.RemoteEndPoint).Port.ToString());
                    client_num += 1;

                    //将新连接加如hash表，方便后面有选择的发送消息（server一对多通信）
                    hb.Add(clientName, newclient);
                    //将新连接名称加入combox中，这样可以在发送时选择client
                    //cb2.Items.Add(clientName);

                    Thread clientThread = new Thread(new ParameterizedThreadStart(ThreadFunc));
                    clientThread.IsBackground = true;
                    clientThread.Start(clientName);
                }
            }
        }

        /// <summary>
        /// 关闭Server,释放资源
        /// </summary>
        public void ServerStop()
        {
            if (server != null)
            {
                server.Stop();
            }
            //关闭客户端,关闭接收线程的事情在ThreadFunc里做
            if (hb.Count != 0)
            {
                foreach (Socket session in hb.Values)
                {
                    session.Shutdown(SocketShutdown.Both);
                }
                hb.Clear();
                hb = null;
                //cb2.Items.Clear();
                //cb2.Text = null;
                //lb5.Text = "当前连接数:0";
            }
        }

        /// <summary>
        /// 执行server对client数据的发送
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        public void ServerSend(object obj, string msg)
        {
            //通过hash表hb得到client的socket
            Socket s = hb[obj] as Socket;
            s.Send(Encoding.GetEncoding("gb2312").GetBytes(msg));
        }
        //private MainWindow mainWindow;
        public MySocket()
        {
            //mainWindow = main;
        }

        byte[] recv_buf_socket = new byte[1024];
        private void readDataThread()
        {
            while (true)
            {
                try
                {
                    netstream = client.GetStream();
                    int n = netstream.Read(recv_buf_socket, 0, 1024);

                    DATA_LINK.Save_DownLink_Data(recv_buf_socket, (uint)n);

                    if (DATA_LINK.byteToBeParse + n <= 10000)
                    {
                        if (DATA_LINK.byteToBeParse < 0)
                            DATA_LINK.byteToBeParse = 0;

                        Array.Copy(recv_buf_socket, 0, DATA_LINK.destinationArray, DATA_LINK.byteToBeParse, n);
                        DATA_LINK.byteToBeParse += n;
                    }
                    else
                    {
                        Array.Copy(recv_buf_socket, 0, DATA_LINK.destinationArray, 0, n);
                        DATA_LINK.byteToBeParse = n;
                    }
                    DATA_LINK.Decode_SerialPort_Data();
                }
                catch
                {
                }
            }
        }

        public bool ClientStart(System.Net.IPAddress _ipAddr, int _port)
        {
            client = new TcpClient();
            try
            {
                client.Connect(_ipAddr, _port);
                readClientThread = new Thread(readDataThread);
                readClientThread.SetApartmentState(ApartmentState.STA);
                readClientThread.Start();
                readClientThread.IsBackground = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void clientSend(string msg)
        {
            netstream.Write(Encoding.GetEncoding("gb2312").GetBytes(msg), 0, msg.Length);
        }
        public void clientSend1(string msg)
        {           
            netstream.Write(Encoding.GetEncoding("gb2312").GetBytes(msg), 0, msg.Length);          
        }
        public void clientSend(byte[] buf, int argBuf_len)
        {
            netstream.Write(buf, 0, argBuf_len);
        }
        
        public void ClientStop()
        {
            readClientThread.Abort();
            client.Close();
        }
    }
}

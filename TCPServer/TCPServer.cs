using System.Text;
using SuperSimpleTcp;
using chiffrement_C_sar;
using System.CodeDom;

namespace TCPServer
{
    public partial class TCPServer : Form
    {
        public TCPServer()
        {
            InitializeComponent();
            //server = new SimpleTcpServer("127.0.0.1:9000"); // Provide a default IP and port
        }
        SimpleTcpServer server;
        private const int ROT_KEY = 55;


        private void TCPServer_Load(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            server = new SimpleTcpServer(txtIP.Text);
            server.Events.ClientConnected += Events_ClientConnected;
            server.Events.ClientDisconnected += Events_ClientDisconnected;
            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string receivedMessage = Encoding.UTF8.GetString(e.Data);
                string decryptedMessage = Chiffrement_C_sar.RotString(receivedMessage, -ROT_KEY); // Decrypt before displaying

                txtInfo.Text += $"{e.IpPort}: {decryptedMessage} {Environment.NewLine}";

                // Forward the decrypted message to another client (if any)
                foreach (var client in server.GetClients())
                {
                    if (client != e.IpPort) // Avoid echoing back to the sender
                    {
                        string encryptedMessage = Chiffrement_C_sar.RotString(decryptedMessage, ROT_KEY);
                        server.Send(client, encryptedMessage);
                    }
                }
            });
        }

        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort}: disconnected {Environment.NewLine}";
                listClientIP.Items.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.Text += $"{e.IpPort} connected {Environment.NewLine}";
                listClientIP.Items.Add(e.IpPort);
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.Text += $"Server started..{Environment.NewLine}";
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening && listClientIP.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(txtMsg.Text))
                {
                    string encryptedMessage = Chiffrement_C_sar.RotString(txtMsg.Text, ROT_KEY);
                    server.Send(listClientIP.SelectedItem.ToString(), encryptedMessage);
                    txtInfo.Text += $"Server (Encrypted): {encryptedMessage} {Environment.NewLine}";
                    txtMsg.Text = string.Empty;
                }
            }
        }


    }
}

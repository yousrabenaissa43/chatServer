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
                string encryptedMessage = Encoding.UTF8.GetString(e.Data);

                txtInfo.Text += $"{e.IpPort}: {encryptedMessage} {Environment.NewLine}";

                // Forward the received (already encrypted) message to other clients
                foreach (var client in server.GetClients())
                {
                    if (client != e.IpPort) // Avoid echoing back to sender
                    {
                        server.Send(client, encryptedMessage); // Forward as is (already encrypted)
                    }
                }
            });
        }



        private void Events_ClientDisconnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.AppendText($"{e.IpPort}: disconnected{Environment.NewLine}");
                listClientIP.Items.Remove(e.IpPort);
            });
        }

        private void Events_ClientConnected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.AppendText($"{e.IpPort} connected{Environment.NewLine}");
                listClientIP.Items.Add(e.IpPort);
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server.Start();
            txtInfo.AppendText("Server started.." + Environment.NewLine);
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }
    }
}
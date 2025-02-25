using System.Text;
using SuperSimpleTcp;

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
                txtInfo.Text += $"{e.IpPort} {Encoding.UTF8.GetString(e.Data)} {Environment.NewLine}";
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
            txtInfo.Text += $"Starting..{Environment.NewLine}";
            btnStart.Enabled = false;
            btnSend.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (server.IsListening)
            {
                if (!string.IsNullOrEmpty(txtMsg.Text) && listClientIP.SelectedItem != null)
                {
                    server.Send(listClientIP.SelectedItem.ToString(), txtMsg.Text);
                    txtInfo.Text += $"Server : {txtMsg.Text} {Environment.NewLine}";
                    txtMsg.Text = string.Empty;
                }
            }
        }

    
    }
}

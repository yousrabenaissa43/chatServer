using SuperSimpleTcp;
using System.Text;
using chiffrement_C_sar;
namespace TCPClient
{
    public partial class TCPClient : Form
    {
        private const int ROT_KEY = 55;

        public TCPClient()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;

        private void TCPClient_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient(txtIP.Text);
            client.Events.Connected += Events_Connected;
            client.Events.Disconnected += Events_Disconnected;
            client.Events.DataReceived += Events_DataReceived;
            btnSend.Enabled = false;
        }
        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string encryptedMessage = Encoding.UTF8.GetString(e.Data);
                string decryptedMessage = Chiffrement_C_sar.RotString(encryptedMessage, -ROT_KEY); // Decrypt

                txtInfo.Text += $"Other Client: {decryptedMessage}{Environment.NewLine}";
            });
        }


        private void Events_Disconnected(object sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.AppendText("Server disconnected" + Environment.NewLine);
            });
        }

        private void Events_Connected(object? sender, ConnectionEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtInfo.AppendText("Server connected" + Environment.NewLine);
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();
                btnSend.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                if (!string.IsNullOrEmpty(txtMsg.Text))
                {
                    string encryptedMessage = Chiffrement_C_sar.RotString(txtMsg.Text, ROT_KEY);
                    client.Send(encryptedMessage);
                    txtInfo.AppendText($"Me : {txtMsg.Text}{Environment.NewLine}");
                    txtMsg.Text = string.Empty;
                }
            }
        }
    }
}
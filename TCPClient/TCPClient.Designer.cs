namespace TCPClient
{
    partial class TCPClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtIP = new TextBox();
            txtInfo = new TextBox();
            txtMsg = new TextBox();
            btnSend = new Button();
            btnConnect = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 29);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 0;
            label1.Text = "server :";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(137, 29);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(242, 27);
            txtIP.TabIndex = 1;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // txtInfo
            // 
            txtInfo.Enabled = false;
            txtInfo.Location = new Point(53, 75);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(711, 244);
            txtInfo.TabIndex = 2;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(172, 341);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(592, 27);
            txtMsg.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(373, 388);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 4;
            btnSend.Text = "send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(532, 388);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 341);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "message :";
            // 
            // TCPClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 467);
            Controls.Add(label2);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Controls.Add(txtMsg);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "TCPClient";
            Text = "TCP Client";
            Load += TCPClient_Load;
            ResumeLayout(false);
            PerformLayout();
            // 
            // TCPClientForm
            // 


        }

        #endregion

        private Label label1;
        private TextBox txtIP;
        private TextBox txtInfo;
        private TextBox txtMsg;
        private Button btnSend;
        private Button btnConnect;
        private Label label2;
    }
}

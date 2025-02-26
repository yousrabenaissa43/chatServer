namespace TCPServer
{
    partial class TCPServer
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
            label2 = new Label();
            btnStart = new Button();
            btnSend = new Button();
            txtMsg = new TextBox();
            txtInfo = new TextBox();
            txtIP = new TextBox();
            label1 = new Label();
            listClientIP = new ListBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 350);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 13;
            label2.Text = "message :";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(307, 390);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 12;
            btnStart.Text = "start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(175, 392);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 11;
            btnSend.Text = "send";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(137, 347);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(276, 27);
            txtMsg.TabIndex = 10;
            // 
            // txtInfo
            // 
            txtInfo.Enabled = false;
            txtInfo.Location = new Point(45, 77);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(368, 244);
            txtInfo.TabIndex = 9;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(129, 31);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(242, 27);
            txtIP.TabIndex = 8;
            txtIP.Text = "127.0.0.1:9000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 31);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 7;
            label1.Text = "server :";
            // 
            // listClientIP
            // 
            listClientIP.FormattingEnabled = true;
            listClientIP.Location = new Point(440, 77);
            listClientIP.Name = "listClientIP";
            listClientIP.Size = new Size(329, 344);
            listClientIP.TabIndex = 14;
            // 
            // TCPServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listClientIP);
            Controls.Add(label2);
            Controls.Add(btnStart);
            Controls.Add(btnSend);
            Controls.Add(txtMsg);
            Controls.Add(txtInfo);
            Controls.Add(txtIP);
            Controls.Add(label1);
            Name = "TCPServer";
            Text = "Form1";
            Load += TCPServer_Load;
            Click += TCPServer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnStart;
        private Button btnSend;
        private TextBox txtMsg;
        private TextBox txtInfo;
        private TextBox txtIP;
        private Label label1;
        private ListBox listClientIP;
    }
}

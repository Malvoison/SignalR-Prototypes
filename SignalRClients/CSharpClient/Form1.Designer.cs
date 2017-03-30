namespace CSharpClient
{
    partial class frmSignalRClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSimpleTest = new System.Windows.Forms.Button();
            this.pbConnect = new System.Windows.Forms.Button();
            this.pbChatSend = new System.Windows.Forms.Button();
            this.pbSetMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbSimpleTest
            // 
            this.pbSimpleTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbSimpleTest.Location = new System.Drawing.Point(12, 12);
            this.pbSimpleTest.Name = "pbSimpleTest";
            this.pbSimpleTest.Size = new System.Drawing.Size(145, 37);
            this.pbSimpleTest.TabIndex = 0;
            this.pbSimpleTest.Text = "Simple Test";
            this.pbSimpleTest.UseVisualStyleBackColor = true;
            this.pbSimpleTest.Click += new System.EventHandler(this.pbSimpleTest_Click);
            // 
            // pbConnect
            // 
            this.pbConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbConnect.Location = new System.Drawing.Point(163, 12);
            this.pbConnect.Name = "pbConnect";
            this.pbConnect.Size = new System.Drawing.Size(145, 37);
            this.pbConnect.TabIndex = 1;
            this.pbConnect.Text = "Connect to SR Hub";
            this.pbConnect.UseVisualStyleBackColor = true;
            this.pbConnect.Click += new System.EventHandler(this.pbConnect_Click);
            // 
            // pbChatSend
            // 
            this.pbChatSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbChatSend.Location = new System.Drawing.Point(314, 12);
            this.pbChatSend.Name = "pbChatSend";
            this.pbChatSend.Size = new System.Drawing.Size(145, 37);
            this.pbChatSend.TabIndex = 2;
            this.pbChatSend.Text = "Call Chat.Send";
            this.pbChatSend.UseVisualStyleBackColor = true;
            this.pbChatSend.Click += new System.EventHandler(this.pbChatSend_Click);
            // 
            // pbSetMessage
            // 
            this.pbSetMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbSetMessage.Location = new System.Drawing.Point(465, 12);
            this.pbSetMessage.Name = "pbSetMessage";
            this.pbSetMessage.Size = new System.Drawing.Size(145, 37);
            this.pbSetMessage.TabIndex = 3;
            this.pbSetMessage.Text = "Call Chat.SetMsg";
            this.pbSetMessage.UseVisualStyleBackColor = true;
            this.pbSetMessage.Click += new System.EventHandler(this.pbSetMessage_Click);
            // 
            // frmSignalRClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(704, 488);
            this.Controls.Add(this.pbSetMessage);
            this.Controls.Add(this.pbChatSend);
            this.Controls.Add(this.pbConnect);
            this.Controls.Add(this.pbSimpleTest);
            this.Name = "frmSignalRClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignalR Client Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pbSimpleTest;
        private System.Windows.Forms.Button pbConnect;
        private System.Windows.Forms.Button pbChatSend;
        private System.Windows.Forms.Button pbSetMessage;
    }
}


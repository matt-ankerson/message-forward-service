namespace Notifier.UI
{
    partial class Form1
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
            this.lblSenderName = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.lblMessageContent = new System.Windows.Forms.Label();
            this.txtMessageContent = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSenderName
            // 
            this.lblSenderName.AutoSize = true;
            this.lblSenderName.Location = new System.Drawing.Point(12, 60);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(72, 13);
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Text = "Sender Name";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Location = new System.Drawing.Point(12, 77);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(100, 20);
            this.txtSenderName.TabIndex = 1;
            // 
            // lblMessageContent
            // 
            this.lblMessageContent.AutoSize = true;
            this.lblMessageContent.Location = new System.Drawing.Point(12, 104);
            this.lblMessageContent.Name = "lblMessageContent";
            this.lblMessageContent.Size = new System.Drawing.Size(90, 13);
            this.lblMessageContent.TabIndex = 2;
            this.lblMessageContent.Text = "Message Content";
            // 
            // txtMessageContent
            // 
            this.txtMessageContent.Location = new System.Drawing.Point(12, 121);
            this.txtMessageContent.Name = "txtMessageContent";
            this.txtMessageContent.Size = new System.Drawing.Size(199, 20);
            this.txtMessageContent.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(101, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Register a Message";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 157);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 216);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtMessageContent);
            this.Controls.Add(this.lblMessageContent);
            this.Controls.Add(this.txtSenderName);
            this.Controls.Add(this.lblSenderName);
            this.Name = "Form1";
            this.Text = "Create Message";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSenderName;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label lblMessageContent;
        private System.Windows.Forms.TextBox txtMessageContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSend;
    }
}


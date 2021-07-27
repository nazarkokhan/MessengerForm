namespace MessengerForm
{
    partial class Form1
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Send = new System.Windows.Forms.Button();
            this.Messages = new System.Windows.Forms.ListBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Send
            // 
            this.Send.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Send.Location = new System.Drawing.Point(463, 385);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(55, 45);
            this.Send.TabIndex = 0;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = false;
            this.Send.Click += new System.EventHandler(this.button1_Click);
            // 
            // Messages
            // 
            this.Messages.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Messages.FormattingEnabled = true;
            this.Messages.Location = new System.Drawing.Point(27, 12);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(491, 251);
            this.Messages.TabIndex = 1;
            this.Messages.SelectedIndexChanged += new System.EventHandler(this.Messages_SelectedIndexChanged);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox.Location = new System.Drawing.Point(27, 385);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(430, 45);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image) (resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.Send);
            this.Name = "Form1";
            this.Text = "Pipe";
            this.Load += new System.EventHandler(this.Pipe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.ListBox Messages;

        private System.Windows.Forms.TextBox textBox;

        #endregion
    }
}
namespace pocRssReader
{
    partial class RssReaderForm
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.TitlesComboBox = new System.Windows.Forms.ComboBox();
            this.LinkLabel = new System.Windows.Forms.LinkLabel();
            this.ChannelTextBox = new System.Windows.Forms.TextBox();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.ReturnedItems = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(549, 45);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(197, 61);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // TitlesComboBox
            // 
            this.TitlesComboBox.FormattingEnabled = true;
            this.TitlesComboBox.Location = new System.Drawing.Point(51, 155);
            this.TitlesComboBox.Name = "TitlesComboBox";
            this.TitlesComboBox.Size = new System.Drawing.Size(695, 28);
            this.TitlesComboBox.TabIndex = 1;
            this.TitlesComboBox.SelectedIndexChanged += new System.EventHandler(this.TitlesComboBox_SelectedIndexChanged);
            // 
            // LinkLabel
            // 
            this.LinkLabel.AutoSize = true;
            this.LinkLabel.Location = new System.Drawing.Point(47, 625);
            this.LinkLabel.Name = "LinkLabel";
            this.LinkLabel.Size = new System.Drawing.Size(52, 20);
            this.LinkLabel.TabIndex = 2;
            this.LinkLabel.TabStop = true;
            this.LinkLabel.Text = "Open:";
            this.LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // ChannelTextBox
            // 
            this.ChannelTextBox.Location = new System.Drawing.Point(51, 45);
            this.ChannelTextBox.Name = "ChannelTextBox";
            this.ChannelTextBox.ReadOnly = true;
            this.ChannelTextBox.Size = new System.Drawing.Size(423, 26);
            this.ChannelTextBox.TabIndex = 3;
            // 
            // WebBrowser
            // 
            this.WebBrowser.Location = new System.Drawing.Point(51, 232);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(686, 376);
            this.WebBrowser.TabIndex = 5;
            // 
            // ReturnedItems
            // 
            this.ReturnedItems.AutoSize = true;
            this.ReturnedItems.Location = new System.Drawing.Point(59, 206);
            this.ReturnedItems.Name = "ReturnedItems";
            this.ReturnedItems.Size = new System.Drawing.Size(93, 20);
            this.ReturnedItems.TabIndex = 7;
            this.ReturnedItems.Text = "Returned: 0";
            // 
            // RssReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 702);
            this.Controls.Add(this.ReturnedItems);
            this.Controls.Add(this.WebBrowser);
            this.Controls.Add(this.ChannelTextBox);
            this.Controls.Add(this.LinkLabel);
            this.Controls.Add(this.TitlesComboBox);
            this.Controls.Add(this.RefreshButton);
            this.Name = "RssReaderForm";
            this.Text = "RSS Reader PoC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox TitlesComboBox;
        private System.Windows.Forms.LinkLabel LinkLabel;
        private System.Windows.Forms.TextBox ChannelTextBox;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.Label ReturnedItems;
    }
}


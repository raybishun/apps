using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace pocRssReader
{
    public partial class RssReaderForm : Form
    {
        public RssReaderForm()
        {
            InitializeComponent();

            // Set Form Properties
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            CenterToScreen();
            AcceptButton = RefreshButton;
            ChannelTextBox.Text = "https://status.cloudappsecurity.com/history.rss";
        }

        string[,] rssData = null;
        
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ReturnedItems.Text = "Returned: 0";
            TitlesComboBox.Items.Clear();

            try
            {
                RssItem rssItem = new RssItem();

                rssData = rssItem.GetRssData(ChannelTextBox.Text.Trim());

                ReturnedItems.Text = $"Returned: {rssItem.RssItemCount.ToString()}";

                if (rssData != null)
                {
                    for (int i = 0; i < rssData.GetLength(0); i++)
                    {
                        if (rssData[i, 1] != null)
                        {
                            string pubDate = UtilScrubData.RemoveZeros(rssData[i, 0]);
                            string title = rssData[i, 1];

                            // Populate ComboBox
                            TitlesComboBox.Items.Add($"{pubDate} | {title}");
                        }
                    }

                    TitlesComboBox.SelectedIndex = 0;

                    rssItem.CreateCsvFile(rssData, @"rssItems.csv");

                    rssItem.CreateJsonFile(rssData, @"rssItems.json"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TitlesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rssData[TitlesComboBox.SelectedIndex, 1] != null)
            {
                WebBrowser.DocumentText = rssData[TitlesComboBox.SelectedIndex, 2];
            }

            if (rssData[TitlesComboBox.SelectedIndex, 1] != null)
            {
                LinkLabel.Text = $"Open: {rssData[TitlesComboBox.SelectedIndex, 1]}";
            }
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (rssData[TitlesComboBox.SelectedIndex, 3] != null)
                {
                    Process.Start(rssData[TitlesComboBox.SelectedIndex, 3]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
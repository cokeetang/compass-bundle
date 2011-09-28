using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IniParser;
namespace compass_bundle_ui
{
    public partial class confForm : Form
    {
        private string compassBatPath;
        private string dirListPath;
        public confForm()
        {
            IniParser.FileIniDataParser parser = new FileIniDataParser();
            IniData parsedData = parser.LoadFile("d:/tmp/compass-bundle/ui-setting.ini");
            compassBatPath = parsedData["PATH"]["compass_bat"];
            dirListPath = parsedData["PATH"]["dirlist"];
            InitializeComponent();
            txtCompassBatPath.Text = compassBatPath;
            txtPathListPath.Text = dirListPath;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result=openFileDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filePath = openFileDlg.FileName;
                txtCompassBatPath.Text = filePath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                String filePath = openFileDlg.FileName;
                txtPathListPath.Text = filePath;
            }

        }
    }
}

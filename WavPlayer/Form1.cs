using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace WavPlayer
{
    public partial class Form1 : Form
    {
        public bool loop { get; set; }
        public bool isOpend = false;

        [DllImport("winmm.dll")]
        private static extern long mciSendString
            (string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwsdCallback);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Wav.File|*.wav";

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                label1.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(label1.Text))
            {
                return;
            }

            if (!loop)
                //strCommand += " REPEAT";

            mciSendString("open\"" + label1.Text + "\"type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mciSendString("Close MediaFile", null, 0, IntPtr.Zero);
        }
    }
}

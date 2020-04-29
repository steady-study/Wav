using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using mook_PlaySound;
using System.Windows.Forms.DataVisualization.Charting;

namespace mook_WavSound
{   /// <summary>
///        
/// </summary>
    public partial class Form1 : Form
    {
        private Thread SoundPlayThread;
        private string FilePath = "";

        public List<int> valueList1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(this.ofdFile.ShowDialog() == DialogResult.OK)
            {
                this.txtOpen.Text = this.ofdFile.FileName;
                this.FilePath = this.ofdFile.FileName;
                SoundPlayThread = new Thread(SoundPlayGo);
                SoundPlayThread.Start();
            }

            timer1.Interval = 1000;
            timer1.Start();
        }
        
        private void SoundPlayGo()
        {
            PlaySoundGo.PlaySoundStart(FilePath, new IntPtr(), PlaySoundFlags.SND_SYNC);

            SoundPlayThread.Abort();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart1.ChartAreas[0].AxisX.ScaleView.SizeType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Seconds;
            chart1.ChartAreas[0].AxisX.Interval = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 100;

            valueList1 = new List<int>();

            DateTime now = DateTime.Now;

            chart1.ChartAreas[0].AxisX.Minimum = now.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(60).ToOADate();
        }

        private void AddData()
        {
            
            /*
            valueList1.Add(new Random().Next(0, 100));
            DateTime now = DateTime.Now;
            if (chart1.Series[0].Points.Count > 0)
            {
                while (chart1.Series[0].Points[0].XValue < now.AddSeconds(-60).ToOADate())
                {
                    chart1.Series[0].Points.RemoveAt(0);
                    chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
                    chart1.ChartAreas[0].AxisX.Maximum = now.AddSeconds(0).ToOADate();
                }
            }
            chart1.Series[0].Points.AddXY(now.ToOADate(), valueList1[valueList1.Count - 1]);



            chart1.Invalidate();
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddData();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            PlaySoundGo.PlaySoundStart(FilePath, new IntPtr(), PlaySoundFlags.SND_ASYNC);
        }
        */
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ACTMULTILIB_K;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        ActEasyIF control = new ActEasyIF();
        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            CustomLabel customLabel = new CustomLabel();
            customLabel.FromPosition = 0.5; // 시작 위치 설정
            customLabel.ToPosition = 1.5; // 끝 위치 설정
            customLabel.Text = "전진중"; // 레이블 텍스트 설정
            chart1.ChartAreas[0].AxisY.CustomLabels.Add(customLabel);
            for (int i = 0; i < 50; i++)
            {
                chart1.Series[0].Points.AddY(0);
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if(control.Open() == 0)
            {
                MessageBox.Show("연결완료");
                connectLabel.Text = "연결 중";
                timer1.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("연결실패");
                connectLabel.Text = "연결 전";
            }
        }

        private void frontbutton_Click(object sender, EventArgs e)
        {
            short value = 1 << 1;
            control.WriteDeviceBlock2("Y0", 1,ref value);
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            short value = 1 << 2;
            control.WriteDeviceBlock2("Y0", 1, ref value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short sensor = 0;
            control.ReadDeviceBlock2("X0", 1, out sensor);
            if (chart1.Series[0].Points.Count > 50)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            if ((sensor & 1 << 10) != 0)
            {
                short value = 1 << 1;
                control.WriteDeviceBlock2("Y0", 1, ref value);
                liftLable.Text = "물건이 올려져 있습니다.";
                label2.Text = "전진 중";
                chart1.Series[0].Points.AddY(1);
                pictureBox1.ImageLocation = "cylinderon.png";
            }
            else if ((sensor & 1 << 10) == 0)
            {
                short value = 1 << 2;
                control.WriteDeviceBlock2("Y0", 1, ref value);
                liftLable.Text = "물건이 올려져 있지않습니다.";
                label2.Text = "후진 중";
                chart1.Series[0].Points.AddY(0);
                pictureBox1.ImageLocation = "cylinderoff.png";
            }
            //if ((sensor & (1 << 2)) != 0)
            //{
            //    label2.Text = "전진 중";
            //    chart1.Series[0].Points.AddY(1);
            //    pictureBox1.ImageLocation = "cylinderon.png";
            //}
            //else if ((sensor & (1 << 3)) != 0)
            //{
            //    label2.Text = "후진 중";
            //    chart1.Series[0].Points.AddY(0);
            //    pictureBox1.ImageLocation = "cylinderoff.png";
            //}
            else if ((sensor & 12) == 0)
            {
                label2.Text = "이동 중";
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }
    }
}

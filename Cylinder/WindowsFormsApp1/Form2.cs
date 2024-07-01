using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ACTMULTILIB_K;
namespace WindowsFormsApp1
{
    
    public partial class Form2 : Form
    {
        ActEasyIF control = new ActEasyIF();
        public Form2()
        {
            InitializeComponent();
            chart1.ChartAreas[0].AxisY.Maximum = 1;
            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

            // "전진중" 레이블 설정
            CustomLabel customLabelForward = new CustomLabel();
            customLabelForward.FromPosition = 0.5; // 시작 위치 설정
            customLabelForward.ToPosition = 1.5; // 끝 위치 설정
            customLabelForward.Text = "전진중"; // 레이블 텍스트 설정
            chart1.ChartAreas[0].AxisY.CustomLabels.Add(customLabelForward);

            // "후진중" 레이블 설정
            CustomLabel customLabelBackward = new CustomLabel();
            customLabelBackward.FromPosition = -0.5; // 시작 위치 설정
            customLabelBackward.ToPosition = 0.5; // 끝 위치 설정
            customLabelBackward.Text = "후진중"; // 레이블 텍스트 설정
            chart1.ChartAreas[0].AxisY.CustomLabels.Add(customLabelBackward);
            CustomLabel customLabelMove = new CustomLabel();
            customLabelMove.FromPosition = 0; // 시작 위치 설정
            customLabelMove.ToPosition = 1; // 끝 위치 설정
            customLabelMove.Text = "이동중"; // 레이블 텍스트 설정
            chart1.ChartAreas[0].AxisY.CustomLabels.Add(customLabelMove);
            for (int i = 0; i < 50; i++)
            {
                chart1.Series[0].Points.AddY(0);
                chart1.Series[1].Points.AddY(0);
            }
        }

        private void connectBTN_Click(object sender, EventArgs e)
        {
            if (control.Open() == 0)
            {
                MessageBox.Show("연결됨");
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("연결안됨");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            short sensor = 0;
            control.ReadDeviceBlock2("X0", 1, out sensor);
            Console.WriteLine("Timer1 - Sensor value: " + sensor);
            short originOutput = 0;
            control.ReadDeviceBlock2("Y0", 1, out originOutput);
            if (chart1.Series[0].Points.Count > 50)
            {
                chart1.Series[0].Points.RemoveAt(0);
            }
            if (chart1.Series[1].Points.Count > 50)
            {
                chart1.Series[1].Points.RemoveAt(0);
            }

            if ((sensor & (1 << 2)) != 0)  // B 실린더 전진 상태 확인
            {
                label1.Text = sensor.ToString();
                BCylStatus.Text = "전진중";
                pictureBox1.ImageLocation = "cylinderon.png";
                chart1.Series[0].Points.AddY(1);
            }
            else if ((sensor & (1 << 3)) != 0)  // B 실린더 후진 상태 확인
            {
                label1.Text = sensor.ToString();
                BCylStatus.Text = "후진중";
                pictureBox1.ImageLocation = "cylinderoff.png";
                chart1.Series[0].Points.AddY(0);
            }
            else if ((sensor & (3 << 2)) == 0)
            {
                label1.Text = sensor.ToString();
                BCylStatus.Text = "이동중";
                chart1.Series[0].Points.AddY(0.5);
            }
            if ((sensor & (1 << 5)) != 0)  // C 실린더 전진 상태 확인
            {
                label1.Text = sensor.ToString();
                CCylStatus.Text = "전진중";
                pictureBox2.ImageLocation = "cylinderon.png";
                chart1.Series[1].Points.AddY(1);
            }
            else if ((sensor & (1 << 4)) != 0)  // C 실린더 후진 상태 확인
            {
                label1.Text = sensor.ToString();
                CCylStatus.Text = "후진중";
                pictureBox2.ImageLocation = "cylinderoff.png";
                chart1.Series[1].Points.AddY(0);
            }
            else if ((sensor & (12 << 2)) == 0)
            {
                label1.Text = sensor.ToString();
                CCylStatus.Text = "이동중";
               
            }
            if ((sensor & (1 << 2)) != 0) // 0000 0000 0000 0100
            {
                //전진상태면 후진해야함 실린더B               
                short value = 1 << 2; //0b0000 0000 0000 0100
                originOutput = (short)(originOutput & 0xFFF9);
                originOutput |= value;
      
            }
            //control.WriteDeviceBlock2("Y0", 1, ref originOutput);
            if ((sensor & (1 << 10)) != 0) //XA -> 10 0000 0100 0000 0000
            {
                //리프트에 물건이 올려지면 전진 실린더 B
                short value = 1 << 1; //0n0000 0000 0000 0100
                originOutput = (short)(originOutput & 0xFFF9);
                originOutput |= value;
  
            }
            //control.WriteDeviceBlock2("Y0", 1, ref originOutput);
            if ((sensor & (1 << 5)) != 0) // 0000 0000 0001 0000
            {
                // 전진상태면 후진해야함 실린더C
                short value = 1 << 4; //0b0000 0000 0000 0100
                originOutput = (short)(originOutput & 0xFFE7);
                originOutput |= value;
   
            }
            //control.WriteDeviceBlock2("Y0", 1, ref originOutput);
            if ((sensor & (1 << 11)) != 0)
            {
                // 리프트B에 물건이 올려지면 전진 실린더 C
                short value = 1 << 3; // 0b0000 0000 0000 0100
                originOutput = (short)(originOutput & 0xFFE7);
                originOutput |= value;
  
            }
            control.WriteDeviceBlock2("Y0", 1, ref originOutput);
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    if (chart1.Series[1].Points.Count > 50)
        //    {
        //        chart1.Series[1].Points.RemoveAt(0);
        //    }
        //    short sensor = 0;
        //    control.ReadDeviceBlock2("X0", 1, out sensor);
        //    Console.WriteLine("Timer2 - Sensor value: " + sensor);

        //}
    }
}

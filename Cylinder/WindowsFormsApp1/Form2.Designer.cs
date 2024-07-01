namespace WindowsFormsApp1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.connectBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BCylLabel = new System.Windows.Forms.Label();
            this.CCylLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BCylStatus = new System.Windows.Forms.Label();
            this.CCylStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Enabled = false;
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(12, 260);
            this.chart1.Name = "chart1";
            series15.BorderWidth = 5;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            series16.BorderWidth = 2;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Color = System.Drawing.Color.Red;
            series16.Legend = "Legend1";
            series16.Name = "Series2";
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(776, 178);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // connectBTN
            // 
            this.connectBTN.Location = new System.Drawing.Point(46, 57);
            this.connectBTN.Name = "connectBTN";
            this.connectBTN.Size = new System.Drawing.Size(230, 175);
            this.connectBTN.TabIndex = 1;
            this.connectBTN.Text = "연결";
            this.connectBTN.UseVisualStyleBackColor = true;
            this.connectBTN.Click += new System.EventHandler(this.connectBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(499, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(499, 144);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(289, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // BCylLabel
            // 
            this.BCylLabel.AutoSize = true;
            this.BCylLabel.Location = new System.Drawing.Point(365, 57);
            this.BCylLabel.Name = "BCylLabel";
            this.BCylLabel.Size = new System.Drawing.Size(41, 12);
            this.BCylLabel.TabIndex = 4;
            this.BCylLabel.Text = "B:CYL";
            // 
            // CCylLabel
            // 
            this.CCylLabel.AutoSize = true;
            this.CCylLabel.Location = new System.Drawing.Point(365, 199);
            this.CCylLabel.Name = "CCylLabel";
            this.CCylLabel.Size = new System.Drawing.Size(42, 12);
            this.CCylLabel.TabIndex = 5;
            this.CCylLabel.Text = "C:CYL";
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BCylStatus
            // 
            this.BCylStatus.AutoSize = true;
            this.BCylStatus.Location = new System.Drawing.Point(365, 79);
            this.BCylStatus.Name = "BCylStatus";
            this.BCylStatus.Size = new System.Drawing.Size(81, 12);
            this.BCylStatus.TabIndex = 6;
            this.BCylStatus.Text = "B 실린더 상태";
            // 
            // CCylStatus
            // 
            this.CCylStatus.AutoSize = true;
            this.CCylStatus.Location = new System.Drawing.Point(367, 220);
            this.CCylStatus.Name = "CCylStatus";
            this.CCylStatus.Size = new System.Drawing.Size(82, 12);
            this.CCylStatus.TabIndex = 7;
            this.CCylStatus.Text = "C 실린더 상태";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CCylStatus);
            this.Controls.Add(this.BCylStatus);
            this.Controls.Add(this.CCylLabel);
            this.Controls.Add(this.BCylLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.connectBTN);
            this.Controls.Add(this.chart1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button connectBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label BCylLabel;
        private System.Windows.Forms.Label CCylLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label BCylStatus;
        private System.Windows.Forms.Label CCylStatus;
        private System.Windows.Forms.Label label1;
    }
}
namespace UI_Kiosk
{
    partial class ResultForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_change = new System.Windows.Forms.Label();
            this.closeResultForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(256, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(252, 280);
            this.listBox1.TabIndex = 1;
            // 
            // label_change
            // 
            this.label_change.AutoSize = true;
            this.label_change.Location = new System.Drawing.Point(315, 349);
            this.label_change.Name = "label_change";
            this.label_change.Size = new System.Drawing.Size(53, 12);
            this.label_change.TabIndex = 2;
            this.label_change.Text = "거스름돈";
            // 
            // closeResultForm
            // 
            this.closeResultForm.Location = new System.Drawing.Point(610, 344);
            this.closeResultForm.Name = "closeResultForm";
            this.closeResultForm.Size = new System.Drawing.Size(75, 23);
            this.closeResultForm.TabIndex = 3;
            this.closeResultForm.Text = "종료";
            this.closeResultForm.UseVisualStyleBackColor = true;
            this.closeResultForm.Click += new System.EventHandler(this.closeResultForm_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.closeResultForm);
            this.Controls.Add(this.label_change);
            this.Controls.Add(this.listBox1);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_change;
        private System.Windows.Forms.Button closeResultForm;
    }
}
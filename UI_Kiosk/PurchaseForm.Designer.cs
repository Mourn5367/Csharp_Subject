namespace UI_Kiosk
{
    partial class PurchaseForm
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
            this.bill = new System.Windows.Forms.Label();
            this.inputMoney = new System.Windows.Forms.Label();
            this.input_1000 = new System.Windows.Forms.Button();
            this.input_5000 = new System.Windows.Forms.Button();
            this.input_10000 = new System.Windows.Forms.Button();
            this.resetMoney = new System.Windows.Forms.Button();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.select_Delete = new System.Windows.Forms.Button();
            this.undo_Button = new System.Windows.Forms.Button();
            this.close_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(256, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(252, 280);
            this.listBox1.TabIndex = 0;
            // 
            // bill
            // 
            this.bill.AutoSize = true;
            this.bill.Location = new System.Drawing.Point(280, 330);
            this.bill.Name = "bill";
            this.bill.Size = new System.Drawing.Size(77, 12);
            this.bill.TabIndex = 1;
            this.bill.Text = "청구된 금액 :";
            // 
            // inputMoney
            // 
            this.inputMoney.AutoSize = true;
            this.inputMoney.Location = new System.Drawing.Point(280, 355);
            this.inputMoney.Name = "inputMoney";
            this.inputMoney.Size = new System.Drawing.Size(69, 12);
            this.inputMoney.TabIndex = 2;
            this.inputMoney.Text = "투입 금액 : ";
            // 
            // input_1000
            // 
            this.input_1000.Location = new System.Drawing.Point(621, 296);
            this.input_1000.Name = "input_1000";
            this.input_1000.Size = new System.Drawing.Size(75, 23);
            this.input_1000.TabIndex = 3;
            this.input_1000.Text = "천원넣기";
            this.input_1000.UseVisualStyleBackColor = true;
            this.input_1000.Click += new System.EventHandler(this.input_1000_Click);
            // 
            // input_5000
            // 
            this.input_5000.Location = new System.Drawing.Point(621, 325);
            this.input_5000.Name = "input_5000";
            this.input_5000.Size = new System.Drawing.Size(75, 23);
            this.input_5000.TabIndex = 4;
            this.input_5000.Text = "오천원넣기";
            this.input_5000.UseVisualStyleBackColor = true;
            this.input_5000.Click += new System.EventHandler(this.input_5000_Click);
            // 
            // input_10000
            // 
            this.input_10000.Location = new System.Drawing.Point(621, 355);
            this.input_10000.Name = "input_10000";
            this.input_10000.Size = new System.Drawing.Size(75, 23);
            this.input_10000.TabIndex = 5;
            this.input_10000.Text = "만원넣기";
            this.input_10000.UseVisualStyleBackColor = true;
            this.input_10000.Click += new System.EventHandler(this.input_10000_Click);
            // 
            // resetMoney
            // 
            this.resetMoney.Location = new System.Drawing.Point(599, 384);
            this.resetMoney.Name = "resetMoney";
            this.resetMoney.Size = new System.Drawing.Size(120, 23);
            this.resetMoney.TabIndex = 6;
            this.resetMoney.Text = "아 잘못넣었다";
            this.resetMoney.UseVisualStyleBackColor = true;
            this.resetMoney.Click += new System.EventHandler(this.resetMoney_Click);
            // 
            // purchaseButton
            // 
            this.purchaseButton.Location = new System.Drawing.Point(256, 384);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(252, 54);
            this.purchaseButton.TabIndex = 7;
            this.purchaseButton.Text = "결제하기";
            this.purchaseButton.UseVisualStyleBackColor = true;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // select_Delete
            // 
            this.select_Delete.Location = new System.Drawing.Point(621, 147);
            this.select_Delete.Name = "select_Delete";
            this.select_Delete.Size = new System.Drawing.Size(75, 23);
            this.select_Delete.TabIndex = 8;
            this.select_Delete.Text = "이거 빼기";
            this.select_Delete.UseVisualStyleBackColor = true;
            this.select_Delete.Click += new System.EventHandler(this.select_Delete_Click);
            // 
            // undo_Button
            // 
            this.undo_Button.Location = new System.Drawing.Point(621, 197);
            this.undo_Button.Name = "undo_Button";
            this.undo_Button.Size = new System.Drawing.Size(75, 23);
            this.undo_Button.TabIndex = 9;
            this.undo_Button.Text = "아맞다";
            this.undo_Button.UseVisualStyleBackColor = true;
            this.undo_Button.Click += new System.EventHandler(this.undo_Button_Click);
            // 
            // close_Button
            // 
            this.close_Button.Location = new System.Drawing.Point(599, 33);
            this.close_Button.Name = "close_Button";
            this.close_Button.Size = new System.Drawing.Size(120, 23);
            this.close_Button.TabIndex = 10;
            this.close_Button.Text = "다시 주문하러가기";
            this.close_Button.UseVisualStyleBackColor = true;
            this.close_Button.Click += new System.EventHandler(this.close_Button_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(561, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "가격 표시란";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_Button);
            this.Controls.Add(this.undo_Button);
            this.Controls.Add(this.select_Delete);
            this.Controls.Add(this.purchaseButton);
            this.Controls.Add(this.resetMoney);
            this.Controls.Add(this.input_10000);
            this.Controls.Add(this.input_5000);
            this.Controls.Add(this.input_1000);
            this.Controls.Add(this.inputMoney);
            this.Controls.Add(this.bill);
            this.Controls.Add(this.listBox1);
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label bill;
        private System.Windows.Forms.Label inputMoney;
        private System.Windows.Forms.Button input_1000;
        private System.Windows.Forms.Button input_5000;
        private System.Windows.Forms.Button input_10000;
        private System.Windows.Forms.Button resetMoney;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Button select_Delete;
        private System.Windows.Forms.Button undo_Button;
        private System.Windows.Forms.Button close_Button;
        private System.Windows.Forms.Label label1;
    }
}
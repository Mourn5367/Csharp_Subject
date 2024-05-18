using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace UI_Kiosk
{
    
    public partial class PurchaseForm : Form
    {
        static Thread easterEggThread;
        OrderForm orderForm;
        Random ran;
        static Button eggStop;
        int bills = 0;
        int input = 0;
        public int change = 0;
        string oneUnit = " 원";

        string undoMenuName = "";

        public PurchaseForm()
        {
            InitializeComponent();
            ran = new Random();
            easterEggThread = new Thread(randBackColor);
        }
        public void SetForm(OrderForm form)
        {
            orderForm = form;
        }

        public void PurchaseListBox(ListBox listBox_)
        {
            foreach (String items in listBox_.Items)
            {
                listBox1.Items.Add(items);
            }
            CalPrice();
        }
        public virtual void CalPrice()
        {
            int cnt = listBox1.Items.Count;
            bills = 0;
            for (int i = 0; i< orderForm.menuList[0].Length; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (listBox1.Items[j].ToString() == orderForm.menuList[0][i])
                    {
                        bills += int.Parse(orderForm.menuList[1][i]);
                    }
                    
                }
            }
            bill.Text = bills.ToString() +oneUnit;
        }

        private void input_1000_Click(object sender, EventArgs e)
        {
            input += 1000;

            inputMoney.Text = input.ToString() + oneUnit;
        }

        private void input_5000_Click(object sender, EventArgs e)
        {
            input += 5000;

            inputMoney.Text = input.ToString() + oneUnit;
        }

        private void input_10000_Click(object sender, EventArgs e)
        {
            input += 10000;

            inputMoney.Text = input.ToString() + oneUnit;
        }

        private void resetMoney_Click(object sender, EventArgs e)
        {
            input = 0;
            inputMoney.Text = input.ToString() + oneUnit;
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if (input >= bills)
            {
                if (easterEggThread.IsAlive == true)
                {
                    easterEggThread.Abort();
                }
                change = input - bills;
                ResultForm purchaseForm = new ResultForm();
                purchaseForm.SetForm(this);
                purchaseForm.ResultListBox(listBox1, change, input,bills);
                purchaseForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("금액이 " + (bills - input) + oneUnit +" 만큼 부족합니다.");
            }
        }

        public void closePurchaseForm()
        {
            orderForm.clearListBox();
            easterEggThread.Abort();
            Close();
        }

        private void select_Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                undoMenuName = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            CalPrice();
            easterEggCondition();
        }

        private void undo_Button_Click(object sender, EventArgs e)
        {
            if (undoMenuName != "")
            {
                foreach (String item in orderForm.menuList[0])
                {                
                    if (undoMenuName.Equals(item))
                    {
                        listBox1.Items.Add(undoMenuName);
                        undoMenuName = "";
                        break;
                    }
                }
                CalPrice();
            }
            easterEggCondition();

        }
        private void randBackColor()
        {
            while (true)
            {
                this.BackColor = Color.FromArgb(ran.Next(0, 255),
                                ran.Next(0, 255),
                                ran.Next(0, 255));
                Thread.Sleep(200);
            }
        }
        private void easterEgg_Stop_Button(object sender, EventArgs e)
        {
            easterEggThread.Abort();
            this.BackColor = default(Color);
            Controls.Remove(eggStop);
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            Close();
            orderForm.reOrder(listBox1,bills);
        }

        private void easterEggCondition()
        {
            if (listBox1.Items.Count >= 3)
            {
                if (listBox1.Items[0].ToString().Equals(orderForm.menuList[0][0]) && listBox1.Items[1].ToString().Equals(orderForm.menuList[0][1]) && listBox1.Items[2].ToString().Equals(orderForm.menuList[0][2]))
                {
                    
                    eggStop = new Button();
                    eggStop.Location = new Point(input_1000.Location.X, input_1000.Location.Y - 50);
                    eggStop.Text = "이스터 에그 멈추기";
                    eggStop.AutoSize = true;

                    eggStop.Click += (send, even) =>
                    {
                        easterEgg_Stop_Button(send, even);
                    };
                    Controls.Add(eggStop);
                    easterEggThread.Start();
                }
            }
        }
    }
}

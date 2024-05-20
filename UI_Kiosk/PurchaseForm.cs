﻿using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace UI_Kiosk
{

    public partial class PurchaseForm : Form
    {
        OrderForm orderForm;
        Random ran;
        static Button eggStop;
        int bills = 0;
        int input = 0;
        public int change = 0;
        string oneUnit = " 원";
        string undoMenuName = "";
        bool threadFunc = false;
        Thread easterEggThread;
        static ManualResetEvent threadControl = new ManualResetEvent(false);
        public PurchaseForm()
        {
            InitializeComponent();
            ran = new Random();
            listBox1.Click += listBox_index_Click;
        }
        public void SetForm(OrderForm form)
        {
            orderForm = form;
        }
        private void listBox_index_Click( object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int selectIndex = listBox1.SelectedIndex;

                for (int i = 0; i < orderForm.menuList[1].Length; i++)
                {
                    if (listBox1.Items[selectIndex].ToString() == orderForm.menuList[0][i])
                    {
                        label1.Text = orderForm.menuList[0][i] + "는 " + orderForm.menuList[1][i] + " 원";
                    }
                }
            }
        }

        public void PurchaseListBox(ListBox listBox_) // orderForm의 ListBox item가져오기
        {
            foreach (String items in listBox_.Items)
            {
                listBox1.Items.Add(items);
            }
            CalPrice();
        }
        public void CalPrice() // 주문한 메뉴들 값 계산하기
        {
            int cnt = listBox1.Items.Count;
            bills = 0;
            for (int i = 0; i < orderForm.menuList[0].Length; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (listBox1.Items[j].ToString() == orderForm.menuList[0][i])
                    {
                        bills += int.Parse(orderForm.menuList[1][i]);
                    }

                }
            }
            bill.Text = bills.ToString() + oneUnit;
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

        // 투입금액 초기화
        private void resetMoney_Click(object sender, EventArgs e)
        {
            input = 0;
            inputMoney.Text = input.ToString() + oneUnit;
        }

        // 결제하기 버튼 클릭 이벤트시 작동하는 함수 투입금액이 주문금액 보다 크다면 새 창을 연다.
        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("주문을 하나 이상 해주세요..!");
                return;
            }
            if (input >= bills)
            {
                change = input - bills;
                ResultForm purchaseForm = new ResultForm();
                if (easterEggThread.IsAlive == true)
                    easterEggThread.Join();
                purchaseForm.SetForm(this);
                purchaseForm.ResultListBox(listBox1, change, input, bills);
                purchaseForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("금액이 " + (bills - input) + oneUnit + " 만큼 부족합니다.");
            }
        }

        // 결제 다 끝났을때 OrderForm ListBox 초기화, Purchase 폼 닫기위한 함수
        public void closePurchaseForm()
        {
            orderForm.clearListBox();
            if (easterEggThread.IsAlive == true)
                easterEggThread.Join();
            Close();
        }

        // 메뉴 빼는 버튼 클릭 이벤트시 작동하는 함수
        private void select_Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                undoMenuName = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                easterEggCondition();
                CalPrice();
            }
        }

        // 메뉴 되돌리는 버튼 클릭 이벤트시 작동하는 함수
        // 메뉴 빼는 버튼을 잘못 눌렀을 시 되돌려 주는 함수
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
                        easterEggCondition();
                        break;
                    }
                }
                CalPrice();
            }

        }

        // 빼먹은 주문이 있어 창을 닫고 OrderForm 창으로 돌아가는 함수
        private void close_Button_Click(object sender, EventArgs e)
        {
            threadFunc = false;
            if (easterEggThread != null)
            {
                if (easterEggThread.IsAlive == true)
                    easterEggThread.Join();
            }
            orderForm.reOrder(listBox1, bills);
            //orderForm.clearListBox();
            Close();
        }

        // 특정 조건시 발동하기 위한 함수 및 조건들
        private void randBackColor()
        {
            while (threadFunc == true)
            {
                this.BackColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
                Thread.Sleep(200);
            }
        }
        private void easterEgg_Stop_Button(object sender, EventArgs e)
        {
            this.BackColor = default(Color);
            threadFunc = false;
            if (easterEggThread != null)
            {
                if (easterEggThread.IsAlive == true)
                    easterEggThread.Join();
            }

            Controls.Remove(eggStop);
           
        }
        private void easterEggCondition()
        {
            if (listBox1.Items.Count == 3)
            {
                if (listBox1.Items[0].ToString().Equals(orderForm.menuList[0][0]) && listBox1.Items[1].ToString().Equals(orderForm.menuList[0][1]) && listBox1.Items[2].ToString().Equals(orderForm.menuList[0][2]))
                {
                    if (!Controls.Contains(eggStop))
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
                    }
                    if (easterEggThread != null)
                    {
                        threadFunc = false;
                        easterEggThread.Join();
                    }
                    threadFunc = true;
                    easterEggThread = new Thread(randBackColor);
                    easterEggThread.Start();

                }
            }
        }
    }
}
//using System;
//using System.Drawing;
//using System.Threading;
//using System.Windows.Forms;

//namespace UI_Kiosk
//{
//    public partial class PurchaseForm : Form
//    {
//        OrderForm orderForm;
//        Random ran;
//        static Button eggStop;
//        int bills = 0;
//        int input = 0;
//        public int change = 0;
//        string oneUnit = " 원";
//        string undoMenuName = "";
//        Thread easterEggThread;
//        bool threadRunning = false;
//        CancellationTokenSource cancellationTokenSource;

//        public PurchaseForm()
//        {
//            InitializeComponent();
//            ran = new Random();
//            cancellationTokenSource = new CancellationTokenSource();
//        }

//        public void SetForm(OrderForm form)
//        {
//            orderForm = form;
//        }

//        public void PurchaseListBox(ListBox listBox_)
//        {
//            foreach (String items in listBox_.Items)
//            {
//                listBox1.Items.Add(items);
//            }
//            CalPrice();
//        }

//        public void CalPrice()
//        {
//            int cnt = listBox1.Items.Count;
//            bills = 0;
//            for (int i = 0; i < orderForm.menuList[0].Length; i++)
//            {
//                for (int j = 0; j < cnt; j++)
//                {
//                    if (listBox1.Items[j].ToString() == orderForm.menuList[0][i])
//                    {
//                        bills += int.Parse(orderForm.menuList[1][i]);
//                    }
//                }
//            }
//            bill.Text = bills.ToString() + oneUnit;
//        }

//        private void input_1000_Click(object sender, EventArgs e)
//        {
//            input += 1000;
//            inputMoney.Text = input.ToString() + oneUnit;
//        }

//        private void input_5000_Click(object sender, EventArgs e)
//        {
//            input += 5000;
//            inputMoney.Text = input.ToString() + oneUnit;
//        }

//        private void input_10000_Click(object sender, EventArgs e)
//        {
//            input += 10000;
//            inputMoney.Text = input.ToString() + oneUnit;
//        }

//        private void resetMoney_Click(object sender, EventArgs e)
//        {
//            input = 0;
//            inputMoney.Text = input.ToString() + oneUnit;
//        }

//        private void purchaseButton_Click(object sender, EventArgs e)
//        {
//            if (listBox1.Items.Count == 0)
//            {
//                MessageBox.Show("주문을 하나 이상 해주세요..!");
//                return;
//            }
//            if (input >= bills)
//            {
//                change = input - bills;
//                ResultForm purchaseForm = new ResultForm();
//                StopEasterEggThread();
//                purchaseForm.SetForm(this);
//                purchaseForm.ResultListBox(listBox1, change, input, bills);
//                purchaseForm.ShowDialog();
//            }
//            else
//            {
//                MessageBox.Show("금액이 " + (bills - input) + oneUnit + " 만큼 부족합니다.");
//            }
//        }

//        public void closePurchaseForm()
//        {
//            orderForm.clearListBox();
//            StopEasterEggThread();
//            Close();
//        }

//        private void select_Delete_Click(object sender, EventArgs e)
//        {
//            if (listBox1.SelectedIndex >= 0)
//            {
//                undoMenuName = listBox1.Items[listBox1.SelectedIndex].ToString();
//                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
//                easterEggCondition();
//                CalPrice();
//            }
//        }

//        private void undo_Button_Click(object sender, EventArgs e)
//        {
//            if (undoMenuName != "")
//            {
//                foreach (String item in orderForm.menuList[0])
//                {
//                    if (undoMenuName.Equals(item))
//                    {
//                        listBox1.Items.Add(undoMenuName);
//                        undoMenuName = "";
//                        easterEggCondition();
//                        break;
//                    }
//                }
//                CalPrice();
//            }
//        }

//        private void close_Button_Click(object sender, EventArgs e)
//        {
//            StopEasterEggThread();
//            orderForm.reOrder(listBox1, bills);
//            //orderForm.clearListBox();
//            Close();
//        }

//        private void randBackColor()
//        {
//            try
//            {
//                while (!cancellationTokenSource.Token.IsCancellationRequested)
//                {
//                    this.Invoke((MethodInvoker)delegate {
//                        this.BackColor = Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255));
//                    });
//                    Thread.Sleep(200);
//                }
//            }
//            catch (OperationCanceledException)
//            {

//            }
//        }

//        private void StartEasterEggThread()
//        {
//            if (!threadRunning)
//            {
//                cancellationTokenSource = new CancellationTokenSource();
//                easterEggThread = new Thread(randBackColor);
//                easterEggThread.Start();
//                threadRunning = true;
//            }
//        }

//        private void StopEasterEggThread()
//        {
//            if (threadRunning)
//            {
//                cancellationTokenSource.Cancel();
//                easterEggThread.Join();
//                threadRunning = false;
//                this.BackColor = default(Color);
//            }
//        }

//        private void easterEgg_Stop_Button(object sender, EventArgs e)
//        {
//            StopEasterEggThread();
//            Controls.Remove(eggStop);
//        }

//        private void easterEggCondition()
//        {
//            if (listBox1.Items.Count == 3)
//            {
//                if (listBox1.Items[0].ToString().Equals(orderForm.menuList[0][0]) && listBox1.Items[1].ToString().Equals(orderForm.menuList[0][1]) && listBox1.Items[2].ToString().Equals(orderForm.menuList[0][2]))
//                {
//                    eggStop = new Button();
//                    eggStop.Location = new Point(input_1000.Location.X, input_1000.Location.Y - 50);
//                    eggStop.Text = "이스터 에그 멈추기";
//                    eggStop.AutoSize = true;

//                    eggStop.Click += (send, even) =>
//                    {
//                        easterEgg_Stop_Button(send, even);
//                    };
//                    Controls.Add(eggStop);
//                    StartEasterEggThread();
//                }
//            }
//        }
//    }
//}
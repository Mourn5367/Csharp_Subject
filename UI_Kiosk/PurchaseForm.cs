using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
namespace UI_Kiosk
{

    public partial class PurchaseForm : Form
    {
        OrderForm orderForm;
        Random ran;
        Thread easterEggThread;
        Button eggStop;
        int bills = 0;
        int input = 0;
        int change = 0;
        string undoMenuName = "";
        //string curCoupon = "";
        bool threadFunc = false;
        //List<string> coupons = new List<string>();
        //ListBox couponListBox = new ListBox();
        public PurchaseForm()
        {
            InitializeComponent();
            ran = new Random();
            listBox1.Click += listBox_Index_Click;
           
            //couponListBox.Location = new Point(listBox1.Location.X-150, listBox1.Location.Y);
            //Controls.Add(couponListBox);
            //coupons.Add("50");
            //coupons.Add("10");
            //couponListBox.Click += CouponListBox_Click;
            //couponListBox.Items.AddRange(coupons.ToArray());
        }

        //private void CouponListBox_Click(object sender, EventArgs e)
        //{
        //    if (couponListBox.SelectedIndex >= 0)
        //    {
        //        int selectIndex = couponListBox.SelectedIndex;
        //        curCoupon = couponListBox.Items[selectIndex].ToString();
        //    }
        //}

        public void SetForm(OrderForm form)
        {
            orderForm = form;
        }

        //public void deleteCoupons(List<string> coupons,int index)
        //{
        //    coupons.RemoveAt(index);
        //}


        private void listBox_Index_Click( object sender, EventArgs e)
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
        private void CalPrice() // 주문한 메뉴들 값 계산하기
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
            bill.Text = "청구 금액 : " + bills.ToString() + " 원";
        }

        private void input_1000_Click(object sender, EventArgs e)
        {
            input += 1000;

            inputMoney.Text = "투입 금액 : " + input.ToString() + " 원";
        }

        private void input_5000_Click(object sender, EventArgs e)
        {
            input += 5000;

            inputMoney.Text = "투입 금액 : " + input.ToString() + " 원";
        }

        private void input_10000_Click(object sender, EventArgs e)
        {
            input += 10000;

            inputMoney.Text = "투입 금액 : " + input.ToString() + " 원";
        }

        // 투입금액 초기화
        private void resetMoney_Click(object sender, EventArgs e)
        {
            input = 0;
            inputMoney.Text = "투입 금액 : " + input.ToString() + " 원";
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
                threadFunc = false;
                change = input - bills;
                ResultForm purchaseForm = new ResultForm();
                if (easterEggThread != null)
                {
                    if (easterEggThread.IsAlive == true)
                        easterEggThread.Join();
                }
                purchaseForm.SetForm(this);
                purchaseForm.ResultListBox(listBox1, change, input, bills);
                purchaseForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("금액이 " + (bills - input) + " 원" + " 만큼 부족합니다.");
            }
        }

        // 결제 다 끝났을때 OrderForm ListBox 초기화, Purchase 폼 닫기위한 함수
        public void closePurchaseForm()
        {
            orderForm.clearListBox();
            if (easterEggThread != null)
            {
                if (easterEggThread.IsAlive == true)
                    easterEggThread.Join();
            }
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
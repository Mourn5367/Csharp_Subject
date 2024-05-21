// 2024_05_16_융합UI_실습과제
// 한국폴리텍대학_서울정수캠퍼스_인공지능소프트웨어학과
// 2401110252_박지수
// 키오스크 제작
// https://github.com/Mourn5367/Csharp_Subject

using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Kiosk
{
    
    public partial class OrderForm : Form
    {
        string menuText = "";
        int price = 2000;
        int menus = 3;
        string selText = "선택 한 메뉴는 ";
        string selPrice = "선택 한 메뉴 가격은 ";
        public string[][] menuList;
        Button[] selectButtons ;
        Button[] addButtons;
        Label[] labels;
        public OrderForm() // 생성자
        {
            InitializeComponent();
            Text = "OrderForm";
            menuList = new string[][] // 첫번째는 메뉴명, 두번째는 가격, 세번째는 설명
            {
                new string[menus*3], 
                new string[menus*3],
                new string[menus]

            };
            // 넣을 메뉴 입력 , 설명 넣기
            menuList[0][0] = "박카스";
            menuList[2][0] = "카페인과 타우린이 첨가된 음료";
            menuList[0][1] = "지사제";
            menuList[2][1] = "설사를 멎게하는 약으로 주의깊게 사용해야한다";
            menuList[0][2] = "수액";
            menuList[2][2] = "여러 수액이 있지만 이 메뉴는 링거액입니다.";
            for (int i = 0; i < menus; i++)
            {
                menuList[0][i + menus] = menuList[0][i] + " * 05";
                menuList[0][i + menus * 2] = menuList[0][i] + " * 10";
            }

            for (int i = 0; i < menuList[0].Length; i++) // 가격 넣기
            {
                if (i < menus)
                {
                    menuList[1][i] = ((i+1) * price).ToString();
                }
                else if (i < menus * 2)
                {
                    menuList[1][i] = ((i+1- menus) * price*5).ToString();
                }
                else
                {
                    menuList[1][i] = ((i+1 - menus * 2) * price*10).ToString();
                }
            }


            selectButtons = new Button[menus]; // 메뉴 선택 버튼 만들기
            for (int i = 0; i < menus; i++)
            {
                int index = i;
                selectButtons[i] = new Button();
                selectButtons[i].Location = new Point(this.Size.Width / 20 + i * 100, this.Size.Height / 10);
                selectButtons[i].Text = menuList[0][i];
                selectButtons[i].Click += (sender, e) =>
                {
                    menu_Index_Button_Click(sender, e, index);
                };
                Controls.Add(selectButtons[i]);
            }

            labels = new Label[2]; // 선택한 메뉴 라벨, 설명 라벨 만들기
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Location = new Point(this.Size.Width / 20, selectButtons[0].Location.Y + i*20  + 50);
                labels[i].AutoSize = true;
                Controls.Add(labels[i]);
            }
            labels[0].Text = selText;
            labels[1].Text = "설명";


            addButtons = new Button[3]; // 1개 추가하기 버튼 5개 추가하기 버튼 10개 추가하기 버튼
            for ( int i = 0; i < 3; i++)
            {
                int index = i;
                addButtons[i] = new Button();
                addButtons[i].Text = i == 0 ? $"{i+1} 개 추가 버튼" : $"{i*5} 개 추가 버튼";
                addButtons[i].Location = new Point(this.Size.Width / 27 + i * 100, labels[0].Location.Y + 50);
                addButtons[i].AutoSize = true;
                addButtons[i].Click += (sender, e) =>
                {
                    menu_Add_Button_Click(sender, e, index);
                };
                Controls.Add(addButtons[i]);
            }
            listBox1.Sorted = true;
        }


        // 메뉴가 5개,10개모였는지 감지하여 묶어버리는 함수
        public void detectMenuCount()
        {
            int detected = 0;
            int detectedSet = 0;
            int findMenuIndex = 0;
            int findMenuIndexSet = 0;
            for (int i = 0; i <  menus; i++)
            {
                int equalCount = 0;
                if (detected != 0) break;
                foreach (String items in listBox1.Items)
                {
                    if (menuList[0][i] == items)
                    {
                        equalCount++;
                        if (equalCount >= 10)
                        {
                            detected++;
                            findMenuIndex = i;
                        }
                        else if (equalCount >= 5)
                        {
                            detected++;
                            findMenuIndex = i;
                        }
                    }
                }
            }
            if ( detected >= 5)
            {
                listBox1.Items.Add(menuList[0][findMenuIndex + menus*2]);
                for (int i = 0; i < 10; i++)
                {
                    listBox1.Items.Remove(menuList[0][findMenuIndex]);
                }
            }
            else if ( detected >= 1)
            {
                listBox1.Items.Add(menuList[0][findMenuIndex + menus]);
                for (int i = 0; i < 5; i++)
                {
                    listBox1.Items.Remove(menuList[0][findMenuIndex]);
                }
            }

            for (int i = menus; i < menus * 2; i++)
            {
                int equalCount = 0;
                if (detectedSet != 0)
                {
                    break;
                }
                foreach (String items in listBox1.Items)
                {

                    if (menuList[0][i] == items)
                    {
                        equalCount++;
                        if (equalCount >= 2)
                        {
                            detectedSet++;
                            findMenuIndexSet = i;
                        }
                    }
                }
            }

            if (detectedSet >= 1)
            {
                listBox1.Items.Add(menuList[0][findMenuIndexSet + menus]);
                for (int i = 0; i < 2; i++)
                {
                    listBox1.Items.Remove(menuList[0][findMenuIndexSet]);
                }
            }
        }

        // 메뉴의 이름을 비교하여 메뉴 값을 계산하는 함수
        public void calPrice()
        {
            int cnt = listBox1.Items.Count;
            int m = 0;
            for (int i = 0; i < menuList[0].Length; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (listBox1.Items[j].ToString() == menuList[0][i])
                    {
                        m += int.Parse(menuList[1][i]);
                    }
                }
            }
            label3.Text = "총 가격 : " + m.ToString() + " 원";
        }

        // 결제 도중 다시 주문하기 위해 돌아올때 다시 ListBox items를 받아오는 함수
        public void reOrder(ListBox listBox, int price)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(listBox.Items);
            int cnt = listBox.Items.Count;
            label3.Text = "총 가격 : " + price.ToString() + " 원";
        }

        //결제까지 다 끝난후 주문상태를 초기화 하는 함수
        public void clearListBox()
        {
            labels[0].Text = selText;
            labels[1].Text = "설명";
            label2.Text = selPrice;
            label3.Text = "총 가격";
            listBox1.Items.Clear();
        }
        // 메뉴 버튼 클릭 이벤트시 작동하는 함수
        private void menu_Index_Button_Click(object sender, EventArgs e, int index)
        {
            menuText = selectButtons[index].Text;
            labels[0].Text = selText + " \"" + menuText + "\"" + " 가격은 " + menuList[1][index] + " 원 입니다.";
            labels[1].Text = menuList[2][index];

        }
        // 메뉴 추가 버튼 클릭 이벤트시 작동하는 함수
        private void menu_Add_Button_Click(object sender, EventArgs e, int index)
        {
            if (menuText != "")
            {
                switch (index)
                {
                    case 0:
                        listBox1.Items.Add(menuText);
                        break;
                    case 1:
                        for (int i = 0; i < 5; i++)
                        {
                            listBox1.Items.Add(menuText);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 10; i++)
                        {
                            listBox1.Items.Add(menuText);
                        }
                        break;
                }
                detectMenuCount();
                calPrice();
            }
        }

        // ListBox items 클릭 후 삭제하기 버튼 클릭 이벤트시 작동하는 함수 
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            calPrice();
        }

        // ListBox items 전부 비우기
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            calPrice();
        }

        // ListBox items 클릭 후 가격 확인 버튼 클릭 이벤트시 작동하는 함수
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < menuList[0].Length; i++)
                {
                    if (listBox1.SelectedItem.ToString() == menuList[0][i])
                    {
                        label2.Text = menuList[0][i] + " 가격은" + menuList[1][i] + " 원";
                    }
                }
            }
        }

        // 주문하기 버튼 클릭 이벤트시 작동하는 함수 새 창을 연다.
        private void purchaseButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                PurchaseForm purchaseForm = new PurchaseForm();
                purchaseForm.SetForm(this);
                purchaseForm.PurchaseListBox(listBox1);
                purchaseForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("주문을 하나 이상 해주세요..!");
            }
        }
    }
}

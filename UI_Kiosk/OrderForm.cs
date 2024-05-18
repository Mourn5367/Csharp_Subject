using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI_Kiosk
{
    
    public partial class OrderForm : Form
    {
        string menuText = "";
        int price = 3000;
        int menus = 3;
        string selText = "선택 한 메뉴는 ";
        string selPrice = "선택 한 메뉴 가격은 ";
        public string[][] menuList;
        
        Button[] selectButtons ;
        Button[] addButtons;
        Label[] labels;
        public OrderForm()
        {
            
            InitializeComponent();
            
            menuList = new string[][]
            {
                new string[] { "엄", "준", "식", "엄 * 05", "준 * 05", "식 * 05","엄 * 10", "준 * 10", "식 * 10"},
                new string[menus*3]

            };
            for (int i = 0; i < menuList[0].Length; i++)
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

            selectButtons = new Button[menus];
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

            labels = new Label[1];
            labels[0] = new Label();
            labels[0].Location = new Point(this.Size.Width / 20, selectButtons[0].Location.Y + 50);
            labels[0].Text = selText;
            labels[0].AutoSize = true;
            Controls.Add(labels[0]);


            addButtons = new Button[3];
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

        public void menu_Index_Button_Click(object sender, EventArgs e,int index)
        {
            menuText = selectButtons[index].Text;
            labels[0].Text = selText + " \"" + menuText + "\"";

        }
        public void menu_Add_Button_Click(object sender, EventArgs e, int index)
        {
            if (menuText != "")
            {
                switch(index)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
               listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            calPrice();
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            calPrice();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < menuList[0].Length; i++)
                {
                    if (listBox1.SelectedItem.ToString() == menuList[0][i])
                    {
                        label2.Text = menuList[0][i] +" 가격은"+ menuList[1][i]+"원" ;
                    }
                }   
            }            
        }

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

        public void detectMenuCount()
        {
            int detected = 0;
            int detected5 = 0;
            int findMenuIndex = 0;
            int findMenuIndex5 = 0;
            for (int i = 0; i <  menus; i++)
            {
                int equalCount = 0;
                if (detected != 0)
                {
                    break;
                }
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
                if (detected5 != 0)
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
                            detected5++;
                            findMenuIndex5 = i;
                        }
                    }
                }

            }

            if (detected5 >= 1)
            {
                listBox1.Items.Add(menuList[0][findMenuIndex5 + menus]);
                for (int i = 0; i < 2; i++)
                {
                    listBox1.Items.Remove(menuList[0][findMenuIndex5]);
                }
            }

        }

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

        public void reOrder(ListBox listBox, int price)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(listBox.Items);
            int cnt = listBox.Items.Count;
            label3.Text = "총 가격 : " + price.ToString() + " 원";
        }

        public void clearListBox()
        {
            labels[0].Text = selText;
            label2.Text= selPrice;
            listBox1.Items.Clear();
        }

    }
}

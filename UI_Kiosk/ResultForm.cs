using System;
using System.Windows.Forms;

namespace UI_Kiosk
{
    public partial class ResultForm : Form
    {
        PurchaseForm purchase;

        public ResultForm()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        public void SetForm(PurchaseForm form)
        {
            purchase = form;
        }
        public void ResultListBox(ListBox listBox_, int change, int input, int bills)
        {
            foreach (String items in listBox_.Items)
            {
                listBox1.Items.Add(items);
            }
            label_change.Text = "요금 "+bills + " 원\n\n투입 금액 " + input +" 원 \n\n거스름돈 "+change.ToString()+ " 원";
        }

        // 버튼을 눌렸을때 실행되는 함수 PurchaseForm 까지 닫고 OrderForm 창 초기화 한다.
        private void closeResultForm_Click(object sender, EventArgs e)
        {
            purchase.closePurchaseForm();
            Close();
        }


        // ResultForm이 닫길때 실행되는 함수 PurchaseForm 까지 닫고 OrderForm 창 초기화 한다.
        private void ResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            purchase.closePurchaseForm();
        }
    }
}

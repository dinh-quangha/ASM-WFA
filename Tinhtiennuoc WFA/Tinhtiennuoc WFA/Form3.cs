using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinhtiennuoc_WFA
{
    public partial class Form3 : Form
    {
        private string ID;
        private string Name;
        private string Address;
        private string PhoneNumber;
        private string CustomerType;
        private string BillWater;
        private string Fee;
        private string VAT;
        private string TotalBill;
        private string NumPeople;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string customerID, string name, string address, string phone, string type, string billWater, string fee, string vat, string Totalbill, string numPeople)
        {
            InitializeComponent();
            this.ID = customerID;
            this.Name = name;
            this.Address = address;
            this.PhoneNumber = phone;
            this.CustomerType = type;
            this.BillWater = billWater;
            this.Fee = fee;
            this.VAT = vat;
            this.TotalBill = Totalbill;
            this.NumPeople = numPeople;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lbID.Text = ID;
            lbName.Text = Name;
            lbAddress.Text = Address;
            lbPhoneNumber.Text = PhoneNumber;
            lbCustomType.Text = CustomerType;
            lbBill.Text = BillWater;
            lbFee.Text = Fee;
            lbVat.Text = VAT;
            lbTotalBill.Text = TotalBill;
            lbNumPeople.Text = NumPeople;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult check_Exit = MessageBox.Show("Do you want to exit?", "Confim",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check_Exit == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

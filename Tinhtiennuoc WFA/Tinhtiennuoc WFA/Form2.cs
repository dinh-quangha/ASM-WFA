using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tinhtiennuoc_WFA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tbTotalBill.Enabled = false;
            tbVat.Enabled = false;
            tbFee.Enabled = false;
            tbBill.Enabled = false;
            tbConsumption.Enabled = false;



        }





        private void btResets_Click(object sender, EventArgs e)
        {
            tbCustomerID.Clear();
            tbName.Clear();
            tbAddress.Clear();
            tbPhone.Clear();
            tbWtLastMonth.Clear();
            tbWtThisMonth.Clear();
            tbNumberPeople.Clear();
            tbTotalBill.Clear();
            tbFee.Clear();
            tbBill.Clear();
            tbVat.Clear();
            tbConsumption.Clear();
            cbCustomerType.SelectedIndex = -1;

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

        private void btCalculate_Click(object sender, EventArgs e)
        {

            if (cbCustomerType.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer type.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int lastMonthUsage, thisMonthUsage, numPeople = 1;
            if (!int.TryParse(tbWtLastMonth.Text, out lastMonthUsage) || !int.TryParse(tbWtThisMonth.Text, out thisMonthUsage))
            {
                MessageBox.Show("Please enter valid water usage numbers.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lastMonthUsage >= thisMonthUsage)
            {
                MessageBox.Show("Last month's water usage should be less than this month's. Please try again.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int waterConsumption = thisMonthUsage - lastMonthUsage;

            string choice = cbCustomerType.SelectedItem.ToString();
            double waterPrice = GetWaterPrice(choice, waterConsumption);

            tbConsumption.Text = waterConsumption.ToString();
            tbTotalBill.Text = waterPrice.ToString("0.000" + "VND");
            double environmentFee = waterPrice * 0.1;
            tbFee.Text = environmentFee.ToString("0.000" + "VND");

            double VAT = waterPrice * 0.1;
            tbVat.Text = VAT.ToString("0.000" + "VND");

            double totalBill = waterPrice + VAT + environmentFee;
            tbBill.Text = totalBill.ToString("0.000" + "VND");

            if (choice == "Household")
            {
                
                if (!int.TryParse(tbNumberPeople.Text, out numPeople) || numPeople <= 0)
                {
                    MessageBox.Show("Please enter a valid number of people in household.");
                    return;
                }
                double avgPerPerson = waterConsumption / numPeople;
                tbConsumption.Text = (avgPerPerson + "m3");
               
            }
            else
            {
                tbNumberPeople.Enabled = false;

            }


            if (choice != "Household")
            {
                tbConsumption.Text = null;
            }
          

        }
        private double GetWaterPrice(string choice, int waterConsumption)
        {
            double waterPrice = 0;
            switch (choice)
            {
                case "Business services":
                    waterPrice = waterConsumption * 22.068;
                    break;
                case "Administrative agency, public services":
                    waterPrice = waterConsumption * 9.955;
                    break;
                case "Production units":
                    waterPrice = waterConsumption * 11.615;
                    break;
                case "Household":
                    if (waterConsumption <= 10)
                    {
                        waterPrice = 5.973 * waterConsumption;
                    }
                    else if (waterConsumption <= 20)
                    {
                        waterPrice = (10 * 5.973) + (waterConsumption - 10) * 7.052;
                    }
                    else if (waterConsumption <= 30)
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (waterConsumption - 20) * 8.699;
                    }
                    else
                    {
                        waterPrice = (10 * 5.973) + (10 * 7.052) + (10 * 8.699) + (waterConsumption - 30) * 15.929;
                    }
                    break;

            }
            return waterPrice;
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAddress.Text) ||
                string.IsNullOrWhiteSpace(tbCustomerID.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(tbPhone.Text))

            {
                MessageBox.Show("Please enter complete information", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                Form3 form3 = new Form3(tbCustomerID.Text, tbName.Text, tbAddress.Text, tbPhone.Text, cbCustomerType.Text, tbTotalBill.Text, tbFee.Text, tbVat.Text, tbBill.Text, tbNumberPeople.Text);
                this.Hide();
                form3.ShowDialog();
                this.Show();
            }
        }
    }
}

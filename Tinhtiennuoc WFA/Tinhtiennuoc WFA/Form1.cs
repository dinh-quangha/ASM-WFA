namespace Tinhtiennuoc_WFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btLoggin_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string pass = tbPass.Text;
            string confirm = tbConfirm.Text;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please Enter User Name", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbName.Focus();
            }
            else if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Please Enter Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPass.Focus();
            }
            else if (string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Please Enter Confirm Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbConfirm.Focus();

            }
           

            if (confirm == pass )
            {
                MessageBox.Show("Register success", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Register un-success", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPass.Text = "";
                tbConfirm.Text = "";
                tbPass.Focus();
                tbConfirm.Focus();
            }

        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult check_Exit = MessageBox.Show("Do you want Exit", "Confim", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check_Exit == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

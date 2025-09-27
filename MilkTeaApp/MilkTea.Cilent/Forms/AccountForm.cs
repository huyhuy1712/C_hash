using MilkTea.Client.Forms.ChildForm_Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms
{
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void roundedTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();
        }

        private void btnThemAccount_Click(object sender, EventArgs e)
        {
            AddAccountForm themTaiKhoan = new AddAccountForm();
            themTaiKhoan.ShowDialog();
        }
    }
}

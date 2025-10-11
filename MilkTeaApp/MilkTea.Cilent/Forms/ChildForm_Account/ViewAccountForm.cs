using MilkTea.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Account
{
    public partial class ViewAccountForm : Form
    {
        private ChiTietTaiKhoan _taiKhoan;
        public ViewAccountForm(ChiTietTaiKhoan taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewAccountForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MilkTea.Client.Forms.ChildForm_Discount;

namespace MilkTea.Client.Forms
{
    public partial class DiscountForm : Form
    {
        public DiscountForm()
        {
            InitializeComponent();
        }

        private void DiscountForm_Load(object sender, EventArgs e)
        {
            
        }
        private void btnThemDiscount_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();
            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                // Cập nhật danh sách khuyến mãi trong flowLayoutPanel1 (nếu cần)
            }
        }
    }
}

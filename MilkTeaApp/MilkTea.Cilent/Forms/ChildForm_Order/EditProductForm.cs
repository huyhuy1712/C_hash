using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkTea.Client.Forms.ChildForm_Order
{
    public partial class EditProductForm : Form
    {
        public EditProductForm()
        {
            InitializeComponent();
        }

        private void roundedComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void huy_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

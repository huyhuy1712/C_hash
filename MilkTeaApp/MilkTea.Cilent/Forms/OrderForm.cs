using MilkTea.Client.Forms.ChildForm_Order;
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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void roundedTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void roundedComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

        }

        private void roundedComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatDon_Click(object sender, EventArgs e)
        {
            InvoiceOrder invoiceForm = new InvoiceOrder();
            invoiceForm.ShowDialog();

        }

        private void SL_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void section_table_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void popup_Opening(object sender, CancelEventArgs e)
        {

        }

        private void three_dots_label_click(object sender, EventArgs e)
        {
            // Lấy vị trí Label trên màn hình
            var location = three_dots_label.PointToScreen(new Point(0, three_dots_label.Height));

            // Hiển thị menu ngay dưới label
            popup.Show(location);
        }

        private void Hủy_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void product_delete_btn1_Click(object sender, EventArgs e)
        {

        }

        private void Topping_Click(object sender, EventArgs e)
        {
            ToppingForm toppingForm = new ToppingForm();
            toppingForm.ShowDialog();

        }

        private void product_edit_btn1_Click(object sender, EventArgs e)
        {
            EditProductForm editProductForm = new EditProductForm();
            editProductForm.ShowDialog();
        }

        private void roundedButton1_Click_1(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

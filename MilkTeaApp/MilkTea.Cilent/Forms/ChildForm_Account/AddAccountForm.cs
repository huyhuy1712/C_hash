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
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn ảnh";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = ofd.FileName; // hiện đường dẫn ảnh
                //pictureBox1.Image = Image.FromFile(ofd.FileName); // load ảnh xem trước
            }
        }

        private void btnThoatTTK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


namespace MilkTea.Client.Forms
{
    partial class ImportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            excel_Import_btn = new MilkTea.Client.Controls.RoundedButton();
            cbx_search_Import = new MilkTea.Client.Controls.RoundedComboBox();
            search_Import = new MilkTea.Client.Controls.RoundedTextBox();
            add_Import_btn = new MilkTea.Client.Controls.RoundedButton();
            panel4 = new Panel();
            label2 = new Label();
            panel5 = new Panel();
            dataGridView1 = new DataGridView();
            maPhieuNhap_Tb = new DataGridViewTextBoxColumn();
            ngayNhap_Tb = new DataGridViewTextBoxColumn();
            soLuong_Tb = new DataGridViewTextBoxColumn();
            tenNVN_Tb = new DataGridViewTextBoxColumn();
            tongTien_Tb = new DataGridViewTextBoxColumn();
            thongTin_Tb = new DataGridViewImageColumn();
            xoa_Tb = new DataGridViewImageColumn();
            panel1 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1897, 57);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1897, 57);
            label1.TabIndex = 0;
            label1.Text = "Phiếu Nhập Kho";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(excel_Import_btn);
            panel3.Controls.Add(cbx_search_Import);
            panel3.Controls.Add(search_Import);
            panel3.Controls.Add(add_Import_btn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 57);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(23, 27, 23, 27);
            panel3.Size = new Size(1897, 103);
            panel3.TabIndex = 1;
            // 
            // excel_Import_btn
            // 
            excel_Import_btn.BackColor = Color.DodgerBlue;
            excel_Import_btn.BorderColor = Color.DodgerBlue;
            excel_Import_btn.BorderRadius = 20;
            excel_Import_btn.BorderSize = 0;
            excel_Import_btn.Dock = DockStyle.Left;
            excel_Import_btn.FlatAppearance.BorderSize = 0;
            excel_Import_btn.FlatStyle = FlatStyle.Flat;
            excel_Import_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            excel_Import_btn.ForeColor = Color.White;
            excel_Import_btn.Location = new Point(168, 27);
            excel_Import_btn.Margin = new Padding(3, 4, 3, 4);
            excel_Import_btn.Name = "excel_Import_btn";
            excel_Import_btn.Size = new Size(145, 49);
            excel_Import_btn.TabIndex = 3;
            excel_Import_btn.Text = "Execl";
            excel_Import_btn.UseVisualStyleBackColor = false;
            excel_Import_btn.Click += excel_Import_btn_Click;
            // 
            // cbx_search_Import
            // 
            cbx_search_Import.BackColor = Color.White;
            cbx_search_Import.BorderColor = Color.Gray;
            cbx_search_Import.BorderRadius = 15;
            cbx_search_Import.BorderSize = 1;
            cbx_search_Import.Dock = DockStyle.Right;
            cbx_search_Import.DrawMode = DrawMode.OwnerDrawFixed;
            cbx_search_Import.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_search_Import.FlatStyle = FlatStyle.Flat;
            cbx_search_Import.FocusBorderColor = Color.DeepSkyBlue;
            cbx_search_Import.Font = new Font("Segoe UI", 10F);
            cbx_search_Import.FormattingEnabled = true;
            cbx_search_Import.ItemHeight = 30;
            cbx_search_Import.Location = new Point(1360, 27);
            cbx_search_Import.Margin = new Padding(3, 4, 3, 4);
            cbx_search_Import.Name = "cbx_search_Import";
            cbx_search_Import.Size = new Size(138, 36);
            cbx_search_Import.TabIndex = 1;
            // 
            // search_Import
            // 
            search_Import.BackColor = Color.White;
            search_Import.BorderColor = Color.Gray;
            search_Import.BorderRadius = 20;
            search_Import.Dock = DockStyle.Right;
            search_Import.FocusBorderColor = Color.DeepSkyBlue;
            search_Import.Location = new Point(1498, 27);
            search_Import.Margin = new Padding(3, 4, 3, 4);
            search_Import.Name = "search_Import";
            search_Import.Padding = new Padding(11, 7, 46, 7);
            search_Import.Placeholder = "Từ khóa tìm kiếm...";
            search_Import.Size = new Size(376, 49);
            search_Import.TabIndex = 2;
            search_Import.TextValue = "";
            // 
            // add_Import_btn
            // 
            add_Import_btn.BackColor = Color.DodgerBlue;
            add_Import_btn.BorderColor = Color.DodgerBlue;
            add_Import_btn.BorderRadius = 20;
            add_Import_btn.BorderSize = 0;
            add_Import_btn.Dock = DockStyle.Left;
            add_Import_btn.FlatAppearance.BorderSize = 0;
            add_Import_btn.FlatStyle = FlatStyle.Flat;
            add_Import_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            add_Import_btn.ForeColor = Color.White;
            add_Import_btn.Location = new Point(23, 27);
            add_Import_btn.Margin = new Padding(3, 4, 3, 4);
            add_Import_btn.Name = "add_Import_btn";
            add_Import_btn.Size = new Size(145, 49);
            add_Import_btn.TabIndex = 0;
            add_Import_btn.Text = "Thêm";
            add_Import_btn.UseVisualStyleBackColor = false;
            add_Import_btn.Click += add_Import_btn_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 160);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(1897, 57);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(1897, 57);
            label2.TabIndex = 1;
            label2.Text = "Danh Sách Phiếu Nhập";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 217);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(23, 27, 23, 27);
            panel5.Size = new Size(1897, 486);
            panel5.TabIndex = 3;
            panel5.TabStop = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { maPhieuNhap_Tb, ngayNhap_Tb, soLuong_Tb, tenNVN_Tb, tongTien_Tb, thongTin_Tb, xoa_Tb });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(23, 27);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1851, 432);
            dataGridView1.TabIndex = 0;
            // 
            // maPhieuNhap_Tb
            // 
            maPhieuNhap_Tb.HeaderText = "Mã Phiếu Nhập";
            maPhieuNhap_Tb.MinimumWidth = 6;
            maPhieuNhap_Tb.Name = "maPhieuNhap_Tb";
            maPhieuNhap_Tb.Width = 300;
            // 
            // ngayNhap_Tb
            // 
            ngayNhap_Tb.HeaderText = "Ngày nhập";
            ngayNhap_Tb.MinimumWidth = 6;
            ngayNhap_Tb.Name = "ngayNhap_Tb";
            ngayNhap_Tb.Width = 200;
            // 
            // soLuong_Tb
            // 
            soLuong_Tb.HeaderText = "Số lượng";
            soLuong_Tb.MinimumWidth = 6;
            soLuong_Tb.Name = "soLuong_Tb";
            soLuong_Tb.Width = 125;
            // 
            // tenNVN_Tb
            // 
            tenNVN_Tb.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNVN_Tb.HeaderText = "Tên NV nhập";
            tenNVN_Tb.MinimumWidth = 6;
            tenNVN_Tb.Name = "tenNVN_Tb";
            // 
            // tongTien_Tb
            // 
            tongTien_Tb.HeaderText = "Tổng Tiền";
            tongTien_Tb.MinimumWidth = 6;
            tongTien_Tb.Name = "tongTien_Tb";
            tongTien_Tb.Width = 200;
            // 
            // thongTin_Tb
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = resources.GetObject("dataGridViewCellStyle1.NullValue");
            dataGridViewCellStyle1.Padding = new Padding(3);
            thongTin_Tb.DefaultCellStyle = dataGridViewCellStyle1;
            thongTin_Tb.HeaderText = "Thông tin";
            thongTin_Tb.Image = Properties.Resources.information;
            thongTin_Tb.ImageLayout = DataGridViewImageCellLayout.Zoom;
            thongTin_Tb.MinimumWidth = 6;
            thongTin_Tb.Name = "thongTin_Tb";
            thongTin_Tb.Resizable = DataGridViewTriState.True;
            thongTin_Tb.SortMode = DataGridViewColumnSortMode.Automatic;
            thongTin_Tb.Width = 125;
            // 
            // xoa_Tb
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(3);
            xoa_Tb.DefaultCellStyle = dataGridViewCellStyle2;
            xoa_Tb.HeaderText = "Xóa";
            xoa_Tb.Image = Properties.Resources.trash;
            xoa_Tb.MinimumWidth = 6;
            xoa_Tb.Name = "xoa_Tb";
            xoa_Tb.Resizable = DataGridViewTriState.True;
            xoa_Tb.SortMode = DataGridViewColumnSortMode.Automatic;
            xoa_Tb.Width = 125;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1897, 703);
            panel1.TabIndex = 0;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1897, 703);
            Controls.Add(panel1);
            Name = "ImportForm";
            Text = "Import Form";
            Load += ImportForm_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Controls.RoundedButton excel_Import_btn;
        private Controls.RoundedComboBox cbx_search_Import;
        private Controls.RoundedTextBox search_Import;
        private Controls.RoundedButton add_Import_btn;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn maPhieuNhap_Tb;
        private DataGridViewTextBoxColumn ngayNhap_Tb;
        private DataGridViewTextBoxColumn soLuong_Tb;
        private DataGridViewTextBoxColumn tenNVN_Tb;
        private DataGridViewTextBoxColumn tongTien_Tb;
        private DataGridViewImageColumn thongTin_Tb;
        private DataGridViewImageColumn xoa_Tb;
        private Panel panel1;
    }
}
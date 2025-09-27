
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            panel2.Name = "panel2";
            panel2.Size = new Size(1660, 80);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(691, 19);
            label1.Name = "label1";
            label1.Size = new Size(263, 45);
            label1.TabIndex = 0;
            label1.Text = "Phiếu Nhập Kho";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(excel_Import_btn);
            panel3.Controls.Add(cbx_search_Import);
            panel3.Controls.Add(search_Import);
            panel3.Controls.Add(add_Import_btn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 80);
            panel3.Name = "panel3";
            panel3.Size = new Size(1660, 80);
            panel3.TabIndex = 1;
            // 
            // excel_Import_btn
            // 
            excel_Import_btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            excel_Import_btn.BackColor = Color.DodgerBlue;
            excel_Import_btn.BorderColor = Color.DodgerBlue;
            excel_Import_btn.BorderRadius = 20;
            excel_Import_btn.BorderSize = 0;
            excel_Import_btn.FlatAppearance.BorderSize = 0;
            excel_Import_btn.FlatStyle = FlatStyle.Flat;
            excel_Import_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            excel_Import_btn.ForeColor = Color.White;
            excel_Import_btn.Location = new Point(159, 23);
            excel_Import_btn.Name = "excel_Import_btn";
            excel_Import_btn.Size = new Size(127, 36);
            excel_Import_btn.TabIndex = 3;
            excel_Import_btn.Text = "Execl";
            excel_Import_btn.UseVisualStyleBackColor = false;
            // 
            // cbx_search_Import
            // 
            cbx_search_Import.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cbx_search_Import.BackColor = Color.White;
            cbx_search_Import.BorderColor = Color.Gray;
            cbx_search_Import.BorderRadius = 15;
            cbx_search_Import.BorderSize = 1;
            cbx_search_Import.DrawMode = DrawMode.OwnerDrawFixed;
            cbx_search_Import.DropDownStyle = ComboBoxStyle.DropDownList;
            cbx_search_Import.FlatStyle = FlatStyle.Flat;
            cbx_search_Import.FocusBorderColor = Color.DeepSkyBlue;
            cbx_search_Import.Font = new Font("Segoe UI", 10F);
            cbx_search_Import.FormattingEnabled = true;
            cbx_search_Import.ItemHeight = 30;
            cbx_search_Import.Location = new Point(1527, 23);
            cbx_search_Import.Name = "cbx_search_Import";
            cbx_search_Import.Size = new Size(121, 36);
            cbx_search_Import.TabIndex = 1;
            // 
            // search_Import
            // 
            search_Import.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            search_Import.BackColor = Color.White;
            search_Import.BorderColor = Color.Gray;
            search_Import.BorderRadius = 20;
            search_Import.FocusBorderColor = Color.DeepSkyBlue;
            search_Import.Location = new Point(1192, 23);
            search_Import.Name = "search_Import";
            search_Import.Padding = new Padding(10, 5, 40, 5);
            search_Import.Placeholder = "Từ khóa tìm kiếm...";
            search_Import.Size = new Size(329, 36);
            search_Import.TabIndex = 2;
            search_Import.TextValue = "";
            // 
            // add_Import_btn
            // 
            add_Import_btn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            add_Import_btn.BackColor = Color.DodgerBlue;
            add_Import_btn.BorderColor = Color.DodgerBlue;
            add_Import_btn.BorderRadius = 20;
            add_Import_btn.BorderSize = 0;
            add_Import_btn.FlatAppearance.BorderSize = 0;
            add_Import_btn.FlatStyle = FlatStyle.Flat;
            add_Import_btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            add_Import_btn.ForeColor = Color.White;
            add_Import_btn.Location = new Point(12, 23);
            add_Import_btn.Name = "add_Import_btn";
            add_Import_btn.Size = new Size(127, 36);
            add_Import_btn.TabIndex = 0;
            add_Import_btn.Text = "Thêm";
            add_Import_btn.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 160);
            panel4.Name = "panel4";
            panel4.Size = new Size(1660, 80);
            panel4.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label2.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(691, 16);
            label2.Name = "label2";
            label2.Size = new Size(263, 45);
            label2.TabIndex = 1;
            label2.Text = "Phiếu Nhập Kho";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(dataGridView1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 240);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20);
            panel5.Size = new Size(1660, 287);
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
            dataGridView1.Location = new Point(20, 20);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1620, 247);
            dataGridView1.TabIndex = 0;
            // 
            // maPhieuNhap_Tb
            // 
            maPhieuNhap_Tb.HeaderText = "Mã Phiếu Nhập";
            maPhieuNhap_Tb.Name = "maPhieuNhap_Tb";
            maPhieuNhap_Tb.Width = 300;
            // 
            // ngayNhap_Tb
            // 
            ngayNhap_Tb.HeaderText = "Ngày nhập";
            ngayNhap_Tb.Name = "ngayNhap_Tb";
            ngayNhap_Tb.Width = 200;
            // 
            // soLuong_Tb
            // 
            soLuong_Tb.HeaderText = "Số lượng";
            soLuong_Tb.Name = "soLuong_Tb";
            // 
            // tenNVN_Tb
            // 
            tenNVN_Tb.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNVN_Tb.HeaderText = "Tên NV nhập";
            tenNVN_Tb.Name = "tenNVN_Tb";
            // 
            // tongTien_Tb
            // 
            tongTien_Tb.HeaderText = "Tổng Tiền";
            tongTien_Tb.Name = "tongTien_Tb";
            tongTien_Tb.Width = 200;
            // 
            // thongTin_Tb
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = resources.GetObject("dataGridViewCellStyle3.NullValue");
            dataGridViewCellStyle3.Padding = new Padding(3);
            thongTin_Tb.DefaultCellStyle = dataGridViewCellStyle3;
            thongTin_Tb.HeaderText = "Thông tin";
            thongTin_Tb.Image = Properties.Resources.information;
            thongTin_Tb.ImageLayout = DataGridViewImageCellLayout.Zoom;
            thongTin_Tb.Name = "thongTin_Tb";
            thongTin_Tb.Resizable = DataGridViewTriState.True;
            thongTin_Tb.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // xoa_Tb
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = resources.GetObject("dataGridViewCellStyle4.NullValue");
            dataGridViewCellStyle4.Padding = new Padding(3);
            xoa_Tb.DefaultCellStyle = dataGridViewCellStyle4;
            xoa_Tb.HeaderText = "Xóa";
            xoa_Tb.Image = Properties.Resources.trash;
            xoa_Tb.Name = "xoa_Tb";
            xoa_Tb.Resizable = DataGridViewTriState.True;
            xoa_Tb.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1660, 527);
            panel1.TabIndex = 0;
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1660, 527);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
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
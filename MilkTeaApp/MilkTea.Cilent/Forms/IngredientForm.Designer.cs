using MilkTea.Client.Controls;

namespace MilkTea.Client.Forms
{
    partial class IngredientForm
    {
        private System.ComponentModel.IContainer components = null;



        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            labelHeader = new Label();
            panelFilter = new Panel();
            panelBtnAdd = new Panel();
            btnAddIngredient = new RoundedButton();
            panelSearch = new Panel();
            txtSearch = new RoundedTextBox();
            panelTitle = new Panel();
            labelTitle = new Label();
            IngredientPanel = new Panel();
            dGV_ingredients = new DataGridView();
            maNL_col = new DataGridViewTextBoxColumn();
            tenNL_col = new DataGridViewTextBoxColumn();
            soLuong_col = new DataGridViewTextBoxColumn();
            giaBan_col = new DataGridViewTextBoxColumn();
            donVi_col = new DataGridViewTextBoxColumn();
            sua_col = new DataGridViewImageColumn();
            xoa_col = new DataGridViewImageColumn();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            panelBtnAdd.SuspendLayout();
            panelSearch.SuspendLayout();
            panelTitle.SuspendLayout();
            IngredientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_ingredients).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1660, 60);
            panelHeader.TabIndex = 3;
            // 
            // labelHeader
            // 
            labelHeader.Dock = DockStyle.Fill;
            labelHeader.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            labelHeader.ForeColor = Color.DodgerBlue;
            labelHeader.Location = new Point(0, 0);
            labelHeader.Name = "labelHeader";
            labelHeader.Size = new Size(1660, 60);
            labelHeader.TabIndex = 0;
            labelHeader.Text = "Nguyên liệu";
            labelHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = SystemColors.ActiveBorder;
            panelFilter.Controls.Add(panelBtnAdd);
            panelFilter.Controls.Add(panelSearch);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 60);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(4);
            panelFilter.Size = new Size(1660, 38);
            panelFilter.TabIndex = 2;
            // 
            // panelBtnAdd
            // 
            panelBtnAdd.Controls.Add(btnAddIngredient);
            panelBtnAdd.Dock = DockStyle.Right;
            panelBtnAdd.Location = new Point(1519, 4);
            panelBtnAdd.Name = "panelBtnAdd";
            panelBtnAdd.Size = new Size(137, 30);
            panelBtnAdd.TabIndex = 0;
            // 
            // btnAddIngredient
            // 
            btnAddIngredient.BackColor = Color.DodgerBlue;
            btnAddIngredient.BorderColor = Color.DodgerBlue;
            btnAddIngredient.BorderRadius = 20;
            btnAddIngredient.BorderSize = 0;
            btnAddIngredient.Dock = DockStyle.Fill;
            btnAddIngredient.FlatStyle = FlatStyle.Flat;
            btnAddIngredient.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddIngredient.ForeColor = Color.White;
            btnAddIngredient.Location = new Point(0, 0);
            btnAddIngredient.Name = "btnAddIngredient";
            btnAddIngredient.Size = new Size(137, 30);
            btnAddIngredient.TabIndex = 0;
            btnAddIngredient.Text = "Thêm";
            btnAddIngredient.UseVisualStyleBackColor = false;
            btnAddIngredient.Click += btnAddIngredient_Click;
            // 
            // panelSearch
            // 
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Dock = DockStyle.Left;
            panelSearch.Location = new Point(4, 4);
            panelSearch.Name = "panelSearch";
            panelSearch.Size = new Size(250, 30);
            panelSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderColor = Color.Gray;
            txtSearch.BorderRadius = 20;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.FocusBorderColor = Color.DeepSkyBlue;
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(10, 5, 40, 5);
            txtSearch.Placeholder = "Nhập mã hoặc tên nguyên liệu...";
            txtSearch.Size = new Size(250, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(labelTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 98);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1660, 38);
            panelTitle.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 18F);
            labelTitle.ForeColor = Color.DodgerBlue;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(1660, 38);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Danh Sách Nguyên Liệu";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // IngredientPanel
            // 
            IngredientPanel.Controls.Add(dGV_ingredients);
            IngredientPanel.Controls.Add(panelTitle);
            IngredientPanel.Controls.Add(panelFilter);
            IngredientPanel.Controls.Add(panelHeader);
            IngredientPanel.Dock = DockStyle.Fill;
            IngredientPanel.Location = new Point(0, 0);
            IngredientPanel.Name = "IngredientPanel";
            IngredientPanel.Size = new Size(1660, 527);
            IngredientPanel.TabIndex = 0;
            // 
            // dGV_ingredients
            // 
            dGV_ingredients.AllowUserToAddRows = false;
            dGV_ingredients.AllowUserToDeleteRows = false;
            dGV_ingredients.BackgroundColor = SystemColors.ButtonFace;
            dGV_ingredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV_ingredients.Columns.AddRange(new DataGridViewColumn[] { maNL_col, tenNL_col, soLuong_col, giaBan_col, donVi_col, sua_col, xoa_col });
            dGV_ingredients.Dock = DockStyle.Fill;
            dGV_ingredients.Location = new Point(0, 136);
            dGV_ingredients.Name = "dGV_ingredients";
            dGV_ingredients.Size = new Size(1660, 391);
            dGV_ingredients.TabIndex = 0;
            dGV_ingredients.CellContentClick += dGV_ingredients_CellContentClick;
            // 
            // maNL_col
            // 
            maNL_col.HeaderText = "Mã nguyên liệu";
            maNL_col.Name = "maNL_col";
            maNL_col.Width = 150;
            // 
            // tenNL_col
            // 
            tenNL_col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tenNL_col.HeaderText = "Tên nguyên liệu";
            tenNL_col.Name = "tenNL_col";
            // 
            // soLuong_col
            // 
            soLuong_col.HeaderText = "Số lượng";
            soLuong_col.Name = "soLuong_col";
            soLuong_col.Width = 120;
            // 
            // giaBan_col
            // 
            giaBan_col.HeaderText = "Giá bán (VNĐ)";
            giaBan_col.Name = "giaBan_col";
            giaBan_col.Width = 150;
            // 
            // donVi_col
            // 
            donVi_col.HeaderText = "Đơn vị";
            donVi_col.Name = "donVi_col";
            donVi_col.Width = 100;
            // 
            // sua_col
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Padding = new Padding(3);
            sua_col.DefaultCellStyle = dataGridViewCellStyle1;
            sua_col.HeaderText = "Sửa";
            sua_col.Image = Properties.Resources.edit;
            sua_col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            sua_col.Name = "sua_col";
            sua_col.ReadOnly = true;
            sua_col.Width = 75;
            // 
            // xoa_col
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(3);
            xoa_col.DefaultCellStyle = dataGridViewCellStyle2;
            xoa_col.HeaderText = "Xóa";
            xoa_col.Image = Properties.Resources.trash;
            xoa_col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            xoa_col.Name = "xoa_col";
            xoa_col.ReadOnly = true;
            xoa_col.Width = 75;
            // 
            // IngredientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1660, 527);
            Controls.Add(IngredientPanel);
            Name = "IngredientForm";
            Text = "IngredientForm";
            panelHeader.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelBtnAdd.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            IngredientPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dGV_ingredients).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel IngredientPanel;
        private Label labelHeader;
        private Label labelTitle;
        private RoundedButton btnAddIngredient;
        private RoundedTextBox txtSearch;
        private DataGridView dGV_ingredients;
        private DataGridViewTextBoxColumn maNL_col;
        private DataGridViewTextBoxColumn tenNL_col;
        private DataGridViewTextBoxColumn soLuong_col;
        private DataGridViewTextBoxColumn giaBan_col;
        private DataGridViewTextBoxColumn donVi_col;
        private DataGridViewImageColumn sua_col;
        private DataGridViewImageColumn xoa_col;
        private Panel panelBtnAdd;
        private Panel panelSearch;
        private Panel panelHeader;
        private Panel panelFilter;
        private Panel panelTitle;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvNV.Columns.Add("MSNV", "MSNV");
            dgvNV.Columns.Add("TenNV", "Ten NV");
            dgvNV.Columns.Add("LuongCB", "Luong CB");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            var formNhanVien = new ThongTinNV();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                dgvNV.Rows.Add(formNhanVien.MSNV, formNhanVien.TenNV, formNhanVien.LuongCB);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvNV.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvNV.CurrentRow;
                string msnv = currentRow.Cells["MSNV"].Value?.ToString();
                string tenNV = currentRow.Cells["TenNV"].Value?.ToString();
                string luongCB = currentRow.Cells["LuongCB"].Value?.ToString();
                var formNhanVien = new ThongTinNV
                {
                    MSNV = msnv,
                    TenNV = tenNV,
                    LuongCB = luongCB
                };
                
                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    currentRow.Cells["TenNV"].Value = formNhanVien.TenNV;
                    currentRow.Cells["LuongCB"].Value = formNhanVien.LuongCB;

                    MessageBox.Show("Cap nhat thanh cong!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Loi!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvNV.CurrentRow != null)
            {
                dgvNV.Rows.Remove(dgvNV.CurrentRow);
            }
            else
            {
                MessageBox.Show("Loi! Hay chon dong de xoa.");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

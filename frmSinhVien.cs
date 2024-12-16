using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using De01.Models;

namespace De01
{
    public partial class frmSinhVien : Form
    {
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<Lop> listLop = context.Lop.ToList();
                List<Sinhvien> listSinhvien = context.Sinhvien.ToList();
                FillFalcultyCombobox(listLop);
                BindGrid(listSinhvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFalcultyCombobox(List<Lop> listLop)
        {
            this.cblop.DataSource = listLop;
            this.cblop.DisplayMember = "TenLop";
            this.cblop.ValueMember = "MaLop";
        }
        
        private void BindGrid(List<Sinhvien> listStudent)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.MaSV;
                dataGridView1.Rows[index].Cells[1].Value = item.HoTenSV;
                dataGridView1.Rows[index].Cells[2].Value = item.NgaySinh;
                dataGridView1.Rows[index].Cells[3].Value = item.Lop.MaLop;
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<Sinhvien> studentList = context.Sinhvien.ToList();
                if (studentList.Any(s => s.MaSV == txtmssv.Text))
                {
                    MessageBox.Show("Mã SV đã tồn tại! BẠN VUI LÒNG NHẬP LẠI!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                var newStudent = new Sinhvien
                {
                    MaSV = txtmssv.Text,
                    HoTenSV = txtname.Text,

                    NgaySinh = cbdate.Value,
                    MaLop = cblop.SelectedValue.ToString(),
                };
                context.Sinhvien.Add(newStudent);
                context.SaveChanges();
                //Hàm BinGrid
                BindGrid(context.Sinhvien.ToList());
                MessageBox.Show("Thêm SV thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<Sinhvien> students = context.Sinhvien.ToList();
                var sinhvien = students.FirstOrDefault(s => s.MaSV == txtmssv.Text);

                if (sinhvien != null)
                {
                    
                    if (students.Any(s => s.MaSV == txtmssv.Text && s.MaSV != sinhvien.MaSV))
                    {
                        MessageBox.Show("Mã SV đã tồn tại! BẠN VUI LONG NHẬP LẠI!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }

                    sinhvien.HoTenSV = txtname.Text;

                    sinhvien.NgaySinh = cbdate.Value;
                    sinhvien.MaLop= cblop.SelectedValue.ToString();

                    context.SaveChanges();

                    BindGrid(context.Sinhvien.ToList());

                    MessageBox.Show("Chỉnh sửa thông tin SV thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                 
                    MessageBox.Show("Không tìm thấy sinh viên!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<Sinhvien> students = context.Sinhvien.ToList();
                var student = students.FirstOrDefault(s => s.MaSV == txtmssv.Text);
                if (student != null)
                {
                    var result =MessageBox.Show("Bạn chắc chắn muốn xóa SV này Không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result== DialogResult.Yes)
                    {
                        context.Sinhvien.Remove(student);
                        context.SaveChanges();
                        BindGrid(context.Sinhvien.ToList());
                        MessageBox.Show("Đã xóa thành công!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"lỗi khi cập nhật dữ liệu: {ex.Message}", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectRow = dataGridView1.Rows[e.RowIndex];
                txtmssv.Text = selectRow.Cells[0].Value.ToString();
                txtname.Text = selectRow.Cells[1].Value.ToString();
                cbdate.Text = selectRow.Cells[2].Value.ToString();
                cblop.Text = selectRow.Cells[3].Value.ToString();
            }
        }

        private void bttim_Click(object sender, EventArgs e)
        {
       
            try
            {
                string searchMSSV = txttim.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchMSSV))
                {
                    MessageBox.Show("Vui lòng nhập MSSV cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Model1 context = new Model1();
                var sinhvien = context.Sinhvien.FirstOrDefault(s => s.MaSV == searchMSSV);

                if (sinhvien != null)
                {
                    txtmssv.Text = sinhvien.MaSV;
                    txtname.Text = sinhvien.HoTenSV;
                    cbdate.Value = (DateTime)sinhvien.NgaySinh;
                    cblop.SelectedValue = sinhvien.MaLop;
                    BindGrid(new List<Sinhvien> { sinhvien });

                    MessageBox.Show("Tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên với MSSV này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm sinh viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btthoat_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn chắc chắn muốn thoát không?","Thông báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1(); 
                context.SaveChanges();
                BindGrid(context.Sinhvien.ToList());
                MessageBox.Show("Thông tin sinh viên đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btkluu_Click(object sender, EventArgs e)
        {
           
        }

    }
}





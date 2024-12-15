﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Windows.Forms;
using EF_Demo.models;


namespace QLSV_Form
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }
        Model1 db = new Model1();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<Khoa> listFalcultys = context.Khoas.ToList(); //lấy các khoa
                List<sinhvien> listStudent = context.sinhviens.ToList(); //lấy sinh viên
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Hàm binding list có tên hiện thị là tên khoa, giá trị là Mã khoa
        private void FillFalcultyCombobox(List<Khoa> listFalcultys)
        {
            this.cbkhoa.DataSource = listFalcultys;
            this.cbkhoa.DisplayMember = "KhoaName";
            this.cbkhoa.ValueMember = "KhoaId";
        }
        //Hàm binding gridView từ list sinh viên
        private void BindGrid(List<sinhvien> listStudent)
        {
            dataGridView1.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.Id;
                dataGridView1.Rows[index].Cells[1].Value = item.fullname;
                dataGridView1.Rows[index].Cells[2].Value = item.Khoa.KhoaName;
                dataGridView1.Rows[index].Cells[3].Value = item.diemtb;
            }
        }
        
      

        private void btthem_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Khởi tạo context để làm việc với database

                Model1 db = new Model1();
                // Lấy danh sách tất cả sinh viên trong CSDL
                List<sinhvien> studentList =db.sinhviens.ToList();

                // Kiểm tra trùng mã sinh viên
                if (studentList.Any(s => s.Id == int.Parse(txtmssv.Text)))
                {
                    MessageBox.Show("Mã SV đã tồn tại. Vui lòng nhập một mã khác.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng sinh viên mới
                var newStudent = new sinhvien
                {
                    Id =  int.Parse(txtmssv.Text),
                    fullname = txtname.Text,
                    
                    khoaid =int.Parse(cbkhoa.SelectedValue.ToString()),
                    diemtb = float.Parse(txtdtb.Text)
                };

                // Thêm sinh viên vào CSDL
                db.sinhviens.Add(newStudent);
                db.SaveChanges();

                // Hiển thị lại danh sách sinh viên sau khi thêm
                BindGrid(db.sinhviens.ToList());

                // Thông báo thành công
                MessageBox.Show("Thêm sinh viên thành công!",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi khi thêm dữ liệu
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Khởi tạo context để làm việc với CSDL
                Model1 db = new Model1();

                // Lấy danh sách sinh viên từ CSDL
                List<sinhvien> students = db.sinhviens.ToList();

                // Tìm sinh viên cần cập nhật theo mã sinh viên
                var student = students.FirstOrDefault(s => s.Id == int.Parse(txtmssv.Text));

                if (student != null)
                {
                    // Kiểm tra trùng mã sinh viên ngoại trừ sinh viên hiện tại
                    if (students.Any(s => s.Id == int.Parse(txtmssv.Text) && s.Id != student.Id))
                    {
                        MessageBox.Show("Mã SV đã tồn tại. Vui lòng nhập một mã khác.",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }

                    // Cập nhật thông tin sinh viên
                    student.fullname = txtname.Text;
                    
                    student.khoaid = int.Parse(cbkhoa.SelectedValue.ToString());
                    student.diemtb = float.Parse(txtdtb.Text);

                    // Lưu thay đổi vào CSDL
                    db.SaveChanges();

                    // Hiển thị lại danh sách sinh viên sau khi cập nhật
                    BindGrid(db.sinhviens.ToList());

                    // Thông báo thành công
                    MessageBox.Show("Chỉnh sửa thông tin sinh viên thành công!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    // Thông báo khi không tìm thấy sinh viên
                    MessageBox.Show("Sinh viên không tìm thấy!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Thông báo lỗi khi xảy ra ngoại lệ
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu: {ex.Message}",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<sinhvien> students = context.sinhviens.ToList();
                var student = students.FirstOrDefault(s => s.Id == int.Parse(txtmssv.Text));
                if(student != null)
                {
                    context.sinhviens.Remove(student);
                    context.SaveChanges();
                    BindGrid(context.sinhviens.ToList());
                    MessageBox.Show("Sinh vien da duoc xoa thanh cong!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sinh vien khong tim thay!", "Thong bao!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Loi khi cap nhat du lieu: {ex.Message}","Thong bao!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectRow=dataGridView1.Rows[e.RowIndex];
                txtmssv.Text = selectRow.Cells[0].Value.ToString();
                txtname.Text = selectRow.Cells[1].Value.ToString();
                cbkhoa.Text = selectRow.Cells[2].Value.ToString();
                txtdtb.Text = selectRow.Cells[3].Value.ToString();
            }
        }
    }
}

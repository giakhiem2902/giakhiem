using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tuan3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void xuat_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item = thongtin.Items.Add(txtHo.Text);
            
            item.SubItems.Add(txtTen.Text);
            item.SubItems.Add(date.Value.ToShortDateString());
            txtHo.Text = " ";
            txtTen.Text = " ";
            date.Value = DateTime.Now;
        }

        private void thongtin_SelectedIndexChanged(object sender, EventArgs e)
        {
            thongtin.Columns[0].Width =(int) (thongtin.Width * 0.25);
            thongtin.Columns[1].Width = (int)(thongtin.Width * 0.25);
            thongtin.Columns[2].Width = (int)(thongtin.Width * 0.25);
            thongtin.View = View.Details;
            thongtin.GridLines= true;
            thongtin.FullRowSelect=false;
            if (thongtin.SelectedItems.Count > 0)
            {
                txtHo.Text=thongtin.SelectedItems[0].SubItems[0].Text;
                txtTen.Text = thongtin.SelectedItems[0].SubItems[1].Text;
                date.Text = thongtin.SelectedItems[0].SubItems[2].Text;
               
            }

        }

        private void sua_Click(object sender, EventArgs e)
        {
            thongtin.SelectedItems[0].SubItems[0].Text=txtHo.Text;
            thongtin.SelectedItems[0].SubItems[1].Text = txtTen.Text;
            thongtin.SelectedItems[0].SubItems[2].Text=date.Value.ToShortDateString();
            
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if(thongtin.SelectedItems.Count > 0)
            {
                thongtin.Items.Remove(thongtin.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Ban phai chon it nhat 1 dong thong tin!");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

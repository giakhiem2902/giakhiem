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
    public partial class ThongTinNV : Form
    {
        public ThongTinNV()
        {
            InitializeComponent();
        }
        public string MSNV
        {
            get { return txtmssv.Text; }
            set { txtmssv.Text = value; } 
        }

        public string TenNV
        {
            get { return txtname.Text; }
            set { txtname.Text = value; }
        }

        public string LuongCB
        {
            get { return txtluong.Text; }
            set { txtluong.Text = value; }
        }

        private void ThongTinNV_Load(object sender, EventArgs e)
        {
            txtmssv.Text = MSNV;
            txtname.Text = TenNV;
            txtluong.Text = LuongCB;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MSNV = txtmssv.Text;
            TenNV = txtname.Text;
            LuongCB = txtluong.Text;
            if (string.IsNullOrWhiteSpace(MSNV) || string.IsNullOrWhiteSpace(TenNV) || string.IsNullOrWhiteSpace(LuongCB))
            {
                MessageBox.Show("Loi! Hay dien day du thong tin.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

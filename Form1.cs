using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int size = 14;
        string font = "Tahoma";
        private void AddFontInCMB()
        {
            foreach(FontFamily font in new InstalledFontCollection().Families)
            {
                cbmFonts.Items.Add(font.Name);
            }
        }
        private void AddSizeInCMB()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 50, 72 };
            foreach(int size in sizes)
            {
                cbmSizes.Items.Add(size);
            }
        }
        private void dinhDangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg=new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if(fontDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }
        private void lamMoiRich()
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cbmFonts.SelectedItem = "Tahoma";
            cbmSizes.SelectedItem = 14;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddFontInCMB();
            AddSizeInCMB();
            lamMoiRich();
        }

        private void cbmSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(cbmSizes.Text);
            richTextBox1.Font=new Font(font,size,FontStyle.Regular);
        }

        private void cbmFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cbmFonts.Text;
            richTextBox1.Font = new Font(font, size);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taoVanBanMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lamMoiRich();

        }

        private void moTapTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd =new OpenFileDialog();
            ofd.Filter = "Text file|*.txt| RFT File | *.rft";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName=ofd.FileName;
                richTextBox1.LoadFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.N)
            {
                lamMoiRich();
                e.Handled = true;
                return;
            }
            if(e.Control&& e.KeyCode == Keys.O)
            {
                moTapTinToolStripMenuItem_Click(this,e);
                e.Handled = true;
                return;
            }
            if(e.Control&& e.KeyCode == Keys.S)
            {
                toolStripButton2_Click(this, e);
                e.Handled = true;
                return;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaLog=new SaveFileDialog();
            saveFileDiaLog.CheckPathExists = true;
            saveFileDiaLog.Title = "Luu tap tin van ban";
            saveFileDiaLog.DefaultExt = "rft";
            saveFileDiaLog.Filter = "RichText files|*.rft";
            saveFileDiaLog.RestoreDirectory = true;
            saveFileDiaLog.AddExtension = true;
            if(saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDiaLog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tap tin da duoc luu thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Da xay ra loi trong qua trinh luu tap tin", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void luuNoiDungVanBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDiaLog = new SaveFileDialog();
            saveFileDiaLog.CheckPathExists = true;
            saveFileDiaLog.Title = "Luu tap tin van ban";
            saveFileDiaLog.DefaultExt = "rft";
            saveFileDiaLog.Filter = "RichText files|*.rft";
            saveFileDiaLog.RestoreDirectory = true;
            saveFileDiaLog.AddExtension = true;
            if (saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDiaLog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tap tin da duoc luu thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Da xay ra loi trong qua trinh luu tap tin", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont=new Font(richTextBox1.SelectionFont,richTextBox1.SelectionFont.Style&~FontStyle.Bold);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);
            }
        }
    }
}

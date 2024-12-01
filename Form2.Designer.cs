namespace tuan3
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.thongtin = new System.Windows.Forms.ListView();
            this.coHo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coNgaysinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.them = new System.Windows.Forms.Button();
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thong tin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ho";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngay sinh";
            // 
            // txtHo
            // 
            this.txtHo.Location = new System.Drawing.Point(91, 81);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(306, 22);
            this.txtHo.TabIndex = 5;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(476, 84);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 22);
            this.date.TabIndex = 6;
            this.date.Value = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.date.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // thongtin
            // 
            this.thongtin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.coHo,
            this.coTen,
            this.coNgaysinh});
            this.thongtin.FullRowSelect = true;
            this.thongtin.GridLines = true;
            this.thongtin.HideSelection = false;
            this.thongtin.Location = new System.Drawing.Point(74, 205);
            this.thongtin.Name = "thongtin";
            this.thongtin.Size = new System.Drawing.Size(649, 233);
            this.thongtin.TabIndex = 14;
            this.thongtin.UseCompatibleStateImageBehavior = false;
            this.thongtin.View = System.Windows.Forms.View.Details;
            this.thongtin.SelectedIndexChanged += new System.EventHandler(this.thongtin_SelectedIndexChanged);
            // 
            // coHo
            // 
            this.coHo.Text = "Ho";
            this.coHo.Width = 100;
            // 
            // coTen
            // 
            this.coTen.Text = "Ten";
            this.coTen.Width = 100;
            // 
            // coNgaysinh
            // 
            this.coNgaysinh.Text = "NgaySinh";
            this.coNgaysinh.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Ten";
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(91, 135);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(306, 22);
            this.txtTen.TabIndex = 16;
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(406, 167);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(75, 23);
            this.them.TabIndex = 17;
            this.them.Text = "Them";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.button1_Click);
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(500, 166);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(75, 23);
            this.sua.TabIndex = 18;
            this.sua.Text = "Sua";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Location = new System.Drawing.Point(597, 166);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(75, 23);
            this.xoa.TabIndex = 19;
            this.xoa.Text = "Xoa";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.xoa_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.them);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.thongtin);
            this.Controls.Add(this.date);
            this.Controls.Add(this.txtHo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Ho ten";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHo;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.ListView thongtin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.ColumnHeader coHo;
        private System.Windows.Forms.ColumnHeader coTen;
        private System.Windows.Forms.ColumnHeader coNgaysinh;
    }
}
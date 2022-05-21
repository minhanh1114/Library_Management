using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLTV_DTO;
using QLTV_BUS;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace QLTV_GUI
{
    public partial class frmADMIN : DevExpress.XtraEditors.XtraForm
    {
        List<TTADMINDTO> listad = new List<TTADMINDTO>();
        BindingSource ListBDadmin = new BindingSource();

        public GridColumn IDAdmin { get; private set; }
        public GridColumn NameAdmin { get; private set; }

        public frmADMIN()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        void LoadAdminInfo()
        {
            listad = ADMINBUS.Instance.GetInfoAdmin().ToList();
        }

        private void frmADMIN_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
           
            Loadadmingirl();
            Binding_DocGia();
        }
        private void Loadadmingirl()
        {
            listad.Clear();
            listad = QLTV_BUS.ADMINBUS.Instance.GetInfoAdmin();
            ListBDadmin.DataSource = listad.ToList();
            gridControl1.DataSource = ListBDadmin;
        }
        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
           
        }
       
        // load dữ liệu lên text box
        void Binding_DocGia()
        {
            try
            {
                textBox1.DataBindings.Add("Text", ListBDadmin, "IDAdmin", true, DataSourceUpdateMode.Never);
                textBox2.DataBindings.Add("Text", ListBDadmin, "NameAdmin", true, DataSourceUpdateMode.Never);
                textBox3.DataBindings.Add("Text", ListBDadmin, "Email", true, DataSourceUpdateMode.Never);
                textBox4.DataBindings.Add("Text", ListBDadmin, "IDAccount", true, DataSourceUpdateMode.Never);
                dateNgaySinh.DataBindings.Add("EditValue", ListBDadmin, "Birthday", true, DataSourceUpdateMode.Never);
                textBox6.DataBindings.Add("Text", ListBDadmin, "NumberPhone", true, DataSourceUpdateMode.Never);
                textBox7.DataBindings.Add("Text", ListBDadmin, "Address", true, DataSourceUpdateMode.Never);
                textmk.DataBindings.Add("Text", ListBDadmin, "PasswordAccount", true, DataSourceUpdateMode.Never);


            }
            catch
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!dxErrorProvider1.HasErrors)
            {
                if (XtraMessageBox.Show("Bạn có muốn lưu thông tin độc giả đã thay đổi không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string idadmin = textBox1.Text;

                    //(MaAD, idtaikhoan, TenAD, DiaChi, email, NgaySinh, phone);

                    QLTV_BUS.ADMINBUS.Instance.updateInfoadmin(idadmin, textBox4.Text, textBox2.Text, textBox7.Text, textBox3.Text,Convert.ToDateTime(dateNgaySinh.EditValue),textBox6.Text);
                    QLTV_BUS.ACCOUNTBUS.Instance.UpdateInfoAccount(textBox4.Text, textmk.Text);
                    XtraMessageBox.Show("Thay đổi đã lưu thành công!", "Thông Báo"+ idadmin, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnLamMoi_ItemClick(sender, e as DevExpress.XtraBars.ItemClickEventArgs);
                    // gridControl.Focus();
                    Loadadmingirl();
                }
            }
            else
            {
                XtraMessageBox.Show("Thông tin độc giả đã sửa không hợp lệ!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnluu.Visible = true;
            btnhuy.Visible = true;
            



        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnluu.Visible = false;
            btnhuy.Visible = false;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Loadadmingirl();
            textBox1.ReadOnly = true;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            textmk.Text = "12345678";
        }
    }
}
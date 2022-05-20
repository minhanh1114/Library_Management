using QLTV_DAO;
using QLTV_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV_BUS
{
    public class ADMINBUS
    {
        private static ADMINBUS instance;

        public static ADMINBUS Instance
        {
            get { if (instance == null) instance = new ADMINBUS(); return instance; }
            set => instance = value;
        }
        private ADMINBUS() { }
        public List<ADMIN> GetInfoAdmin(string idaccount="")
        {
            return ADMINDAO.Instance.GetInfoAdmin(idaccount);
        }
        public void updateInfoadmin(string MaAD, string idtaikhoan, string TenAD, string DiaChi, string email, DateTime NgaySinh, string phone)
        {
            ADMINDAO.Instance.UpdateInfoadmin(MaAD, idtaikhoan, TenAD, DiaChi, email,NgaySinh, phone);
        }
        public void RemoveInfoAD(string MaAD)
        {
            ADMINDAO.Instance.RemoveInfoadmin(MaAD);
        }
    }
}

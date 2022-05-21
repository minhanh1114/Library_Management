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
        public List<TTADMINDTO> GetInfoAdmin()
        {
            return ADMINDAO.Instance.GetInfoAdmin();
        }
        public List<ADMIN> GetInfoAdmin1(string iDAccount="")
        {
            return ADMINDAO.Instance.GetInfoAdmin1(iDAccount);
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

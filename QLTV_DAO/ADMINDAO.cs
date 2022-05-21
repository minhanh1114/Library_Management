using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using QLTV_DTO;

namespace QLTV_DAO
{
    public class ADMINDAO
    {
        private static ADMINDAO instance;

        public static ADMINDAO Instance
        {
            get { if (instance == null) instance = new ADMINDAO(); return instance; }
            set => instance = value;
        }
        private ADMINDAO() { }
        public List<TTADMINDTO> GetInfoAdmin()
        {
            List<TTADMINDTO> listad = new List<TTADMINDTO>();
            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {

                    var data = ((from u in db.ADMINs
                                 join n in db.ACCOUNTs on u.IDAccount equals n.IDAccount
                                 select new { u.IDAdmin, u.IDAccount, u.NameAdmin, u.Birthday, u.Address, u.Email, u.NumberPhone, n.PasswordAccount })).ToList();
              
                foreach (var item in data)
                {
                    TTADMINDTO ad = new TTADMINDTO
                    {
                        IDAdmin = item.IDAdmin,
                        IDAccount = item.IDAccount,
                        NameAdmin = item.NameAdmin,
                        Birthday = item.Birthday,
                        Address = item.Address,
                        PasswordAccount=item.PasswordAccount,
                        Email = item.Email,
                        NumberPhone = item.NumberPhone
                    };
                    listad.Add(ad);
                }
            }
            return listad;
        }
        //code 2
        public List<ADMIN> GetInfoAdmin1(string idaccount="")
        {
            List<ADMIN> listad = new List<ADMIN>();
            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                List<ADMIN> list = new List<ADMIN>();
                if (idaccount == "")
                {    list = db.ADMINs.ToList();
                    
                }
                else
                    list = db.ADMINs.Where(p => p.IDAccount == idaccount).Select(p => p).ToList();
                foreach (var item in list)
                {
                    ADMIN ad = new ADMIN
                    {
                        IDAdmin = item.IDAdmin,
                        IDAccount = item.IDAccount,
                        NameAdmin = item.NameAdmin,
                        Birthday = item.Birthday,
                        Address = item.Address,             
                        Email = item.Email,
                        NumberPhone = item.NumberPhone
                    };
                    listad.Add(ad);
                }
            }
            return listad;
        }
        public void UpdateInfoadmin(string MaAD,string idtaikhoan, string TenAD, string DiaChi, string email, DateTime NgaySinh, string phone)
        {
            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                ADMIN dg = db.ADMINs.Find(MaAD);
                dg.IDAccount = idtaikhoan;
                dg.NameAdmin = TenAD;
                dg.Birthday = NgaySinh;
                dg.Address = DiaChi;
                dg.Email = email;
                dg.NumberPhone = phone;
                db.SaveChanges();
            }
        }
        public void RemoveInfoadmin(string MaAD)
        {
            using (QuanLyThuVienEntities db = new QuanLyThuVienEntities())
            {
                ADMIN ad = db.ADMINs.Find(MaAD);
                
                db.ADMINs.Remove(ad);
                db.SaveChanges();
            }
        }
    }
}

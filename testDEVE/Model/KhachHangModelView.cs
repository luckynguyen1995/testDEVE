using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDEVE.Model
{
    class KhachHangModelView
    {
        public IEnumerable<object> DSNV { get; set; }
        public IEnumerable<object> DSNVList { get; set; }

        public dtbbdsDataContext dc = new dtbbdsDataContext();
        public KhachHangModelView()
        {
            this.DSNV = getDSKHView();
            this.DSNVList = getDSKHViewList();
        }
        public IEnumerable<object> getDSKHView()
        {
            return dc.NhanViens.Select(x => new NhanVienView
            {
                nvid = x.nvid,
                tennv = x.tennv,
                diachi = x.diachi,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                email = x.email,
                sdt = x.sdt.Value,
                tuoi = DateTime.Now.Year - x.ngaysinh.Value.Year,
                hinh = x.hinh.ToString() == null ? null : x.hinh.ToArray(),

            }).ToList();
        }

        public IEnumerable<object> getDSKHViewList()
        {
            return dc.NhanViens.Select(x => new NhanVienViewList
            {
                nvid = x.nvid,
                doanhthu = x.doanhthu.Value,
                email = x.email,
                matkhau = x.matkhau,
                gioitinh = x.gioitinh.Value ? "Nam" : "Nữ",
                ngaysinh = x.ngaysinh.Value,
                hinh = x.hinh.ToString() == null ? null : x.hinh.ToArray(),
                tennv = x.tennv,
                sdt = x.sdt.Value,
                diachi = x.diachi,
                taikhoan = x.taikhoan,
                quyen = x.quyen.Value
            }).ToList();
        }

    }
    public class KhachHangView
    {
        private int khid { get; set; }
        private string hoten { get; set; }
        private string diachi { get; set; }
        private string diachitt { get; set; }
        private int cmnd { get; set; }
        private int tuoi { get; set; }
        private int sodienthoai { get; set; }
        private string gioitinh { get; set; }
        private string email { get; set; }
        private string mota { get; set; }
    }
}

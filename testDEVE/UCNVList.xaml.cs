﻿using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for UCNVList.xaml
    /// </summary>
    public partial class UCNVList : UserControl
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        public UCNVList()
        {
            InitializeComponent();
            cbo.Items.Add("Nam");
            cbo.Items.Add("Nữ");
            grid.ItemsSource = new NhanVienModelView().DSNVList;
        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        
        private void tableView_RowUpdated(object sender, RowEventArgs e)
        {
            NhanVienViewList row = (NhanVienViewList)grid.SelectedItem;
            if (row == null) return;
            grid.RefreshData();
            
            foreach(NhanVien i in dc.NhanViens.Where(x => x.nvid == row.nvid)){
                if (i != null)
                {
                    i.tennv = row.tennv;
                    if (row.gioitinh == "Nam")
                        i.gioitinh = true;
                    else i.gioitinh = false;
                    if (row.hinh != null)
                    {
                        i.hinh = ByteImageConverter.ToByteArray(row.hinh);
                    }
                    else i.hinh = null;
                    i.diachi = row.diachi;
                    i.doanhthu = row.doanhthu;
                    i.ngaysinh = row.ngaysinh;
                    i.matkhau = row.matkhau;
                    i.email = row.email;
                    i.sdt = row.sdt;
                    i.quyen = row.quyen;
                    dc.SubmitChanges();
                    MessageBox.Show("Đã cập nhật thành công !");
                }
            }
            grid.ItemsSource = new NhanVienModelView().DSNVList;
        }
        


       

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có đồng ý xóa nhân viên này ?", "Thông Báo", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        NhanVienViewList a = grid.SelectedItem as NhanVienViewList;
                        if (a == null)
                        {
                            MessageBox.Show("Không tồn tại nhân viên !!");
                            return;
                        };
                        foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == a.nvid))
                        {
                            if (i != null)
                            {
                                dc.NhanViens.DeleteOnSubmit(i);
                                dc.SubmitChanges();
                                MessageBox.Show("Xóa nhân viên thành công !");
                                grid.ItemsSource = new NhanVienModelView().DSNVList;
                            }
                            else MessageBox.Show("Không tồn tại nhân viên !!");
                        }
                        break;
                    case MessageBoxResult.No:

                        break;

                }
                
            }
        }
    }
}

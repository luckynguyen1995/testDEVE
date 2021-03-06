﻿using DevExpress.Xpf.Core.Native;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for UCNV.xaml
    /// </summary>
    public partial class UCNV : UserControl
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        public UCNV()
        {
            InitializeComponent();
            gridControl.ItemsSource = new NhanVienModelView().DSNV;
        }

        private void TableView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {

        }

        private void gridControl_SelectionChanged(object sender, DevExpress.Xpf.Grid.GridSelectionChangedEventArgs e)
        {
            NhanVienView nv = gridControl.SelectedItem as NhanVienView;
            if (nv == null) return;
            foreach (NhanVien i in dc.NhanViens.Where(x => x.nvid == nv.nvid))
            {
                if (i != null)
                {
                    lbsdt.Content = i.sdt;
                    lbtennv.Content = i.tennv;
                    lbmail.Content = i.email;
                    lbtdiachi.Content = i.diachi;
                    lbdt.Content = i.doanhthu;
                    lbns.Content = i.ngaysinh;
                    if (i.hinh == null) { image.Source = null; }
                    else {
                        Byte[] byteBLOBData = i.hinh.ToArray();
                        MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                        image.Source = ImageHelper.CreateImageFromStream(stmBLOBData);
                    }
                    

                }
            }
        }

        private void gridControl_Loaded(object sender, RoutedEventArgs e)
        {
           

        }
    }
}

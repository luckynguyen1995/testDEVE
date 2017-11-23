using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testDEVE.Model;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for UCBatDongSan.xaml
    /// </summary>
    public partial class UCBatDongSan : UserControl
    {
        dtbbdsDataContext dc = new dtbbdsDataContext();
        public UCBatDongSan()
        {
            InitializeComponent();
        }

        private void CardView_RowUpdated(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
            BDSView bds = grid.SelectedItem as BDSView;
            MessageBox.Show(bds.tenkh);
            if (bds == null) return;
            foreach (BatDongSan i in dc.BatDongSans.Where(x => x.bdsid == bds.bdsid))
            {
                if (i != null)
                {
                    i.hinhanh = ByteImageConverter.ToByteArray(bds.hinhanh).ToArray();
                    dc.SubmitChanges();
                }
            }
            grid.ItemsSource = new BDSModelView().DSBDS;
        }
    }
}

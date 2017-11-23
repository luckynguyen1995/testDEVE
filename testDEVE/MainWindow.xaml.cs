using System.Windows;

namespace testDEVE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCNVList a = new UCNVList();
        public MainWindow()
        {
            InitializeComponent();
            UCNV nv = new UCNV();
            usnv.Content = nv;
            biNV.IsEnabled = false;
            nbiList.IsEnabled = true;

        }

      

        private void biNV_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            UCNV a = new UCNV();
            usnv.Content = a;
            biNV.IsEnabled = false;
            nbiList.IsEnabled = true;
            biKH.IsEnabled = true;
        }

        private void biKH_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            usnv.Content = null;
            biNV.IsEnabled = true;
            biKH.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = false;
        }

        private void nbiDetail_Click(object sender, System.EventArgs e)
        {
            UCNV a = new UCNV();
            usnv.Content = a;
            biNV.IsEnabled = false;
            nbiDetail.IsEnabled = false;
            nbiList.IsEnabled = true;
        }

        private void nbiList_Click(object sender, System.EventArgs e)
        {
            UCNVList ucList = new UCNVList();
            usnv.Content = ucList;
            nbiList.IsEnabled = false;
            nbiDetail.IsEnabled = true;
            
        }

        private void bithoat_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Close();
        }

        private void bixoa_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            

        }

        private void biBDS_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            UCBatDongSan a = new UCBatDongSan();
            usnv.Content = a;
        }
    }
}

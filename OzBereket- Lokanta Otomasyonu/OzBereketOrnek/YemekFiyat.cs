using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    public partial class YemekFiyat : UserControl
    {
        Genel gnl = new Genel();
        private static YemekFiyat _instance;

        public static YemekFiyat Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = new YemekFiyat();
                }
                return _instance;
            }
        }

        public void YemekFiyatGetir()
        {
            string sorgu = "SELECT yemekadi as [Yemek Fiyat Adı], yemekucret as [Yemeğin Fiyatı] FROM yemekFiyat";
            // as [Yemek Fiyat Adı]
            // as [Yemeğin Fiyatı]

            gnl.veriGetir(sorgu, dtYemekFiyat);
        }

        public YemekFiyat()
        {
            InitializeComponent();

            YemekFiyatGetir();
        }

        private void btnYeniFiyat_Click(object sender, EventArgs e)
        {
            YeniYemekFiyat yyf = new YeniYemekFiyat();
            yyf.Show();
        }
    }
}

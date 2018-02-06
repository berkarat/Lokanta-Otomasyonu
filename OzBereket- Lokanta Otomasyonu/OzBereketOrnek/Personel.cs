using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace OzBereketOrnek
{
    public partial class Personel : UserControl
    {
        Genel gnl = new Genel();
        private static Personel _instance;

        public static Personel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Personel();
                }
                return _instance;
            }
        }

        public void personelGetir()
        {
            SqlConnection conn = new SqlConnection(gnl.baglan);
            conn.Open();
            //string gelir = "";

            string sorgu = "SELECT adi as Adı, soyadi as Soyadı, tcno as TCNo, tel as Telefon, adres as Adres, giristarihi as İşeGiriş, cikistarihi as İştenÇıkış, maas as Maaşı, gorev as Görevi, aciklama as Açıklama FROM personel";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtPersonel.DataSource = dt;
            
            conn.Close();
        }
        public Personel()
        {
            InitializeComponent();
            personelGetir();
            
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            PersonelEkle frmPersonelEkle = new PersonelEkle();
            frmPersonelEkle.Show();
            personelGetir();
        }
    }
}

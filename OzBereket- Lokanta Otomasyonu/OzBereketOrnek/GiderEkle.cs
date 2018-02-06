using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    public partial class GiderEkle : Form
    {
        Genel gnl = new Genel();
        public GiderEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtGiderturu.Text == "" || txtTutar.Text == "")
            {
                MessageBox.Show("Lütfen Gider Adı ve Tutarı Alanlarını Boş Bırakmayın.");
            }
            else
            {
                SqlConnection conn = new SqlConnection(gnl.baglan);
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("INSERT INTO gider(giderturu,tarih,tutar,aciklama) VALUES(@giderturu,@tarih,@tutar,@aciklama)", conn);

                cmd2.Parameters.AddWithValue("@giderturu", txtGiderturu.Text);
                cmd2.Parameters.AddWithValue("@tarih", dtTarih.Value);
                cmd2.Parameters.AddWithValue("@tutar", Math.Round(float.Parse(txtTutar.Text),2));
                cmd2.Parameters.AddWithValue("@aciklama", txtAciklama.Text);

                cmd2.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Kaydedildi");
            }
        }

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}

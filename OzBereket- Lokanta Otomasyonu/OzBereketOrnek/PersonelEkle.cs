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
    public partial class PersonelEkle : Form
    {
        Genel gnl = new Genel();
        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text == "" || txtMaas.Text == "")
            {
                MessageBox.Show("Lütfen Ad ve Maaş Alanlarını Boş Bırakmayın.");
            }
            else
            {
                SqlConnection conn = new SqlConnection(gnl.baglan);
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("INSERT INTO personel(adi,soyadi,tcno,tel,adres,giristarihi,maas,gorev,aciklama) VALUES(@adi,@soyadi,@tcno,@tel,@adres,@giristarihi,@maas,@gorev,@aciklama)", conn);

                cmd2.Parameters.AddWithValue("@adi", txtAdi.Text);
                cmd2.Parameters.AddWithValue("@soyadi", txtSoyadi.Text);
                cmd2.Parameters.AddWithValue("@tcno", txtTc.Text);
                cmd2.Parameters.AddWithValue("@tel", txtTel.Text);
                cmd2.Parameters.AddWithValue("@adres", txtAdres.Text);
                cmd2.Parameters.AddWithValue("@giristarihi", dtIsegiris.Value);
                cmd2.Parameters.AddWithValue("@maas", Math.Round(float.Parse(txtMaas.Text),2));
                cmd2.Parameters.AddWithValue("@gorev", txtGorev.Text);
                cmd2.Parameters.AddWithValue("@aciklama", txtAciklama.Text);

                cmd2.ExecuteNonQuery();

                //Personel prsnl = (Personel)Parent.Vir

                //DataGridView dtv = ((DataGridView)Application.OpenForms["AnaFrm"].Controls["panel2"].Controls["dtPersonel"]);

                ////dtv.Update();
                //dtv.Refresh();

                conn.Close();
                MessageBox.Show("Kaydedildi");
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVeSilme(e);
        }

        private void txtMaas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }
    }
}

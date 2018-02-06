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
    public partial class YeniYemekFiyat : Form
    {
        Genel gnl = new Genel();
        public YeniYemekFiyat()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtYemekAdi.Text == "" || txtYemekUcret.Text == "")
            {
                MessageBox.Show("Lütfen Yemek Adı ve Ücret Alanlarını Boş Bırakmayın.");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(gnl.baglan);
                    conn.Open();

                    string veriGir = "INSERT INTO yemekFiyat(yemekadi, yemekucret) VALUES(@yemekadi, @yemekucret)";

                    SqlCommand cmd = new SqlCommand(veriGir, conn);

                    cmd.Parameters.AddWithValue("@yemekadi", txtYemekAdi.Text);
                    cmd.Parameters.AddWithValue("@yemekucret", Math.Round(float.Parse(txtYemekUcret.Text),2));

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Kayıt Yapıldı.");
                }

                catch (Exception ex)
                {
                    lblSonuc.Text = ex.Message;
                }
            }
        }

        private void txtYemekUcret_KeyPress(object sender, KeyPressEventArgs e)
        {
            Genel gnl = new Genel();
            gnl.SadeceRakamVirgulVeSilme(e);
        }

        private void txtYemekAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            gnl.VirgulYasak(e);
        }
    }
}

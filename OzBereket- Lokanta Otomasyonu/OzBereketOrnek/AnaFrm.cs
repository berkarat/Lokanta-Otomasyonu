using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OzBereketOrnek
{
    public partial class AnaFrm : Form
    {
        Firmalar frmlr = new Firmalar();
        Kasa ks = new Kasa();
        FirmaDetay fd = new FirmaDetay();
        CekSenet cs = new CekSenet();
        public AnaFrm()
        {
            InitializeComponent();

            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();

            //anaPanel.ResumeLayout(false);

            frmlr.Dispose();
            ks.Dispose();

            if (!anaPanel.Controls.Contains(Kasa.Instance))
            {
                anaPanel.Controls.Add(Kasa.Instance);
                Kasa.Instance.Dock = DockStyle.Fill;
                Kasa.Instance.BringToFront();
                
                
                             
            }
            else
            {
                Kasa.Instance.BringToFront();
                frmlr.Dispose();
                
            }
        }
 

        private void btnFirmalar_Click(object sender, EventArgs e)
        {

            //frmlr.Yenile();

            //frmlr.Update();

            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();
            //anaPanel.ResumeLayout(false);


            //ks.Dispose();
            //fd.Dispose();
            //if (frmlr.dataGridView1.DataSource != null)
           // {
               // frmlr.dataGridView1.DataSource = null;
                frmlr.FirmaGoser();
            //}


            if (!anaPanel.Controls.Contains(Firmalar.Instance))
            {
                anaPanel.Controls.Add(Firmalar.Instance);
                Firmalar.Instance.Dock = DockStyle.Fill;
                Firmalar.Instance.BringToFront();
                //frmlr.Refresh();

                
            }
            else
            {
                Firmalar.Instance.BringToFront();
                
                frmlr.Show();
            }
            
        }

        private void btnFirmaDetay_Click(object sender, EventArgs e)
        {
            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();
            //anaPanel.ResumeLayout(false);


            // frmlr.Dispose();
            // ks.Dispose();

            fd.FirmaAdiGetir();

            
            if (!anaPanel.Controls.Contains(FirmaDetay.Instance))
            {
                anaPanel.Controls.Add(FirmaDetay.Instance);
                FirmaDetay.Instance.Dock = DockStyle.Fill;
                FirmaDetay.Instance.BringToFront();
                fd.Show();
            }
            else
            {
                FirmaDetay.Instance.BringToFront();
                fd.Show();
            }
        }

       

        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            if (!anaPanel.Controls.Contains(Tahsilat.Instance))
            {
                anaPanel.Controls.Add(Tahsilat.Instance);
                Tahsilat.Instance.Dock = DockStyle.Fill;
                Tahsilat.Instance.BringToFront();
            }
            else
            {
                Tahsilat.Instance.BringToFront();
            }
        }

        private void btnCekSenet_Click(object sender, EventArgs e)
        {
            cs.dtCek.DataSource = null;
            cs.dtSenet.DataSource = null;
            cs.CekGetir();
            cs.SenetGetir();
            if(!anaPanel.Controls.Contains(CekSenet.Instance))
            {
                anaPanel.Controls.Add(CekSenet.Instance);
                CekSenet.Instance.Dock = DockStyle.Fill;
                CekSenet.Instance.BringToFront();
            }
            else
            {
                CekSenet.Instance.BringToFront();
            }
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            if(!anaPanel.Controls.Contains(Personel.Instance))
            {
                anaPanel.Controls.Add(Personel.Instance);
                Personel.Instance.Dock = DockStyle.Fill;
                Personel.Instance.BringToFront();
            }
            else
            {
                Personel.Instance.BringToFront();
            }
        }

        private void btnGider_Click(object sender, EventArgs e)
        {
            if(!anaPanel.Controls.Contains(Gider.Instance))
            {
                anaPanel.Controls.Add(Gider.Instance);
                Gider.Instance.Dock = DockStyle.Fill;
                Gider.Instance.BringToFront();
            }
            else
            {
                Gider.Instance.BringToFront();
            }
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            if (!anaPanel.Controls.Contains(Raporlar.Instance))
            {
                anaPanel.Controls.Add(Raporlar.Instance);
                Raporlar.Instance.Dock = DockStyle.Fill;
                Raporlar.Instance.BringToFront();
            }
            else
            {
                Raporlar.Instance.BringToFront();
            }
        }

        private void btnKasa_Click(object sender, EventArgs e)
        {
            if (!anaPanel.Controls.Contains(Kasa.Instance))
            {
                anaPanel.Controls.Add(Kasa.Instance);
                Kasa.Instance.Dock = DockStyle.Fill;
                Kasa.Instance.BringToFront();
            }
            else
            {
                Kasa.Instance.BringToFront();
            }
        }

        

        private void btnKasa_MouseDown(object sender, MouseEventArgs e)
        {
            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();
            //anaPanel.ResumeLayout(false);

            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Bold);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = tColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnFirmalar_MouseDown(object sender, MouseEventArgs e)
        {
            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();
            //anaPanel.ResumeLayout(false);

            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Bold);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = tColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnFirmaDetay_MouseDown(object sender, MouseEventArgs e)
        {
            //anaPanel.Controls.Clear();
            //anaPanel.SuspendLayout();
            //anaPanel.ResumeLayout(false);

            FirmaDetay fd = new FirmaDetay();
            fd.Update();
            fd.Refresh();
            fd.Show();

            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Bold);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = tColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnTahsilat_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Bold);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = tColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnCekSenet_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Bold);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = tColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnPersonel_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Bold);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = tColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnGider_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Bold);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = tColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnRaporlar_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Bold);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = tColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = nColor;
        }

        private void btnYemekFiyat_Click(object sender, EventArgs e)
        {
            if (!anaPanel.Controls.Contains(YemekFiyat.Instance))
            {
                anaPanel.Controls.Add(YemekFiyat.Instance);
                YemekFiyat.Instance.Dock = DockStyle.Fill;
                YemekFiyat.Instance.BringToFront();
            }
            else
            {
                YemekFiyat.Instance.BringToFront();
            }
        }

        private void btnYemekFiyat_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Bold);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Regular);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = tColor;
            btnFatura.BackColor = nColor;
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            if(!anaPanel.Controls.Contains(Faturalar.Instance))
            {
                anaPanel.Controls.Add(Faturalar.Instance);
                Faturalar.Instance.Dock = DockStyle.Fill;
                Faturalar.Instance.BringToFront();
            }
            else
            {
                Faturalar.Instance.BringToFront();
            }
            Faturalar ftrlr = new Faturalar();
        }

        private void btnFatura_MouseDown(object sender, MouseEventArgs e)
        {
            string tikliRenk = "#1B5E20";
            string normalRenk = "#388E3C";

            Color tColor = System.Drawing.ColorTranslator.FromHtml(tikliRenk);
            Color nColor = System.Drawing.ColorTranslator.FromHtml(normalRenk);

            btnKasa.Font = new Font(btnKasa.Font, FontStyle.Regular);
            btnFirmalar.Font = new Font(btnFirmalar.Font, FontStyle.Regular);
            btnFirmaDetay.Font = new Font(btnFirmaDetay.Font, FontStyle.Regular);
            btnTahsilat.Font = new Font(btnTahsilat.Font, FontStyle.Regular);
            btnCekSenet.Font = new Font(btnCekSenet.Font, FontStyle.Regular);
            btnPersonel.Font = new Font(btnPersonel.Font, FontStyle.Regular);
            btnGider.Font = new Font(btnGider.Font, FontStyle.Regular);
            btnRaporlar.Font = new Font(btnRaporlar.Font, FontStyle.Regular);
            btnYemekFiyat.Font = new Font(btnYemekFiyat.Font, FontStyle.Regular);
            btnFatura.Font = new Font(btnFatura.Font, FontStyle.Bold);

            btnKasa.BackColor = nColor;
            btnFirmalar.BackColor = nColor;
            btnFirmaDetay.BackColor = nColor;
            btnTahsilat.BackColor = nColor;
            btnCekSenet.BackColor = nColor;
            btnPersonel.BackColor = nColor;
            btnGider.BackColor = nColor;
            btnRaporlar.BackColor = nColor;
            btnYemekFiyat.BackColor = nColor;
            btnFatura.BackColor = tColor;
        }
    }
}

namespace OzBereketOrnek
{
    partial class FaturaEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGuncelle = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.txtFaturaTutar = new System.Windows.Forms.TextBox();
            this.lblOncekiBorcu = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFirmaAdi = new System.Windows.Forms.ComboBox();
            this.dtFaturaTarih = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblGuncelle
            // 
            this.lblGuncelle.AutoSize = true;
            this.lblGuncelle.Location = new System.Drawing.Point(36, 289);
            this.lblGuncelle.Name = "lblGuncelle";
            this.lblGuncelle.Size = new System.Drawing.Size(13, 13);
            this.lblGuncelle.TabIndex = 63;
            this.lblGuncelle.Text = "g";
            this.lblGuncelle.Visible = false;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(99, 289);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(15, 13);
            this.lblid.TabIndex = 62;
            this.lblid.Text = "id";
            this.lblid.Visible = false;
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Location = new System.Drawing.Point(201, 263);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 61;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = false;
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.LimeGreen;
            this.btnIptal.FlatAppearance.BorderSize = 0;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Location = new System.Drawing.Point(120, 263);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 60;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.LimeGreen;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Location = new System.Drawing.Point(39, 263);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(75, 23);
            this.btnKaydet.TabIndex = 52;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(92, 138);
            this.txtAciklama.Multiline = true;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(155, 92);
            this.txtAciklama.TabIndex = 50;
            // 
            // txtFaturaTutar
            // 
            this.txtFaturaTutar.Location = new System.Drawing.Point(92, 112);
            this.txtFaturaTutar.Name = "txtFaturaTutar";
            this.txtFaturaTutar.Size = new System.Drawing.Size(155, 20);
            this.txtFaturaTutar.TabIndex = 46;
            this.txtFaturaTutar.Text = "0";
            this.txtFaturaTutar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFaturaTutar_KeyPress);
            // 
            // lblOncekiBorcu
            // 
            this.lblOncekiBorcu.AutoSize = true;
            this.lblOncekiBorcu.Location = new System.Drawing.Point(54, 112);
            this.lblOncekiBorcu.Name = "lblOncekiBorcu";
            this.lblOncekiBorcu.Size = new System.Drawing.Size(32, 13);
            this.lblOncekiBorcu.TabIndex = 56;
            this.lblOncekiBorcu.Text = "Tutar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Açıklama";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tarih";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Firma Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(88, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 24);
            this.label1.TabIndex = 41;
            // 
            // cbFirmaAdi
            // 
            this.cbFirmaAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFirmaAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFirmaAdi.FormattingEnabled = true;
            this.cbFirmaAdi.Location = new System.Drawing.Point(92, 57);
            this.cbFirmaAdi.Name = "cbFirmaAdi";
            this.cbFirmaAdi.Size = new System.Drawing.Size(155, 21);
            this.cbFirmaAdi.TabIndex = 64;
            // 
            // dtFaturaTarih
            // 
            this.dtFaturaTarih.Location = new System.Drawing.Point(92, 84);
            this.dtFaturaTarih.Name = "dtFaturaTarih";
            this.dtFaturaTarih.Size = new System.Drawing.Size(155, 20);
            this.dtFaturaTarih.TabIndex = 65;
            // 
            // FaturaEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(187)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(327, 332);
            this.Controls.Add(this.dtFaturaTarih);
            this.Controls.Add(this.cbFirmaAdi);
            this.Controls.Add(this.lblGuncelle);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtFaturaTutar);
            this.Controls.Add(this.lblOncekiBorcu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FaturaEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FaturaEkle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblGuncelle;
        public System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Button btnKaydet;
        public System.Windows.Forms.TextBox txtAciklama;
        public System.Windows.Forms.TextBox txtFaturaTutar;
        public System.Windows.Forms.Label lblOncekiBorcu;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFirmaAdi;
        private System.Windows.Forms.DateTimePicker dtFaturaTarih;
    }
}
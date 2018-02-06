namespace OzBereketOrnek
{
    partial class FirmaDetay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFirmaAdi = new System.Windows.Forms.ComboBox();
            this.btnFisGetirmeyen = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblToplamKisi = new System.Windows.Forms.Label();
            this.lblToplamTutar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtTarih1 = new System.Windows.Forms.DateTimePicker();
            this.dtTarih2 = new System.Windows.Forms.DateTimePicker();
            this.btnSuz = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbFirmaAdi);
            this.panel3.Controls.Add(this.btnSil);
            this.panel3.Controls.Add(this.btnFisGetirmeyen);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1074, 59);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Firmalar";
            // 
            // cbFirmaAdi
            // 
            this.cbFirmaAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbFirmaAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFirmaAdi.FormattingEnabled = true;
            this.cbFirmaAdi.Location = new System.Drawing.Point(119, 21);
            this.cbFirmaAdi.Name = "cbFirmaAdi";
            this.cbFirmaAdi.Size = new System.Drawing.Size(138, 21);
            this.cbFirmaAdi.TabIndex = 1;
            this.cbFirmaAdi.SelectedIndexChanged += new System.EventHandler(this.cbFirmaAdi_SelectedIndexChanged);
            // 
            // btnFisGetirmeyen
            // 
            this.btnFisGetirmeyen.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFisGetirmeyen.FlatAppearance.BorderSize = 0;
            this.btnFisGetirmeyen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFisGetirmeyen.Location = new System.Drawing.Point(387, 3);
            this.btnFisGetirmeyen.Name = "btnFisGetirmeyen";
            this.btnFisGetirmeyen.Size = new System.Drawing.Size(95, 53);
            this.btnFisGetirmeyen.TabIndex = 0;
            this.btnFisGetirmeyen.Text = "Fiş Getirmeyen";
            this.btnFisGetirmeyen.UseVisualStyleBackColor = false;
            this.btnFisGetirmeyen.Click += new System.EventHandler(this.btnFisGetirmeyen_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(286, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Günlük Fiş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 489);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSil.FlatAppearance.BorderSize = 0;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Location = new System.Drawing.Point(488, 3);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(95, 53);
            this.btnSil.TabIndex = 0;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblToplamKisi
            // 
            this.lblToplamKisi.AutoSize = true;
            this.lblToplamKisi.BackColor = System.Drawing.Color.GhostWhite;
            this.lblToplamKisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblToplamKisi.Location = new System.Drawing.Point(319, 536);
            this.lblToplamKisi.Name = "lblToplamKisi";
            this.lblToplamKisi.Size = new System.Drawing.Size(100, 13);
            this.lblToplamKisi.TabIndex = 8;
            this.lblToplamKisi.Text = "dgjhfghnmfghnmfgh";
            // 
            // lblToplamTutar
            // 
            this.lblToplamTutar.AutoSize = true;
            this.lblToplamTutar.BackColor = System.Drawing.Color.GhostWhite;
            this.lblToplamTutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblToplamTutar.Location = new System.Drawing.Point(744, 536);
            this.lblToplamTutar.Name = "lblToplamTutar";
            this.lblToplamTutar.Size = new System.Drawing.Size(100, 13);
            this.lblToplamTutar.TabIndex = 8;
            this.lblToplamTutar.Text = "dgjhfghnmfghnmfgh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtTarih2);
            this.groupBox1.Controls.Add(this.dtTarih1);
            this.groupBox1.Controls.Add(this.btnSuz);
            this.groupBox1.Location = new System.Drawing.Point(722, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 52);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aralık Seç";
            // 
            // dtTarih1
            // 
            this.dtTarih1.Location = new System.Drawing.Point(6, 19);
            this.dtTarih1.Name = "dtTarih1";
            this.dtTarih1.Size = new System.Drawing.Size(112, 20);
            this.dtTarih1.TabIndex = 0;
            // 
            // dtTarih2
            // 
            this.dtTarih2.Location = new System.Drawing.Point(124, 19);
            this.dtTarih2.Name = "dtTarih2";
            this.dtTarih2.Size = new System.Drawing.Size(108, 20);
            this.dtTarih2.TabIndex = 1;
            // 
            // btnSuz
            // 
            this.btnSuz.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSuz.FlatAppearance.BorderSize = 0;
            this.btnSuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuz.Location = new System.Drawing.Point(238, 15);
            this.btnSuz.Name = "btnSuz";
            this.btnSuz.Size = new System.Drawing.Size(95, 30);
            this.btnSuz.TabIndex = 0;
            this.btnSuz.Text = "Süz";
            this.btnSuz.UseVisualStyleBackColor = false;
            this.btnSuz.Click += new System.EventHandler(this.btnSuz_Click);
            // 
            // FirmaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.Controls.Add(this.lblToplamTutar);
            this.Controls.Add(this.lblToplamKisi);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Name = "FirmaDetay";
            this.Size = new System.Drawing.Size(1080, 557);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFisGetirmeyen;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox cbFirmaAdi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblToplamKisi;
        private System.Windows.Forms.Label lblToplamTutar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTarih2;
        private System.Windows.Forms.DateTimePicker dtTarih1;
        private System.Windows.Forms.Button btnSuz;
    }
}

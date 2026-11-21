
namespace SIMRS
{
    partial class FrmPembayaran
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
            this.cmbPendaftaran = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbMetode = new System.Windows.Forms.ComboBox();
            this.txtPoli = new System.Windows.Forms.TextBox();
            this.txtNoPembayaran = new System.Windows.Forms.TextBox();
            this.txtPasien = new System.Windows.Forms.TextBox();
            this.txtDokter = new System.Windows.Forms.TextBox();
            this.txtBiayaObat = new System.Windows.Forms.TextBox();
            this.txtBiayaKonsultasi = new System.Windows.Forms.TextBox();
            this.txtBiayaLainnya = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.dtpTanggalPembayaran = new System.Windows.Forms.DateTimePicker();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPendaftaran
            // 
            this.cmbPendaftaran.FormattingEnabled = true;
            this.cmbPendaftaran.Location = new System.Drawing.Point(292, 100);
            this.cmbPendaftaran.Name = "cmbPendaftaran";
            this.cmbPendaftaran.Size = new System.Drawing.Size(121, 21);
            this.cmbPendaftaran.TabIndex = 0;
            this.cmbPendaftaran.SelectedIndexChanged += new System.EventHandler(this.cmbPendaftaran_SelectedIndexChanged_1);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(291, 365);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 3;
            // 
            // cmbMetode
            // 
            this.cmbMetode.FormattingEnabled = true;
            this.cmbMetode.Location = new System.Drawing.Point(292, 341);
            this.cmbMetode.Name = "cmbMetode";
            this.cmbMetode.Size = new System.Drawing.Size(121, 21);
            this.cmbMetode.TabIndex = 4;
            // 
            // txtPoli
            // 
            this.txtPoli.Location = new System.Drawing.Point(291, 153);
            this.txtPoli.Name = "txtPoli";
            this.txtPoli.Size = new System.Drawing.Size(107, 20);
            this.txtPoli.TabIndex = 5;
            // 
            // txtNoPembayaran
            // 
            this.txtNoPembayaran.Location = new System.Drawing.Point(291, 74);
            this.txtNoPembayaran.Name = "txtNoPembayaran";
            this.txtNoPembayaran.Size = new System.Drawing.Size(100, 20);
            this.txtNoPembayaran.TabIndex = 6;
            // 
            // txtPasien
            // 
            this.txtPasien.Location = new System.Drawing.Point(292, 127);
            this.txtPasien.Name = "txtPasien";
            this.txtPasien.Size = new System.Drawing.Size(100, 20);
            this.txtPasien.TabIndex = 7;
            // 
            // txtDokter
            // 
            this.txtDokter.Location = new System.Drawing.Point(292, 179);
            this.txtDokter.Name = "txtDokter";
            this.txtDokter.Size = new System.Drawing.Size(100, 20);
            this.txtDokter.TabIndex = 8;
            // 
            // txtBiayaObat
            // 
            this.txtBiayaObat.Location = new System.Drawing.Point(291, 263);
            this.txtBiayaObat.Name = "txtBiayaObat";
            this.txtBiayaObat.Size = new System.Drawing.Size(100, 20);
            this.txtBiayaObat.TabIndex = 9;
            this.txtBiayaObat.TextChanged += new System.EventHandler(this.txtBiayaObat_TextChanged);
            // 
            // txtBiayaKonsultasi
            // 
            this.txtBiayaKonsultasi.Location = new System.Drawing.Point(293, 237);
            this.txtBiayaKonsultasi.Name = "txtBiayaKonsultasi";
            this.txtBiayaKonsultasi.Size = new System.Drawing.Size(100, 20);
            this.txtBiayaKonsultasi.TabIndex = 10;
            this.txtBiayaKonsultasi.TextChanged += new System.EventHandler(this.txtBiayaKonsultasi_TextChanged);
            // 
            // txtBiayaLainnya
            // 
            this.txtBiayaLainnya.Location = new System.Drawing.Point(292, 289);
            this.txtBiayaLainnya.Name = "txtBiayaLainnya";
            this.txtBiayaLainnya.Size = new System.Drawing.Size(100, 20);
            this.txtBiayaLainnya.TabIndex = 11;
            this.txtBiayaLainnya.TextChanged += new System.EventHandler(this.txtBiayaLainnya_TextChanged);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(293, 315);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 12;
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Location = new System.Drawing.Point(178, 503);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.Size = new System.Drawing.Size(457, 188);
            this.dgvPembayaran.TabIndex = 13;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(457, 442);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 39;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(358, 442);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 38;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(263, 442);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 37;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(457, 403);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 36;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(365, 403);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 35;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(263, 403);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 34;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // dtpTanggalPembayaran
            // 
            this.dtpTanggalPembayaran.Location = new System.Drawing.Point(293, 205);
            this.dtpTanggalPembayaran.Name = "dtpTanggalPembayaran";
            this.dtpTanggalPembayaran.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalPembayaran.TabIndex = 40;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(247, 477);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(107, 20);
            this.txtCari.TabIndex = 50;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Cari Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Pendaftaran  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Status Pembayaran";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "TOTAL BIAYA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Poli               ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Dokter";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(180, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Metode Pembayaran";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.label7.TabIndex = 57;
            this.label7.Text = "Tanggal Pembayaran ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Biaya Konsultasi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Biaya Lainnya";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Biaya Obat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(216, 127);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 61;
            this.label12.Text = "Pasien";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(199, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 62;
            this.label13.Text = "No. Pembayaran";
            // 
            // FrmPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 705);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtpTanggalPembayaran);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.dgvPembayaran);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtBiayaLainnya);
            this.Controls.Add(this.txtBiayaKonsultasi);
            this.Controls.Add(this.txtBiayaObat);
            this.Controls.Add(this.txtDokter);
            this.Controls.Add(this.txtPasien);
            this.Controls.Add(this.txtNoPembayaran);
            this.Controls.Add(this.txtPoli);
            this.Controls.Add(this.cmbMetode);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbPendaftaran);
            this.Name = "FrmPembayaran";
            this.Text = "x";
            this.Load += new System.EventHandler(this.FrmPembayaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPendaftaran;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbMetode;
        private System.Windows.Forms.TextBox txtPoli;
        private System.Windows.Forms.TextBox txtNoPembayaran;
        private System.Windows.Forms.TextBox txtPasien;
        private System.Windows.Forms.TextBox txtDokter;
        private System.Windows.Forms.TextBox txtBiayaObat;
        private System.Windows.Forms.TextBox txtBiayaKonsultasi;
        private System.Windows.Forms.TextBox txtBiayaLainnya;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.DateTimePicker dtpTanggalPembayaran;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
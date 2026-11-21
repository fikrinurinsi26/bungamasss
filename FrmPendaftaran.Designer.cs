
namespace SIMRS
{
    partial class FrmPendaftaran
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
            this.txtNoDaftar = new System.Windows.Forms.TextBox();
            this.txtKeluhan = new System.Windows.Forms.TextBox();
            this.cmbPasien = new System.Windows.Forms.ComboBox();
            this.cmbPoli = new System.Windows.Forms.ComboBox();
            this.cmbDokter = new System.Windows.Forms.ComboBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvPendaftaran = new System.Windows.Forms.DataGridView();
            this.NoPendaftaran = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTanggalKunjungan = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendaftaran)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoDaftar
            // 
            this.txtNoDaftar.Location = new System.Drawing.Point(149, 52);
            this.txtNoDaftar.Name = "txtNoDaftar";
            this.txtNoDaftar.Size = new System.Drawing.Size(107, 20);
            this.txtNoDaftar.TabIndex = 21;
            // 
            // txtKeluhan
            // 
            this.txtKeluhan.Location = new System.Drawing.Point(149, 185);
            this.txtKeluhan.Name = "txtKeluhan";
            this.txtKeluhan.Size = new System.Drawing.Size(107, 20);
            this.txtKeluhan.TabIndex = 22;
            // 
            // cmbPasien
            // 
            this.cmbPasien.FormattingEnabled = true;
            this.cmbPasien.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbPasien.Location = new System.Drawing.Point(149, 104);
            this.cmbPasien.Name = "cmbPasien";
            this.cmbPasien.Size = new System.Drawing.Size(107, 21);
            this.cmbPasien.TabIndex = 23;
            // 
            // cmbPoli
            // 
            this.cmbPoli.FormattingEnabled = true;
            this.cmbPoli.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbPoli.Location = new System.Drawing.Point(149, 131);
            this.cmbPoli.Name = "cmbPoli";
            this.cmbPoli.Size = new System.Drawing.Size(107, 21);
            this.cmbPoli.TabIndex = 24;
            // 
            // cmbDokter
            // 
            this.cmbDokter.FormattingEnabled = true;
            this.cmbDokter.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbDokter.Location = new System.Drawing.Point(149, 158);
            this.cmbDokter.Name = "cmbDokter";
            this.cmbDokter.Size = new System.Drawing.Size(107, 21);
            this.cmbDokter.TabIndex = 25;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(149, 78);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggal.TabIndex = 26;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatus.Location = new System.Drawing.Point(149, 211);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(107, 21);
            this.cmbStatus.TabIndex = 27;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(661, 81);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 33;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(562, 81);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 32;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(467, 81);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 31;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(661, 42);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 30;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(569, 42);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 29;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(467, 42);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 28;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(562, 219);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(107, 20);
            this.txtCari.TabIndex = 48;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(559, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Cari Data";
            // 
            // dgvPendaftaran
            // 
            this.dgvPendaftaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendaftaran.Location = new System.Drawing.Point(-7, 331);
            this.dgvPendaftaran.Name = "dgvPendaftaran";
            this.dgvPendaftaran.Size = new System.Drawing.Size(807, 128);
            this.dgvPendaftaran.TabIndex = 49;
            this.dgvPendaftaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPendaftaran_CellClick);
            // 
            // NoPendaftaran
            // 
            this.NoPendaftaran.AutoSize = true;
            this.NoPendaftaran.Location = new System.Drawing.Point(60, 55);
            this.NoPendaftaran.Name = "NoPendaftaran";
            this.NoPendaftaran.Size = new System.Drawing.Size(85, 13);
            this.NoPendaftaran.TabIndex = 50;
            this.NoPendaftaran.Text = "No. Pendaftaran";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Tanggal Daftar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Pasien";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Poli Tujuan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Dokter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Keluhan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 56;
            this.label7.Text = "Status";
            // 
            // dtpTanggalKunjungan
            // 
            this.dtpTanggalKunjungan.Location = new System.Drawing.Point(149, 238);
            this.dtpTanggalKunjungan.Name = "dtpTanggalKunjungan";
            this.dtpTanggalKunjungan.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalKunjungan.TabIndex = 57;
            // 
            // FrmPendaftaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpTanggalKunjungan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NoPendaftaran);
            this.Controls.Add(this.dgvPendaftaran);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.cmbDokter);
            this.Controls.Add(this.cmbPoli);
            this.Controls.Add(this.cmbPasien);
            this.Controls.Add(this.txtKeluhan);
            this.Controls.Add(this.txtNoDaftar);
            this.Name = "FrmPendaftaran";
            this.Text = "FrmPendaftaran";
            this.Load += new System.EventHandler(this.FrmPendaftaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendaftaran)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoDaftar;
        private System.Windows.Forms.TextBox txtKeluhan;
        private System.Windows.Forms.ComboBox cmbPasien;
        private System.Windows.Forms.ComboBox cmbPoli;
        private System.Windows.Forms.ComboBox cmbDokter;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvPendaftaran;
        private System.Windows.Forms.Label NoPendaftaran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTanggalKunjungan;
    }
}
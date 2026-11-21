
namespace SIMRS
{
    partial class FrmPasien
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
            this.txtTempatLahir = new System.Windows.Forms.TextBox();
            this.txtNamaPasien = new System.Windows.Forms.TextBox();
            this.txtNIK = new System.Windows.Forms.TextBox();
            this.txtKodePasien = new System.Windows.Forms.TextBox();
            this.cmbJenisKelamin = new System.Windows.Forms.ComboBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoHP = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbGolonganDarah = new System.Windows.Forms.ComboBox();
            this.dtpTanggalLahir = new System.Windows.Forms.DateTimePicker();
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
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.dgvPasien = new System.Windows.Forms.DataGridView();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStatusPernikahan = new System.Windows.Forms.ComboBox();
            this.cmbAgama = new System.Windows.Forms.ComboBox();
            this.txtPekerjaan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasien)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTempatLahir
            // 
            this.txtTempatLahir.Location = new System.Drawing.Point(109, 133);
            this.txtTempatLahir.Name = "txtTempatLahir";
            this.txtTempatLahir.Size = new System.Drawing.Size(107, 20);
            this.txtTempatLahir.TabIndex = 18;
            // 
            // txtNamaPasien
            // 
            this.txtNamaPasien.Location = new System.Drawing.Point(109, 65);
            this.txtNamaPasien.Name = "txtNamaPasien";
            this.txtNamaPasien.Size = new System.Drawing.Size(107, 20);
            this.txtNamaPasien.TabIndex = 19;
            // 
            // txtNIK
            // 
            this.txtNIK.Location = new System.Drawing.Point(109, 39);
            this.txtNIK.Name = "txtNIK";
            this.txtNIK.Size = new System.Drawing.Size(107, 20);
            this.txtNIK.TabIndex = 20;
            // 
            // txtKodePasien
            // 
            this.txtKodePasien.Location = new System.Drawing.Point(109, 13);
            this.txtKodePasien.Name = "txtKodePasien";
            this.txtKodePasien.Size = new System.Drawing.Size(107, 20);
            this.txtKodePasien.TabIndex = 21;
            // 
            // cmbJenisKelamin
            // 
            this.cmbJenisKelamin.FormattingEnabled = true;
            this.cmbJenisKelamin.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbJenisKelamin.Location = new System.Drawing.Point(109, 106);
            this.cmbJenisKelamin.Name = "cmbJenisKelamin";
            this.cmbJenisKelamin.Size = new System.Drawing.Size(107, 21);
            this.cmbJenisKelamin.TabIndex = 23;
            // 
            // txtAlamat
            // 
            this.txtAlamat.Location = new System.Drawing.Point(109, 188);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(107, 20);
            this.txtAlamat.TabIndex = 22;
            // 
            // txtNoHP
            // 
            this.txtNoHP.Location = new System.Drawing.Point(109, 224);
            this.txtNoHP.Name = "txtNoHP";
            this.txtNoHP.Size = new System.Drawing.Size(107, 20);
            this.txtNoHP.TabIndex = 24;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatus.Location = new System.Drawing.Point(109, 277);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(107, 21);
            this.cmbStatus.TabIndex = 25;
            // 
            // cmbGolonganDarah
            // 
            this.cmbGolonganDarah.FormattingEnabled = true;
            this.cmbGolonganDarah.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbGolonganDarah.Location = new System.Drawing.Point(109, 250);
            this.cmbGolonganDarah.Name = "cmbGolonganDarah";
            this.cmbGolonganDarah.Size = new System.Drawing.Size(107, 21);
            this.cmbGolonganDarah.TabIndex = 26;
            // 
            // dtpTanggalLahir
            // 
            this.dtpTanggalLahir.Location = new System.Drawing.Point(109, 162);
            this.dtpTanggalLahir.Name = "dtpTanggalLahir";
            this.dtpTanggalLahir.Size = new System.Drawing.Size(350, 20);
            this.dtpTanggalLahir.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Kode Pasien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Jenis Kelamin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Nama Lengkap";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Golongan Darah";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Tempat Lahir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "No HP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Alamat";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Tanggal Lahir";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "NIK";
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(549, 121);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 43;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(457, 121);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 42;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(355, 121);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 41;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(549, 82);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 40;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(457, 82);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 39;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(355, 82);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 38;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // dgvPasien
            // 
            this.dgvPasien.AllowUserToAddRows = false;
            this.dgvPasien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPasien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasien.Location = new System.Drawing.Point(222, 263);
            this.dgvPasien.MultiSelect = false;
            this.dgvPasien.Name = "dgvPasien";
            this.dgvPasien.ReadOnly = true;
            this.dgvPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasien.Size = new System.Drawing.Size(1011, 186);
            this.dgvPasien.TabIndex = 44;
            this.dgvPasien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasien_CellClick);
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(582, 211);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(107, 20);
            this.txtCari.TabIndex = 46;
            this.txtCari.TextChanged += new System.EventHandler(this.txtCari_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(579, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Cari Data";
            // 
            // cmbStatusPernikahan
            // 
            this.cmbStatusPernikahan.FormattingEnabled = true;
            this.cmbStatusPernikahan.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbStatusPernikahan.Location = new System.Drawing.Point(109, 341);
            this.cmbStatusPernikahan.Name = "cmbStatusPernikahan";
            this.cmbStatusPernikahan.Size = new System.Drawing.Size(107, 21);
            this.cmbStatusPernikahan.TabIndex = 47;
            // 
            // cmbAgama
            // 
            this.cmbAgama.FormattingEnabled = true;
            this.cmbAgama.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cmbAgama.Location = new System.Drawing.Point(109, 314);
            this.cmbAgama.Name = "cmbAgama";
            this.cmbAgama.Size = new System.Drawing.Size(107, 21);
            this.cmbAgama.TabIndex = 48;
            // 
            // txtPekerjaan
            // 
            this.txtPekerjaan.Location = new System.Drawing.Point(109, 368);
            this.txtPekerjaan.Name = "txtPekerjaan";
            this.txtPekerjaan.Size = new System.Drawing.Size(107, 20);
            this.txtPekerjaan.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 378);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "Pekerjaan";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 344);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Status Pernikahan";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(60, 317);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Agama";
            // 
            // FrmPasien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 461);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPekerjaan);
            this.Controls.Add(this.cmbAgama);
            this.Controls.Add(this.cmbStatusPernikahan);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvPasien);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBaru);
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
            this.Controls.Add(this.dtpTanggalLahir);
            this.Controls.Add(this.cmbGolonganDarah);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtNoHP);
            this.Controls.Add(this.cmbJenisKelamin);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.txtKodePasien);
            this.Controls.Add(this.txtNIK);
            this.Controls.Add(this.txtNamaPasien);
            this.Controls.Add(this.txtTempatLahir);
            this.Name = "FrmPasien";
            this.Text = "FrmPasien";
            this.Load += new System.EventHandler(this.FrmPasien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtTempatLahir;
        private System.Windows.Forms.TextBox txtNamaPasien;
        private System.Windows.Forms.TextBox txtNIK;
        private System.Windows.Forms.TextBox txtKodePasien;
        private System.Windows.Forms.ComboBox cmbJenisKelamin;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoHP;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbGolonganDarah;
        private System.Windows.Forms.DateTimePicker dtpTanggalLahir;
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
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.DataGridView dgvPasien;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStatusPernikahan;
        private System.Windows.Forms.ComboBox cmbAgama;
        private System.Windows.Forms.TextBox txtPekerjaan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}
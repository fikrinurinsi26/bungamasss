
namespace SIMRS
{
    partial class FrmRekamMedis
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
            this.gbIdentitas = new System.Windows.Forms.GroupBox();
            this.cmbDokter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTanggalPemeriksaan = new System.Windows.Forms.DateTimePicker();
            this.cmbPasien = new System.Windows.Forms.ComboBox();
            this.txtIdRekamMedis = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTinggiBadan = new System.Windows.Forms.TextBox();
            this.txtBeratBadan = new System.Windows.Forms.TextBox();
            this.txtSuhuTubuh = new System.Windows.Forms.TextBox();
            this.txtTekananDarah = new System.Windows.Forms.TextBox();
            this.txtKeluhan = new System.Windows.Forms.TextBox();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCatatan = new System.Windows.Forms.TextBox();
            this.txtTindakan = new System.Windows.Forms.TextBox();
            this.btnTutup = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBaru = new System.Windows.Forms.Button();
            this.dgvRekamMedis = new System.Windows.Forms.DataGridView();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.gbIdentitas.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRekamMedis)).BeginInit();
            this.SuspendLayout();
            // 
            // gbIdentitas
            // 
            this.gbIdentitas.Controls.Add(this.cmbDokter);
            this.gbIdentitas.Controls.Add(this.label3);
            this.gbIdentitas.Controls.Add(this.label2);
            this.gbIdentitas.Controls.Add(this.label1);
            this.gbIdentitas.Controls.Add(this.dtpTanggalPemeriksaan);
            this.gbIdentitas.Controls.Add(this.cmbPasien);
            this.gbIdentitas.Controls.Add(this.txtIdRekamMedis);
            this.gbIdentitas.Location = new System.Drawing.Point(25, 12);
            this.gbIdentitas.Name = "gbIdentitas";
            this.gbIdentitas.Size = new System.Drawing.Size(395, 100);
            this.gbIdentitas.TabIndex = 0;
            this.gbIdentitas.TabStop = false;
            this.gbIdentitas.Text = "\tIdentitas Pemeriksaan";
            // 
            // cmbDokter
            // 
            this.cmbDokter.FormattingEnabled = true;
            this.cmbDokter.Location = new System.Drawing.Point(268, 45);
            this.cmbDokter.Name = "cmbDokter";
            this.cmbDokter.Size = new System.Drawing.Size(121, 21);
            this.cmbDokter.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tanggal Pemeriksaan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pasien";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID Rekam Medis";
            // 
            // dtpTanggalPemeriksaan
            // 
            this.dtpTanggalPemeriksaan.Location = new System.Drawing.Point(138, 72);
            this.dtpTanggalPemeriksaan.Name = "dtpTanggalPemeriksaan";
            this.dtpTanggalPemeriksaan.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalPemeriksaan.TabIndex = 2;
            // 
            // cmbPasien
            // 
            this.cmbPasien.FormattingEnabled = true;
            this.cmbPasien.Location = new System.Drawing.Point(80, 45);
            this.cmbPasien.Name = "cmbPasien";
            this.cmbPasien.Size = new System.Drawing.Size(121, 21);
            this.cmbPasien.TabIndex = 1;
            this.cmbPasien.SelectedIndexChanged += new System.EventHandler(this.cmbPasien_SelectedIndexChanged);
            // 
            // txtIdRekamMedis
            // 
            this.txtIdRekamMedis.Location = new System.Drawing.Point(138, 16);
            this.txtIdRekamMedis.Name = "txtIdRekamMedis";
            this.txtIdRekamMedis.Size = new System.Drawing.Size(100, 20);
            this.txtIdRekamMedis.TabIndex = 0;
            this.txtIdRekamMedis.TextChanged += new System.EventHandler(this.txtIdRekamMedis_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTinggiBadan);
            this.groupBox2.Controls.Add(this.txtBeratBadan);
            this.groupBox2.Controls.Add(this.txtSuhuTubuh);
            this.groupBox2.Controls.Add(this.txtTekananDarah);
            this.groupBox2.Controls.Add(this.txtKeluhan);
            this.groupBox2.Controls.Add(this.txtDiagnosis);
            this.groupBox2.Location = new System.Drawing.Point(25, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "\tHasil Pemeriksaan";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(119, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tinggi";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Suhu Tubuh";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Berat Badan";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Diagnosis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tekanan Darah";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Keluhan";
            // 
            // txtTinggiBadan
            // 
            this.txtTinggiBadan.Location = new System.Drawing.Point(217, 150);
            this.txtTinggiBadan.Name = "txtTinggiBadan";
            this.txtTinggiBadan.Size = new System.Drawing.Size(100, 20);
            this.txtTinggiBadan.TabIndex = 6;
            // 
            // txtBeratBadan
            // 
            this.txtBeratBadan.Location = new System.Drawing.Point(217, 122);
            this.txtBeratBadan.Name = "txtBeratBadan";
            this.txtBeratBadan.Size = new System.Drawing.Size(100, 20);
            this.txtBeratBadan.TabIndex = 5;
            // 
            // txtSuhuTubuh
            // 
            this.txtSuhuTubuh.Location = new System.Drawing.Point(217, 98);
            this.txtSuhuTubuh.Name = "txtSuhuTubuh";
            this.txtSuhuTubuh.Size = new System.Drawing.Size(100, 20);
            this.txtSuhuTubuh.TabIndex = 4;
            // 
            // txtTekananDarah
            // 
            this.txtTekananDarah.Location = new System.Drawing.Point(217, 71);
            this.txtTekananDarah.Name = "txtTekananDarah";
            this.txtTekananDarah.Size = new System.Drawing.Size(100, 20);
            this.txtTekananDarah.TabIndex = 3;
            // 
            // txtKeluhan
            // 
            this.txtKeluhan.Location = new System.Drawing.Point(217, 19);
            this.txtKeluhan.Name = "txtKeluhan";
            this.txtKeluhan.Size = new System.Drawing.Size(100, 20);
            this.txtKeluhan.TabIndex = 2;
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.Location = new System.Drawing.Point(217, 45);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.Size = new System.Drawing.Size(100, 20);
            this.txtDiagnosis.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCatatan);
            this.groupBox3.Controls.Add(this.txtTindakan);
            this.groupBox3.Location = new System.Drawing.Point(472, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tindakan dan Catatan";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(105, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Catatan";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(105, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Tindakan";
            // 
            // txtCatatan
            // 
            this.txtCatatan.Location = new System.Drawing.Point(180, 66);
            this.txtCatatan.Name = "txtCatatan";
            this.txtCatatan.Size = new System.Drawing.Size(100, 20);
            this.txtCatatan.TabIndex = 2;
            // 
            // txtTindakan
            // 
            this.txtTindakan.Location = new System.Drawing.Point(180, 40);
            this.txtTindakan.Name = "txtTindakan";
            this.txtTindakan.Size = new System.Drawing.Size(100, 20);
            this.txtTindakan.TabIndex = 1;
            // 
            // btnTutup
            // 
            this.btnTutup.Location = new System.Drawing.Point(672, 223);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 23);
            this.btnTutup.TabIndex = 19;
            this.btnTutup.Text = "Tutup";
            this.btnTutup.UseVisualStyleBackColor = true;
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(580, 223);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 23);
            this.btnBatal.TabIndex = 18;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(478, 223);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 23);
            this.btnHapus.TabIndex = 17;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnUbah
            // 
            this.btnUbah.Location = new System.Drawing.Point(672, 184);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 23);
            this.btnUbah.TabIndex = 16;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(580, 184);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 23);
            this.btnSimpan.TabIndex = 15;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnBaru
            // 
            this.btnBaru.Location = new System.Drawing.Point(478, 184);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 23);
            this.btnBaru.TabIndex = 14;
            this.btnBaru.Text = "Baru";
            this.btnBaru.UseVisualStyleBackColor = true;
            // 
            // dgvRekamMedis
            // 
            this.dgvRekamMedis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRekamMedis.Location = new System.Drawing.Point(1, 327);
            this.dgvRekamMedis.Name = "dgvRekamMedis";
            this.dgvRekamMedis.Size = new System.Drawing.Size(1143, 221);
            this.dgvRekamMedis.TabIndex = 20;
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(540, 140);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(100, 20);
            this.txtCari.TabIndex = 21;
            // 
            // FrmRekamMedis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 560);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.dgvRekamMedis);
            this.Controls.Add(this.btnTutup);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBaru);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbIdentitas);
            this.Name = "FrmRekamMedis";
            this.Text = "FrmRekamMedis";
            this.Load += new System.EventHandler(this.FrmRekamMedis_Load);
            this.gbIdentitas.ResumeLayout(false);
            this.gbIdentitas.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRekamMedis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIdentitas;
        private System.Windows.Forms.DateTimePicker dtpTanggalPemeriksaan;
        private System.Windows.Forms.ComboBox cmbPasien;
        private System.Windows.Forms.TextBox txtIdRekamMedis;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTinggiBadan;
        private System.Windows.Forms.TextBox txtBeratBadan;
        private System.Windows.Forms.TextBox txtSuhuTubuh;
        private System.Windows.Forms.TextBox txtTekananDarah;
        private System.Windows.Forms.TextBox txtKeluhan;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCatatan;
        private System.Windows.Forms.TextBox txtTindakan;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.DataGridView dgvRekamMedis;
        private System.Windows.Forms.ComboBox cmbDokter;
        private System.Windows.Forms.TextBox txtCari;
    }
}
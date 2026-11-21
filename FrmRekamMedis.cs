
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIMRS
{
    public partial class FrmRekamMedis : Form
    {
        private string connectionString =
            "server=localhost;database=db_rumah_sakit;uid=root;pwd=;";

        public FrmRekamMedis()
        {
            InitializeComponent();

            this.Load += FrmRekamMedis_Load;

            btnBaru.Click += btnBaru_Click;
            btnSimpan.Click += btnSimpan_Click;
            btnUbah.Click += btnUbah_Click;
            btnHapus.Click += btnHapus_Click;
            btnBatal.Click += btnBatal_Click;
            btnTutup.Click += btnTutup_Click;

            txtCari.TextChanged += txtCari_TextChanged;
            dgvRekamMedis.CellClick += dgvRekamMedis_CellClick;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // ==============================
        // LOAD FORM
        // ==============================
        private void FrmRekamMedis_Load(object sender, EventArgs e)
        {
            AturForm();
            TampilkanDokter();
            TampilkanPasien();
            TampilkanData();

            BersihkanForm();
            TampilkanIdBerikutnya();
        }

        // ==============================
        // PENGATURAN FORM
        // ==============================
        private void AturForm()
        {
            txtIdRekamMedis.ReadOnly = true;
            txtIdRekamMedis.Enabled = true;

            txtKeluhan.Multiline = true;
            txtDiagnosis.Multiline = true;
            txtTindakan.Multiline = true;
            txtCatatan.Multiline = true;

            dgvRekamMedis.ReadOnly = true;
            dgvRekamMedis.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvRekamMedis.MultiSelect = false;
            dgvRekamMedis.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ==============================
        // ID REKAM MEDIS OTOMATIS
        // ==============================
        private void TampilkanIdBerikutnya()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT COALESCE(MAX(id_rekam_medis), 0) + 1
                        FROM rekam_medis";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        int id = Convert.ToInt32(
                            cmd.ExecuteScalar());

                        txtIdRekamMedis.Text =
                            "RM" + id.ToString("D6");
                    }
                }
            }
            catch (Exception ex)
            {
                txtIdRekamMedis.Clear();

                MessageBox.Show(
                    "Gagal membuat ID Rekam Medis: " + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ==============================
        // MENAMPILKAN DOKTER
        // ==============================
        private void TampilkanDokter()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_dokter, nama_lengkap
                        FROM dokter
                        WHERE status_aktif = 1
                        ORDER BY nama_lengkap ASC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbDokter.DataSource = dt;
                    cmbDokter.DisplayMember = "nama_lengkap";
                    cmbDokter.ValueMember = "id_dokter";
                    cmbDokter.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat dokter: " + ex.Message);
            }
        }

        // ==============================
        // MENAMPILKAN PASIEN
        // ==============================
        private void TampilkanPasien()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            pendaftaran.id_pendaftaran,
                            CONCAT(
                                pasien.nama_lengkap,
                                ' - ',
                                pendaftaran.nomor_pendaftaran
                            ) AS nama_tampilan
                        FROM pendaftaran
                        INNER JOIN pasien
                            ON pendaftaran.id_pasien =
                               pasien.id_pasien
                        ORDER BY pendaftaran.id_pendaftaran DESC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbPasien.DataSource = dt;
                    cmbPasien.DisplayMember = "nama_tampilan";
                    cmbPasien.ValueMember = "id_pendaftaran";
                    cmbPasien.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat pasien: " + ex.Message);
            }
        }

        // ==============================
        // MENAMPILKAN DATA REKAM MEDIS
        // ==============================
        private void TampilkanData()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            rm.id_rekam_medis,
                            rm.id_pendaftaran,
                            rm.id_dokter,
                            pendaftaran.nomor_pendaftaran,
                            pasien.nama_lengkap AS nama_pasien,
                            dokter.nama_lengkap AS nama_dokter,
                            rm.tanggal_pemeriksaan,
                            rm.keluhan,
                            rm.diagnosis,
                            rm.tekanan_darah,
                            rm.suhu_tubuh,
                            rm.berat_badan,
                            rm.tinggi_badan,
                            rm.tindakan,
                            rm.catatan
                        FROM rekam_medis rm
                        INNER JOIN pendaftaran
                            ON rm.id_pendaftaran =
                               pendaftaran.id_pendaftaran
                        INNER JOIN pasien
                            ON pendaftaran.id_pasien =
                               pasien.id_pasien
                        INNER JOIN dokter
                            ON rm.id_dokter = dokter.id_dokter
                        ORDER BY rm.id_rekam_medis DESC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRekamMedis.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan data: " + ex.Message);
            }
        }

        // ==============================
        // VALIDASI DATA
        // ==============================
        private bool ValidasiData()
        {
            if (cmbPasien.SelectedIndex == -1 ||
                cmbPasien.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih pasien!");
                cmbPasien.Focus();
                return false;
            }

            if (cmbDokter.SelectedIndex == -1 ||
                cmbDokter.SelectedValue == null)
            {
                MessageBox.Show("Silakan pilih dokter!");
                cmbDokter.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKeluhan.Text))
            {
                MessageBox.Show("Keluhan harus diisi!");
                txtKeluhan.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnosis.Text))
            {
                MessageBox.Show("Diagnosis harus diisi!");
                txtDiagnosis.Focus();
                return false;
            }

            return true;
        }

        // ==============================
        // SIMPAN DAN UBAH DATA
        // ==============================
        private bool SimpanData(bool ubah)
        {
            if (!ValidasiData())
                return false;

            decimal suhu, berat, tinggi;

            if (!decimal.TryParse(
                txtSuhuTubuh.Text,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out suhu))
            {
                MessageBox.Show("Suhu tubuh harus berupa angka!");
                txtSuhuTubuh.Focus();
                return false;
            }

            if (!decimal.TryParse(
                txtBeratBadan.Text,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out berat))
            {
                MessageBox.Show("Berat badan harus berupa angka!");
                txtBeratBadan.Focus();
                return false;
            }

            if (!decimal.TryParse(
                txtTinggiBadan.Text,
                NumberStyles.Any,
                CultureInfo.CurrentCulture,
                out tinggi))
            {
                MessageBox.Show("Tinggi badan harus berupa angka!");
                txtTinggiBadan.Focus();
                return false;
            }

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query;

                    if (ubah)
                    {
                        query = @"
                            UPDATE rekam_medis SET
                                id_pendaftaran = @pendaftaran,
                                id_dokter = @dokter,
                                tanggal_pemeriksaan = @tanggal,
                                keluhan = @keluhan,
                                diagnosis = @diagnosis,
                                tekanan_darah = @tekanan,
                                suhu_tubuh = @suhu,
                                berat_badan = @berat,
                                tinggi_badan = @tinggi,
                                tindakan = @tindakan,
                                catatan = @catatan
                            WHERE id_rekam_medis = @id";
                    }
                    else
                    {
                        query = @"
                            INSERT INTO rekam_medis
                            (
                                id_pendaftaran,
                                id_dokter,
                                tanggal_pemeriksaan,
                                keluhan,
                                diagnosis,
                                tekanan_darah,
                                suhu_tubuh,
                                berat_badan,
                                tinggi_badan,
                                tindakan,
                                catatan
                            )
                            VALUES
                            (
                                @pendaftaran,
                                @dokter,
                                @tanggal,
                                @keluhan,
                                @diagnosis,
                                @tekanan,
                                @suhu,
                                @berat,
                                @tinggi,
                                @tindakan,
                                @catatan
                            )";
                    }

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@pendaftaran",
                            Convert.ToInt32(cmbPasien.SelectedValue));

                        cmd.Parameters.AddWithValue(
                            "@dokter",
                            Convert.ToInt32(cmbDokter.SelectedValue));

                        cmd.Parameters.AddWithValue(
                            "@tanggal",
                            dtpTanggalPemeriksaan.Value);

                        cmd.Parameters.AddWithValue(
                            "@keluhan", txtKeluhan.Text);

                        cmd.Parameters.AddWithValue(
                            "@diagnosis", txtDiagnosis.Text);

                        cmd.Parameters.AddWithValue(
                            "@tekanan", txtTekananDarah.Text);

                        cmd.Parameters.AddWithValue(
                            "@suhu", suhu);

                        cmd.Parameters.AddWithValue(
                            "@berat", berat);

                        cmd.Parameters.AddWithValue(
                            "@tinggi", tinggi);

                        cmd.Parameters.AddWithValue(
                            "@tindakan", txtTindakan.Text);

                        cmd.Parameters.AddWithValue(
                            "@catatan", txtCatatan.Text);

                        if (ubah)
                        {
                            string idText =
                                txtIdRekamMedis.Text.Replace("RM", "");

                            cmd.Parameters.AddWithValue(
                                "@id",
                                Convert.ToInt32(idText));
                        }

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    ubah
                    ? "Data rekam medis berhasil diubah!"
                    : "Data rekam medis berhasil disimpan!");

                TampilkanData();
                BersihkanForm();
                TampilkanIdBerikutnya();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menyimpan data: " + ex.Message);

                return false;
            }
        }

        // ==============================
        // TOMBOL BARU
        // ==============================
        private void btnBaru_Click(object sender, EventArgs e)
        {
            BersihkanForm();
            TampilkanIdBerikutnya();
        }

        // ==============================
        // TOMBOL SIMPAN
        // ==============================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanData(false);
        }

        // ==============================
        // TOMBOL UBAH
        // ==============================
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdRekamMedis.Text))
            {
                MessageBox.Show(
                    "Pilih data yang ingin diubah!");
                return;
            }

            SimpanData(true);
        }

        // ==============================
        // TOMBOL HAPUS
        // ==============================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdRekamMedis.Text))
            {
                MessageBox.Show(
                    "Pilih data yang ingin dihapus!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data rekam medis ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil == DialogResult.Yes)
            {
                try
                {
                    string idText =
                        txtIdRekamMedis.Text.Replace("RM", "");

                    using (MySqlConnection conn = GetConnection())
                    {
                        conn.Open();

                        string query = @"
                            DELETE FROM rekam_medis
                            WHERE id_rekam_medis = @id";

                        using (MySqlCommand cmd =
                            new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue(
                                "@id",
                                Convert.ToInt32(idText));

                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Data berhasil dihapus!");

                    TampilkanData();
                    BersihkanForm();
                    TampilkanIdBerikutnya();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menghapus data: " + ex.Message);
                }
            }
        }

        // ==============================
        // PILIH DATA DARI DATAGRIDVIEW
        // ==============================
        private void dgvRekamMedis_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvRekamMedis.Rows[e.RowIndex];

                int id = Convert.ToInt32(
                    row.Cells["id_rekam_medis"].Value);

                txtIdRekamMedis.Text =
                    "RM" + id.ToString("D6");

                cmbPasien.SelectedValue =
                    Convert.ToInt32(
                        row.Cells["id_pendaftaran"].Value);

                cmbDokter.SelectedValue =
                    Convert.ToInt32(
                        row.Cells["id_dokter"].Value);

                dtpTanggalPemeriksaan.Value =
                    Convert.ToDateTime(
                        row.Cells["tanggal_pemeriksaan"].Value);

                txtKeluhan.Text =
                    Convert.ToString(
                        row.Cells["keluhan"].Value);

                txtDiagnosis.Text =
                    Convert.ToString(
                        row.Cells["diagnosis"].Value);

                txtTekananDarah.Text =
                    Convert.ToString(
                        row.Cells["tekanan_darah"].Value);

                txtSuhuTubuh.Text =
                    Convert.ToString(
                        row.Cells["suhu_tubuh"].Value);

                txtBeratBadan.Text =
                    Convert.ToString(
                        row.Cells["berat_badan"].Value);

                txtTinggiBadan.Text =
                    Convert.ToString(
                        row.Cells["tinggi_badan"].Value);

                txtTindakan.Text =
                    Convert.ToString(
                        row.Cells["tindakan"].Value);

                txtCatatan.Text =
                    Convert.ToString(
                        row.Cells["catatan"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memilih data: " + ex.Message);
            }
        }

        // ==============================
        // PENCARIAN DATA
        // ==============================
        private void txtCari_TextChanged(
            object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            rm.id_rekam_medis,
                            rm.id_pendaftaran,
                            rm.id_dokter,
                            pendaftaran.nomor_pendaftaran,
                            pasien.nama_lengkap AS nama_pasien,
                            dokter.nama_lengkap AS nama_dokter,
                            rm.tanggal_pemeriksaan,
                            rm.keluhan,
                            rm.diagnosis,
                            rm.tekanan_darah,
                            rm.suhu_tubuh,
                            rm.berat_badan,
                            rm.tinggi_badan,
                            rm.tindakan,
                            rm.catatan
                        FROM rekam_medis rm
                        INNER JOIN pendaftaran
                            ON rm.id_pendaftaran =
                               pendaftaran.id_pendaftaran
                        INNER JOIN pasien
                            ON pendaftaran.id_pasien =
                               pasien.id_pasien
                        INNER JOIN dokter
                            ON rm.id_dokter = dokter.id_dokter
                        WHERE pasien.nama_lengkap LIKE @cari
                           OR dokter.nama_lengkap LIKE @cari
                           OR pendaftaran.nomor_pendaftaran LIKE @cari
                           OR rm.diagnosis LIKE @cari
                        ORDER BY rm.id_rekam_medis DESC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    adapter.SelectCommand.Parameters.AddWithValue(
                        "@cari",
                        "%" + txtCari.Text + "%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvRekamMedis.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Pencarian gagal: " + ex.Message);
            }
        }

        // ==============================
        // TOMBOL BATAL
        // ==============================
        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanForm();
            TampilkanIdBerikutnya();
        }

        // ==============================
        // TOMBOL TUTUP
        // ==============================
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ==============================
        // MEMBERSIHKAN FORM
        // ==============================
        private void BersihkanForm()
        {
            txtIdRekamMedis.Clear();

            cmbPasien.SelectedIndex = -1;
            cmbDokter.SelectedIndex = -1;

            dtpTanggalPemeriksaan.Value = DateTime.Now;

            txtKeluhan.Clear();
            txtDiagnosis.Clear();
            txtTekananDarah.Clear();
            txtSuhuTubuh.Clear();
            txtBeratBadan.Clear();
            txtTinggiBadan.Clear();
            txtTindakan.Clear();
            txtCatatan.Clear();

            dgvRekamMedis.ClearSelection();
        }

        private void txtIdRekamMedis_TextChanged(
            object sender, EventArgs e)
        {
        }

        private void cmbPasien_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }
    }
}

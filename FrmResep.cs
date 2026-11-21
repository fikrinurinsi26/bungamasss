
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIMRS
{
    public partial class FrmResep : Form
    {
        private string connectionString =
            "server=localhost;database=db_rumah_sakit;uid=root;pwd=;";

        private int idResep = 0;
        private int idDetailResep = 0;

        public FrmResep()
        {
            InitializeComponent();

            txtIdResep.ReadOnly = true;

            PasangEvent();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Menunggu");
            cmbStatus.Items.Add("Diproses");
            cmbStatus.Items.Add("Selesai");
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = "dd-MM-yyyy";

            LoadComboBox();
            LoadData();

            BersihkanInput();
        }

        // =========================================
        // PASANG EVENT
        // =========================================

        private void PasangEvent()
        {
            btnBaru.Click -= btnBaru_Click;
            btnBaru.Click -= btnBaru_Click_1;
            btnBaru.Click += btnBaru_Click;

            btnSimpan.Click -= btnSimpan_Click;
            btnSimpan.Click -= btnSimpan_Click_1;
            btnSimpan.Click += btnSimpan_Click;

            btnUbah.Click -= btnUbah_Click;
            btnUbah.Click -= btnUbah_Click_1;
            btnUbah.Click += btnUbah_Click;

            btnHapus.Click -= btnHapus_Click;
            btnHapus.Click -= btnHapus_Click_1;
            btnHapus.Click += btnHapus_Click;

            btnBatal.Click -= btnBatal_Click;
            btnBatal.Click -= btnBatal_Click_1;
            btnBatal.Click += btnBatal_Click;

            btnTutup.Click -= btnTutup_Click;
            btnTutup.Click -= btnTutup_Click_1;
            btnTutup.Click += btnTutup_Click;

            txtCari.TextChanged -= txtCari_TextChanged;
            txtCari.TextChanged -= txtCari_TextChanged_1;
            txtCari.TextChanged += txtCari_TextChanged;

            dgvDetailResep.CellClick -= dgvDetailResep_CellClick;
            dgvDetailResep.CellClick += dgvDetailResep_CellClick;
        }

        // =========================================
        // KONEKSI DATABASE
        // =========================================

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // =========================================
        // LOAD COMBOBOX
        // =========================================

        private void LoadComboBox()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    // REKAM MEDIS + NAMA PASIEN + NOMOR RM

                    string sqlRM = @"
                        SELECT
                            rm.id_rekam_medis,

                            CONCAT(
                                'RM',
                                LPAD(rm.id_rekam_medis, 6, '0'),
                                ' | ',
                                p.nama_lengkap,
                                ' | No. RM: ',
                                p.nomor_rekam_medis,
                                ' | No. Daftar: ',
                                pd.nomor_pendaftaran
                            ) AS tampilan

                        FROM rekam_medis rm

                        INNER JOIN pendaftaran pd
                            ON rm.id_pendaftaran =
                               pd.id_pendaftaran

                        INNER JOIN pasien p
                            ON pd.id_pasien =
                               p.id_pasien

                        ORDER BY rm.id_rekam_medis DESC";

                    MySqlDataAdapter daRM =
                        new MySqlDataAdapter(sqlRM, conn);

                    DataTable dtRM = new DataTable();
                    daRM.Fill(dtRM);

                    cmbRekamMedis.DataSource = null;
                    cmbRekamMedis.DisplayMember = "tampilan";
                    cmbRekamMedis.ValueMember = "id_rekam_medis";
                    cmbRekamMedis.DataSource = dtRM;
                    cmbRekamMedis.SelectedIndex = -1;

                    // OBAT

                    string sqlObat = @"
                        SELECT id_obat, nama_obat
                        FROM obat
                        ORDER BY nama_obat ASC";

                    MySqlDataAdapter daObat =
                        new MySqlDataAdapter(sqlObat, conn);

                    DataTable dtObat = new DataTable();
                    daObat.Fill(dtObat);

                    cmbObat.DataSource = null;
                    cmbObat.DisplayMember = "nama_obat";
                    cmbObat.ValueMember = "id_obat";
                    cmbObat.DataSource = dtObat;
                    cmbObat.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat pilihan data: " + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // LOAD DATA RESEP
        // =========================================

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            dr.id_detail_resep,
                            r.id_resep,
                            r.id_rekam_medis,

                            p.nomor_rekam_medis,
                            p.nama_lengkap AS nama_pasien,
                            pd.nomor_pendaftaran,

                            r.tanggal_resep,
                            r.status_resep,

                            o.nama_obat,
                            dr.id_obat,
                            dr.jumlah,
                            dr.dosis,
                            dr.aturan_pakai

                        FROM detail_resep dr

                        INNER JOIN resep r
                            ON dr.id_resep = r.id_resep

                        INNER JOIN rekam_medis rm
                            ON r.id_rekam_medis =
                               rm.id_rekam_medis

                        INNER JOIN pendaftaran pd
                            ON rm.id_pendaftaran =
                               pd.id_pendaftaran

                        INNER JOIN pasien p
                            ON pd.id_pasien =
                               p.id_pasien

                        INNER JOIN obat o
                            ON dr.id_obat = o.id_obat

                        WHERE
                            CAST(r.id_resep AS CHAR) LIKE @cari
                            OR CAST(r.id_rekam_medis AS CHAR) LIKE @cari
                            OR p.nama_lengkap LIKE @cari
                            OR p.nomor_rekam_medis LIKE @cari
                            OR pd.nomor_pendaftaran LIKE @cari
                            OR o.nama_obat LIKE @cari
                            OR dr.dosis LIKE @cari
                            OR dr.aturan_pakai LIKE @cari

                        ORDER BY
                            r.id_resep DESC,
                            dr.id_detail_resep DESC";

                    MySqlCommand cmd =
                        new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue(
                        "@cari",
                        "%" + txtCari.Text.Trim() + "%");

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDetailResep.DataSource = dt;

                    dgvDetailResep.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvDetailResep.ReadOnly = true;
                    dgvDetailResep.AllowUserToAddRows = false;

                    dgvDetailResep.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    dgvDetailResep.MultiSelect = false;

                    // KOLOM TERSEMBUNYI

                    dgvDetailResep.Columns["id_detail_resep"].Visible = false;
                    dgvDetailResep.Columns["id_obat"].Visible = false;

                    // NAMA KOLOM

                    dgvDetailResep.Columns["id_resep"].HeaderText = "ID Resep";

                    dgvDetailResep.Columns["id_rekam_medis"].HeaderText = "ID Rekam Medis";

                    dgvDetailResep.Columns["nomor_rekam_medis"].HeaderText = "Nomor RM";

                    dgvDetailResep.Columns["nama_pasien"].HeaderText = "Nama Pasien";

                    dgvDetailResep.Columns["nomor_pendaftaran"].HeaderText = "Nomor Pendaftaran";

                    dgvDetailResep.Columns["tanggal_resep"].HeaderText = "Tanggal Resep";

                    dgvDetailResep.Columns["status_resep"].HeaderText = "Status";

                    dgvDetailResep.Columns["nama_obat"].HeaderText = "Nama Obat";

                    dgvDetailResep.Columns["jumlah"].HeaderText = "Jumlah";

                    dgvDetailResep.Columns["dosis"].HeaderText = "Dosis";

                    dgvDetailResep.Columns["aturan_pakai"].HeaderText = "Aturan Pakai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan data resep: " + ex.Message,
                    "Kesalahan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =========================================
        // VALIDASI INPUT
        // =========================================

        private bool ValidasiInput(out int jumlah)
        {
            jumlah = 0;

            if (cmbRekamMedis.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih rekam medis terlebih dahulu.");
                cmbRekamMedis.Focus();
                return false;
            }

            if (cmbObat.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih obat terlebih dahulu.");
                cmbObat.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih status resep.");
                cmbStatus.Focus();
                return false;
            }

            if (txtJumlah.Text.Trim() == "")
            {
                MessageBox.Show("Jumlah obat belum diisi.");
                txtJumlah.Focus();
                return false;
            }

            if (!int.TryParse(txtJumlah.Text.Trim(), out jumlah) ||
                jumlah <= 0)
            {
                MessageBox.Show("Jumlah obat harus berupa angka positif.");
                txtJumlah.Focus();
                return false;
            }

            if (txtDosis.Text.Trim() == "")
            {
                MessageBox.Show("Dosis belum diisi.");
                txtDosis.Focus();
                return false;
            }

            if (txtAturanPakai.Text.Trim() == "")
            {
                MessageBox.Show("Aturan pakai belum diisi.");
                txtAturanPakai.Focus();
                return false;
            }

            return true;
        }

        // =========================================
        // BERSIHKAN INPUT
        // =========================================

        private void BersihkanInput()
        {
            idResep = 0;
            idDetailResep = 0;

            txtIdResep.Clear();
            txtJumlah.Clear();
            txtDosis.Clear();
            txtAturanPakai.Clear();

            cmbRekamMedis.SelectedIndex = -1;
            cmbObat.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;

            dtpTanggal.Value = DateTime.Now;

            dgvDetailResep.ClearSelection();
        }

        // =========================================
        // TOMBOL BARU
        // =========================================

        private void btnBaru_Click(object sender, EventArgs e)
        {
            BersihkanInput();

            MessageBox.Show(
                "Silakan masukkan data resep baru.");
        }

        // =========================================
        // TOMBOL SIMPAN
        // =========================================

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            int jumlah;

            if (!ValidasiInput(out jumlah))
                return;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            int idResepSimpan = idResep;

                            // BUAT RESEP UTAMA

                            if (idResepSimpan == 0)
                            {
                                string sqlResep = @"
                                    INSERT INTO resep
                                    (
                                        id_rekam_medis,
                                        tanggal_resep,
                                        status_resep
                                    )
                                    VALUES
                                    (
                                        @rm,
                                        @tanggal,
                                        @status
                                    )";

                                using (MySqlCommand cmdResep =
                                    new MySqlCommand(sqlResep, conn, trans))
                                {
                                    cmdResep.Parameters.AddWithValue(
                                        "@rm", cmbRekamMedis.SelectedValue);

                                    cmdResep.Parameters.AddWithValue(
                                        "@tanggal", dtpTanggal.Value);

                                    cmdResep.Parameters.AddWithValue(
                                        "@status", cmbStatus.SelectedItem.ToString());

                                    cmdResep.ExecuteNonQuery();

                                    idResepSimpan =
                                        Convert.ToInt32(cmdResep.LastInsertedId);
                                }
                            }

                            // SIMPAN DETAIL OBAT

                            string sqlDetail = @"
                                INSERT INTO detail_resep
                                (
                                    id_resep,
                                    id_obat,
                                    jumlah,
                                    dosis,
                                    aturan_pakai
                                )
                                VALUES
                                (
                                    @resep,
                                    @obat,
                                    @jumlah,
                                    @dosis,
                                    @aturan
                                )";

                            using (MySqlCommand cmdDetail =
                                new MySqlCommand(sqlDetail, conn, trans))
                            {
                                cmdDetail.Parameters.AddWithValue(
                                    "@resep", idResepSimpan);

                                cmdDetail.Parameters.AddWithValue(
                                    "@obat", cmbObat.SelectedValue);

                                cmdDetail.Parameters.AddWithValue(
                                    "@jumlah", jumlah);

                                cmdDetail.Parameters.AddWithValue(
                                    "@dosis", txtDosis.Text.Trim());

                                cmdDetail.Parameters.AddWithValue(
                                    "@aturan", txtAturanPakai.Text.Trim());

                                cmdDetail.ExecuteNonQuery();
                            }

                            trans.Commit();

                            idResep = idResepSimpan;
                            txtIdResep.Text = idResep.ToString();

                            MessageBox.Show(
                                "Data resep berhasil disimpan.\n" +
                                "ID Resep: " + idResep,
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            idDetailResep = 0;

                            txtJumlah.Clear();
                            txtDosis.Clear();
                            txtAturanPakai.Clear();

                            cmbObat.SelectedIndex = -1;

                            LoadData();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menyimpan resep: " + ex.Message,
                        "Kesalahan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // =========================================
        // PILIH DATA GRID
        // =========================================

        private void dgvDetailResep_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvDetailResep.Rows[e.RowIndex];

                idDetailResep = Convert.ToInt32(
                    row.Cells["id_detail_resep"].Value);

                idResep = Convert.ToInt32(
                    row.Cells["id_resep"].Value);

                txtIdResep.Text = idResep.ToString();

                cmbRekamMedis.SelectedValue =
                    Convert.ToInt32(
                        row.Cells["id_rekam_medis"].Value);

                cmbObat.SelectedValue =
                    Convert.ToInt32(
                        row.Cells["id_obat"].Value);

                dtpTanggal.Value = Convert.ToDateTime(
                    row.Cells["tanggal_resep"].Value);

                cmbStatus.SelectedItem =
                    row.Cells["status_resep"].Value.ToString();

                txtJumlah.Text =
                    row.Cells["jumlah"].Value.ToString();

                txtDosis.Text =
                    row.Cells["dosis"].Value.ToString();

                txtAturanPakai.Text =
                    row.Cells["aturan_pakai"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memilih data: " + ex.Message);
            }
        }

        // =========================================
        // TOMBOL UBAH
        // =========================================

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idResep == 0 || idDetailResep == 0)
            {
                MessageBox.Show(
                    "Pilih data resep dari tabel terlebih dahulu.");
                return;
            }

            int jumlah;

            if (!ValidasiInput(out jumlah))
                return;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlResep = @"
                                UPDATE resep
                                SET
                                    id_rekam_medis = @rm,
                                    tanggal_resep = @tanggal,
                                    status_resep = @status
                                WHERE id_resep = @id";

                            using (MySqlCommand cmdResep =
                                new MySqlCommand(sqlResep, conn, trans))
                            {
                                cmdResep.Parameters.AddWithValue(
                                    "@rm", cmbRekamMedis.SelectedValue);

                                cmdResep.Parameters.AddWithValue(
                                    "@tanggal", dtpTanggal.Value);

                                cmdResep.Parameters.AddWithValue(
                                    "@status", cmbStatus.SelectedItem.ToString());

                                cmdResep.Parameters.AddWithValue(
                                    "@id", idResep);

                                cmdResep.ExecuteNonQuery();
                            }

                            string sqlDetail = @"
                                UPDATE detail_resep
                                SET
                                    id_obat = @obat,
                                    jumlah = @jumlah,
                                    dosis = @dosis,
                                    aturan_pakai = @aturan
                                WHERE id_detail_resep = @id";

                            using (MySqlCommand cmdDetail =
                                new MySqlCommand(sqlDetail, conn, trans))
                            {
                                cmdDetail.Parameters.AddWithValue(
                                    "@obat", cmbObat.SelectedValue);

                                cmdDetail.Parameters.AddWithValue(
                                    "@jumlah", jumlah);

                                cmdDetail.Parameters.AddWithValue(
                                    "@dosis", txtDosis.Text.Trim());

                                cmdDetail.Parameters.AddWithValue(
                                    "@aturan", txtAturanPakai.Text.Trim());

                                cmdDetail.Parameters.AddWithValue(
                                    "@id", idDetailResep);

                                cmdDetail.ExecuteNonQuery();
                            }

                            trans.Commit();

                            MessageBox.Show(
                                "Data resep berhasil diubah.",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            BersihkanInput();
                            LoadData();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal mengubah data: " + ex.Message,
                        "Kesalahan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // =========================================
        // TOMBOL HAPUS
        // =========================================

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idDetailResep == 0)
            {
                MessageBox.Show(
                    "Pilih detail resep yang ingin dihapus.");
                return;
            }

            DialogResult jawab = MessageBox.Show(
                "Yakin ingin menghapus detail resep ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (jawab != DialogResult.Yes)
                return;

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    using (MySqlTransaction trans = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlHapus = @"
                                DELETE FROM detail_resep
                                WHERE id_detail_resep = @id";

                            using (MySqlCommand cmd =
                                new MySqlCommand(sqlHapus, conn, trans))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id", idDetailResep);

                                cmd.ExecuteNonQuery();
                            }

                            string sqlCek = @"
                                SELECT COUNT(*)
                                FROM detail_resep
                                WHERE id_resep = @id";

                            int sisa;

                            using (MySqlCommand cmdCek =
                                new MySqlCommand(sqlCek, conn, trans))
                            {
                                cmdCek.Parameters.AddWithValue(
                                    "@id", idResep);

                                sisa = Convert.ToInt32(
                                    cmdCek.ExecuteScalar());
                            }

                            if (sisa == 0)
                            {
                                string sqlResep = @"
                                    DELETE FROM resep
                                    WHERE id_resep = @id";

                                using (MySqlCommand cmdResep =
                                    new MySqlCommand(sqlResep, conn, trans))
                                {
                                    cmdResep.Parameters.AddWithValue(
                                        "@id", idResep);

                                    cmdResep.ExecuteNonQuery();
                                }
                            }

                            trans.Commit();

                            MessageBox.Show(
                                "Data resep berhasil dihapus.",
                                "Informasi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            BersihkanInput();
                            LoadData();
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menghapus data: " + ex.Message,
                        "Kesalahan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        // =========================================
        // TOMBOL BATAL
        // =========================================

        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanInput();

            MessageBox.Show(
                "Input berhasil dibatalkan.");
        }

        // =========================================
        // TOMBOL TUTUP
        // =========================================

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =========================================
        // PENCARIAN OTOMATIS
        // =========================================

        private void txtCari_TextChanged(
            object sender, EventArgs e)
        {
            LoadData();
        }

        // =========================================
        // EVENT DESIGNER LAMA
        // =========================================

        private void FrmResep_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void cmbRekamMedis_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cmbStatus_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }

        private void cmbObat_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDosis_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtAturanPakai_TextChanged(
            object sender, EventArgs e)
        {
        }

        private void btnBaru_Click_1(object sender, EventArgs e)
        {
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {
        }

        private void btnUbah_Click_1(object sender, EventArgs e)
        {
        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {
        }

        private void btnBatal_Click_1(object sender, EventArgs e)
        {
        }

        private void btnTutup_Click_1(object sender, EventArgs e)
        {
        }

        private void txtCari_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void dgvDetailResep_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}

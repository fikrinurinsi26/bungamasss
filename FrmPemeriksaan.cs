
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIMRS
{
    public partial class FrmPemeriksaan : Form
    {
        private string connectionString =
            "server=localhost;database=db_rumah_sakit;uid=root;pwd=;";

        private int idPemeriksaan = 0;

        public FrmPemeriksaan()
        {
            InitializeComponent();

            Load -= FrmPemeriksaan_Load;
            Load += FrmPemeriksaan_Load;

            btnBaru.Click -= btnBaru_Click;
            btnBaru.Click += btnBaru_Click;

            btnSimpan.Click -= btnSimpan_Click;
            btnSimpan.Click += btnSimpan_Click;

            btnUbah.Click -= btnUbah_Click;
            btnUbah.Click += btnUbah_Click;

            btnHapus.Click -= btnHapus_Click;
            btnHapus.Click += btnHapus_Click;

            btnTutup.Click -= btnTutup_Click;
            btnTutup.Click += btnTutup_Click;

            btnBatal.Click -= btnBatal_Click;
            btnBatal.Click += btnBatal_Click;

            textCari.TextChanged -= textCari_TextChanged;
            textCari.TextChanged += textCari_TextChanged;

            dgvPemeriksaan.CellClick -= dgvPemeriksaan_CellClick;
            dgvPemeriksaan.CellClick += dgvPemeriksaan_CellClick;
        }

        private void FrmPemeriksaan_Load(object sender, EventArgs e)
        {
            cmbPendaftaran.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDokter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbJenis.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbJenis.Items.Clear();
            cmbJenis.Items.Add("Pemeriksaan Umum");
            cmbJenis.Items.Add("Pemeriksaan Fisik");
            cmbJenis.Items.Add("Pemeriksaan Laboratorium");
            cmbJenis.Items.Add("Pemeriksaan Gigi");
            cmbJenis.Items.Add("Pemeriksaan Mata");
            cmbJenis.Items.Add("Pemeriksaan Spesialis");

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Menunggu");
            cmbStatus.Items.Add("Selesai");

            dtpTanggal.Format = DateTimePickerFormat.Custom;
            dtpTanggal.CustomFormat = "dd-MM-yyyy HH:mm";
            dtpTanggal.ShowUpDown = true;

            txtHasil.Multiline = true;
            txtKeterangan.Multiline = true;

            dgvPemeriksaan.ReadOnly = true;
            dgvPemeriksaan.AllowUserToAddRows = false;
            dgvPemeriksaan.AllowUserToDeleteRows = false;
            dgvPemeriksaan.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvPemeriksaan.MultiSelect = false;
            dgvPemeriksaan.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            LoadPendaftaran();
            LoadDokter();
            LoadDataPemeriksaan();

            BersihkanForm();
        }

        // =====================================
        // LOAD DATA PENDAFTARAN
        // =====================================
        private void LoadPendaftaran()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            p.id_pendaftaran,
                            CONCAT(
                                p.nomor_pendaftaran,
                                ' - ',
                                ps.nama_lengkap
                            ) AS nama_pendaftaran
                        FROM pendaftaran p
                        INNER JOIN pasien ps
                            ON p.id_pasien = ps.id_pasien
                        ORDER BY p.id_pendaftaran DESC";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPendaftaran.DataSource = null;
                    cmbPendaftaran.DataSource = dt;
                    cmbPendaftaran.DisplayMember = "nama_pendaftaran";
                    cmbPendaftaran.ValueMember = "id_pendaftaran";
                    cmbPendaftaran.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data pendaftaran: " + ex.Message
                );
            }
        }

        // =====================================
        // LOAD DATA DOKTER
        // =====================================
        private void LoadDokter()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            id_dokter,
                            CONCAT(kode_dokter, ' - ', nama_lengkap)
                                AS nama_dokter
                        FROM dokter
                        WHERE status_aktif = 1
                        ORDER BY nama_lengkap ASC";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDokter.DataSource = null;
                    cmbDokter.DataSource = dt;
                    cmbDokter.DisplayMember = "nama_dokter";
                    cmbDokter.ValueMember = "id_dokter";
                    cmbDokter.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data dokter: " + ex.Message
                );
            }
        }

        // =====================================
        // LOAD DATA PEMERIKSAAN + PENCARIAN
        // =====================================
        private void LoadDataPemeriksaan(string keyword = "")
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    string query = @"
                        SELECT
                            pm.id_pemeriksaan,
                            pm.id_pendaftaran,
                            pm.id_dokter,
                            p.nomor_pendaftaran,
                            ps.nama_lengkap AS nama_pasien,
                            d.nama_lengkap AS nama_dokter,
                            pm.tanggal_pemeriksaan,
                            pm.jenis_pemeriksaan,
                            pm.hasil_pemeriksaan,
                            pm.keterangan,
                            pm.status_pemeriksaan
                        FROM pemeriksaan pm
                        LEFT JOIN pendaftaran p
                            ON pm.id_pendaftaran = p.id_pendaftaran
                        LEFT JOIN pasien ps
                            ON p.id_pasien = ps.id_pasien
                        LEFT JOIN dokter d
                            ON pm.id_dokter = d.id_dokter
                        WHERE
                            p.nomor_pendaftaran LIKE @cari
                            OR ps.nama_lengkap LIKE @cari
                            OR d.nama_lengkap LIKE @cari
                            OR pm.jenis_pemeriksaan LIKE @cari
                            OR pm.status_pemeriksaan LIKE @cari
                        ORDER BY pm.id_pemeriksaan DESC";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@cari", "%" + keyword + "%"
                    );

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPemeriksaan.DataSource = dt;

                    if (dgvPemeriksaan.Columns.Count > 0)
                    {
                        dgvPemeriksaan.Columns["id_pemeriksaan"].Visible = false;
                        dgvPemeriksaan.Columns["id_pendaftaran"].Visible = false;
                        dgvPemeriksaan.Columns["id_dokter"].Visible = false;

                        dgvPemeriksaan.Columns["nomor_pendaftaran"].HeaderText =
                            "Nomor Pendaftaran";

                        dgvPemeriksaan.Columns["nama_pasien"].HeaderText =
                            "Nama Pasien";

                        dgvPemeriksaan.Columns["nama_dokter"].HeaderText =
                            "Nama Dokter";

                        dgvPemeriksaan.Columns["tanggal_pemeriksaan"].HeaderText =
                            "Tanggal Pemeriksaan";

                        dgvPemeriksaan.Columns["jenis_pemeriksaan"].HeaderText =
                            "Jenis Pemeriksaan";

                        dgvPemeriksaan.Columns["hasil_pemeriksaan"].HeaderText =
                            "Hasil Pemeriksaan";

                        dgvPemeriksaan.Columns["keterangan"].HeaderText =
                            "Keterangan";

                        dgvPemeriksaan.Columns["status_pemeriksaan"].HeaderText =
                            "Status";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data pemeriksaan: " + ex.Message
                );
            }
        }

        // =====================================
        // TOMBOL BARU
        // =====================================
        private void btnBaru_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }

        // =====================================
        // TOMBOL SIMPAN
        // =====================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbPendaftaran.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih pendaftaran terlebih dahulu.");
                cmbPendaftaran.Focus();
                return;
            }

            if (cmbDokter.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih dokter terlebih dahulu.");
                cmbDokter.Focus();
                return;
            }

            if (cmbJenis.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih jenis pemeriksaan.");
                cmbJenis.Focus();
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih status pemeriksaan.");
                cmbStatus.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO pemeriksaan
                        (
                            id_pendaftaran,
                            id_dokter,
                            tanggal_pemeriksaan,
                            jenis_pemeriksaan,
                            hasil_pemeriksaan,
                            keterangan,
                            status_pemeriksaan
                        )
                        VALUES
                        (
                            @id_pendaftaran,
                            @id_dokter,
                            @tanggal_pemeriksaan,
                            @jenis_pemeriksaan,
                            @hasil_pemeriksaan,
                            @keterangan,
                            @status_pemeriksaan
                        )";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_pendaftaran", cmbPendaftaran.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@id_dokter", cmbDokter.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@tanggal_pemeriksaan", dtpTanggal.Value);

                        cmd.Parameters.AddWithValue(
                            "@jenis_pemeriksaan", cmbJenis.Text);

                        cmd.Parameters.AddWithValue(
                            "@hasil_pemeriksaan", txtHasil.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@keterangan", txtKeterangan.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@status_pemeriksaan", cmbStatus.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data pemeriksaan berhasil disimpan.");

                LoadDataPemeriksaan(textCari.Text.Trim());
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menyimpan pemeriksaan: " + ex.Message
                );
            }
        }

        // =====================================
        // TOMBOL UBAH
        // =====================================
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idPemeriksaan == 0)
            {
                MessageBox.Show(
                    "Pilih data pemeriksaan dari tabel terlebih dahulu."
                );
                return;
            }

            if (cmbPendaftaran.SelectedIndex == -1 ||
                cmbDokter.SelectedIndex == -1 ||
                cmbJenis.SelectedIndex == -1 ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Lengkapi pilihan data pemeriksaan terlebih dahulu."
                );
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE pemeriksaan SET
                            id_pendaftaran = @id_pendaftaran,
                            id_dokter = @id_dokter,
                            tanggal_pemeriksaan = @tanggal_pemeriksaan,
                            jenis_pemeriksaan = @jenis_pemeriksaan,
                            hasil_pemeriksaan = @hasil_pemeriksaan,
                            keterangan = @keterangan,
                            status_pemeriksaan = @status_pemeriksaan
                        WHERE id_pemeriksaan = @id_pemeriksaan";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_pendaftaran", cmbPendaftaran.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@id_dokter", cmbDokter.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@tanggal_pemeriksaan", dtpTanggal.Value);

                        cmd.Parameters.AddWithValue(
                            "@jenis_pemeriksaan", cmbJenis.Text);

                        cmd.Parameters.AddWithValue(
                            "@hasil_pemeriksaan", txtHasil.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@keterangan", txtKeterangan.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@status_pemeriksaan", cmbStatus.Text);

                        cmd.Parameters.AddWithValue(
                            "@id_pemeriksaan", idPemeriksaan);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data pemeriksaan berhasil diubah.");

                LoadDataPemeriksaan(textCari.Text.Trim());
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengubah pemeriksaan: " + ex.Message
                );
            }
        }

        // =====================================
        // TOMBOL HAPUS
        // =====================================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idPemeriksaan == 0)
            {
                MessageBox.Show(
                    "Pilih data pemeriksaan yang ingin dihapus."
                );
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Apakah kamu yakin ingin menghapus data pemeriksaan ini?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (hasil != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        DELETE FROM pemeriksaan
                        WHERE id_pemeriksaan = @id_pemeriksaan";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id_pemeriksaan", idPemeriksaan);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data pemeriksaan berhasil dihapus.");

                LoadDataPemeriksaan(textCari.Text.Trim());
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menghapus pemeriksaan: " + ex.Message
                );
            }
        }

        // =====================================
        // KLIK DATA PADA TABEL
        // =====================================
        private void dgvPemeriksaan_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                DataGridViewRow row =
                    dgvPemeriksaan.Rows[e.RowIndex];

                idPemeriksaan = Convert.ToInt32(
                    row.Cells["id_pemeriksaan"].Value
                );

                cmbPendaftaran.SelectedValue =
                    Convert.ToInt32(row.Cells["id_pendaftaran"].Value);

                cmbDokter.SelectedValue =
                    Convert.ToInt32(row.Cells["id_dokter"].Value);

                if (row.Cells["tanggal_pemeriksaan"].Value != DBNull.Value)
                {
                    dtpTanggal.Value = Convert.ToDateTime(
                        row.Cells["tanggal_pemeriksaan"].Value
                    );
                }

                cmbJenis.Text =
                    Convert.ToString(row.Cells["jenis_pemeriksaan"].Value);

                txtHasil.Text =
                    row.Cells["hasil_pemeriksaan"].Value == DBNull.Value
                    ? ""
                    : Convert.ToString(row.Cells["hasil_pemeriksaan"].Value);

                txtKeterangan.Text =
                    row.Cells["keterangan"].Value == DBNull.Value
                    ? ""
                    : Convert.ToString(row.Cells["keterangan"].Value);

                cmbStatus.Text =
                    Convert.ToString(row.Cells["status_pemeriksaan"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memilih data: " + ex.Message
                );
            }
        }

        // =====================================
        // TOMBOL BATAL
        // =====================================
        private void btnBatal_Click(object sender, EventArgs e)
        {
            BersihkanForm();

            MessageBox.Show(
                "Proses dibatalkan.",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // =====================================
        // PENCARIAN OTOMATIS
        // =====================================
        private void textCari_TextChanged(object sender, EventArgs e)
        {
            LoadDataPemeriksaan(textCari.Text.Trim());
        }

        // =====================================
        // MEMBERSIHKAN FORM
        // =====================================
        private void BersihkanForm()
        {
            idPemeriksaan = 0;

            cmbPendaftaran.SelectedIndex = -1;
            cmbDokter.SelectedIndex = -1;
            cmbJenis.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dtpTanggal.Value = DateTime.Now;

            txtHasil.Clear();
            txtKeterangan.Clear();

            dgvPemeriksaan.ClearSelection();
        }

        // =====================================
        // TOMBOL TUTUP
        // =====================================
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

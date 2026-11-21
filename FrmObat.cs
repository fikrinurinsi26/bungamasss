
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SIMRS
{
    public partial class FrmObat : Form
    {
        private string connectionString =
            "server=localhost;database=db_rumah_sakit;uid=root;pwd=;";

        private int idObat = 0;

        public FrmObat()
        {
            InitializeComponent();

            btnBaru.Click += btnBaru_Click;
            btnSimpan.Click += btnSimpan_Click;
            btnUbah.Click += btnUbah_Click;
            btnHapus.Click += btnHapus_Click;
            btnBatal.Click += btnBatal_Click;
            btnTutup.Click += btnTutup_Click;

            txtCari.TextChanged += txtCari_TextChanged;
            dgvObat.CellClick += dgvObat_CellClick;

            this.Load += FrmObat_Load;
        }

        // KONEKSI DATABASE
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // FORM LOAD
        private void FrmObat_Load(object sender, EventArgs e)
        {
            cmbKategori.Items.Clear();

            cmbKategori.Items.AddRange(new string[]
            {
                "Antibiotik",
                "Analgesik",
                "Vitamin",
                "Antiseptik",
                "Antipiretik",
                "Antihistamin",
                "Obat Lambung",
                "Obat Luar",
                "Obat Lainnya"
            });

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Aktif");
            cmbStatus.Items.Add("Tidak Aktif");

            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpKadaluarsa.Format = DateTimePickerFormat.Custom;
            dtpKadaluarsa.CustomFormat = "dd-MM-yyyy";

            dgvObat.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvObat.MultiSelect = false;
            dgvObat.ReadOnly = true;
            dgvObat.AllowUserToAddRows = false;
            dgvObat.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            TampilData();
            KosongkanForm();
        }

        // TAMPIL DATA
        private void TampilData()
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_obat, kode_obat, nama_obat,
                        kategori_obat, satuan, jumlah_stok,
                        harga_beli, harga_jual,
                        tanggal_kadaluarsa,
                        CASE WHEN status_aktif = 1
                        THEN 'Aktif' ELSE 'Tidak Aktif'
                        END AS status
                        FROM obat
                        ORDER BY id_obat DESC";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvObat.DataSource = dt;
                }

                if (dgvObat.Columns.Contains("id_obat"))
                    dgvObat.Columns["id_obat"].HeaderText = "ID";

                if (dgvObat.Columns.Contains("kode_obat"))
                    dgvObat.Columns["kode_obat"].HeaderText = "Kode Obat";

                if (dgvObat.Columns.Contains("nama_obat"))
                    dgvObat.Columns["nama_obat"].HeaderText = "Nama Obat";

                if (dgvObat.Columns.Contains("kategori_obat"))
                    dgvObat.Columns["kategori_obat"].HeaderText = "Kategori";

                if (dgvObat.Columns.Contains("satuan"))
                    dgvObat.Columns["satuan"].HeaderText = "Satuan";

                if (dgvObat.Columns.Contains("jumlah_stok"))
                    dgvObat.Columns["jumlah_stok"].HeaderText = "Stok";

                if (dgvObat.Columns.Contains("harga_beli"))
                    dgvObat.Columns["harga_beli"].HeaderText = "Harga Beli";

                if (dgvObat.Columns.Contains("harga_jual"))
                    dgvObat.Columns["harga_jual"].HeaderText = "Harga Jual";

                if (dgvObat.Columns.Contains("tanggal_kadaluarsa"))
                    dgvObat.Columns["tanggal_kadaluarsa"].HeaderText =
                        "Tanggal Kedaluwarsa";

                if (dgvObat.Columns.Contains("status"))
                    dgvObat.Columns["status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menampilkan data: " + ex.Message);
            }
        }

        // VALIDASI
        private bool ValidasiInput()
        {
            if (txtKodeObat.Text.Trim() == "")
            {
                MessageBox.Show("Kode obat harus diisi!");
                txtKodeObat.Focus();
                return false;
            }

            if (txtNamaObat.Text.Trim() == "")
            {
                MessageBox.Show("Nama obat harus diisi!");
                txtNamaObat.Focus();
                return false;
            }

            if (cmbKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih kategori obat!");
                return false;
            }

            if (txtSatuan.Text.Trim() == "")
            {
                MessageBox.Show("Satuan harus diisi!");
                return false;
            }

            int stok;
            if (!int.TryParse(txtStok.Text, out stok) || stok < 0)
            {
                MessageBox.Show("Stok harus berupa angka 0 atau lebih!");
                txtStok.Focus();
                return false;
            }

            decimal beli, jual;

            if (!decimal.TryParse(txtHargaBeli.Text,
                NumberStyles.Number, CultureInfo.CurrentCulture, out beli)
                || beli < 0)
            {
                MessageBox.Show("Harga beli tidak valid!");
                txtHargaBeli.Focus();
                return false;
            }

            if (!decimal.TryParse(txtHargaJual.Text,
                NumberStyles.Number, CultureInfo.CurrentCulture, out jual)
                || jual < 0)
            {
                MessageBox.Show("Harga jual tidak valid!");
                txtHargaJual.Focus();
                return false;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih status obat!");
                return false;
            }

            return true;
        }

        // PARAMETER SQL
        private void IsiParameter(MySqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@kode", txtKodeObat.Text.Trim());
            cmd.Parameters.AddWithValue("@nama", txtNamaObat.Text.Trim());
            cmd.Parameters.AddWithValue("@kategori", cmbKategori.Text);
            cmd.Parameters.AddWithValue("@satuan", txtSatuan.Text.Trim());
            cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(txtStok.Text));

            cmd.Parameters.AddWithValue("@beli",
                decimal.Parse(txtHargaBeli.Text, CultureInfo.CurrentCulture));

            cmd.Parameters.AddWithValue("@jual",
                decimal.Parse(txtHargaJual.Text, CultureInfo.CurrentCulture));

            cmd.Parameters.AddWithValue("@kadaluarsa",
                dtpKadaluarsa.Value.Date);

            cmd.Parameters.AddWithValue("@status",
                cmbStatus.Text == "Aktif" ? 1 : 0);
        }

        // TOMBOL BARU
        private void btnBaru_Click(object sender, EventArgs e)
        {
            KosongkanForm();
            txtKodeObat.Focus();
        }

        // TOMBOL SIMPAN
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string cek = "SELECT COUNT(*) FROM obat WHERE kode_obat=@kode";

                    using (MySqlCommand cmdCek = new MySqlCommand(cek, conn))
                    {
                        cmdCek.Parameters.AddWithValue(
                            "@kode", txtKodeObat.Text.Trim());

                        if (Convert.ToInt32(cmdCek.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Kode obat sudah digunakan!");
                            return;
                        }
                    }

                    string query = @"
                        INSERT INTO obat
                        (kode_obat, nama_obat, kategori_obat, satuan,
                         jumlah_stok, harga_beli, harga_jual,
                         tanggal_kadaluarsa, status_aktif)
                        VALUES
                        (@kode, @nama, @kategori, @satuan,
                         @stok, @beli, @jual, @kadaluarsa, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        IsiParameter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data obat berhasil disimpan!");
                TampilData();
                KosongkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan: " + ex.Message);
            }
        }

        // TOMBOL UBAH
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (idObat == 0)
            {
                MessageBox.Show("Pilih data obat terlebih dahulu!");
                return;
            }

            if (!ValidasiInput()) return;

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string cek = @"
                        SELECT COUNT(*) FROM obat
                        WHERE kode_obat=@kode AND id_obat<>@id";

                    using (MySqlCommand cmdCek = new MySqlCommand(cek, conn))
                    {
                        cmdCek.Parameters.AddWithValue(
                            "@kode", txtKodeObat.Text.Trim());

                        cmdCek.Parameters.AddWithValue("@id", idObat);

                        if (Convert.ToInt32(cmdCek.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show("Kode obat sudah digunakan!");
                            return;
                        }
                    }

                    string query = @"
                        UPDATE obat SET
                        kode_obat=@kode,
                        nama_obat=@nama,
                        kategori_obat=@kategori,
                        satuan=@satuan,
                        jumlah_stok=@stok,
                        harga_beli=@beli,
                        harga_jual=@jual,
                        tanggal_kadaluarsa=@kadaluarsa,
                        status_aktif=@status
                        WHERE id_obat=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        IsiParameter(cmd);
                        cmd.Parameters.AddWithValue("@id", idObat);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data obat berhasil diubah!");
                TampilData();
                KosongkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengubah: " + ex.Message);
            }
        }

        // TOMBOL HAPUS
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (idObat == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            DialogResult hasil = MessageBox.Show(
                "Yakin ingin menghapus data obat ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (hasil != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query =
                        "DELETE FROM obat WHERE id_obat=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idObat);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data obat berhasil dihapus!");
                TampilData();
                KosongkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus: " + ex.Message);
            }
        }

        // PILIH DATA DARI GRID
        private void dgvObat_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvObat.Rows[e.RowIndex];

            idObat = Convert.ToInt32(row.Cells["id_obat"].Value);

            txtKodeObat.Text = row.Cells["kode_obat"].Value.ToString();
            txtNamaObat.Text = row.Cells["nama_obat"].Value.ToString();
            cmbKategori.Text = row.Cells["kategori_obat"].Value.ToString();
            txtSatuan.Text = row.Cells["satuan"].Value.ToString();
            txtStok.Text = row.Cells["jumlah_stok"].Value.ToString();
            txtHargaBeli.Text = row.Cells["harga_beli"].Value.ToString();
            txtHargaJual.Text = row.Cells["harga_jual"].Value.ToString();

            dtpKadaluarsa.Value =
                Convert.ToDateTime(row.Cells["tanggal_kadaluarsa"].Value);

            cmbStatus.Text = row.Cells["status"].Value.ToString();
        }

        // PENCARIAN
        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT id_obat, kode_obat, nama_obat,
                        kategori_obat, satuan, jumlah_stok,
                        harga_beli, harga_jual, tanggal_kadaluarsa,
                        CASE WHEN status_aktif=1
                        THEN 'Aktif' ELSE 'Tidak Aktif'
                        END AS status
                        FROM obat
                        WHERE kode_obat LIKE @cari
                        OR nama_obat LIKE @cari
                        ORDER BY id_obat DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@cari", "%" + txtCari.Text.Trim() + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvObat.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pencarian gagal: " + ex.Message);
            }
        }

        // KOSONGKAN FORM
        private void KosongkanForm()
        {
            idObat = 0;

            txtKodeObat.Clear();
            txtNamaObat.Clear();
            txtSatuan.Clear();
            txtStok.Clear();
            txtHargaBeli.Clear();
            txtHargaJual.Clear();

            cmbKategori.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            dtpKadaluarsa.Value = DateTime.Today;

            dgvObat.ClearSelection();
        }

        // TOMBOL BATAL
        private void btnBatal_Click(object sender, EventArgs e)
        {
            KosongkanForm();
        }

        // TOMBOL TUTUP
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbKategori_SelectedIndexChanged(
            object sender, EventArgs e)
        {
        }
    }
}

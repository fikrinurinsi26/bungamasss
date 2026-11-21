using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace SIMRS
{
    public partial class FrmPoli : Form
    {
        // Koneksi Database
        private KoneksiDatabase db = new KoneksiDatabase();
        private int idPoli = 0;
        public FrmPoli()
        {
            InitializeComponent();
        }

        private void grpDataPoli_Enter(object sender, EventArgs e)
        {

        }
        private void SimpanData()
        {
            if (txtKodePoli.Text == "" || txtNamaPoli.Text == "")
            {
                MessageBox.Show("Kode Poli dan Nama Poli wajib diisi!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string cek = "SELECT COUNT(*) FROM poli WHERE kode_poli=@kode";

                    MySqlCommand cmdCek = new MySqlCommand(cek, conn);
                    cmdCek.Parameters.AddWithValue("@kode", txtKodePoli.Text);

                    int jumlah = Convert.ToInt32(cmdCek.ExecuteScalar());

                    if (jumlah > 0)
                    {
                        MessageBox.Show(
                            "Kode Poli sudah digunakan!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        txtKodePoli.Focus();
                        return;
                    }
                    string sql = @"INSERT INTO poli
                        (kode_poli,nama_poli,lokasi,keterangan,is_active)
                        VALUES
                        (@kode,@nama,@lokasi,@ket,@status)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@kode", txtKodePoli.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPoli.Text);
                    cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
                    cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);
                    cmd.Parameters.AddWithValue("@status",
                        cmbStatus.Text == "Aktif" ? 1 : 0);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil disimpan.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UbahData()
        {
            if (idPoli == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string cek = @"SELECT COUNT(*) FROM poli
               WHERE kode_poli=@kode
               AND poli_id<>@id";

                    MySqlCommand cmdCek = new MySqlCommand(cek, conn);

                    cmdCek.Parameters.AddWithValue("@kode", txtKodePoli.Text);
                    cmdCek.Parameters.AddWithValue("@id", idPoli);

                    int jumlah = Convert.ToInt32(cmdCek.ExecuteScalar());

                    if (jumlah > 0)
                    {
                        MessageBox.Show(
                            "Kode Poli sudah digunakan!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                    string sql = @"UPDATE poli SET
                        kode_poli=@kode,
                        nama_poli=@nama,
                        lokasi=@lokasi,
                        keterangan=@ket,
                        is_active=@status
                        WHERE poli_id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@kode", txtKodePoli.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPoli.Text);
                    cmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
                    cmd.Parameters.AddWithValue("@ket", txtKeterangan.Text);
                    cmd.Parameters.AddWithValue("@status",
                        cmbStatus.Text == "Aktif" ? 1 : 0);

                    cmd.Parameters.AddWithValue("@id", idPoli);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil diubah.");

                    Bersih();
                    TampilData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void HapusData()
        {
            if (idPoli == 0)
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
                return;
            }

            if (MessageBox.Show("Hapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM poli WHERE poli_id=@id", conn);

                    cmd.Parameters.AddWithValue("@id", idPoli);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data berhasil dihapus.");

                    Bersih();
                    TampilData();
                }
            }
        }
        private void FrmPoli_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Aktif");
            cmbStatus.Items.Add("Tidak Aktif");
            cmbStatus.SelectedIndex = 0;

            TampilData();
            Bersih();
            // Pengaturan DataGridView
            dgvPoli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPoli.MultiSelect = false;
            dgvPoli.ReadOnly = true;
            dgvPoli.AllowUserToAddRows = false;
            dgvPoli.AllowUserToDeleteRows = false;
            dgvPoli.AllowUserToResizeRows = false;
            dgvPoli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPoli.RowHeadersVisible = false;
        }
        private void Bersih()
        {
            idPoli = 0;

            GenerateKodePoli();
            txtNamaPoli.Clear();
            txtLokasi.Clear();
            txtKeterangan.Clear();

            cmbStatus.SelectedIndex = 0;

            txtKodePoli.Focus();
        }
        private void TampilData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                                 poli_id,
                                  kode_poli,
                                  nama_poli,
                                  lokasi,
                                  keterangan,
                                  CASE
                                  WHEN is_active=1 THEN 'Aktif'
                                 ELSE 'Tidak Aktif'
                                END AS Status
                                  FROM poli
                                  ORDER BY kode_poli ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPoli.DataSource = dt;
                    dgvPoli.Columns[0].Visible = false;
                    dgvPoli.Columns[0].HeaderText = "ID";
                    dgvPoli.Columns[1].HeaderText = "Kode";
                    dgvPoli.Columns[2].HeaderText = "Nama Poli";
                    dgvPoli.Columns[3].HeaderText = "Lokasi";
                    dgvPoli.Columns[4].HeaderText = "Keterangan";
                    dgvPoli.Columns[5].HeaderText = "Status";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GenerateKodePoli()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "SELECT MAX(kode_poli) FROM poli";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    object hasil = cmd.ExecuteScalar();

                    if (hasil != DBNull.Value && hasil != null)
                    {
                        string kodeTerakhir = hasil.ToString();

                        int nomor = Convert.ToInt32(kodeTerakhir.Substring(2));

                        nomor++;

                        txtKodePoli.Text = "PL" + nomor.ToString("D3");
                    }
                    else
                    {
                        txtKodePoli.Text = "PL001";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            SimpanData();
        }

        private void dgvPoli_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT
                    poli_id,
                    kode_poli,
                    nama_poli,
                    lokasi,
                    keterangan,
                    is_active
                    FROM poli
                    WHERE kode_poli LIKE @cari
                    OR nama_poli LIKE @cari";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.AddWithValue("@cari",
                    "%" + txtCari.Text + "%");

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvPoli.DataSource = dt;
            }
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            UbahData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            HapusData();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Bersih();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPoli_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPoli.Rows[e.RowIndex];

                idPoli = Convert.ToInt32(row.Cells[0].Value);

                txtKodePoli.Text = row.Cells[1].Value.ToString();
                txtNamaPoli.Text = row.Cells[2].Value.ToString();
                txtLokasi.Text = row.Cells[3].Value.ToString();
                txtKeterangan.Text = row.Cells[4].Value.ToString();

                cmbStatus.Text = row.Cells[5].Value.ToString();
            }
        }
    }
}

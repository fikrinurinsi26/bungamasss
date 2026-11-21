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
    public partial class FrmDokter : Form


    {

        // Koneksi Database
        private KoneksiDatabase db = new KoneksiDatabase();

        // Menyimpan ID Dokter
        private int idDokter = 0;
        public FrmDokter()
        {
            InitializeComponent();
        }
        private void SimpanData()
        {
            if (txtNamaDokter.Text == "")
            {
                MessageBox.Show("Nama Dokter masih kosong!");
                txtNamaDokter.Focus();
                return;
            }

            if (cmbPoli.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih Poli terlebih dahulu!");
                cmbPoli.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO dokter
            (poli_id,
             kode_dokter,
             nama_lengkap,
             jenis_kelamin,
             nomor_telepon,
             alamat_email,
             spesialisasi,
             nomor_izin_praktik,
             status_aktif)

            VALUES
            (@poli,
             @kode,
             @nama,
             @jk,
             @telp,
             @email,
             @spesialisasi,
             @sip,
             @status)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@poli", cmbPoli.SelectedValue);
                    cmd.Parameters.AddWithValue("@kode", txtKodeDokter.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaDokter.Text);
                    cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
                    cmd.Parameters.AddWithValue("@telp", txtNoHP.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@spesialisasi", txtSpesialisasi.Text);
                    cmd.Parameters.AddWithValue("@sip", txtNomorIzin.Text);
                    cmd.Parameters.AddWithValue("@status",
                        cmbStatus.Text == "Aktif" ? 1 : 0);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data dokter berhasil disimpan.");

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
            if (idDokter == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"UPDATE dokter SET
                            poli_id=@poli,
                            kode_dokter=@kode,
                            nama_lengkap=@nama,
                            jenis_kelamin=@jk,
                            nomor_telepon=@telp,
                            alamat_email=@email,
                            spesialisasi=@spesialisasi,
                            nomor_izin_praktik=@sip,
                            status_aktif=@status
                           WHERE id_dokter=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@poli", cmbPoli.SelectedValue);
                    cmd.Parameters.AddWithValue("@kode", txtKodeDokter.Text);
                    cmd.Parameters.AddWithValue("@nama", txtNamaDokter.Text);
                    cmd.Parameters.AddWithValue("@jk", cmbJenisKelamin.Text);
                    cmd.Parameters.AddWithValue("@telp", txtNoHP.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@spesialisasi", txtSpesialisasi.Text);
                    cmd.Parameters.AddWithValue("@sip", txtNomorIzin.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text == "Aktif" ? 1 : 0);
                    cmd.Parameters.AddWithValue("@id", idDokter);

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
            if (idDokter == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!");
                return;
            }

            DialogResult jawab = MessageBox.Show(
                "Yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (jawab == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string sql = "DELETE FROM dokter WHERE id_dokter=@id";

                        MySqlCommand cmd = new MySqlCommand(sql, conn);

                        cmd.Parameters.AddWithValue("@id", idDokter);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Data berhasil dihapus.");

                        Bersih();
                        TampilData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void TampilData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                            d.id_dokter,
                            d.kode_dokter,
                            d.nama_lengkap,
                            d.jenis_kelamin,
                            d.nomor_telepon,
                            d.alamat_email,
                            d.spesialisasi,
                            p.nama_poli,
                            d.nomor_izin_praktik,
                            d.status_aktif
                           FROM dokter d
                           LEFT JOIN poli p
                           ON d.poli_id = p.poli_id
                           ORDER BY d.id_dokter DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvDokter.DataSource = dt;

                    dgvDokter.Columns[0].Visible = false;
                    dgvDokter.Columns[1].HeaderText = "Kode";
                    dgvDokter.Columns[2].HeaderText = "Nama Dokter";
                    dgvDokter.Columns[3].HeaderText = "JK";
                    dgvDokter.Columns[4].HeaderText = "No HP";
                    dgvDokter.Columns[5].HeaderText = "Email";
                    dgvDokter.Columns[6].HeaderText = "Spesialisasi";
                    dgvDokter.Columns[7].HeaderText = "Poli";
                    dgvDokter.Columns[8].HeaderText = "Nomor SIP";
                    dgvDokter.Columns[9].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CariData()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = @"SELECT
                            d.id_dokter,
                            d.kode_dokter,
                            d.nama_lengkap,
                            d.jenis_kelamin,
                            d.nomor_telepon,
                            d.alamat_email,
                            d.spesialisasi,
                            p.nama_poli,
                            d.nomor_izin_praktik,
                            d.status_aktif
                           FROM dokter d
                           LEFT JOIN poli p
                           ON d.poli_id = p.poli_id
                           WHERE d.kode_dokter LIKE @cari
                              OR d.nama_lengkap LIKE @cari
                              OR p.nama_poli LIKE @cari
                           ORDER BY d.id_dokter DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    da.SelectCommand.Parameters.AddWithValue("@cari", "%" + txtCari.Text + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvDokter.DataSource = dt;

                    dgvDokter.Columns[0].Visible = false;
                    dgvDokter.Columns[1].HeaderText = "Kode";
                    dgvDokter.Columns[2].HeaderText = "Nama Dokter";
                    dgvDokter.Columns[3].HeaderText = "JK";
                    dgvDokter.Columns[4].HeaderText = "No HP";
                    dgvDokter.Columns[5].HeaderText = "Email";
                    dgvDokter.Columns[6].HeaderText = "Spesialisasi";
                    dgvDokter.Columns[7].HeaderText = "Poli";
                    dgvDokter.Columns[8].HeaderText = "Nomor SIP";
                    dgvDokter.Columns[9].HeaderText = "Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadJenisKelamin()
        {
            cmbJenisKelamin.Items.Clear();

            cmbJenisKelamin.Items.Add("L");
            cmbJenisKelamin.Items.Add("P");

            cmbJenisKelamin.SelectedIndex = 0;
        }
        private void LoadPoli()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "SELECT poli_id, nama_poli FROM poli ORDER BY nama_poli";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    cmbPoli.DataSource = dt;
                    cmbPoli.DisplayMember = "nama_poli";
                    cmbPoli.ValueMember = "poli_id";
                    cmbPoli.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Aktif");
            cmbStatus.Items.Add("Tidak Aktif");

            cmbStatus.SelectedIndex = 0;
        }
        private void Bersih()
        {
            idDokter = 0;

            GenerateKodeDokter();

            txtNamaDokter.Clear();
            txtNoHP.Clear();
            txtEmail.Clear();
            txtSpesialisasi.Clear();
            txtNomorIzin.Clear();
            txtCari.Clear();
            
            cmbJenisKelamin.SelectedIndex = 0;
            cmbPoli.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;

            txtNamaDokter.Focus();
        }
        private void GenerateKodeDokter()
        {
           
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string sql = "SELECT MAX(kode_dokter) FROM dokter";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    object hasil = cmd.ExecuteScalar();

                    if (hasil != null && hasil != DBNull.Value)
                    {
                        string kode = hasil.ToString();

                        // DR-001 -> 001
                        int nomor = Convert.ToInt32(kode.Substring(3));

                        nomor++;

                        txtKodeDokter.Text = "DR-" + nomor.ToString("D3");
                    }
                    else
                    {
                        txtKodeDokter.Text = "DR-001";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    
        private void FrmDokter_Load(object sender, EventArgs e)
        {
            LoadJenisKelamin();
            LoadStatus();
            LoadPoli();

            GenerateKodeDokter();
            Bersih();
            TampilData();
        }

        private void cmbJenisKelamin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPoli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtKodeDokter_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void txtNamaDokter_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlamat_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            Bersih();

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (idDokter == 0)
                SimpanData();
            else
                UbahData();
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
            this.Close();
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            CariData();
        }

        private void dgvDokter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDokter.Rows[e.RowIndex];

                idDokter = Convert.ToInt32(row.Cells[0].Value);

                txtKodeDokter.Text = row.Cells[1].Value.ToString();
                txtNamaDokter.Text = row.Cells[2].Value.ToString();

                cmbJenisKelamin.Text = row.Cells[3].Value.ToString();

                txtNoHP.Text = row.Cells[4].Value.ToString();
                txtEmail.Text = row.Cells[5].Value.ToString();
                txtSpesialisasi.Text = row.Cells[6].Value.ToString();

                cmbPoli.Text = row.Cells[7].Value.ToString();

                txtNomorIzin.Text = row.Cells[8].Value.ToString();

                cmbStatus.Text =
                    row.Cells[9].Value.ToString() == "1"
                    ? "Aktif"
                    : "Tidak Aktif";
            }
        }
    }
}

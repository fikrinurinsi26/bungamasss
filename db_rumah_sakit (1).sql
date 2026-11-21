-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 31 Jul 2026 pada 14.36
-- Versi server: 10.4.32-MariaDB
-- Versi PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_rumah_sakit`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `antrian`
--

CREATE TABLE `antrian` (
  `id_antrian` int(11) NOT NULL,
  `id_pendaftaran` int(11) NOT NULL,
  `nomor_antrian` int(11) NOT NULL,
  `tanggal_antrian` date NOT NULL,
  `status_antrian` enum('Menunggu','Dipanggil','Selesai','Batal') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `detail_resep`
--

CREATE TABLE `detail_resep` (
  `id_detail_resep` int(11) NOT NULL,
  `id_resep` int(11) NOT NULL,
  `id_obat` int(11) NOT NULL,
  `jumlah` int(11) NOT NULL,
  `dosis` varchar(100) NOT NULL,
  `aturan_pakai` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `dokter`
--

CREATE TABLE `dokter` (
  `id_dokter` int(11) NOT NULL,
  `poli_id` int(11) NOT NULL,
  `kode_dokter` varchar(20) NOT NULL,
  `nama_lengkap` varchar(100) NOT NULL,
  `jenis_kelamin` enum('L','P') NOT NULL,
  `nomor_telepon` varchar(20) NOT NULL,
  `alamat_email` varchar(100) NOT NULL,
  `spesialisasi` varchar(100) NOT NULL,
  `nomor_izin_praktik` varchar(50) NOT NULL,
  `status_aktif` tinyint(1) NOT NULL DEFAULT 1,
  `tanggal_dibuat` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `dokter`
--

INSERT INTO `dokter` (`id_dokter`, `poli_id`, `kode_dokter`, `nama_lengkap`, `jenis_kelamin`, `nomor_telepon`, `alamat_email`, `spesialisasi`, `nomor_izin_praktik`, `status_aktif`, `tanggal_dibuat`) VALUES
(1, 13, 'DR-001', 'dr. Ahmad Fauzi', 'L', '081234567800', 'ahmad@rumahsakit.com', 'Penyakit Dalam', 'SIP-123456', 0, '2026-07-27 12:54:54'),
(4, 13, 'DR-002', 'dr.Fikri', 'L', '08993560600', 'fikri@gmail.com', 'penyakit dalam', 'SIP-12333', 1, '2026-07-31 11:35:40');

-- --------------------------------------------------------

--
-- Struktur dari tabel `obat`
--

CREATE TABLE `obat` (
  `id_obat` int(11) NOT NULL,
  `kode_obat` varchar(20) NOT NULL,
  `nama_obat` varchar(100) NOT NULL,
  `kategori_obat` varchar(100) NOT NULL,
  `satuan` varchar(30) NOT NULL,
  `jumlah_stok` int(11) NOT NULL,
  `harga_beli` decimal(15,2) NOT NULL DEFAULT 0.00,
  `harga_jual` decimal(15,2) NOT NULL DEFAULT 0.00,
  `tanggal_kadaluarsa` date NOT NULL,
  `status_aktif` tinyint(1) NOT NULL DEFAULT 1,
  `tanggal_dibuat` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `obat`
--

INSERT INTO `obat` (`id_obat`, `kode_obat`, `nama_obat`, `kategori_obat`, `satuan`, `jumlah_stok`, `harga_beli`, `harga_jual`, `tanggal_kadaluarsa`, `status_aktif`, `tanggal_dibuat`) VALUES
(1, 'OBT-001', 'Paracetamol 500mg', 'Tablet', 'Tablet', 100, 500.00, 1000.00, '2027-12-31', 1, '2026-07-27 13:26:32');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pasien`
--

CREATE TABLE `pasien` (
  `id_pasien` int(11) NOT NULL,
  `nomor_rekam_medis` varchar(20) NOT NULL,
  `nomor_identitas` varchar(30) NOT NULL,
  `nama_lengkap` varchar(100) NOT NULL,
  `jenis_kelamin` enum('L','P') NOT NULL,
  `tempat_lahir` varchar(100) NOT NULL,
  `tanggal_lahir` date NOT NULL,
  `alamat` varchar(250) NOT NULL,
  `nomor_telepon` varchar(20) NOT NULL,
  `golongan_darah` varchar(5) NOT NULL,
  `agama` varchar(30) NOT NULL,
  `status_pernikahan` varchar(30) NOT NULL,
  `pekerjaan` varchar(100) NOT NULL,
  `tanggal_dibuat` timestamp NOT NULL DEFAULT current_timestamp(),
  `tanggal_diubah` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pasien`
--

INSERT INTO `pasien` (`id_pasien`, `nomor_rekam_medis`, `nomor_identitas`, `nama_lengkap`, `jenis_kelamin`, `tempat_lahir`, `tanggal_lahir`, `alamat`, `nomor_telepon`, `golongan_darah`, `agama`, `status_pernikahan`, `pekerjaan`, `tanggal_dibuat`, `tanggal_diubah`) VALUES
(1, 'RM-001', '3200000000000001', 'Budi Santoso', 'L', 'Bandung', '1995-05-10', 'Jl. Merdeka No. 10', '081234567890', 'O', 'Islam', 'Belum Menikah', 'Karyawan Swasta', '2026-07-27 12:47:38', NULL),
(2, 'RM-002', '325873321', 'MuhamaD', 'L', 'bandung', '2026-07-23', 'Jl.Matanegara', '08993560600', 'A', 'Islam', 'Menikah', 'Racing', '2026-07-30 12:40:06', NULL);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pembayaran`
--

CREATE TABLE `pembayaran` (
  `id_pembayaran` int(11) NOT NULL,
  `id_pendaftaran` int(11) NOT NULL,
  `nomor_pembayaran` varchar(30) NOT NULL,
  `tanggal_pembayaran` timestamp NOT NULL DEFAULT current_timestamp(),
  `biaya_konsultasi` decimal(15,2) NOT NULL DEFAULT 0.00,
  `biaya_obat` decimal(15,2) NOT NULL DEFAULT 0.00,
  `biaya_lainnya` decimal(15,2) NOT NULL DEFAULT 0.00,
  `total_biaya` decimal(15,2) NOT NULL DEFAULT 0.00,
  `metode_pembayaran` enum('Tunai','Debit','Transfer','QRIS') NOT NULL,
  `status_pembayaran` enum('Belum Bayar','Lunas') NOT NULL DEFAULT 'Belum Bayar'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `pendaftaran`
--

CREATE TABLE `pendaftaran` (
  `id_pendaftaran` int(11) NOT NULL,
  `nomor_pendaftaran` varchar(30) NOT NULL,
  `id_pasien` int(11) NOT NULL,
  `id_dokter` int(11) NOT NULL,
  `id_poli` int(11) NOT NULL,
  `tanggal_pendaftaran` timestamp NOT NULL DEFAULT current_timestamp(),
  `tanggal_kunjungan` date NOT NULL,
  `keluhan` varchar(250) NOT NULL,
  `status_pendaftaran` enum('Menunggu','Dipanggil','Sedang Diperiksa','Selesai','Batal') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `pendaftaran`
--

INSERT INTO `pendaftaran` (`id_pendaftaran`, `nomor_pendaftaran`, `id_pasien`, `id_dokter`, `id_poli`, `tanggal_pendaftaran`, `tanggal_kunjungan`, `keluhan`, `status_pendaftaran`) VALUES
(2, 'PD-002', 1, 1, 12, '2026-07-15 17:00:00', '2026-07-17', 'sakitperut', '');

-- --------------------------------------------------------

--
-- Struktur dari tabel `poli`
--

CREATE TABLE `poli` (
  `poli_id` int(11) NOT NULL,
  `kode_poli` varchar(10) NOT NULL,
  `nama_poli` varchar(100) NOT NULL,
  `lokasi` varchar(100) NOT NULL,
  `keterangan` text NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `poli`
--

INSERT INTO `poli` (`poli_id`, `kode_poli`, `nama_poli`, `lokasi`, `keterangan`, `is_active`, `created_at`) VALUES
(11, 'PL001', 'Poli Umum', 'Lantai 1', 'Pelayanan umum', 1, '2026-07-28 06:08:27'),
(12, 'PL002', 'Poli Gigi', 'Lantai 1', 'Pelayanan gigi', 1, '2026-07-28 06:08:27'),
(13, 'PL003', 'Poli Anak', 'Lantai 2', 'Pelayanan anak', 1, '2026-07-28 06:08:27'),
(14, 'PL004', 'Poli Kandungan', 'Lantai 2', 'Pelayanan kandungan', 1, '2026-07-28 06:08:27'),
(15, 'PL005', 'Poli Mata', 'Lantai 3', 'Pelayanan mata', 1, '2026-07-28 06:08:27');

-- --------------------------------------------------------

--
-- Struktur dari tabel `rekam_medis`
--

CREATE TABLE `rekam_medis` (
  `id_rekam_medis` int(11) NOT NULL,
  `id_pendaftaran` int(11) NOT NULL,
  `id_dokter` int(11) NOT NULL,
  `tanggal_pemeriksaan` timestamp NOT NULL DEFAULT current_timestamp(),
  `keluhan` text NOT NULL,
  `diagnosis` text NOT NULL,
  `tekanan_darah` varchar(20) NOT NULL,
  `suhu_tubuh` decimal(4,1) NOT NULL,
  `berat_badan` decimal(5,2) NOT NULL,
  `tinggi_badan` decimal(5,2) NOT NULL,
  `tindakan` text NOT NULL,
  `catatan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `resep`
--

CREATE TABLE `resep` (
  `id_resep` int(11) NOT NULL,
  `id_rekam_medis` int(11) NOT NULL,
  `tanggal_resep` timestamp NOT NULL DEFAULT current_timestamp(),
  `status_resep` enum('Menunggu','Diproses','Selesai') NOT NULL DEFAULT 'Menunggu'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `roles`
--

CREATE TABLE `roles` (
  `role_id` int(11) NOT NULL,
  `role_name` varchar(50) NOT NULL,
  `description` varchar(255) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `roles`
--

INSERT INTO `roles` (`role_id`, `role_name`, `description`, `created_at`) VALUES
(1, 'Administrator', 'Mengelola seluruh sistem', '2026-07-27 12:25:58'),
(2, 'Dokter', 'Melakukan pemeriksaan pasien', '2026-07-27 12:25:58'),
(3, 'Perawat', 'Mengelola antrian dan pemeriksaan awal', '2026-07-27 12:25:58'),
(4, 'Apoteker', 'Mengelola obat dan resep', '2026-07-27 12:25:58'),
(5, 'Kasir', 'Mengelola pembayaran', '2026-07-27 12:25:58'),
(6, 'Pendaftaran', 'Mengelola pendaftaran pasien', '2026-07-27 12:25:58');

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `role_id` int(11) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`user_id`, `role_id`, `full_name`, `username`, `password`, `is_active`, `created_at`) VALUES
(1, 1, 'Fikri', 'admin', 'admin123', 1, '2026-07-27 12:34:51');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `antrian`
--
ALTER TABLE `antrian`
  ADD PRIMARY KEY (`id_antrian`);

--
-- Indeks untuk tabel `detail_resep`
--
ALTER TABLE `detail_resep`
  ADD PRIMARY KEY (`id_detail_resep`);

--
-- Indeks untuk tabel `dokter`
--
ALTER TABLE `dokter`
  ADD PRIMARY KEY (`id_dokter`),
  ADD UNIQUE KEY `kode_dokter` (`kode_dokter`);

--
-- Indeks untuk tabel `obat`
--
ALTER TABLE `obat`
  ADD PRIMARY KEY (`id_obat`),
  ADD UNIQUE KEY `kode_obat` (`kode_obat`);

--
-- Indeks untuk tabel `pasien`
--
ALTER TABLE `pasien`
  ADD PRIMARY KEY (`id_pasien`),
  ADD UNIQUE KEY `nomor_rekam_medis` (`nomor_rekam_medis`);

--
-- Indeks untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  ADD PRIMARY KEY (`id_pembayaran`),
  ADD UNIQUE KEY `nomor_pembayaran` (`nomor_pembayaran`);

--
-- Indeks untuk tabel `pendaftaran`
--
ALTER TABLE `pendaftaran`
  ADD PRIMARY KEY (`id_pendaftaran`),
  ADD UNIQUE KEY `nomor_pendaftaran` (`nomor_pendaftaran`);

--
-- Indeks untuk tabel `poli`
--
ALTER TABLE `poli`
  ADD PRIMARY KEY (`poli_id`),
  ADD UNIQUE KEY `kode_poli` (`kode_poli`);

--
-- Indeks untuk tabel `rekam_medis`
--
ALTER TABLE `rekam_medis`
  ADD PRIMARY KEY (`id_rekam_medis`);

--
-- Indeks untuk tabel `resep`
--
ALTER TABLE `resep`
  ADD PRIMARY KEY (`id_resep`);

--
-- Indeks untuk tabel `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`role_id`),
  ADD UNIQUE KEY `role_name` (`role_name`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `antrian`
--
ALTER TABLE `antrian`
  MODIFY `id_antrian` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `detail_resep`
--
ALTER TABLE `detail_resep`
  MODIFY `id_detail_resep` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `dokter`
--
ALTER TABLE `dokter`
  MODIFY `id_dokter` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT untuk tabel `obat`
--
ALTER TABLE `obat`
  MODIFY `id_obat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT untuk tabel `pasien`
--
ALTER TABLE `pasien`
  MODIFY `id_pasien` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT untuk tabel `pembayaran`
--
ALTER TABLE `pembayaran`
  MODIFY `id_pembayaran` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `pendaftaran`
--
ALTER TABLE `pendaftaran`
  MODIFY `id_pendaftaran` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `poli`
--
ALTER TABLE `poli`
  MODIFY `poli_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT untuk tabel `rekam_medis`
--
ALTER TABLE `rekam_medis`
  MODIFY `id_rekam_medis` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `resep`
--
ALTER TABLE `resep`
  MODIFY `id_resep` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT untuk tabel `roles`
--
ALTER TABLE `roles`
  MODIFY `role_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

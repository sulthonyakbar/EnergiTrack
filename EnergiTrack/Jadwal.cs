using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiTrack
{
    public enum StatusJadwal
    {
        DRAFT,
        AKTIF,
        SELESAI
    }

    public enum Aksi
    {
        MULAI,
        SELESAIKAN,
        RESET
    }

    public class Jadwal
    {
        public int Id { get; set; }
        public string NamaPerangkat { get; set; }
        public string Hari { get; set; }
        public TimeSpan JamMulai { get; set; }
        public TimeSpan JamSelesai { get; set; }
        public StatusJadwal Status { get; set; }

        public Jadwal(int id, string namaPerangkat, string hari, TimeSpan mulai, TimeSpan selesai)
        {
            if (string.IsNullOrWhiteSpace(namaPerangkat)) throw new ArgumentException("Nama perangkat tidak boleh kosong.");
            if (mulai >= selesai) throw new ArgumentException("Jam mulai harus lebih awal dari jam selesai.");

            Id = id;
            NamaPerangkat = namaPerangkat;
            Hari = hari;
            JamMulai = mulai;
            JamSelesai = selesai;
            Status = StatusJadwal.DRAFT;
        }
    }
}

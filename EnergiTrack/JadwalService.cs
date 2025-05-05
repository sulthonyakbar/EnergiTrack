using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergiTrack
{
    public static class JadwalManager
    {
        private static List<Jadwal> daftarJadwal = new();

        private static Dictionary<(StatusJadwal, Aksi), StatusJadwal> transisi = new()
        {
            {(StatusJadwal.DRAFT, Aksi.MULAI), StatusJadwal.AKTIF},
            {(StatusJadwal.AKTIF, Aksi.SELESAIKAN), StatusJadwal.SELESAI},
            {(StatusJadwal.SELESAI, Aksi.RESET), StatusJadwal.DRAFT}
        };

        public static void TambahJadwal(string nama, string hari, TimeSpan mulai, TimeSpan selesai)
        {
            int id = daftarJadwal.Count + 1;
            Jadwal j = new(id, nama, hari, mulai, selesai);
            daftarJadwal.Add(j);
            Console.WriteLine($"Jadwal '{nama}' ditambahkan untuk hari {hari} pukul {mulai}-{selesai} dengan status {j.Status}.");
        }

        public static void TampilkanJadwal()
        {
            foreach (var j in daftarJadwal)
            {
                Console.WriteLine($"ID: {j.Id} | Perangkat: {j.NamaPerangkat} | Hari: {j.Hari} | {j.JamMulai}-{j.JamSelesai} | Status: {j.Status}");
            }
        }

        public static void UbahStatus(int id, Aksi aksi)
        {
            var jadwal = daftarJadwal.Find(j => j.Id == id);
            if (jadwal != null && transisi.ContainsKey((jadwal.Status, aksi)))
            {
                var statusLama = jadwal.Status;
                jadwal.Status = transisi[(jadwal.Status, aksi)];
                Console.WriteLine($"Status Jadwal untuk perangkat '{jadwal.NamaPerangkat}' berubah dari {statusLama} ke {jadwal.Status}");
            }
            else
            {
                Console.WriteLine("Status tidak valid atau jadwal tidak ditemukan.");
            }
        }

        public static void HapusJadwal(int id)
        {
            var jadwal = daftarJadwal.Find(j => j.Id == id);
            if (jadwal != null)
            {
                daftarJadwal.Remove(jadwal);
                Console.WriteLine($"Jadwal untuk perangkat '{jadwal.NamaPerangkat}' dihapus.");
            }
            else
            {
                Console.WriteLine("Jadwal tidak ditemukan.");
            }
        }
    }
}

using EnergiTrack;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== MENU JADWAL PERANGKAT ===");
            Console.WriteLine("1. Tambah Jadwal");
            Console.WriteLine("2. Edit Jadwal");
            Console.WriteLine("3. Hapus Jadwal");
            Console.WriteLine("4. Ubah Status Jadwal");
            Console.WriteLine("5. Tampilkan Semua Jadwal");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih opsi (1-6): ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    TambahJadwal();
                    break;
                case "2":
                    EditJadwal();
                    break;
                case "3":
                    HapusJadwal();
                    break;
                case "4":
                    UbahStatusJadwal();
                    break;
                case "5":
                    JadwalService.TampilkanJadwal();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }

            Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadLine();
        }
    }

    static void TambahJadwal()
    {
        Console.Write("Nama Perangkat: ");
        string nama = Console.ReadLine();

        Console.Write("Hari: ");
        string hari = Console.ReadLine();

        Console.Write("Jam Mulai (hh:mm): ");
        TimeSpan mulai = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Jam Selesai (hh:mm): ");
        TimeSpan selesai = TimeSpan.Parse(Console.ReadLine());

        JadwalService.TambahJadwal(nama, hari, mulai, selesai);
    }

    static void EditJadwal()
    {
        Console.Write("ID Jadwal yang akan diedit: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nama Baru Perangkat: ");
        string nama = Console.ReadLine();

        Console.Write("Hari Baru: ");
        string hari = Console.ReadLine();

        Console.Write("Jam Mulai Baru (hh:mm): ");
        TimeSpan mulai = TimeSpan.Parse(Console.ReadLine());

        Console.Write("Jam Selesai Baru (hh:mm): ");
        TimeSpan selesai = TimeSpan.Parse(Console.ReadLine());

        JadwalService.EditJadwal(id, nama, hari, mulai, selesai);
    }

    static void HapusJadwal()
    {
        Console.Write("ID Jadwal yang akan dihapus: ");
        int id = int.Parse(Console.ReadLine());

        JadwalService.HapusJadwal(id);
    }

    static void UbahStatusJadwal()
    {
        Console.Write("ID Jadwal: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Aksi: (1 = MULAI, 2 = SELESAIKAN, 3 = RESET)");
        string aksiInput = Console.ReadLine();

        Aksi aksi = aksiInput switch
        {
            "1" => Aksi.MULAI,
            "2" => Aksi.SELESAIKAN,
            "3" => Aksi.RESET,
            _ => throw new ArgumentException("Aksi tidak valid")
        };

        JadwalService.UbahStatus(id, aksi);
    }
}
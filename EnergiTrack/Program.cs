using EnergiTrack;
class Program
{
    static void Main()
    {
        JadwalManager.TambahJadwal("Kulkas", "Senin", new TimeSpan(06, 00, 00), new TimeSpan(12, 00, 00));
        JadwalManager.TambahJadwal("AC", "Selasa", new TimeSpan(18, 00, 00), new TimeSpan(23, 00, 00));
        JadwalManager.TampilkanJadwal();

        JadwalManager.UbahStatus(1, Aksi.MULAI);
        JadwalManager.UbahStatus(1, Aksi.SELESAIKAN);
        JadwalManager.UbahStatus(1, Aksi.RESET);
        JadwalManager.TampilkanJadwal();

        JadwalManager.HapusJadwal(2);
        JadwalManager.TampilkanJadwal();
    }
}
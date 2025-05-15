
                Console.Write("Pilih: ");
namespace LabReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var categoryService = new LabReservationSystem.Services.CrudService<LabReservationSystem.Domain.Category>();

            while (true)
            {
                Console.WriteLine("\n=== CRUD Kategori ===");
                Console.WriteLine("1. Tambah Kategori");
                Console.WriteLine("2. Lihat Semua Kategori");
                Console.WriteLine("3. Edit Kategori");
                Console.WriteLine("4. Hapus Kategori");
                Console.WriteLine("0. Keluar");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Nama Kategori: ");
                        var name = Console.ReadLine();
                        categoryService.Add(new LabReservationSystem.Domain.Category { Name = name });
                        Console.WriteLine("Kategori berhasil ditambahkan!");
                        break;

                    case "2":
                        var categories = categoryService.GetAll();
                        Console.WriteLine("\n--- Daftar Kategori ---");
                        foreach (var cat in categories)
                        {
                            Console.WriteLine($"ID: {cat.Id}, Nama: {cat.Name}");
                        }
                        break;

                    case "3":
                        Console.Write("ID Kategori: ");
                        int editId = int.Parse(Console.ReadLine()!);
                        Console.Write("Nama Baru: ");
                        var newName = Console.ReadLine();
                        categoryService.Edit(editId, new LabReservationSystem.Domain.Category { Id = editId, Name = newName });
                        Console.WriteLine("Kategori berhasil diubah!");
                        break;

                    case "4":
                        Console.Write("ID Kategori: ");
                        int deleteId = int.Parse(Console.ReadLine()!);
                        categoryService.Delete(deleteId);
                        Console.WriteLine("Kategori berhasil dihapus!");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Pilihan tidak valid!");
                        break;
                }
            }
        }
    }
}

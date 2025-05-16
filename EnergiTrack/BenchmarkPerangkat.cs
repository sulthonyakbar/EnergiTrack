using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnergiTrack;

public class BenchmarkPerangkat
{
    [GlobalSetup]
    public void Setup()
    {
        PerangkatService.Reset();
        // Tambah satu perangkat sebagai baseline untuk edit dan hapus, agar tidak dihitung overhead tambah di benchmark tsb
        PerangkatService.TambahPerangkat("PerangkatBaseline", 50);
    }

    [Benchmark]
    public void TambahPerangkat()
    {
        PerangkatService.TambahPerangkat("Lampu", 100);
    }

    [Benchmark]
    public void EditPerangkat()
    {
        // edit perangkat baseline agar hasil benchmark hanya hitung edit saja
        var p = PerangkatService.GetPerangkatById(1);
        PerangkatService.EditPerangkat(p.Id, "Kipas Angin", 80);
    }

    [Benchmark]
    public void HapusPerangkat()
    {
        // hapus perangkat baseline
        var p = PerangkatService.GetPerangkatById(1);
        PerangkatService.HapusPerangkat(p.Id);
        // tambahkan kembali agar benchmark berikutnya tidak error
        PerangkatService.TambahPerangkat("PerangkatBaseline", 50);
    }
}


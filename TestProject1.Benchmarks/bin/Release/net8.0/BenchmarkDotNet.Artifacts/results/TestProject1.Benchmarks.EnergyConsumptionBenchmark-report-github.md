```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.200
  [Host]     : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 8.0.13 (8.0.1325.6609), X64 RyuJIT AVX2


```
| Method                 | Mean         | Error        | StdDev        | Median       | Gen0      | Gen1      | Gen2     | Allocated  |
|----------------------- |-------------:|-------------:|--------------:|-------------:|----------:|----------:|---------:|-----------:|
| TestAddConsumption     | 16,327.19 μs | 1,812.180 μs |  5,314.811 μs | 14,309.96 μs | 1000.0000 |  968.7500 | 398.4375 |  6257042 B |
| TestEditConsumption    | 35,466.67 μs | 3,578.894 μs | 10,268.519 μs | 32,998.65 μs | 2343.7500 | 2250.0000 | 843.7500 | 15735869 B |
| TestRemoveConsumption  | 35,720.57 μs | 1,271.829 μs |  3,460.106 μs | 35,153.56 μs | 2111.1111 | 2000.0000 | 666.6667 | 15741249 B |
| TestCalculateTotalCost |     42.43 μs |     1.626 μs |      4.770 μs |     42.52 μs |         - |         - |        - |          - |

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
Intel Core i3-8100 CPU 3.60GHz (Coffee Lake), 1 CPU, 4 logical and 4 physical cores
.NET SDK=5.0.102
  [Host]     : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.2 (5.0.220.61120), X64 RyuJIT


```
| Method |     Mean |    Error |   StdDev |
|------- |---------:|---------:|---------:|
| Sha256 | 44.38 μs | 0.055 μs | 0.049 μs |
|    Md5 | 19.13 μs | 0.018 μs | 0.016 μs |

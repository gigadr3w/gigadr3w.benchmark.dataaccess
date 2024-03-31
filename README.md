# Benchmark ~ ADO.Net vs EF vs DAPPER
A complete sandbox with a mssql-docker container and Benchmark.Net for a comparison between ADO.Net, EF and Dapper

...please be patient during the execution (it may be take a long) ;)

Here the results:

```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3374/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method | RecordCount | Mean         | Error        | StdDev       | Median       | Gen0      | Gen1      | Gen2     | Allocated   |
|------- |------------ |-------------:|-------------:|-------------:|-------------:|----------:|----------:|---------:|------------:|
| ADO    | 10000       |     19.78 ms |     0.344 ms |     0.322 ms |     19.79 ms |    437.50 |    406.25 |   187.50 |     5.13 MB |
| EF     | 10000       |     33.76 ms |     0.675 ms |     1.089 ms |     33.46 ms |   1466.66 |   1400.00 |   466.66 |    13.87 MB |
| DAPPER | 10000       |     32.15 ms |     1.782 ms |     5.254 ms |     33.32 ms |    375.00 |    312.50 |   156.25 |      4.6 MB |
| ADO    | 100000      |    236.75 ms |     4.573 ms |     8.810 ms |    238.47 ms |   5000.00 |   4000.00 |  1000.00 |     50.8 MB |
| EF     | 100000      |    427.56 ms |    17.161 ms |    50.329 ms |    434.37 ms |  14000.00 |  12000.00 |  5000.00 |    135.7 MB |
| DAPPER | 100000      |    247.20 ms |     4.916 ms |    13.207 ms |    247.90 ms |   4666.66 |   4333.33 |  1333.33 |    45.46 MB |
| ADO    | 1000000     |  3,445.28 ms |   176.233 ms |   519.627 ms |  3,547.52 ms |  52000.00 |  51000.00 | 12000.00 |   503.99 MB |
| EF     | 1000000     |  4,994.63 ms |   275.965 ms |   813.688 ms |  4,578.56 ms | 101000.00 | 100000.00 |  3000.00 |  1334.63 MB |
| DAPPER | 1000000     |  2,421.47 ms |    69.226 ms |   203.029 ms |  2,401.54 ms |  39000.00 |  38000.00 |  4000.00 |   450.58 MB |
| ADO    | 10000000    | 23,690.78 ms | 1,214.037 ms | 3,541.403 ms | 22,811.76 ms | 410000.00 | 409000.00 |  3000.00 |  5135.76 MB |
| EF     | 10000000    | 46,696.58 ms |   899.213 ms | 1,230.852 ms | 46,879.07 ms | 984000.00 | 983000.00 |  3000.00 | 13261.96 MB |
| DAPPER | 10000000    | 23,167.90 ms |   462.907 ms |   996.455 ms | 22,994.92 ms | 361000.00 | 360000.00 |  5000.00 |   4601.7 MB |

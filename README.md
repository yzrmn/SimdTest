# SimdTest
SIMD performance test for .NET (C#)

Typical output (Intel i5 2500K):

```
IsHardwareAccelerated = True
Length = 8000000 (Total Memory: 236 MB)
------------------------------------------------------
1 - NoSimdNoCastShort           9 ms    31171 Ticks
1 - SimdNoCastShort             1 ms    5510 Ticks
2 - NoSimdNoCastInt             11 ms   35502 Ticks
2 - SimdNoCastInt               4 ms    14057 Ticks
3 - NoSimdNoCastFloat           12 ms   39673 Ticks
3 - SimdNoCastFloat             3 ms    10301 Ticks
4 - NoSimdCastIntToByte         9 ms    29918 Ticks
4 - SimdBothCastIntToByte       11 ms   36323 Ticks
4 - SimdPreCastIntToFloat       26 ms   84199 Ticks
4 - SimdPostCastFloatToByte     11 ms   35852 Ticks
4 - SimdBothCastWithFloat       36 ms   119309 Ticks
------------------------------------------------------
1 - NoSimdNoCastShort           7 ms    23226 Ticks
1 - SimdNoCastShort             1 ms    4421 Ticks
2 - NoSimdNoCastInt             6 ms    21425 Ticks
2 - SimdNoCastInt               3 ms    12781 Ticks
3 - NoSimdNoCastFloat           7 ms    25580 Ticks
3 - SimdNoCastFloat             2 ms    9487 Ticks
4 - NoSimdCastIntToByte         7 ms    24852 Ticks
4 - SimdBothCastIntToByte       10 ms   34920 Ticks
4 - SimdPreCastIntToFloat       25 ms   81587 Ticks
4 - SimdPostCastFloatToByte     10 ms   34537 Ticks
4 - SimdBothCastWithFloat       38 ms   124047 Ticks
------------------------------------------------------
1 - NoSimdNoCastShort           7 ms    23196 Ticks
1 - SimdNoCastShort             1 ms    4427 Ticks
2 - NoSimdNoCastInt             6 ms    21296 Ticks
2 - SimdNoCastInt               3 ms    12812 Ticks
3 - NoSimdNoCastFloat           7 ms    25677 Ticks
3 - SimdNoCastFloat             2 ms    9181 Ticks
4 - NoSimdCastIntToByte         7 ms    24846 Ticks
4 - SimdBothCastIntToByte       10 ms   34865 Ticks
4 - SimdPreCastIntToFloat       25 ms   81750 Ticks
4 - SimdPostCastFloatToByte     10 ms   34389 Ticks
4 - SimdBothCastWithFloat       36 ms   116851 Ticks
```

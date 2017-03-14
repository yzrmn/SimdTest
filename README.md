# SimdTest
SIMD performance test for .NET (C#)

Typical output (Intel i5 2500K):

```
IsHardwareAccelerated = True
--------------------------------------
NoSimdNoCast    6 ms    19797 Ticks
NoSimdCastBoth  5 ms    16346 Ticks
SimdNoCast      1 ms    5526 Ticks
SimdCastPre     13 ms   43060 Ticks
SimdCastPost    6 ms    19599 Ticks
SimdCastBoth    18 ms   60648 Ticks
--------------------------------------
NoSimdNoCast    3 ms    12818 Ticks
NoSimdCastBoth  3 ms    12396 Ticks
SimdNoCast      1 ms    4503 Ticks
SimdCastPre     13 ms   44089 Ticks
SimdCastPost    5 ms    18064 Ticks
SimdCastBoth    18 ms   60514 Ticks
--------------------------------------
NoSimdNoCast    3 ms    12856 Ticks
NoSimdCastBoth  3 ms    12388 Ticks
SimdNoCast      1 ms    4392 Ticks
SimdCastPre     12 ms   40898 Ticks
SimdCastPost    5 ms    18307 Ticks
SimdCastBoth    18 ms   58502 Ticks
--------------------------------------
NoSimdNoCast    4 ms    12917 Ticks
NoSimdCastBoth  3 ms    12378 Ticks
SimdNoCast      1 ms    4361 Ticks
SimdCastPre     12 ms   40964 Ticks
SimdCastPost    5 ms    18275 Ticks
SimdCastBoth    19 ms   62025 Ticks
```

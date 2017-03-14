using System;
using System.Diagnostics;
using System.Numerics;

namespace SimdTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = 1000000 * Vector<float>.Count;
            var stopwatch = new Stopwatch();
            var random = new Random();

            var input1 = new float[length];
            var input2 = new float[length];
            var input3 = new int[length];
            var input4 = new int[length];
            var result1 = new float[length];
            var result2 = new byte[length];

            for (int i = 0; i < length; i++)
            {
                input1[i] = random.Next(15);
                input2[i] = random.Next(15);
                input3[i] = random.Next(15);
                input4[i] = random.Next(15);
            }

            Console.WriteLine("IsHardwareAccelerated = {0}", Vector.IsHardwareAccelerated);

            while (true)
            {
                Console.WriteLine("--------------------------------------");

                stopwatch.Restart();
                Program.NoSimdNoCast(input1, input2, result1);
                stopwatch.Stop();
                Console.WriteLine("NoSimdNoCast\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.NoSimdCastBoth(input3, input4, result2);
                stopwatch.Stop();
                Console.WriteLine("NoSimdCastBoth\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdNoCast(input1, input2, result1);
                stopwatch.Stop();
                Console.WriteLine("SimdNoCast\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdCastPre(input3, input4, result1);
                stopwatch.Stop();
                Console.WriteLine("SimdCastPre\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdCastPost(input1, input2, result2);
                stopwatch.Stop();
                Console.WriteLine("SimdCastPost\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdCastBoth(input3, input4, result2);
                stopwatch.Stop();
                Console.WriteLine("SimdCastBoth\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                Console.ReadKey();
            }
        }

        static void NoSimdNoCast(float[] input1, float[] input2, float[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input1[i] * input2[i];
            }
        }

        static void NoSimdCastBoth(int[] input1, int[] input2, byte[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)(input1[i] * input2[i]);
            }
        }

        static void SimdNoCast(float[] input1, float[] input2, float[] result)
        {
            var simdLength = Vector<float>.Count;

            for (int i = 0; i < result.Length; i += simdLength)
            {
                var vinput1 = new Vector<float>(input1);
                var vinput2 = new Vector<float>(input2);

                var vresult = vinput1 * vinput2;

                vresult.CopyTo(result, i);
            }
        }

        static void SimdCastPre(int[] input1, int[] input2, float[] result)
        {
            var simdLength = Vector<float>.Count;

            var buffer1 = new float[4];
            var buffer2 = new float[4];

            for (int i = 0; i < result.Length; i += simdLength)
            {
                for (int j = 0; j < 4; j++)
                {
                    buffer1[j] = input1[i + j];
                    buffer2[j] = input2[i + j];
                }

                var vinput1 = new Vector<float>(buffer1);
                var vinput2 = new Vector<float>(buffer2);

                var vresult = vinput1 * vinput2;

                vresult.CopyTo(result, i);
            }
        }

        static void SimdCastPost(float[] input1, float[] input2, byte[] result)
        {
            var simdLength = Vector<float>.Count;

            for (int i = 0; i < result.Length; i += simdLength)
            {
                var vinput1 = new Vector<float>(input1);
                var vinput2 = new Vector<float>(input2);

                var vresult = vinput1 * vinput2;

                for (int j = 0; j < 4; j++)
                {
                    result[i + j] = (byte)vresult[j];
                }
            }
        }

        static void SimdCastBoth(int[] input1, int[] input2, byte[] result)
        {
            var simdLength = Vector<float>.Count;

            var buffer1 = new float[4];
            var buffer2 = new float[4];

            for (int i = 0; i < result.Length; i += simdLength)
            {
                for (int j = 0; j < 4; j++)
                {
                    buffer1[j] = input1[i + j];
                    buffer2[j] = input2[i + j];
                }

                var vinput1 = new Vector<float>(buffer1);
                var vinput2 = new Vector<float>(buffer2);

                var vresult = vinput1 * vinput2;

                for (int j = 0; j < 4; j++)
                {
                    result[i + j] = (byte)vresult[j];
                }
            }
        }
    }
}
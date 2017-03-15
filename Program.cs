using System;
using System.Diagnostics;
using System.Numerics;

namespace SimdTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = 1000000 * Vector<short>.Count;
            var stopwatch = new Stopwatch();
            var random = new Random();

            var inputShort1 = new short[length];
            var inputShort2 = new short[length];
            var inputInt1 = new int[length];
            var inputInt2 = new int[length];
            var inputFloat1 = new float[length];
            var inputFloat2 = new float[length];

            var resultByte = new byte[length];
            var resultShort = new short[length];
            var resultInt = new int[length];
            var resultFloat = new float[length];

            for (int i = 0; i < length; i++)
            {
                inputShort1[i] = (short)random.Next(15);
                inputShort2[i] = (short)random.Next(15);

                inputInt1[i] = random.Next(15);
                inputInt2[i] = random.Next(15);

                inputFloat1[i] = random.Next(15);
                inputFloat2[i] = random.Next(15);
            }

            Console.WriteLine("IsHardwareAccelerated = {0}", Vector.IsHardwareAccelerated);
            Console.WriteLine("Length = {0} (Total Memory: {1} MB)", length, (length * 31) / (1024 * 1024));

            while (true)
            {
                Console.WriteLine("------------------------------------------------------");

                stopwatch.Restart();
                Program.NoSimdNoCastShort(inputShort1, inputShort2, resultShort);
                stopwatch.Stop();
                Console.WriteLine("1 - NoSimdNoCastShort\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdNoCastShort(inputShort1, inputShort2, resultShort);
                stopwatch.Stop();
                Console.WriteLine("1 - SimdNoCastShort\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.NoSimdNoCastInt(inputInt1, inputInt2, resultInt);
                stopwatch.Stop();
                Console.WriteLine("2 - NoSimdNoCastInt\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdNoCastInt(inputInt1, inputInt2, resultInt);
                stopwatch.Stop();
                Console.WriteLine("2 - SimdNoCastInt\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.NoSimdNoCastFloat(inputFloat1, inputFloat2, resultFloat);
                stopwatch.Stop();
                Console.WriteLine("3 - NoSimdNoCastFloat\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdNoCastFloat(inputFloat1, inputFloat2, resultFloat);
                stopwatch.Stop();
                Console.WriteLine("3 - SimdNoCastFloat\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.NoSimdCastIntToByte(inputInt1, inputInt2, resultByte);
                stopwatch.Stop();
                Console.WriteLine("4 - NoSimdCastIntToByte\t\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdBothCastIntToByte(inputInt1, inputInt2, resultByte);
                stopwatch.Stop();
                Console.WriteLine("4 - SimdBothCastIntToByte\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdPreCastIntToFloat(inputInt1, inputInt2, resultFloat);
                stopwatch.Stop();
                Console.WriteLine("4 - SimdPreCastIntToFloat\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdPostCastFloatToByte(inputFloat1, inputFloat2, resultByte);
                stopwatch.Stop();
                Console.WriteLine("4 - SimdPostCastFloatToByte\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                stopwatch.Restart();
                Program.SimdBothCastWithFloat(inputInt1, inputInt2, resultByte);
                stopwatch.Stop();
                Console.WriteLine("4 - SimdBothCastWithFloat\t{0} ms\t{1} Ticks",
                    stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

                Console.ReadKey();
            }
        }

        static void NoSimdNoCastShort(short[] input1, short[] input2, short[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (short)(input1[i] * input2[i]);
            }
        }

        static void NoSimdNoCastInt(int[] input1, int[] input2, int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input1[i] * input2[i];
            }
        }

        static void NoSimdNoCastFloat(float[] input1, float[] input2, float[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = input1[i] * input2[i];
            }
        }

        static void NoSimdCastIntToByte(int[] input1, int[] input2, byte[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)(input1[i] * input2[i]);
            }
        }

        static void SimdNoCastShort(short[] input1, short[] input2, short[] result)
        {
            var simdLength = Vector<short>.Count;

            for (int i = 0; i < result.Length; i += simdLength)
            {
                var vinput1 = new Vector<short>(input1);
                var vinput2 = new Vector<short>(input2);

                var vresult = vinput1 * vinput2;

                vresult.CopyTo(result, i);
            }
        }

        static void SimdNoCastInt(int[] input1, int[] input2, int[] result)
        {
            var simdLength = Vector<int>.Count;

            for (int i = 0; i < result.Length; i += simdLength)
            {
                var vinput1 = new Vector<int>(input1);
                var vinput2 = new Vector<int>(input2);

                var vresult = vinput1 * vinput2;

                vresult.CopyTo(result, i);
            }
        }

        static void SimdNoCastFloat(float[] input1, float[] input2, float[] result)
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

        static void SimdBothCastIntToByte(int[] input1, int[] input2, byte[] result)
        {
            var simdLength = Vector<int>.Count;

            for (int i = 0; i < result.Length; i += simdLength)
            {
                var vinput1 = new Vector<int>(input1);
                var vinput2 = new Vector<int>(input2);

                var vresult = vinput1 * vinput2;

                for (int j = 0; j < 4; j++)
                {
                    result[i + j] = (byte)vresult[j];
                }
            }
        }

        static void SimdPreCastIntToFloat(int[] input1, int[] input2, float[] result)
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

        static void SimdPostCastFloatToByte(float[] input1, float[] input2, byte[] result)
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

        static void SimdBothCastWithFloat(int[] input1, int[] input2, byte[] result)
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
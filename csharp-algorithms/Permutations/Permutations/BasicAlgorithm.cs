namespace ListAllThePermutationsOfStringInCSharp
{
    public class BasicAlgorithm : IPermutation
    {
        public List<byte[]> GetPermutations(byte number)
        {
            return GeneratePermutations(number, false);
        }

        public void BenchmarkPermutations(byte number)
        {
            GeneratePermutations(number, true);
        }

        private List<byte[]> GeneratePermutations(byte number, bool doBenchmarks)
        {
            var input = Enumerable.Range(0, number).Select(i => (byte)i).ToArray();

            return number switch
            {
                1 => GetPermutations1(input, doBenchmarks),
                2 => GetPermutations2(input, doBenchmarks),
                3 => GetPermutations3(input, doBenchmarks),
                4 => GetPermutations4(input, doBenchmarks),
                5 => GetPermutations5(input, doBenchmarks),
                6 => GetPermutations6(input, doBenchmarks),
                7 => GetPermutations7(input, doBenchmarks),
                8 => GetPermutations8(input, doBenchmarks),
                _ => throw new ArgumentException("Number of number symbols too big"),
            };
        }

        private List<byte[]> GetPermutations1(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            if (!doBenchmarks) result.AddCopy(input);

            return result;
        }

        private List<byte[]> GetPermutations2(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    if (i0 != i1)
                    {
                        input[0] = i0;
                        input[1] = i1;
                        if (!doBenchmarks) result.AddCopy(input);
                    }

            return result;
        }

        private List<byte[]> GetPermutations3(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        if ((i0 != i1) && (i0 != i2) &&
                            (i1 != i2))
                        {
                            input[0] = i0;
                            input[1] = i1;
                            input[2] = i2;
                            if (!doBenchmarks) result.AddCopy(input);
                        }

            return result;
        }

        private List<byte[]> GetPermutations4(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        for (byte i3 = 0; i3 < number; ++i3)
                            if ((i0 != i1) && (i0 != i2) && (i0 != i3) &&
                                (i1 != i2) && (i1 != i3) &&
                                (i2 != i3))
                            {
                                input[0] = i0;
                                input[1] = i1;
                                input[2] = i2;
                                input[3] = i3;
                                if (!doBenchmarks) result.AddCopy(input);
                            }

            return result;
        }

        private List<byte[]> GetPermutations5(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        for (byte i3 = 0; i3 < number; ++i3)
                            for (byte i4 = 0; i4 < number; ++i4)
                                if ((i0 != i1) && (i0 != i2) && (i0 != i3) && (i0 != i4) &&
                                    (i1 != i2) && (i1 != i3) && (i1 != i4) &&
                                    (i2 != i3) && (i2 != i4) &&
                                    (i3 != i4))
                                {
                                    input[0] = i0;
                                    input[1] = i1;
                                    input[2] = i2;
                                    input[3] = i3;
                                    input[4] = i4;
                                    if (!doBenchmarks) result.AddCopy(input);
                                }

            return result;
        }

        private List<byte[]> GetPermutations6(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        for (byte i3 = 0; i3 < number; ++i3)
                            for (byte i4 = 0; i4 < number; ++i4)
                                for (byte i5 = 0; i5 < number; ++i5)
                                    if ((i0 != i1) && (i0 != i2) && (i0 != i3) && (i0 != i4) && (i0 != i5) &&
                                        (i1 != i2) && (i1 != i3) && (i1 != i4) && (i1 != i5) &&
                                        (i2 != i3) && (i2 != i4) && (i2 != i5) &&
                                        (i3 != i4) && (i3 != i5) &&
                                        (i4 != i5))
                                    {
                                        input[0] = i0;
                                        input[1] = i1;
                                        input[2] = i2;
                                        input[3] = i3;
                                        input[4] = i4;
                                        input[5] = i5;
                                        if (!doBenchmarks) result.AddCopy(input);
                                    }

            return result;
        }

        private List<byte[]> GetPermutations7(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        for (byte i3 = 0; i3 < number; ++i3)
                            for (byte i4 = 0; i4 < number; ++i4)
                                for (byte i5 = 0; i5 < number; ++i5)
                                    for (byte i6 = 0; i6 < number; ++i6)
                                        if ((i0 != i1) && (i0 != i2) && (i0 != i3) && (i0 != i4) && (i0 != i5) && (i0 != i6) &&
                                        (i1 != i2) && (i1 != i3) && (i1 != i4) && (i1 != i5) && (i1 != i6) &&
                                        (i2 != i3) && (i2 != i4) && (i2 != i5) && (i2 != i6) &&
                                        (i3 != i4) && (i3 != i5) && (i3 != i6) &&
                                        (i4 != i5) && (i4 != i6) &&
                                        (i5 != i6))
                                        {
                                            input[0] = i0;
                                            input[1] = i1;
                                            input[2] = i2;
                                            input[3] = i3;
                                            input[4] = i4;
                                            input[5] = i5;
                                            input[6] = i6;
                                            if (!doBenchmarks) result.AddCopy(input);
                                        }

            return result;
        }

        private List<byte[]> GetPermutations8(byte[] input, bool doBenchmarks)
        {
            var result = new List<byte[]>();
            var number = input.Length;

            for (byte i0 = 0; i0 < number; ++i0)
                for (byte i1 = 0; i1 < number; ++i1)
                    for (byte i2 = 0; i2 < number; ++i2)
                        for (byte i3 = 0; i3 < number; ++i3)
                            for (byte i4 = 0; i4 < number; ++i4)
                                for (byte i5 = 0; i5 < number; ++i5)
                                    for (byte i6 = 0; i6 < number; ++i6)
                                        for (byte i7 = 0; i7 < number; ++i7)
                                            if ((i0 != i1) && (i0 != i2) && (i0 != i3) && (i0 != i4) && (i0 != i5) && (i0 != i6) && (i0 != i7) &&
                                                (i1 != i2) && (i1 != i3) && (i1 != i4) && (i1 != i5) && (i1 != i6) && (i1 != i7) &&
                                                (i2 != i3) && (i2 != i4) && (i2 != i5) && (i2 != i6) && (i2 != i7) &&
                                                (i3 != i4) && (i3 != i5) && (i3 != i6) && (i3 != i7) &&
                                                (i4 != i5) && (i4 != i6) && (i4 != i7) &&
                                                (i5 != i6) && (i5 != i7) &&
                                                (i6 != i7))
                                            {
                                                input[0] = i0;
                                                input[1] = i1;
                                                input[2] = i2;
                                                input[3] = i3;
                                                input[4] = i4;
                                                input[5] = i5;
                                                input[6] = i6;
                                                input[7] = i7;
                                                if (!doBenchmarks) result.AddCopy(input);
                                            }

            return result;
        }
    }
}

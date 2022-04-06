using System.Text.RegularExpressions;

namespace codility;

public class BinaryGap
{
    private readonly Func<string> inputProvider;
    private readonly Action<string> outputProvider;

    public BinaryGap(Func<string> inputProvider, Action<string> outputProvider)
    {
        this.inputProvider = inputProvider;
        this.outputProvider = outputProvider;
    }

    public void Solution(int val)
    {
        string bits = Convert.ToString(val, 2);
        outputProvider(bits);

        int gapLength = 0, maxGapLength = 0;
        bool ones = false;

        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] == '1') ones = true;

            if (ones && bits[i] == '0') gapLength++;
            else if (ones && bits[i] == '1')
            {
                if (maxGapLength < gapLength)
                    maxGapLength = gapLength; gapLength = 0;
            }
        }

        outputProvider($"Max Gap Length: {maxGapLength}");
    }

    public static int ComputeLargestBinaryGap(int value)
    {
        var binaryGap = new Regex("(?<=1)(0+)(?=1)");
        var binaryString = Convert.ToString(value, 2);
        return
            binaryGap.Matches(binaryString)
                .Cast<Match>()
                .Select(m => m.Length)
                .DefaultIfEmpty(0)
                .Max();
    }
}


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
            if (ones && bits[i] == '0')
            {
                gapLength++;
            }
            if (bits[i] == '1')
            {
                ones = true;
            }
            if (ones && bits[i] == '1')
            {
                if (maxGapLength < gapLength)
                    maxGapLength = gapLength; gapLength = 0;
            }
        }
        outputProvider($"Max Gap Length: {maxGapLength}");
    }
}
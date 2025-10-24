using System.Collections.Immutable;
using Xunit;

namespace Problems.Logical.FindNumberAtPositionBySequence;

public class FindNumberAtPositionBzhemba
{
    public int FindNumber(ImmutableArray<int> digits, int position)
    {
        var sorted = digits.OrderByDescending(
            n => n,
            Comparer<int>.Create((x, y) => 
            {
                var xy = x + y.ToString();
                var yx = y + x.ToString();
                return String.Compare(xy, yx, StringComparison.Ordinal);
            })
        ).ToArray();

        return sorted[position - 1];
    }

    [Theory]
    [InlineData(5, 1, 5)]
    [InlineData(5, 4, 2)]
    [InlineData(99, 15, 87)]
    [InlineData(99, 28, 75)]
    [InlineData(99, 99, 10)]
    [InlineData(89, 17, 76)]
    [InlineData(79, 35, 50)]
    public void Test(int max, int position, int expected)
    {
        var sequence = Enumerable.Range(1, max).ToImmutableArray();

        Assert.Equal(expected, FindNumber(sequence, position));
    }
}
using Xunit;

namespace Problems.DotnetKnowledge;

public class ShadowOfAlmightyBzhemba
{
    internal static void DoIt(string source, string target)
    {
        unsafe
        {
            if (String.IsNullOrWhiteSpace(source)) return;
        
            fixed (char* pointer = source)
            {
                var copyLength = Math.Min(source.Length, target.Length);
            
                for (var i = 0; i < copyLength; i++)
                    pointer[i] = target[i];
            }
        }
    }

    [Fact]
    public void Test()
    {
        DoIt("this is a magic bro", "good luck have fun!!!");

        Assert.Equal("good luck have fun!", "this is a magic bro");

        var text = "this is a magic bro";
        Assert.Equal("good luck have fun!", text);

        var shortText = "abc";
        DoIt(shortText, "hello world");
        Assert.Equal("hel", shortText);
        
        var longText = "hello world";
        var target = "def";
        DoIt(longText, target);
        Assert.Equal("deflo world", longText);
    }
}
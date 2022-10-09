namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void TestTheTruth()
    {
        true.Should()
            .BeTrue();
    }
}

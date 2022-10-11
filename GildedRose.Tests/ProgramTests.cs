namespace GildedRose.Tests;

public class ProgramTests
{
    private readonly Program _program;

    private readonly IReadOnlyCollection<Item> _normalItems;
    private readonly IReadOnlyCollection<Item> _legendaryItems;
    private readonly IReadOnlyCollection<Item> _backstagePasses;
    private readonly Item _agedBrie;
    private readonly Item _conjuredCake;

    public ProgramTests()
    {
        _program = new Program();

        _agedBrie = _program.Items.Single(i => i.Name == "Aged Brie");
        _conjuredCake = _program.Items.Single(i => i.Name == "Conjured Mana Cake");
        _legendaryItems = _program.Items.Where(i => i.Name.StartsWith("Sulfuras"))
            .ToList();
        _backstagePasses = _program.Items.Where(i => i.Name.StartsWith("Backstage"))
            .ToList();
        _normalItems = _program.Items.Where(i => i.Name.Contains("Vest") || i.Name.StartsWith("Elixir"))
            .ToList();
    }

    [Fact]
    public void TestTheTruth()
    {
        true.Should()
            .BeTrue();
    }
}

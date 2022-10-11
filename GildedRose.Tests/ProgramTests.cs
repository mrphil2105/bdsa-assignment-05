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

    //
    // All Items (except Legendary)
    //

    [Fact]
    public void AllItems_SellInDecreasesByOne_InOneDay()
    {
        var items = _program.Items.Except(_legendaryItems)
            .ToList();
        var expected = items.Select(i => i.SellIn - 1)
            .ToList();

        _program.UpdateQuality();

        items.Select(i => i.SellIn)
            .Should()
            .Equal(expected);
    }

    //
    // Normal Items
    //

    [Fact]
    public void NormalItems_QualityDecreasesByOne_InOneDay()
    {
        var expected = _normalItems.Select(i => i.Quality - 1)
            .ToList();

        _program.UpdateQuality();

        _normalItems.Select(i => i.Quality)
            .Should()
            .Equal(expected);
    }

    [Fact]
    public void NormalItems_QualityDoesNotDecrease_WhenZero()
    {
        while (_normalItems.Any(i => i.Quality > 0))
        {
            _program.UpdateQuality();
        }

        _program.UpdateQuality();

        _normalItems.Should()
            .OnlyContain(i => i.Quality == 0);
    }

    [Fact]
    public void Elixir_QualityDecreasesByTwo_AfterFiveDays()
    {
        var elixir = _normalItems.Single(i => i.Name.StartsWith("Elixir"));
        FastForward(5);
        var expected = elixir.Quality - 2;

        _program.UpdateQuality();

        elixir.Quality.Should()
            .Be(expected);
    }

    [Fact]
    public void Vest_QualityDecreasesByTwo_AfterTenDays()
    {
        var elixir = _normalItems.Single(i => i.Name.Contains("Vest"));
        FastForward(10);
        var expected = elixir.Quality - 2;

        _program.UpdateQuality();

        elixir.Quality.Should()
            .Be(expected);
    }

    private void FastForward(int days)
    {
        for (var i = 0; i < days; i++)
        {
            _program.UpdateQuality();
        }
    }
}

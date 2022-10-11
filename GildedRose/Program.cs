using static GildedRose.Inventory;

namespace GildedRose;

public class Program
{
    public readonly Inventory _inv;
    public Program()
    {
        SellInDelegate legendaySellin = (sellin) => sellin;
        QualityDelegate legendayQuality = (sellin, quality) => quality;

        QualityDelegate backstageQuality = (int sellin, int quality) => sellin switch
        {
            <= 0 => 0,
            <= 5 => quality + 3,
            <= 10 => quality + 2,
            _ => quality + 1
        };

        QualityDelegate conjuredQuality = (sellin, quality) => sellin > 0 ? quality - 2 : quality - 4;
        QualityDelegate cheeseQuality = (sellin, quality) => quality + 1;

        _inv = new Inventory()
            .Add(new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 })
            .Add(new() { Name = "Aged Brie", SellIn = 2, Quality = 0 }, quality: cheeseQuality)
            .Add(new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 })
            .Add(new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }, legendaySellin, legendayQuality)
            .Add(new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }, legendaySellin, legendayQuality)
            .Add(new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }, quality: backstageQuality)
            .Add(new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 }, quality: backstageQuality)
            .Add(new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }, quality: backstageQuality)
            .Add(new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }, quality: conjuredQuality);
    }

    private static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        var program = new Program();

        Console.WriteLine("OMGHAI!");

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");

            foreach (var it in program._inv)
            {
                Console.WriteLine($"{it.Item.Name}, {it.Item.SellIn}, {it.Item.Quality}");
            }

            Console.WriteLine("");
            program.UpdateQuality();
        }
    }

    public void UpdateQuality()
    {
        _inv.Update();
    }
}

public class Item
{
    public string? Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}

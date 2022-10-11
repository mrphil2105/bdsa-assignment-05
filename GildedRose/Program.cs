using System.Collections.ObjectModel;

namespace GildedRose;

public class Program
{
    private readonly IList<Item> _items = new List<Item>
    {
        new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
        new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
        new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
        new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
        new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
        new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
        new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
        new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
        // this conjured item does not work properly yet
        new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
    };

    private readonly List<Adapter> _adapters = new();

    private IReadOnlyCollection<Item>? _readOnlyItems;

    public Program()
    {
        IItemFactory factory = new ItemFactory();

        foreach (var item in _items)
        {
            var adapter = factory.Create(item);
            _adapters.Add(adapter);
        }
    }

    public IReadOnlyCollection<Item> Items => _readOnlyItems ??= new ReadOnlyCollection<Item>(_items);

    private static void Main(string[] args)
    {
        var program = new Program();
        program.Run();
    }

    private void Run()
    {
        Console.WriteLine("OMGHAI!");

        for (var i = 0; i < 31; i++)
        {
            Console.WriteLine("-------- day " + i + " --------");
            Console.WriteLine("name, sellIn, quality");

            foreach (var item in _items)
            {
                Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }

            Console.WriteLine("");
            UpdateQuality();
        }
    }

    public void UpdateQuality()
    {
        foreach (var adapter in _adapters)
        {
            adapter.Update();
        }
    }
}

public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}

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

    private IReadOnlyCollection<Item>? _readOnlyItems;

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
        foreach (var item in _items)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality -= 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality += 1;
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}

public class Item
{
    public string Name { get; set; }

    public int SellIn { get; set; }

    public int Quality { get; set; }
}

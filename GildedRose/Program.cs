using System.Collections.ObjectModel;

namespace GildedRose;

public class Program
{
    private static readonly IList<Item> _items = new List<Item>
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

    private static IReadOnlyCollection<Item>? _readOnlyItems;

    public static IReadOnlyCollection<Item> Items => _readOnlyItems ??= new ReadOnlyCollection<Item>(_items);

    private static void Main(string[] args)
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

    public static void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            if (_items[i]
                    .Name != "Aged Brie" && _items[i]
                    .Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (_items[i]
                        .Quality > 0)
                {
                    if (_items[i]
                            .Name != "Sulfuras, Hand of Ragnaros")
                    {
                        _items[i]
                            .Quality -= 1;
                    }
                }
            }
            else
            {
                if (_items[i]
                        .Quality < 50)
                {
                    _items[i]
                        .Quality += 1;

                    if (_items[i]
                            .Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (_items[i]
                                .SellIn < 11)
                        {
                            if (_items[i]
                                    .Quality < 50)
                            {
                                _items[i]
                                    .Quality += 1;
                            }
                        }

                        if (_items[i]
                                .SellIn < 6)
                        {
                            if (_items[i]
                                    .Quality < 50)
                            {
                                _items[i]
                                    .Quality += 1;
                            }
                        }
                    }
                }
            }

            if (_items[i]
                    .Name != "Sulfuras, Hand of Ragnaros")
            {
                _items[i]
                    .SellIn -= 1;
            }

            if (_items[i]
                    .SellIn < 0)
            {
                if (_items[i]
                        .Name != "Aged Brie")
                {
                    if (_items[i]
                            .Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (_items[i]
                                .Quality > 0)
                        {
                            if (_items[i]
                                    .Name != "Sulfuras, Hand of Ragnaros")
                            {
                                _items[i]
                                    .Quality -= 1;
                            }
                        }
                    }
                    else
                    {
                        _items[i]
                            .Quality -= _items[i]
                            .Quality;
                    }
                }
                else
                {
                    if (_items[i]
                            .Quality < 50)
                    {
                        _items[i]
                            .Quality += 1;
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

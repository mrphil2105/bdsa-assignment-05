using System.Collections;
using static GildedRose.Inventory;

namespace GildedRose;

public class InventoryItem
{
    public Item Item { get; }
    public SellInDelegate SellIn { get; }
    public QualityDelegate Quality { get; }
    public InventoryItem(Item item, SellInDelegate sellin, QualityDelegate quality)
    {
        Item = item;
        SellIn = sellin;
        Quality = quality;
    }
}

public class Inventory : IEnumerable<InventoryItem>
{
    public delegate int SellInDelegate(int sellin);
    public delegate int QualityDelegate(int sellin, int quality);

    private List<InventoryItem> inv = new();

    public Inventory Add(Item item, SellInDelegate? sellIn = null, QualityDelegate? quality = null)
    {
        inv.Add(new InventoryItem(item, sellIn ?? SellInDefault, quality ?? QualityDefault));
        return this;
    }

    private static int SellInDefault(int sellin) => sellin - 1;
    private static int QualityDefault(int sellin, int quality) => sellin <= 0 ? quality - 2 : quality - 1;

    public IEnumerator<InventoryItem> GetEnumerator() => inv.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => inv.GetEnumerator();

    public IEnumerable<Item> GetItems()
    {
        foreach (var item in inv)
        {
            yield return item.Item;
        }
    }

    internal void Update()
    {
        foreach (var it in this.inv)
        {
            it.Item.SellIn = it.SellIn.Invoke(it.Item.SellIn);

            var newqual = it.Quality.Invoke(it.Item.SellIn, it.Item.Quality);

            if (newqual < 0)
            {
                it.Item.Quality = 0;
            }
            else if (it.Item.Quality > 50)
            {
                continue;
            }
            else if (newqual > 50)
            {
                it.Item.Quality = 50;
            }
            else
            {
                it.Item.Quality = newqual;
            }
        }
    }
}

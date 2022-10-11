using System.Collections;
using static GildedRose.Inventory;

namespace GildedRose;

public class InventoryItem
{
    public Item Item { get; }
    public SellInDelegate SellIn { get; }
    private QualityDelegate Quality { get; }
    public InventoryItem(Item item, SellInDelegate sellin, QualityDelegate quality)
    {
        Item = item;
        SellIn = sellin;
        Quality = quality;
    }

    public void Update()
    {
        this.Item.SellIn = SellIn.Invoke(this.Item.SellIn);

        var newqual = Quality.Invoke(this.Item.SellIn, this.Item.Quality);

        if (newqual < 0)
        {
            this.Item.Quality = 0;
        }
        else if (Item.Quality > 50)
        {
            return;
        }
        else if (newqual > 50)
        {
            this.Item.Quality = 50;
        }
        else
        {
            this.Item.Quality = newqual;
        }
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

    internal static int SellInDefault(int sellin) => sellin - 1;
    internal static int QualityDefault(int sellin, int quality) => sellin <= 0 ? quality - 2 : quality - 1;

    public IEnumerator<InventoryItem> GetEnumerator() => inv.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => inv.GetEnumerator();
}

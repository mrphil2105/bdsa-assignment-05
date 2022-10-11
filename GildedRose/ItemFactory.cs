namespace GildedRose;

public class ItemFactory : IItemFactory
{
    public Adapter Create(Item item)
    {
        if (item.Name.Contains("Aged Brie"))
        {
            return new AgedBrieItem(item);
        }

        if (item.Name.Contains("Sulfuras"))
        {
            return new LegendaryItem(item);
        }

        if (item.Name.Contains("Backstage passes"))
        {
            return new BackstagePassItem(item);
        }

        if (item.Name.Contains("Conjured"))
        {
            return new ConjuredItem(item);
        }

        return new NormalItem(item);
    }
}

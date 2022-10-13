namespace GildedRose;

public class AgedBrieItem : Adapter
{
    public AgedBrieItem(Item item) : base(item)
    {
    }

    public override void Update()
    {
        _item.SellIn--;
        _item.Quality++;

        if (SellIn < 0)
        {
            _item.Quality++;
        }

        base.Update();
    }
}

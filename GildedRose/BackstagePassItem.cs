namespace GildedRose;

public class BackstagePassItem : Adapter
{
    public BackstagePassItem(Item item) : base(item)
    {
    }

    public override void Update()
    {
        _item.Quality++;

        if (SellIn <= 10)
        {
            _item.Quality++;
        }

        if (SellIn <= 5)
        {
            _item.Quality++;
        }

        _item.SellIn--;

        if (_item.SellIn < 0)
        {
            _item.Quality = 0;

            return;
        }

        base.Update();
    }
}

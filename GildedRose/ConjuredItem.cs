namespace GildedRose;

public class ConjuredItem : Adapter
{
    public ConjuredItem(Item item) : base(item)
    {
    }

    public override void Update()
    {
        _item.SellIn--;
        _item.Quality -= 2;

        if (SellIn < 0)
        {
            _item.Quality -= 2;
        }

        base.Update();
    }
}

namespace GildedRose;

public class NormalItem : Adapter
{
    public NormalItem(Item item) : base(item)
    {
    }

    public override void Update()
    {
        _item.SellIn--;
        _item.Quality--;

        if (SellIn < 0)
        {
            _item.Quality--;
        }

        base.Update();
    }
}

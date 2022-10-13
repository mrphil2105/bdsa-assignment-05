namespace GildedRose;

public abstract class Adapter
{
    protected readonly Item _item;

    protected Adapter(Item item, int minQuality = 0, int maxQuality = 50)
    {
        _item = item;
        MinQuality = minQuality;
        MaxQuality = maxQuality;
    }

    public int MinQuality { get; }

    public int MaxQuality { get; }

    public string Name => _item.Name;

    public int SellIn => _item.SellIn;

    public int Quality => _item.Quality;

    public virtual void Update()
    {
        _item.Quality = Math.Clamp(_item.Quality, MinQuality, MaxQuality);
    }
}

public interface IItem
{
    ItemTag ItemTag { get; }
    void PickUp(IPlayer player);
    void Drop(IPlayer player);
}

using UnityEngine;

public class BaseItem : AbstractInteractableBase, IItem
{
    [SerializeField]
    private ItemTag itemTag;

    private Transform Transform => gameObject.transform;

    public ItemTag ItemTag => ItemTag;

    protected override void InternalStartInteraction(IPlayer player)
    {
        PickUp(player);
    }

    protected virtual void InternalOnPickedUp()
    {

    }

    protected virtual void InternalOnDropped()
    {

    }

    public void PickUp(IPlayer player)
    {
        Transform.parent = player.HandTransform;
        Transform.localPosition = Vector3.zero;
        InternalOnPickedUp();
    }

    public void Drop(IPlayer player)
    {
        Transform.parent = null;
        InternalOnDropped();
        EndInteraction();
    }
}

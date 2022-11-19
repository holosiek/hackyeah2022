using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    ItemTag ItemTag { get; }
    void PickUp(IPlayer player);
    void Drop(IPlayer player);
}

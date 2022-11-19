using UnityEngine;

public interface IPlayer
{
    PlayerType PlayerType { get; }
    Transform HandTransform { get; }
}

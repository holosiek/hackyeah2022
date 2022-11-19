using System.Collections.Generic;
using UnityEngine;

public interface IPlayer
{
    PlayerType PlayerType { get; }
    Transform HandTransform { get; }
    List<InteractionAbilityTag> CurrentInteractionAbilities { get; }
}

using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private List<InteractionAbilityTag> _requiredAbilitiesToUse;

    protected bool _isWorking = false;

    protected abstract void InternalStartInteraction();
    protected abstract void InternalEndInteraction();

    protected bool CanBeInteracted(IPlayer player)
    {
        return IsReadyForInteraction() && CanPlayerInteract(player);
    }

    private bool CanPlayerInteract(IPlayer player)
    {
        foreach (var ability in player.CurrentInteractionAbilities)
        {
            if (!_requiredAbilitiesToUse.Contains(ability))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsReadyForInteraction()
    {
        return !_isWorking;
    }

    protected void EndInteraction()
    {
        InternalEndInteraction();
        _isWorking = false;
    }

    public void StartInteraction(IPlayer player)
    {
        if (CanBeInteracted(player))
        {
            _isWorking = true;
            InternalStartInteraction();
        }
    }
}

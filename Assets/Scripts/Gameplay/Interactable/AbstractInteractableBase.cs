using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInteractableBase : MonoBehaviour, IInteractable
{
    [SerializeField]
    private List<InteractionAbilityTag> _requiredAbilitiesToUse;

    [SerializeField]
    private List<InteractionAbilityTag> _blockingAbilities;

    public event Action OnInteractionStarted;
    public event Action OnInteractionEnded;

    protected bool _isWorking = false;

    protected abstract void InternalStartInteraction(IPlayer player);
    protected virtual void InternalEndInteraction()
    {

    }

    protected virtual bool CanBeInteracted(IPlayer player)
    {
        return IsReadyForInteraction()
            && HasPlayerRequiredAbilities(player)
            && !HasPlayerBlockingAbility(player);
    }

    protected void EndInteraction()
    {
        InternalEndInteraction();
        _isWorking = false;
        OnInteractionEnded?.Invoke();
    }

    public void StartInteraction(IPlayer player)
    {
        if (CanBeInteracted(player))
        {
            _isWorking = true;
            InternalStartInteraction(player);
            OnInteractionStarted?.Invoke();
        }
    }

    public bool CanBeDetected()
    {
        return IsReadyForInteraction();
    }

    private bool IsReadyForInteraction()
    {
        return !_isWorking;
    }

    private bool HasPlayerRequiredAbilities(IPlayer player)
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

    private bool HasPlayerBlockingAbility(IPlayer player)
    {
        foreach (var ability in player.CurrentInteractionAbilities)
        {
            if (_blockingAbilities.Contains(ability))
            {
                return true;
            }
        }

        return false;
    }
}

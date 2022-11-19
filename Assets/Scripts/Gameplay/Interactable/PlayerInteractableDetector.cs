using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableDetector : MonoBehaviour
{
    private readonly List<IInteractable> _interactablesInRange;
    private IInteractable _currentlyFocusedInteractable;

    private void OnCollisionEnter(Collision collision)
    {
        var interactable = collision.gameObject.GetComponent<IInteractable>();

        if (interactable != null)
        {
            _interactablesInRange.Add(interactable);
            TryFocusInteractable(interactable);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var interactable = collision.gameObject.GetComponent<IInteractable>();

        if (interactable != null)
        {
            _interactablesInRange.Remove(interactable);
            TryFocusFirstInteractable();
        }
    }

    private void TryFocusFirstInteractable()
    {
        if (_interactablesInRange.Count > 0)
        {
            TryFocusInteractable(_interactablesInRange[0]);
        }
    }

    private void TryFocusInteractable(IInteractable interactable)
    {
        if (_currentlyFocusedInteractable == null)
        {
            _currentlyFocusedInteractable = interactable;
        }
    }
}

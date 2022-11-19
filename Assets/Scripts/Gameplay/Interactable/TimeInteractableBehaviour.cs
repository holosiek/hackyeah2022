using System.Collections;
using UnityEngine;

public class TimeInteractableBehaviour : AbstractInteractableBase
{
    [SerializeField]
    private float _workingTime = 4f;

    private float _currentWorkingTime = 0;

    private float CurrentProgression => _currentWorkingTime / _workingTime;

    public delegate void OnTimeProgressionDelegate(float progressionTime);
    public event OnTimeProgressionDelegate OnTimeProgressionEvent;

    protected override void InternalStartInteraction(IPlayer player)
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_currentWorkingTime < _workingTime)
        {
            _currentWorkingTime += Time.deltaTime;
            OnTimeProgressionEvent?.Invoke(CurrentProgression);

            yield return null;
        }

        EndInteraction();
    }
}

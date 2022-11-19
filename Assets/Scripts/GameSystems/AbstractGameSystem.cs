using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractGameSystem : MonoBehaviour, IGameSystem
{
    public virtual Task Initialize()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnSystemsInitialized()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnGameReady()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnGameStarted()
    {
        return Task.CompletedTask;
    }

    public virtual Task OnGameEnded()
    {
        return Task.CompletedTask;
    }

    public virtual Task Cleanup()
    {
        return Task.CompletedTask;
    }

    public virtual void Destroy()
    {
        Destroy(this);
    }
}

using System.Threading.Tasks;

public interface IGameSystem
{
    Task Initialize();
    Task OnSystemsInitialized();
    Task OnGameReady();
    Task OnGameStarted();
    Task OnGameEnded();
    Task Cleanup();
    void Destroy();
}

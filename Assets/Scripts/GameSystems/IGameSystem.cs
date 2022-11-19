using System.Threading.Tasks;

public interface IGameSystem
{
    Task Initialize();
    Task OnSystemsInitialized();
    Task OnGameReady();
    Task OnGameStarted();
    void PreDestroy();
}

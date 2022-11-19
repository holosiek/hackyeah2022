using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance _instance;

    public static GameInstance Instance => _instance;

    private List<IGameSystem> _gameSystems;

    private void Awake()
    {
        AssureOneInstance();
    }

    private void Start()
    {
        GatherAllGameSystems();
        PrepareSystemsAndStartGame();
    }

    private void AssureOneInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void GatherAllGameSystems()
    {
        _gameSystems = new List<IGameSystem>(FindObjectsOfType<AbstractGameSystem>(true));
    }

    private void PrepareSystemsAndStartGame()
    {
        InitializeGameSystems();
        OnGameSystemsInitialized();
        OnGameReady();
        OnGameStarted();
    }

    private async void InitializeGameSystems()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.Initialize();
        }
    }

    private async void OnGameSystemsInitialized()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.OnSystemsInitialized();
        }
    }

    private async void OnGameReady()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.OnGameReady();
        }
    }

    private async void OnGameStarted()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.OnGameStarted();
        }
    }

    public async Task EndGame()
    {
        await OnGameEnded();
        await CleanupSystems();
        DestroySystems();
    }

    private async Task OnGameEnded()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.OnGameEnded();
        }
    }

    private async Task CleanupSystems()
    {
        foreach (var gameSystem in _gameSystems)
        {
            await gameSystem.Cleanup();
        }
    }

    private void DestroySystems()
    {
        _gameSystems.ForEach(gameSystem => gameSystem.Destroy());
        _gameSystems.Clear();
        _gameSystems = null;
    }
}
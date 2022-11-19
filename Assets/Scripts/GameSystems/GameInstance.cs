using System;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    private static GameInstance _instance;

    public static GameInstance Instance => _instance;

    private List<IGameSystem> _gameSystems;
    
    public event Action OnGameSystemInitializedEvent;

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

    public bool TryGetSystem<T>(out T typeSystem) where T : IGameSystem
    {
        foreach (var system in _gameSystems)
        {
            if (system is T gameSystem)
            {
                typeSystem = gameSystem;
                return true;
            }

        }
        
        typeSystem = default;
        return false;
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
        OnGameSystemInitializedEvent?.Invoke();
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

    private void OnDestroy()
    {
        if (_instance == this)
        {
            DestroySystems();
        }
    }

    private void DestroySystems()
    {
        _gameSystems.ForEach(gameSystem => gameSystem.PreDestroy());
        _gameSystems.Clear();
        _gameSystems = null;
    }
}

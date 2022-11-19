using System;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [Flags]
    private enum Direction
    {
        Top,
        Right,
        Bottom,
        Left
    }

    [SerializeField]
    private GameObject _meshObject;

    [SerializeField]
    private Transform _handTransform;

    [SerializeField]
    private PlayerType _playerType;

    private const int SPEED = 8;
    private bool _initialized;
    private InputSystem _inputSystem;
    private List<InteractionAbilityTag> _currentInteractionAbilities;

    public PlayerType PlayerType => _playerType;
    public Transform HandTransform => _handTransform;

    public List<InteractionAbilityTag> CurrentInteractionAbilities => _currentInteractionAbilities;

    private Direction _direction;

    public void Awake()
    {
        GameInstance.Instance.OnGameSystemInitializedEvent += OnGameSystemInitialized;
    }

    private void OnGameSystemInitialized()
    {
        _initialized = true;

        if (!GameInstance.Instance.TryGetSystem(out _inputSystem))
        {
            Debug.LogError("Couldn't gather input system!");
        }
    }

    private Vector3 MovePlayer()
    {
        var vector = Vector3.zero;

        if (_inputSystem.IsForwardPressed(_playerType))
        {
            vector += Vector3.forward;
        }

        if (_inputSystem.IsBackPressed(_playerType))
        {
            vector -= Vector3.forward;
        }

        if (_inputSystem.IsLeftPressed(_playerType))
        {
            vector -= Vector3.right;
        }

        if (_inputSystem.IsRightPressed(_playerType))
        {
            vector += Vector3.right;
        }

        return vector;
    }

    private float GetAngle()
    {
        if (_direction.HasFlag(Direction.Top) && _direction.HasFlag(Direction.Right))
        {
            return 45;
        }
        if (_direction.HasFlag(Direction.Top) && _direction.HasFlag(Direction.Left))
        {
            return 315;
        }
        if (_direction.HasFlag(Direction.Bottom) && _direction.HasFlag(Direction.Right))
        {
            return 135;
        }
        if (_direction.HasFlag(Direction.Bottom) && _direction.HasFlag(Direction.Left))
        {
            return 225;
        }
        return _direction switch
        {
            Direction.Top => 0,
            Direction.Right => 90,
            Direction.Bottom => 180,
            Direction.Left => 270,
            _ => 0
        };
    }

    private void UpdatePlayerMeshRotation()
    {
        _meshObject.transform.rotation = Quaternion.AngleAxis(GetAngle(), Vector3.up);
    }

    public void Update()
    {
        var previousDirection = _direction;

        if (_initialized)
        {
            transform.position += MovePlayer().normalized * SPEED * Time.deltaTime;

            if (previousDirection != _direction)
            {
                UpdatePlayerMeshRotation();
            }
        }
    }
}

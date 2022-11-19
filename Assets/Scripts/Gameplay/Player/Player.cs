using System;
using System.Collections.Generic;
using GameSystems;
using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    [Flags]
    private enum Direction
    {
        Zero,
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
        var direction = Direction.Zero;

        if (_inputSystem.IsForwardPressed(_playerType))
        {
            vector += Vector3.forward;
            direction |= Direction.Top;
        }

        if (_inputSystem.IsBackPressed(_playerType))
        {
            vector -= Vector3.forward;
            direction |= Direction.Bottom;
        }

        if (_inputSystem.IsLeftPressed(_playerType))
        {
            vector -= Vector3.right;
            direction |= Direction.Left;
        }

        if (_inputSystem.IsRightPressed(_playerType))
        {
            vector += Vector3.right;
            direction |= Direction.Right;
        }

        _direction = direction;

        return vector;
    }

    private float GetAngle()
    {
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
        if (_initialized)
        {
            transform.position += MovePlayer().normalized * SPEED * Time.deltaTime;

            if (_direction != Direction.Zero)
            {
                UpdatePlayerMeshRotation();
            }
        }
    }
}

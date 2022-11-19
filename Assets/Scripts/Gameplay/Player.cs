using GameSystems;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private GameObject _meshObject;

	[SerializeField]
	[Range(0, 1)]
	private int _id;
	
    private const int SPEED = 8;
    private bool _initialized;
    private InputSystem _inputSystem;

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
	    else
	    {
		    Debug.Log(_inputSystem);
	    }
    }

    private Vector3 Player0Movement()
    {
	    var vector = Vector3.zero;
	    
	    if (_inputSystem.GameControls.Gameplay.Forward.IsPressed())
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay.Back.IsPressed())
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay.Left.IsPressed())
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay.Right.IsPressed())
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }

	    return vector;
    }
    
    private Vector3 Player1Movement()
    {
	    var vector = Vector3.zero;
	    
	    if (_inputSystem.GameControls.Gameplay2.Forward.IsPressed())
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay2.Back.IsPressed())
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay2.Left.IsPressed())
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }
	    if (_inputSystem.GameControls.Gameplay2.Right.IsPressed())
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }

	    return vector;
    }
    
    public void Update()
    {
	    if (_initialized)
	    {
		    if (_id == 0)
		    {
			    transform.position += Player0Movement() * SPEED;;
		    }
		    else
		    {
			    transform.position += Player1Movement() * SPEED;;
		    }
	    }
    }
}

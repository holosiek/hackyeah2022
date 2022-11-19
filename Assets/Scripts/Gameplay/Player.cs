using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private GameObject _meshObject;
	
	[SerializeField]
	[Range(0, 1)]
	private int _id;
	
    private const int SPEED = 8;
    private GameControls _gameControls;
    
    public void Start()
    {
	    _gameControls = new GameControls();
	    
	    if (_id == 0)
	    {
		    _gameControls.Gameplay.Enable();
	    }
	    else
	    {
		    _gameControls.Gameplay2.Enable();
	    }
    }

    private Vector3 Player0Movement()
    {
	    var vector = Vector3.zero;
	    
	    if (_gameControls.Gameplay.Forward.IsPressed())
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay.Back.IsPressed())
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay.Left.IsPressed())
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay.Right.IsPressed())
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }

	    return vector;
    }
    
    private Vector3 Player1Movement()
    {
	    var vector = Vector3.zero;
	    
	    if (_gameControls.Gameplay2.Forward.IsPressed())
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay2.Back.IsPressed())
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay2.Left.IsPressed())
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }
	    if (_gameControls.Gameplay2.Right.IsPressed())
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }

	    return vector;
    }
    
    public void Update()
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

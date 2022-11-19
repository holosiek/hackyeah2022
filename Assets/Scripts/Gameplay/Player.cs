using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Keyboard _Keyboard;
    private const int SPEED = 8;

    public void Start()
    {
	    _Keyboard = Keyboard.current;
    }

    public void Update()
    {
	    var vector = Vector3.zero;
	    
	    if (_Keyboard.wKey.isPressed)
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_Keyboard.sKey.isPressed)
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_Keyboard.dKey.isPressed)
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }
	    if (_Keyboard.aKey.isPressed)
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }

	    transform.position += vector * SPEED;
    }
}

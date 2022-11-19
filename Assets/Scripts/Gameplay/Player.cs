using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Keyboard _keyboard;
    private const int SPEED = 8;

    public void Start()
    {
	    _keyboard = Keyboard.current;
    }

    public void Update()
    {
	    var vector = Vector3.zero;
	    
	    if (_keyboard.wKey.isPressed)
	    {
		    vector += Vector3.forward * Time.deltaTime;
	    }
	    if (_keyboard.sKey.isPressed)
	    {
		    vector -= Vector3.forward * Time.deltaTime;
	    }
	    if (_keyboard.dKey.isPressed)
	    {
		    vector += Vector3.right * Time.deltaTime;
	    }
	    if (_keyboard.aKey.isPressed)
	    {
		    vector -= Vector3.right * Time.deltaTime;
	    }

	    transform.position += vector * SPEED;
    }
}

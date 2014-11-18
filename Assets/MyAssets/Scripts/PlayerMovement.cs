using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;// The speed that the player will move at.
	public float rotSpeed = 2f;

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.


	
	void Awake ()
	{
		// Create a layer mask for the floor layer.

		
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void Update ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		
		// Move the player around the scene.
		Move (h, v);
		
		// Turn the player to face the mouse cursor.

		
		// Animate the player.
		Animating (h, v);
	}
	
	void Move (float h, float v)
	{
		// Set the movement vector based on the axis input.
		if( v > .1)
		{
			playerRigidbody.transform.Translate(Vector3.forward *speed * Time.deltaTime);
		}
		//movement.Set (0f, 0f, v);
		
		// Normalise the movement vector and make it proportional to the speed per second.
		//movement = movement * speed * Time.deltaTime;
		
		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
		//Vector3 rot =( h *rotSpeed * Time.deltaTime);
		playerRigidbody.transform.Rotate(0f,h *rotSpeed * Time.deltaTime, 0f);

	}
	


	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}
}
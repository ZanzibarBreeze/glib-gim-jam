using UnityEngine;
using System.Collections;

public class PlayerTwo : CharacterController 
{
	
	// Use this for initialization
	public override void Start () 
	{
		base.Start ();
		
		// Grab player position on start and use it as the spawn position for subsequent rounds
		spawnPosition = _transform.position;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		UpdateMovement ();
	}
	
	public void FixedUpdate ()
	{
		// inputState is none unless one of the movement keys are pressed
		currentInputState = inputState.None;
		
		// Move Up
		if (Input.GetKey (KeyCode.UpArrow))
		{
			currentInputState = inputState.WalkUp;
			faceDirection = facing.Up;
		}
		
		// Move Down
		if (Input.GetKey (KeyCode.DownArrow) && currentInputState != inputState.WalkUp)
		{
			currentInputState = inputState.WalkDown;
			faceDirection = facing.Down;
		}
		
		// Move Left
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			currentInputState = inputState.WalkLeft;
			faceDirection = facing.Left;
		}
		
		// Move Right
		if (Input.GetKey (KeyCode.RightArrow) && currentInputState != inputState.WalkLeft)
		{
			currentInputState = inputState.WalkRight;
			faceDirection = facing.Right;
		}
		
		// Attack
		if (Input.GetKeyDown (KeyCode.RightControl))
		{
			currentInputState = inputState.Attack;
		}
		
		// Carry
		if (Input.GetKeyDown (KeyCode.RightShift))
		{
			currentInputState = inputState.Carry;
		}
		
		// Throw
		if (Input.GetKeyDown (KeyCode.RightShift) && currentInputState == inputState.Carry)
		{
			currentInputState = inputState.Throw;
		}
		
		UpdatePhysics ();
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("CarryableObject") && hasObject == false)
		{
			PickUpObject ();
		}
	}
	
	void OnTriggerEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("CarryableObject") && hasObject == false)
		{
			PickUpObject ();
		}
	}
	
	public void Respawn ()
	{
		if (alive == true)
		{
			_transform.position = spawnPosition;
			hasObject = false;
		}
	}
	
}
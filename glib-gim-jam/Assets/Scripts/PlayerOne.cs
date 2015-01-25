using UnityEngine;
using System.Collections;

public class PlayerOne : Character 
{

	private bool inPickUpRange = false;

	// Use this for initialization
	public override void Start () 
	{
		base.Start ();

		myTeam = MyTeam.Team1;

		// Grab player position on start and use it as the spawn position for subsequent rounds
		spawnPosition = _transform.position;
	}
	
	// Update is called once per frame
	public void Update () 
	{
		// Reload the scene and reset scores
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.R))
		{
			Debug.Log ("Reset");
			Application.LoadLevel (0);
		}

		UpdateMovement ();
	}

	public void FixedUpdate ()
	{
		Debug.Log (currentInputState);

		// inputState is none unless one of the movement keys are pressed
		currentInputState = inputState.None;

		// Move Up
		if (Input.GetKey (KeyCode.W) && currentInputState != inputState.WalkDown)
		{
			currentInputState = inputState.WalkUp;
			faceDirection = facing.Up;
		}

		// Move Down
		if (Input.GetKey (KeyCode.S) && currentInputState != inputState.WalkUp)
		{
			currentInputState = inputState.WalkDown;
			faceDirection = facing.Down;
		}

		// Move Left
		if (Input.GetKey (KeyCode.A) && currentInputState != inputState.WalkRight)
		{
			currentInputState = inputState.WalkLeft;
			faceDirection = facing.Left;
		}

		// Move Right
		if (Input.GetKey (KeyCode.D) && currentInputState != inputState.WalkLeft)
		{
			currentInputState = inputState.WalkRight;
			faceDirection = facing.Right;
		}

		// Attack
		if (Input.GetKeyDown (KeyCode.Q) && currentInputState != inputState.Carry)
		{
			currentInputState = inputState.Attack;
		}

//		// Carry
//		if (Input.GetKeyDown (KeyCode.E))
//		{
//			currentInputState = inputState.Carry;
//		}

		if (hasObject == true)
		{
			currentInputState = inputState.Carry;
		}

		// Throw
		if (Input.GetKeyDown (KeyCode.E) && currentInputState == inputState.Carry)
		{
			Debug.Log ("Throw");
			currentInputState = inputState.Throw;
		}

		UpdatePhysics ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.CompareTag ("CarryableObject") && currentInputState != inputState.Carry)
		{
			PickUpObject ();
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("CarryableObject") && currentInputState != inputState.Carry)
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

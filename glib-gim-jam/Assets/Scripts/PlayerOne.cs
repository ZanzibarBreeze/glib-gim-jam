﻿using UnityEngine;
using System.Collections;

public class PlayerOne : CharacterController 
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
		// Reload the scene and reset scores
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.R))
		{
			Application.LoadLevel (0);
		}

		UpdateMovement ();
	}

	public void FixedUpdate ()
	{
		// inputState is none unless one of the movement keys are pressed
		currentInputState = inputState.None;

		// Move Up
		if (Input.GetKey (KeyCode.W))
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
		if (Input.GetKey (KeyCode.A))
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
		if (Input.GetKeyDown (KeyCode.Q))
		{
			currentInputState = inputState.Attack;
		}

		// Carry
		if (Input.GetKeyDown (KeyCode.E))
		{
			currentInputState = inputState.Carry;
		}

		// Throw
		if (Input.GetKeyDown (KeyCode.E) && currentInputState == inputState.Carry)
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

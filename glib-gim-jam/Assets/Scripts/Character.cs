using UnityEngine;
using System.Collections;

public enum MyTeam { Team1, Team2, None }

public class Character : MonoBehaviour 
{
	public MyTeam myTeam = MyTeam.Team1;

	public enum inputState { None, WalkUp, WalkDown, WalkLeft, WalkRight, Carry, Throw, Attack }

	[HideInInspector] public inputState currentInputState;

	[HideInInspector] public enum facing { Up, Down, Left, Right }
	[HideInInspector] public facing faceDirection;

	[HideInInspector] public bool alive = true;
	[HideInInspector] public Vector3 spawnPosition;

	/*
	 * Any other flags go here
	 */

	protected Transform _transform;
	protected Rigidbody2D _rigidbody;

	private float runVel = 2.5f; // Run speed when not carrying an object
	private float walkVel = 2.0f; // Walk speed while carrying an object
	private float throwVel = 3.0f; // Velocity of object when thrown
	
	private float moveVel;
	private Vector2 tVel = new Vector2 ();

	protected bool hasObject = false;
	protected string team = "";

	private Vector2 physVel = new Vector2 ();

	public virtual void Awake ()
	{
		_transform = transform;
		_rigidbody = rigidbody2D;
	}

	// Use this for initialization
	public virtual void Start () 
	{
		moveVel = runVel;
	}

	public virtual void UpdateMovement ()
	{
		// if game over || dead, return;

		// If player is carrying an object, then have it follow the player
		if (hasObject == true)
		{
			GameManager.carryableObjects.UpdateObjectFollowPos (_transform);
		}

	}

	public virtual void UpdatePhysics ()
	{
		// if game over || dead, return;

		physVel = Vector2.zero;

		// Move Up
		if (currentInputState == inputState.WalkUp)
		{
			physVel.y = moveVel;
		}
		// Move Down
		if (currentInputState == inputState.WalkDown)
		{
			physVel.y = -moveVel;
		}
		// Move Left
		if (currentInputState == inputState.WalkLeft)
		{
			physVel.x = -moveVel;
		}
		// Move Right
		if (currentInputState == inputState.WalkRight)
		{
			physVel.x = moveVel;
		}

		// Throw an object
		if (currentInputState == inputState.Throw && hasObject == true)
		{
			if (faceDirection == facing.Up)
				tVel.y = throwVel;

			if (faceDirection == facing.Down)
				tVel.y = -throwVel;

			if (faceDirection == facing.Left)
				tVel.x = -throwVel;

			if (faceDirection == facing.Right)
				tVel.x = throwVel;

			GameManager.carryableObjects.ThrowObject (tVel);
			RemoveObject ();
		}

		// Move the player
		_rigidbody.velocity = new Vector2 (physVel.x, physVel.y);
	}

	public virtual void PickUpObject ()
	{
		hasObject = true;
		moveVel = walkVel;

		GameManager.carryableObjects.PickUp (_transform);
	}

	void RemoveObject ()
	{
		hasObject = false;
		moveVel = runVel;
	}

	void AddCoins ()
	{
		if (myTeam == MyTeam.Team1)
			team = "Team1";
		else
			team = "Team2";

		// Get amount from the Coin gameobject's script
//		GameManager.scoreManager.AddCoins (team, amount);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}

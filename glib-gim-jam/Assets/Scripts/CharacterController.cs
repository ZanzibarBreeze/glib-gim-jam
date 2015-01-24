using UnityEngine;
using System.Collections;

public enum Team { Team1, Team2, None }

public class CharacterController : MonoBehaviour 
{
	public Team myTeam = MyTeam.Team1;

	public enum inputState { None, WalkUp, WalkDown, WalkLeft, WalkRight, Carry, Throw, Attack }

	[HideInInspector] public inputState currentInputState;

	[HideInInspector] public enum facing { Up, Down, Left, Right }
	[HideInInspector] public facing faceDirection;

	/*
	[HideInInspector] public enum moving { Up, Down, Left, Right, None }
	[HideInInspector] public moving moveDirection;
	
	[HideInInspector] public bool isUp;
	[HideInInspector] public bool isDown;
	[HideInInspector] public bool isLeft;
	[HideInInspector] public bool isRight;
	[HideInInspector] public bool isCarry;
	[HideInInspector] public bool isThrow;
	[HideInInspector] public bool isAttack;
	*/

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
	private float tVel = 0.0f;

	protected bool hasObject = false;
	protected string team = "";

	// Raycast-related variables
	private RaycastHit2D hit;
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
		// if game over || dead, return


	}

	public virtual void UpdatePhysics ()
	{
		// if game over || dead, return

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
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}

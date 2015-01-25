using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour 
{
	private Transform _transform;
	private Animator _animator;
	private Character character;

	public enum anim { None, WalkUp, WalkDown, WalkLeft, WalkRight, StandUp, StandDown, StandLeft, StandRight, AttackUp, AttackDown, AttackLeft, AttackRight }

	private anim currentAnim;

	// Hash the animation state string to save performance
	private int _p1AnimState = Animator.StringToHash ("P1AnimState");
	private int _p2AnimState = Animator.StringToHash ("P2AnimState");
	private int _animState;

	void Awake ()
	{
		// Cache components to save on performance
		_transform = transform;
		_animator = this.GetComponent<Animator> ();
		character = this.GetComponent<Character> ();

		// Assign the correct animation state depending on team
		if (character.myTeam == MyTeam.Team1)
		{
			_animState = _p1AnimState;
		}
		else
		{
			_animState = _p2AnimState;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		// if game over || dead, return;

		// Walk Up
		if (character.currentInputState == Character.inputState.WalkUp && currentAnim != anim.WalkUp)
		{
			currentAnim = anim.WalkUp;
			_animator.SetInteger(_animState, 5);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Stand Up
		if (character.currentInputState != Character.inputState.WalkUp && currentAnim != anim.StandUp && character.faceDirection == Character.facing.Up)
		{
			currentAnim = anim.StandUp;
			_animator.SetInteger (_animState, 2);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Walk Down
		if (character.currentInputState == Character.inputState.WalkDown && currentAnim != anim.WalkDown)
		{
			currentAnim = anim.WalkDown;
			_animator.SetInteger(_animState, 5);
			_transform.localScale = new Vector3 (1, 1, 1);
		}
		
		// Stand Down
		if (character.currentInputState != Character.inputState.WalkDown && currentAnim != anim.StandDown && character.faceDirection == Character.facing.Down)
		{
			currentAnim = anim.StandDown;
			_animator.SetInteger (_animState, 1);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Walk Left
		if (character.currentInputState == Character.inputState.WalkLeft && currentAnim != anim.WalkLeft)
		{
			currentAnim = anim.WalkLeft;
			_animator.SetInteger(_animState, 5);
			_transform.localScale = new Vector3 (1, 1, 1);
		}
		
		// Stand Left
		if (character.currentInputState != Character.inputState.WalkLeft && currentAnim != anim.StandLeft && character.faceDirection == Character.facing.Left)
		{
			currentAnim = anim.StandLeft;
			_animator.SetInteger (_animState, 3);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Walk Right
		if (character.currentInputState == Character.inputState.WalkRight && currentAnim != anim.WalkRight)
		{
			currentAnim = anim.WalkRight;
			_animator.SetInteger(_animState, 5);
			_transform.localScale = new Vector3 (-1, 1, 1);
		}
		
		// Stand Right
		if (character.currentInputState != Character.inputState.WalkRight && currentAnim != anim.StandRight && character.faceDirection == Character.facing.Right)
		{
			currentAnim = anim.StandRight;
			_animator.SetInteger (_animState, 3);
			_transform.localScale = new Vector3 (-1, 1, 1);
		}

		// Attack Up
		if (currentAnim != anim.AttackUp && character.faceDirection == Character.facing.Up)
		{
			currentAnim = anim.AttackUp;
			_animator.SetInteger (_animState, 6);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Attack Down
		if (currentAnim != anim.AttackDown && character.faceDirection == Character.facing.Down)
		{
			currentAnim = anim.AttackDown;
			_animator.SetInteger (_animState, 6);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Attack Left
		if (currentAnim != anim.AttackLeft && character.faceDirection == Character.facing.Left)
		{
			currentAnim = anim.AttackLeft;
			_animator.SetInteger (_animState, 6);
			_transform.localScale = new Vector3 (1, 1, 1);
		}

		// Attack Right
		if (currentAnim != anim.AttackRight && character.faceDirection == Character.facing.Right)
		{
			currentAnim = anim.AttackRight;
			_animator.SetInteger (_animState, 6);
			_transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
}

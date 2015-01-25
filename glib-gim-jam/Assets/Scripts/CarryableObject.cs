using UnityEngine;
using System.Collections;

public class CarryableObject : MonoBehaviour 
{
	private Transform _transform;
	private Rigidbody2D _rigidbody;
	private Collider2D _collider;

	private bool isBeingCarried = false;

	private SpriteRenderer sprite;

	void Awake ()
	{
		_transform = transform;
		_rigidbody = rigidbody2D;
		_collider = collider2D;

		sprite = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	IEnumerator Start () 
	{
		return null;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void PickUp (Transform trans)
	{
		_transform.position = new Vector3 (trans.position.x, trans.position.y, trans.position.z);

		// Play a "pick up" sound

		isBeingCarried = true;

		sprite.sortingLayerName = "carried objects";
	}

	// Update object position so that it stays above the player's head when being carried
	public void UpdateObjectFollowPos (Transform trans)
	{
		_transform.position = new Vector3 (trans.position.x, trans.position.y, trans.position.z);
	}

	public IEnumerator SpawnObject ()
	{
		return null;
	}

	public void ThrowObject (Vector2 vel)
	{
		isBeingCarried = false;

		sprite.sortingLayerName = "objects";

		_rigidbody.AddForce (vel * 100.0f);
	}
}

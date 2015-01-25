using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			// Play audio
			Destroy (gameObject.collider2D);
			gameObject.renderer.enabled = false;
			Destroy (gameObject, 0.30f); // Destroy the object -after- the sound plays
		}
	}
}

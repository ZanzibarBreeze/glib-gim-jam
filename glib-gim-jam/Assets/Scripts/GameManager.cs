using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public static CarryableObject carryableObjects;
	public static ScoreManager scoreManager;

	public static PlayerOne player1;
	public static PlayerTwo player2;

	public static bool gameOver = false;



	// Use this for initialization
	void Start () 
	{
		carryableObjects = GameObject.FindWithTag ("CarryableObject").GetComponent<CarryableObject> ();
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		player1 = GameObject.Find ("Player1").GetComponent<PlayerOne> ();
//		player2 = GameObject.Find ("Player2").GetComponent<PlayerTwo> ();
	}
}

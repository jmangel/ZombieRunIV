using UnityEngine;
using System.Collections;

// Object spawns random obstacles in a random place in the road at a limited random time.
// preconditions: nothing besides that the game is running
// postconditions: an obstacle is spawned somewhere in the road with each recursvie call.


public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	//time delay variables
	public float spawnMin = .5f;
	public float spawnMax = 1f;

	//array of possible obstacle positions
	private int[] ranges = new int[11] {-10, -11, -12, -13, -14, -15, -16, -17, -18, -19, -20};

	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}

	// Recursive spawn function
	void Spawn ()
	{
		Instantiate (obj [Random.Range (0, obj.GetLength (0))], new Vector3 (ranges [Random.Range (0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax)); // delayed recursive call
	}
	}

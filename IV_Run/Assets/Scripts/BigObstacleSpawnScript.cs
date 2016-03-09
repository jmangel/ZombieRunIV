using UnityEngine;
using System.Collections;

public class BigObstacleSpawnScript : MonoBehaviour {


	public GameObject[] obj;
	public float spawnMin = 3f;
	public float spawnMax = 7f;

	//array of possible obstacle positions
	private int[] ranges = new int[8] { -12, -13, -14, -15, -16, -17, -18, -19};

	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}

	void Spawn()
	{
		Instantiate(obj[Random.Range(0,obj.GetLength(0))], new Vector3(ranges[Random.Range(0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin, spawnMax));
	}

}
using UnityEngine;
using System.Collections;

public class LargeObstacleSpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = .5f;
	public float spawnMax = 1f;

	//array of possible obstacle positions
	private int[] ranges = new int[10] {-11, -12, -13, -14, -15, -16, -17, -18, -19, -20};

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

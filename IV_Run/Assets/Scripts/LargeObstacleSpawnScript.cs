using UnityEngine;
using System.Collections;

//This class recursively spawns large obstacles on the road. This has a smaller range than the SpawnScript so that larger objects do not appear off the road.
//Pre conditions: none
//post conditons: A random obstacle is spawned on the road after each call

public class LargeObstacleSpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = .5f;
	public float spawnMax = 1f;

	//array of possible obstacle positions
	private int[] ranges = new int[10] {-11, -12, -13, -14, -15, -16, -17, -18, -19, -20}; //range of the road

	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}

	//Recursive function which waits a random delay before calling on itself again.
	void Spawn()
	{
		Instantiate(obj[Random.Range(0,obj.GetLength(0))], new Vector3(ranges[Random.Range(0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin, spawnMax)); //recursive call
	}

}

using UnityEngine;
using System.Collections;
//spawns the buildings on the road
public class BuildingSpawnScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = .5f;
	public float spawnMax = 1f;

	//array of possible obstacle positions
	private int[] ranges = new int[2] {-5,-27};

	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}
	//spawns random size buildings on the plane
	void Spawn()
	{
		Instantiate(obj[Random.Range(0,obj.GetLength(0))], new Vector3(ranges[Random.Range(0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin, spawnMax));
	}

}

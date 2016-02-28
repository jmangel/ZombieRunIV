using UnityEngine;
using System.Collections;

public class BuildingSpawnScript1 : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 5f;
	public float spawnMax = 15f;

	//array of left and right side-of-street x positions
	private float[] xranges = new float[2] {-28f, -2.5f};


	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}

	void Spawn()
	{
		Instantiate(obj[Random.Range(0,obj.GetLength(0))], new Vector3(xranges[Random.Range(0, xranges.Length)], 65.5f, transform.position.z), Quaternion.identity);
		Invoke ("Spawn",Random.Range(spawnMin, spawnMax));
	}

}

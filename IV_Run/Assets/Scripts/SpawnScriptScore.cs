using UnityEngine;
using System.Collections;

public class SpawnScriptScore : MonoBehaviour {
	public GameObject[] obj;
	int spawnMin = 4;
	int spawnMax = 12;
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	private int[] ranges = new int[8] { -12, -13, -14, -15, -16, -17, -18, -19};
	private bool isSpawning = false;

	// Update is called once per frame
	void Update ()
	{
		float score = GameObject.Find ("Main Camera").GetComponent<HUDScript> ().playerScore * 100;
		if (score >= 3400)
			isSpawning = true;
		//if (pos < .5f) isSpawning = true;
		if (score >= 6500) {
			spawnMax = 10;
			spawnMin = 3;
		}
		if (score >= 10000) {
			spawnMax = 8;
			spawnMin = 2;
		}


   		if (Time.time > nextActionTime && isSpawning == true) {
			period = Random.Range(spawnMin, spawnMax);
			nextActionTime = Time.time + period;
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], new Vector3 (ranges [Random.Range (0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		}
	}
}
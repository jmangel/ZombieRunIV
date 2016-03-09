using UnityEngine;
using System.Collections;

public class SpawnScriptNight : MonoBehaviour {
	public GameObject[] obj;
	//public int spawnMin = 0;
	//public int spawnMax = 1;
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	private int[] ranges = new int[11] { -10, -11, -12, -13, -14, -15, -16, -17, -18, -19, -20};
	private bool isSpawning = false;

	// Update is called once per frame
	void Update () {
		float pos = GameObject.Find("Sun").transform.position.y;
		pos = (pos + 28)/120;
		if (pos >= .5f) isSpawning = false;
		if (pos < .5f) isSpawning = true;

   		if (Time.time > nextActionTime && isSpawning == true) {
			period = Random.Range(1,4);
			nextActionTime = Time.time + period;
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], new Vector3 (ranges [Random.Range (0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		}
	}
}

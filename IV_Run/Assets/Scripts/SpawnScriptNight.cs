using UnityEngine;
using System.Collections;

// Spawn Script Night spawns enemies only when the Sun object is below a certain point in the sky/background.

public class SpawnScriptNight : MonoBehaviour {

	public GameObject[] obj;
	private float nextActionTime = 0.0f;
	public float period = 0.1f;
	private int[] ranges = new int[11] { -10, -11, -12, -13, -14, -15, -16, -17, -18, -19, -20}; // This range includes all available space on the road
	private bool isSpawning = false;

	// Update is called once per frame
	// Post condition: If the sun is below the half waw point in the sky, spawns randam obstacle in a random x location on the road

	void Update () {
		float pos = GameObject.Find("Sun").transform.position.y; // Finds the position of the sun at each frame
		pos = (pos + 28)/120; // converts to a value between 0-1
		if (pos >= .5f) isSpawning = false; 
		if (pos < .5f) isSpawning = true; 

   		if (Time.time > nextActionTime && isSpawning == true) {
			period = Random.Range(1,4);
			nextActionTime = Time.time + period;
			Instantiate (obj [Random.Range (0, obj.GetLength (0))], new Vector3 (ranges [Random.Range (0, ranges.Length)], transform.position.y, transform.position.z), Quaternion.identity);
		}
	}
}

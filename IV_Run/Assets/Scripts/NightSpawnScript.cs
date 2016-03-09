using UnityEngine;
using System.Collections;

public class NightSpawnScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("Sun").transform.position.y == 28) {
     		// show
			gameObject.GetComponent<SpawnScript>().enabled = true;
 		}
		if (GameObject.Find("Sun").transform.position.y > 30) {
		 	// hide

			gameObject.GetComponent<SpawnScript>().enabled = false;
		}
	
	}
}

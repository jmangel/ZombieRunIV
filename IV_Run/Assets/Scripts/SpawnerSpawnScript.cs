using UnityEngine;
using System.Collections;

public class SpawnerSpawnScript : MonoBehaviour {
	public GameObject[] obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("Sun").transform.position.y < -60) {
		Instantiate(
		}
	}
}

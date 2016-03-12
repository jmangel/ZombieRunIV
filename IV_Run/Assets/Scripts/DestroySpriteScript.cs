using UnityEngine;
using System.Collections;

//This class ensures everything is destroyed
//Pre conditions: none
//Post conditions: if any sprites haven't been destroyed by the Destroyer Script, they are destroyed after 15 seconds.

public class DestroySpriteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}

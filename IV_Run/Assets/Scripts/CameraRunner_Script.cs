using UnityEngine;
using System.Collections;

// has the camera follow the player
public class CameraRunner_Script : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	//Pre: Must have player option
	//Post: keeps the camera postion above the camera.
	void Update ()
	{
		
		transform.position = new Vector3 (-15, 70, player.position.z - 80);
	}
}

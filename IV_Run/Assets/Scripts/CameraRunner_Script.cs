using UnityEngine;
using System.Collections;

public class CameraRunner_Script : MonoBehaviour {

	public Transform player;
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (-15, 70, player.position.z - 80);
	}
}

using UnityEngine;
using System.Collections;

// Pre conditions: none
// Post conditions: if the player collides with an obstacle object, the object is destroyed. 

public class Destroyer_Script : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.parent) {
			Destroy(other.gameObject.transform.parent.gameObject);
		} 
		else {
			Destroy(other.gameObject);
		}
	}
}

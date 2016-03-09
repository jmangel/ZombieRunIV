using UnityEngine;
using System.Collections;

public class demoscript : MonoBehaviour {

	public Light myLight;
	void Update()
	{
		if (Input.GetKeyDown ("space")) {
			myLight.enabled = myLight.enabled;
		} 

	}
}

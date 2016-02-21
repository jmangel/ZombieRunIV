﻿using UnityEngine;
using System.Collections;

public class Destroyer_Script : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} 
		else {
			Destroy(other.gameObject);
		}
	}
}

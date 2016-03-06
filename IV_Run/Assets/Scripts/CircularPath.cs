using UnityEngine;
using System.Collections;

public class CircularPath : MonoBehaviour {

	//radius of circular path
	public float radius = 10f;

	//speed of object moving in path
	public float speed = 1f;

	//remains true 
	public bool offSetIsCenter = true;

	//vector
	public Vector3 offset;

	void Start()
	{
		if (offSetIsCenter) {
			offset = transform.position;
		}
	}

	void Update()
	{
		transform.position = new Vector3 (
			(radius * Mathf.Cos (Time.time * speed)) + offset.x,
			(radius * Mathf.Sin (Time.time * speed)) + offset.y,
			transform.position.z);
	}
}

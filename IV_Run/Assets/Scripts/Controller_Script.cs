using UnityEditor;
using UnityEngine;
using System.Collections;

public class Controller_Script : MonoBehaviour {

	public float maxSpeed =10;
	public float speedZ =50;

	public float jumpForce = 700;

	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		float movex = Input.GetAxis ("Horizontal");
		float movez = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody> ().velocity = new Vector3 (movex * maxSpeed, GetComponent<Rigidbody> ().velocity.y, speedZ); 
	}
	void Update()
	{
		
		if(GameObject.Find("Character").transform.position.y ==65.5 && Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,speedZ));
		}
		if (GameObject.Find ("Character").transform.position.y > 65.5 && Input.GetKeyDown (KeyCode.DownArrow)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -jumpForce, speedZ));
		}

	//void Flip
	}
}

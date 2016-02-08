using UnityEngine;
using System.Collections;

public class Controller_Script : MonoBehaviour {

	public float maxSpeed =10;

	public float jumpForce = 700;

	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		float movex = Input.GetAxis ("Horizontal");
		//float movey = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody> ().velocity = new Vector3 (movex * maxSpeed, GetComponent<Rigidbody> ().velocity.y, GetComponent<Rigidbody> ().velocity.z); 
	}
	void Update()
	{
		
		if(GameObject.Find("Character").transform.position.y <=66 && Input.GetKeyDown(KeyCode.Space))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,0));
		}
	//void Flip
}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller_Script : MonoBehaviour {

	public float maxSpeed =3;
	public float speedZ =50;

	public float jumpForce = 700;
	bool CanPause = true;
	public bool showGUI = false;
	public LayerMask whatIsGround;
	private Transform objectTransfom;
	private float noMovementThreshold = 0.0001f;
	private const int noMovementFrames = 3;
	Vector3[] previousLocations = new Vector3[noMovementFrames];
	private bool isMoving;
	public bool IsMoving
	{
		get{ return isMoving; }
	}


	// Use this for initialization
	void Start () {
		 CanPause = true;
		Time.timeScale = 4;
	
	}
	void Awake()
	{
		//For good measure, set the previous locations
		for(int i = 0; i < previousLocations.Length; i++)
		{
			previousLocations[i] = Vector3.zero;
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		float movex = Input.GetAxis ("Horizontal");

		GetComponent<Rigidbody> ().velocity = new Vector3 (movex * maxSpeed, GetComponent<Rigidbody> ().velocity.y, speedZ); 
	}

	void Update()
	{
		if(GameObject.Find("Character").transform.position.y <= 66 && Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,speedZ));
		}
		if (GameObject.Find ("Character").transform.position.y > 65.5 && Input.GetKeyDown (KeyCode.DownArrow)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -jumpForce, speedZ));
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (CanPause) {
				Debug.Log ("pause");
				Time.timeScale = 0;
				CanPause = false;
				showGUI = true;
			} else {
				CanPause = true;
				showGUI = false;
				Time.timeScale = 4;
			}
				
		}


	}
	void OnGUI()
	{
		if(showGUI)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2-75, 100, 50), "Continue")) {
				showGUI = false;
				Time.timeScale = 4;
				CanPause = true;
				
			}
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 50),"Restart" ))
			{
				showGUI = false;
                GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire = 0;
                SceneManager.LoadScene ("demoscene");
				//Time.timeScale = 1;
				//CanPause = true;
			}
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2+75, 100, 50),"Main Menu"))
			{
				SceneManager.LoadScene ("ZRIV - Main Menu");
				//Time.timeScale = 1;
				//CanPause = true;
			}
		}

	}
}

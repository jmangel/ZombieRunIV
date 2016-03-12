using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//has all the controls for character

public class Controller_Script : MonoBehaviour {

	public float maxSpeed =3;    //speed in x axis
	public float speedZ =50;     //speed in z axis

	public float jumpForce = 700;   //force of jump
	bool CanPause = true;			//can pause game
	public bool showGUI = false;    // shows GUI
	private const int noMovementFrames = 3;    //checks movement
	Vector3[] previousLocations = new Vector3[noMovementFrames];   //keeps storage of previous locations
	private bool audio = true;    //checks audio



	// Use this for initialization
	void Start () {
		 CanPause = true;
		Time.timeScale = 4;
		AudioListener.volume = 1;

	
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

	//gets Rigidbody velocity
	void FixedUpdate () {
		float movex = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody> ().velocity = new Vector3 (movex * maxSpeed, GetComponent<Rigidbody> ().velocity.y, speedZ); 
	}

	void Update()
	{
		//jump if up arrow is pressed
		if(GameObject.Find("Character").transform.position.y <= 66 && Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0,jumpForce,speedZ));
		}
		// quickly lower if in the air if down arrow pressed
		if (GameObject.Find ("Character").transform.position.y > 65.5 && Input.GetKeyDown (KeyCode.DownArrow)) {
			GetComponent<Rigidbody> ().AddForce (new Vector3 (0, -jumpForce, speedZ));
		}

		//pause game if escape key is press
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (CanPause) {
				Debug.Log ("pause");
				Time.timeScale = 0;
				CanPause = false;
				showGUI = true;
				AudioListener.volume = 0;
			} 
			//if escape button pressed in pop up, then resume game
			else {
				CanPause = true;
				showGUI = false;
				Time.timeScale = 4;
				AudioListener.volume = 1;
			}
				
		}
		//mute game or unmute game
		if(Input.GetKeyDown(KeyCode.M))
		{
			if (audio) {
				
				AudioListener.volume = 0;
				audio = false;
			} else {
				AudioListener.volume = 1;
				audio = true;
			}
		}


	}
	//PRE: NONE
	//POST: shows or close GUI
	void OnGUI()
	{
		// if showGUI is true
		if(showGUI)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			//creates button, if press continue gameplay
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2-75, 100, 50), "Continue")) {
				showGUI = false;
				Time.timeScale = 4;
				CanPause = true;
				AudioListener.volume = 1;
				
			}
			//restarts game if  restart button is pressed
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 50),"Restart" ))
			{
				showGUI = false;
                GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire = 0;
                SceneManager.LoadScene ("demoscene");

			}
			//goes to main menu if main menu button pressed
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2+75, 100, 50),"Main Menu"))
			{
				SceneManager.LoadScene ("ZRIV - Main Menu");

			}
		}

	}
}


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller_Script : MonoBehaviour {

	public float maxSpeed =10;
	public float speedZ =50;

	public float jumpForce = 700;
	bool CanPause = true;
	bool showGUI = false;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		 CanPause = true;
	
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
				Time.timeScale = 1;
			}

		}


	//void Flip
	}
	void OnGUI()
	{
		if(showGUI)
		{
			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2-75, 100, 50), "Continue")) {
				showGUI = false;

				Time.timeScale = 1;
				CanPause = true;
				
			}
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 50),"Restart"))
			{
				showGUI = false;
				SceneManager.LoadScene (1);
				Time.timeScale = 1;
				CanPause = true;
			}
			if(GUI.Button (new Rect (Screen.width / 2, Screen.height / 2+75, 100, 50),"Main Menu"))
			{
				SceneManager.LoadScene (0);
				Time.timeScale = 1;
				CanPause = true;
			}
		}

	}
}

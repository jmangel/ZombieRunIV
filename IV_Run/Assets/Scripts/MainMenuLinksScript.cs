using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuLinksScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HoverOverAbout() {
		GameObject.Find ("AboutLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	public void HoverOutAbout() {
		GameObject.Find ("AboutLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	public void ClickAbout() {
		Debug.LogError ("Clicked the about link");
	}

	public void HoverOverHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	public void HoverOutHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	public void ClickHowTo() {
		Debug.LogError ("Clicked the howto link");
	}

	public void HoverOverCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	public void HoverOutCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	public void ClickCredits() {
		Debug.LogError ("Clicked the credits link");
	}
}

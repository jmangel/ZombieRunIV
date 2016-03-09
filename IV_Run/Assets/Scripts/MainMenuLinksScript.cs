using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene ("About");
	}

	public void HoverOverHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	public void HoverOutHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	public void ClickHowTo() {
		SceneManager.LoadScene ("Instructions");
	}

	public void HoverOverCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	public void HoverOutCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	public void ClickCredits() {
		SceneManager.LoadScene ("Credits");
	}
}

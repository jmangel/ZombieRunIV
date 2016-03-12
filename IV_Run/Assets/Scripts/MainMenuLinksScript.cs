using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuLinksScript : MonoBehaviour {

	//when you start hovering over the About button, highlights the button
	public void HoverOverAbout() {
		GameObject.Find ("AboutLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	//when you stop hovering over the About button, returns coloring to normal
	public void HoverOutAbout() {
		GameObject.Find ("AboutLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	//when you click the About button, loads the About scene
	public void ClickAbout() {
		SceneManager.LoadScene ("About");
	}

	//when you start hovering over the HowTo button, highlights the button
	public void HoverOverHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	//when you stop hovering over the HowTo button, returns coloring to normal
	public void HoverOutHowTo() {
		GameObject.Find ("HowToLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	//when you click the HowTo button, loads the HowTo scene
	public void ClickHowTo() {
		SceneManager.LoadScene ("Instructions");
	}

	//when you start hovering over the Credits button, highlights the button
	public void HoverOverCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(66.0f/255,139.0f/255,202.0f/255,1f);
	}

	//when you stop hovering over the Credits button, returns coloring to normal
	public void HoverOutCredits() {
		GameObject.Find ("CreditsLink").GetComponent<Text> ().color = new Color(50.0f/255,50.0f/255,50.0f/255,1f);
	}

	//when you click the Credits button, loads the Credits scene
	public void ClickCredits() {
		SceneManager.LoadScene ("Credits");
	}
}

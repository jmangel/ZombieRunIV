using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//gets players name and stores it
public class NameInputButtonScript : MonoBehaviour {
	//PRE:NONE
	//POST: gets player name
	public void onClick () {
		string text = GameObject.Find ("NameInput").GetComponent<InputField> ().text;
		//checks if player entered name
		if (text.Length == 0) {
			GameObject.Find ("InputError").GetComponent<Text> ().text = "* You must input a name.";

		}
		//stores player name and go to ZRIV- Main Menu
		else {
			GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().player_name = text;
			Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
			SceneManager.LoadScene ("ZRIV - Main Menu");
			GameObject.Find ("InputError").GetComponent<Text> ().text = x.toString();
		}
	}

}

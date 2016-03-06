using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NameInputButtonScript : MonoBehaviour {

	public void onClick () {
		string text = GameObject.Find ("NameInput").GetComponent<InputField> ().text;
		if (text.Length == 0) {
			GameObject.Find ("InputError").GetComponent<Text> ().text = "* You must input a name.";
		} else {
			GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().player_name = text;
			Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
			SceneManager.LoadScene (0);
			GameObject.Find ("InputError").GetComponent<Text> ().text = x.toString();
		}
	}

}

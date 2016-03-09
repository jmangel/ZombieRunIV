using UnityEngine;
using System.Collections;

public class CharacterChoice : MonoBehaviour {
	void Awake ()
	{
		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer ();
		int choice = x.getCharacters ();

		if (choice <= 1) {
			GameObject.Find ("char1").SetActive (true);
			GameObject.Find ("char2").SetActive (false);
		}
		if (choice >= 2) {
			GameObject.Find ("char1").SetActive (false);
			GameObject.Find ("char2").SetActive (true);
		}
	}
}
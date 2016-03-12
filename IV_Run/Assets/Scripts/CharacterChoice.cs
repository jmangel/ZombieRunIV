using UnityEngine;
using System.Collections;

//find the PlayerGameObject player, sees what player they want to be
//other character is there but set to invisible
public class CharacterChoice : MonoBehaviour {
	//starts before loading scene
	//Pre: NONE
	//Post: chooses character
	void Awake ()
	{
		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer ();
		int choice = x.getCharacters ();

		//chooses first character
		if (choice <= 1) {
			GameObject.Find ("char1").SetActive (true);
			GameObject.Find ("char2").SetActive (false);
		}

		//chooses second character
		if (choice >= 2) {
			GameObject.Find ("char1").SetActive (false);
			GameObject.Find ("char2").SetActive (true);
		}
	}
}
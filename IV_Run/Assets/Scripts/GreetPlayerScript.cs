using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GreetPlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player player = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
		GameObject.Find ("GreetPlayer").GetComponent<Text> ().text = "Hello, " + player.getName () + "!";
	}

}

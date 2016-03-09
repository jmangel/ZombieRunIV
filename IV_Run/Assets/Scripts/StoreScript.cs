using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoreScript : MonoBehaviour {
    //int duration = 10; //make this get the duration from the database
    //int cost = 20;

    void OnGUI()
    {
		Debug.LogError ("started store");
		Player x = GameObject.Find ("PlayerGameObject").GetComponent<PlayerSingleton> ().getPlayer();
		GameObject.Find ("HifiveCount").GetComponent<Text> ().text = "" + x.getHiFives ();
		if (x.getCharacters () <= 1) {
			GameObject.Find ("MikeSelected").GetComponent<Text> ().text = "";
		} else {
			GameObject.Find ("SurferSelected").GetComponent<Text> ().text = "";
		}

		GameObject.Find ("CurrentPowerupLvlText").GetComponent<Text> ().text = "Current Powerup Level: " + x.getPowerupLvl ();
        //GUI.Label(new Rect(400, 400, 200, 30), "Current powerup duration: " + duration);
        //GUI.Label(new Rect(400, 430, 300, 30), "Next upgrade duration: " + (duration+5) + ", Cost: " + cost + " high fives");
    }
}

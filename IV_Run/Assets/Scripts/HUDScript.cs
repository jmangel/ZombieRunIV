using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	public const float scorePerMillisecond = 0.1f; //0.1 per millisecond means 100 points per second

	//keep track of some of the stats to display on top of screen
	public float playerScore = 0;
    public int runHighFives = 0;

	//style for the Label displays
    GUIStyle recentlyHitStyle = new GUIStyle();
    GUIStyle invincibilityStyle = new GUIStyle();
    GUIStyle highFiveStyle = new GUIStyle();
    GUIStyle scoreStyle = new GUIStyle();

	//adds to score based on time
	void Update () {
		playerScore += scorePerMillisecond*Time.deltaTime;
	}

	//rewrites the GUI continuously to reflect updated score, invincibility time, etc.
	void OnGUI()
	{
		//displays score on GUI
        scoreStyle.fontSize = 20;
        scoreStyle.normal.textColor = Color.blue;
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100), scoreStyle);

        invincibilityStyle.normal.textColor = Color.white;
        invincibilityStyle.fontSize = 20;
        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire)
        { //displays invincibility time if greater than 0
            GUI.Label(new Rect(150, 10, 250, 30), "Invincibility Time: " + ((GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire - Time.time)/4.0).ToString("F2"), invincibilityStyle); //divide by 4 because of timeScale
        }
        // displays invincibility time as 0 otherwise
        else GUI.Label(new Rect(150, 10, 250, 30), "Invincibility Time: 0", invincibilityStyle);

        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire)
        { //displays time left to heal if you've been recently hit
            recentlyHitStyle.normal.textColor = Color.red;
            recentlyHitStyle.fontSize = 20;
            recentlyHitStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(0, 10, Screen.width, 30), "You've been hit! Time until healed: " + ((GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire - Time.time)/4.0).ToString("F2"), recentlyHitStyle); //divide by 4.0 because of timeScale
            GUI.Label(new Rect(0, 40, Screen.width, 30), "(if you get hit again before this time, you die!)", recentlyHitStyle);
        }

        //displays number of high fives
        highFiveStyle.normal.textColor = Color.yellow;
        highFiveStyle.fontSize = 20;
        highFiveStyle.alignment = TextAnchor.UpperRight;
        GUI.Label(new Rect(0, 10, Screen.width-10, 30), "High Fives: " + runHighFives, highFiveStyle);
    }
}

using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	public const float scorePerMillisecond = 0.1f; //0.1 means 100 points per second

	public float playerScore = 0;
    public int runHighFives = 0;
	int multiplier = 1;
	int currentMultiplier = 1;

    GUIStyle recentlyHitStyle = new GUIStyle();
    GUIStyle invincibilityStyle = new GUIStyle();
    GUIStyle highFiveStyle = new GUIStyle();
    GUIStyle scoreStyle = new GUIStyle();

	// Update is called once per frame
	void Update () {
		playerScore += scorePerMillisecond*currentMultiplier*Time.deltaTime;
	}

	public void IncreaseMultiplierTemp(int amount, int secs){
		currentMultiplier += amount;
		float startScore = playerScore;

		//wait for some given seconds
	
		do {
		} while ((playerScore-startScore)/(scorePerMillisecond*currentMultiplier*1000) > secs);
		//revert currentMultiplier to level multiplier
		currentMultiplier = multiplier;
	}

	public void SetMultiplier(int mult)
	{
		if (mult > multiplier) //should always be true 
		{
			multiplier = mult;
		}
		if (mult > currentMultiplier) 
		{
			currentMultiplier = mult;
		}
	}

	void OnGUI()
	{
        scoreStyle.fontSize = 20;
        scoreStyle.normal.textColor = Color.blue;
        GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100), scoreStyle);

        invincibilityStyle.normal.textColor = Color.white;
        invincibilityStyle.fontSize = 20;
        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire)
        {
            GUI.Label(new Rect(150, 10, 250, 30), "Invincibility Time: " + (GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire - Time.time)/4.0, invincibilityStyle); //divide by 4 because of timeScale
        }
        else GUI.Label(new Rect(150, 10, 250, 30), "Invincibility Time: 0", invincibilityStyle);

        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire)
        {
            recentlyHitStyle.normal.textColor = Color.red;
            recentlyHitStyle.fontSize = 20;
            recentlyHitStyle.alignment = TextAnchor.UpperCenter;
            GUI.Label(new Rect(0, 10, Screen.width, 30), "You've been hit! Time until healed: " + (GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire - Time.time)/4.0, recentlyHitStyle); //divide by 4.0 because of timeScale
            GUI.Label(new Rect(0, 40, Screen.width, 30), "(if you get hit again before this time, you die!)", recentlyHitStyle);
        }

        highFiveStyle.normal.textColor = Color.yellow;
        highFiveStyle.fontSize = 20;
        highFiveStyle.alignment = TextAnchor.UpperRight;
        GUI.Label(new Rect(0, 10, Screen.width-10, 30), "High Fives: " + runHighFives, highFiveStyle);
    }
}

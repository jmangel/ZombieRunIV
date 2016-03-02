using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	public const float scorePerMillisecond = 0.1f; //0.1 means 100 points per second

	public float playerScore = 0;
	int multiplier = 1;
	int currentMultiplier = 1;


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
		GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100));
        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire)
        {
            GUI.Label(new Rect(120, 10, 250, 30), "Invincibility Time: " + (GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire - Time.time));
        }
        else GUI.Label(new Rect(120, 10, 250, 30), "Invincibility Time: 0");
        if (Time.time < GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire)
        {
            GUI.Label(new Rect(380, 10, 500, 30), "Time since last hit: " + (GameObject.Find("Character").GetComponent<CollisionScript>().recentlyHitExpire - Time.time) + " (if you get hit again before this time, you die!)");
        }
    }
}

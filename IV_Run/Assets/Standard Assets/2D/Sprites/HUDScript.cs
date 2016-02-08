using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {
	public const float scorePerMillisecond = 0.1f; //0.1 means 100 points per second

	float playerScore = 0;
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
	}
}

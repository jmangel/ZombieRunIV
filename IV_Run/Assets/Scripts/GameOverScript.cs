using UnityEngine;
using System.Collections;

//This class initializes the game over scene (after the player hits 2 obstacles in a short time) and displays the appropriate stats and buttons
//Pre conditions: none
//Post conditions: the game over screen is initialized and the player can see all of their stats.
//                 if the player had a new highscore it tells them

public class GameOverScript : MonoBehaviour
{
    GUIStyle scoreDisplayStyle = new GUIStyle();
    GUIStyle highScoreStyle = new GUIStyle();

    void OnGUI()
    {
        scoreDisplayStyle.fontSize = 40;
        scoreDisplayStyle.normal.textColor = Color.black;
        scoreDisplayStyle.alignment = TextAnchor.UpperCenter;
        
        highScoreStyle.fontSize = 60;
		highScoreStyle.normal.textColor = Color.blue;
        highScoreStyle.alignment = TextAnchor.UpperCenter;

        Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
        int rank = x.getLastRank();
        
        GUI.Label(new Rect(0, Screen.height / 2 + 130, Screen.width, 50), "Your Score was " + (int)(x.getLastScore()) + ", it is the #" + rank + " best score", scoreDisplayStyle);
        GUI.Label(new Rect(0, Screen.height / 2 + 190, Screen.width, 50), "You got " + x.getLastHifives() + " High-Fives, your High-Five total is " + x.getHiFives(), scoreDisplayStyle);
        if (rank == 1) GUI.Label(new Rect(0, Screen.height / 2 + 250, Screen.width, 50), "New High Score!", highScoreStyle);
    }
}

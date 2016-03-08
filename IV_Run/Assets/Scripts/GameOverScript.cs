using UnityEngine;
using System.Collections;

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
        highScoreStyle.normal.textColor = Color.green;
        highScoreStyle.alignment = TextAnchor.UpperCenter;

        Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
        int rank = x.getLastRank();
        
        GUI.Label(new Rect(0, Screen.height / 2 + 100, Screen.width, 50), "Your Score was " + (int)(x.getLastScore()) + ", it is your #" + rank + " best score", scoreDisplayStyle);
        GUI.Label(new Rect(0, Screen.height / 2 + 160, Screen.width, 50), "You got " + x.getLastHifives() + " high fives, your total is " + x.getHiFives(), scoreDisplayStyle);
        if (rank == 1) GUI.Label(new Rect(0, Screen.height / 2 + 220, Screen.width, 50), "New High Score!", highScoreStyle);
        //GUI.Label(new Rect(0, Screen.height / 2 + 100, Screen.width, 50), "Your score was 0, its rank is -1", scoreDisplayStyle);
    }
}

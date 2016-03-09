using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StatsScript : MonoBehaviour {
	//declare GUI styles for text
	GUIStyle nameStyle = new GUIStyle();

    GUIStyle fieldStyle = new GUIStyle();
    GUIStyle valueStyle = new GUIStyle();
    GUIStyle centerStyle = new GUIStyle();

    void OnGUI()
    {
    	//initialize GUI styles for text
        nameStyle.fontSize = 65;
        nameStyle.normal.textColor = Color.white;
        nameStyle.alignment = TextAnchor.UpperCenter;
        
        fieldStyle.fontSize = 40;
		fieldStyle.normal.textColor = Color.white;
        fieldStyle.alignment = TextAnchor.MiddleRight;

        centerStyle.fontSize = 40;
        centerStyle.normal.textColor = Color.white;
        centerStyle.alignment = TextAnchor.UpperCenter;

        valueStyle.fontSize = 30;
		valueStyle.normal.textColor = Color.yellow;
        valueStyle.alignment = TextAnchor.MiddleLeft;

        //initialize Player object to get stats
        Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
        int myHighScore = x.getScores()[0].score;
        List<Score> highScores = ApiClient.getScores();
        
        //display name
        GUI.Label(new Rect(0, 10, Screen.width, 50), x.getName(), nameStyle);

        //display left-hand fields (personal stats)
        GUI.Label(new Rect(10, 120, Screen.width/4-20, 50), "Your high score: ", fieldStyle);
        GUI.Label(new Rect(10, 190, Screen.width/4-20, 50), "Your High-Fives: ", fieldStyle);
    	
    	//display left-hand values (personal stats)
        GUI.Label(new Rect(Screen.width/4+10, 120, Screen.width/4-20, 50), "" + myHighScore, valueStyle);
        GUI.Label(new Rect(Screen.width/4+10, 190, Screen.width/4-20, 50), "" + x.getHiFives(), valueStyle);

        //display right-hand fields (leaderboard)
        GUI.Label(new Rect(Screen.width/2-50, 120, Screen.width/2-190, 50), "Online Leaderboard: ", fieldStyle);
        GUI.Label(new Rect(Screen.width-220, 120, 50, 50), "#1:", fieldStyle);
        GUI.Label(new Rect(Screen.width-220, 190, 50, 50), "#2:", fieldStyle);
        GUI.Label(new Rect(Screen.width-220, 260, 50, 50), "#3:", fieldStyle);
        GUI.Label(new Rect(Screen.width-220, 330, 50, 50), "#4:", fieldStyle);
        GUI.Label(new Rect(Screen.width-220, 400, 50, 50), "#5:", fieldStyle);

        //display right-hand values (leaderboard)
        GUI.Label(new Rect(Screen.width-160, 120, 150, 50), "" + highScores[0].score + " " + highScores[0].name, valueStyle);
        GUI.Label(new Rect(Screen.width-160, 190, 150, 50), "" + highScores[1].score + " " + highScores[1].name, valueStyle);
        GUI.Label(new Rect(Screen.width-160, 260, 150, 50), "" + highScores[2].score + " " + highScores[2].name, valueStyle);
        GUI.Label(new Rect(Screen.width-160, 330, 150, 50), "" + highScores[3].score + " " + highScores[3].name, valueStyle);
        GUI.Label(new Rect(Screen.width-160, 400, 150, 50), "" + highScores[4].score + " " + highScores[4].name, valueStyle);
    }
}

using UnityEngine;
using System.Collections;

public class StoreScript : MonoBehaviour {
    //int duration = 10; //make this get the duration from the database
    //int cost = 20;

    public void onClick()
    {
        OnGUI();
    }
    void OnGUI()
    {
        //GUI.Label(new Rect(400, 400, 200, 30), "Current powerup duration: " + duration);
        //GUI.Label(new Rect(400, 430, 300, 30), "Next upgrade duration: " + (duration+5) + ", Cost: " + cost + " high fives");
    }
}

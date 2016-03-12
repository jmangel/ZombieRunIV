using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//on click, go back to ZRIV - Main Menu
public class HighFiveStoreButton : MonoBehaviour
{
	//Pre:NONE
	//POST: go to HighFiveStore

    public void onClick()
    {
        SceneManager.LoadScene("HighFiveStore");
    }
}

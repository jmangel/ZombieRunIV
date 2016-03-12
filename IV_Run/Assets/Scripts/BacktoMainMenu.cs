using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//on click, go back to ZRIV - Main Menu
public class BacktoMainMenu : MonoBehaviour {

	//pre-condition: NONE
	//post-condition: go to ZRIV - Main Menu
	public void onClick()
	{
		SceneManager.LoadScene ("ZRIV - Main Menu");
	}
}

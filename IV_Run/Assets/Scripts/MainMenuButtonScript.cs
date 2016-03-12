using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//on click, go back to ZRIV - Main Menu
public class MainMenuButtonScript : MonoBehaviour {
	//PRE:NONE
	//POST:return to ZRIV - Main Menu scene
	public void onClick(){

		SceneManager.LoadScene ("ZRIV - Main Menu");
	}
}
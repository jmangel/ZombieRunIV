using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour {

	public void onClick(){

		SceneManager.LoadScene (0);
	}
}
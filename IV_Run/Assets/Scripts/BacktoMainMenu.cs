using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BacktoMainMenu : MonoBehaviour {

	public void onClick()
	{
		SceneManager.LoadScene ("ZRIV - Main Menu");
	}
}

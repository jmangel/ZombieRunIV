using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
// loads stats scene
public class StatsButtonScript : MonoBehaviour {
	//PRE:NONE
	//POST: loads stats screen
	public void onClick(){
		SceneManager.LoadScene ("Stats");
	}
}
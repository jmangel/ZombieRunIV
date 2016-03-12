using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//loads demoscene for gameplay
public class PlayButtonScript : MonoBehaviour {
	//PRE:NONE
	//POST: loads demoscene for gameplay
	public void onClick(){
		SceneManager.LoadScene ("demoscene");
	}
}

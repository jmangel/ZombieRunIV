using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatsButtonScript : MonoBehaviour {

	public void onClick(){
		SceneManager.LoadScene ("Stats");
	}
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionButtonScript : MonoBehaviour {

	public void onClick(){
		SceneManager.LoadScene ("Instructions");
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This class loads the Instrucions scene
// preconditions: none
// Postconditions: the Instructions scene is loaded

public class InstructionButtonScript : MonoBehaviour {

	public void onClick(){
		SceneManager.LoadScene ("Instructions");
	}

}

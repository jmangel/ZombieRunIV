using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {
	
	public void onClick(){
        GameObject.Find("Character").GetComponent<CollisionScript>().invincibilityExpire = 0;
		SceneManager.LoadScene (1);
	}
}

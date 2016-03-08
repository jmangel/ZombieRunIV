using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //initialize variables for invincibility powerups
    public int invincibilityTime = 10*4; //get this from upgrade settings in database
    public float invincibilityExpire = 0;

    public float recentlyHitExpire = 0;
    public int recentlyHitTime = 5*4;

	public GameObject[] zom;

	public void zombieTimeout (GameObject z)
	{

	}
    
    void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "PowerUp") {
			Destroy (collision.gameObject);
			invincibilityExpire = Time.time + invincibilityTime;
			recentlyHitExpire = 0;

		}
        
		if (collision.gameObject.tag == "Untagged") {
			if (Time.time > invincibilityExpire) {
				//do obstacular stuffs
				if (Time.time > recentlyHitExpire) { //if you haven't been hit recently
					Destroy (collision.gameObject);
					recentlyHitExpire = Time.time + recentlyHitTime;

					//spawn zombie animation behind character
					GameObject Zombies = (GameObject) Instantiate (zom[0], new Vector3 (-15, 66, transform.position.z - 15), Quaternion.identity);
					Destroy (Zombies, 20);

				} else { //if this is second hit in short amount of time
					SceneManager.LoadScene (2);
				}
			} else { //if invincible
				Destroy (collision.gameObject);
			}
		}
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //initialize variables for invincibility powerups and last hit
    public float invincibilityExpire = 0;
    public float recentlyHitExpire = 0;

    int invincibilityTime = 5*4; //get this from upgrade settings in database
    int recentlyHitTime = 5*4; //these are x4 because of timeScale

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
        
        else if (collision.gameObject.tag == "Ped"){
            Destroy(collision.gameObject);
            GameObject.Find("Main Camera").GetComponent<HUDScript>().runHighFives += 1;
        }

		else if (collision.gameObject.tag == "Untagged") {
			if (Time.time > invincibilityExpire) {
				if (Time.time > recentlyHitExpire) { //if you haven't been hit recently
					Destroy (collision.gameObject);
					recentlyHitExpire = Time.time + recentlyHitTime;

					//spawn zombie animation behind character
					GameObject Zombies = (GameObject) Instantiate (zom[0], new Vector3 (-15, 66, transform.position.z - 15), Quaternion.identity);
					Destroy (Zombies, 20);

				} else { //if this is second hit in short amount of time
					Time.timeScale = 0;
                    Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
                    x.addHiFives(GameObject.Find("Main Camera").GetComponent<HUDScript>().runHighFives);
                    x.saveHiFives();
                    x.addScore((int)(GameObject.Find("Main Camera").GetComponent<HUDScript>().playerScore * 100));

					SceneManager.LoadScene (2);
				}
			} else { //if invincible
				Destroy (collision.gameObject);
			}
		}
    }
}

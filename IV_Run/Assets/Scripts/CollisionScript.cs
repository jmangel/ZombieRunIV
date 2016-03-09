using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //initialize variables for invincibility powerups and last hit
    public float invincibilityExpire = 0;
    public float recentlyHitExpire = 0;

    //Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
    int invincibilityTime = 2*4; //*4 because of timeScale
    int recentlyHitTime = 5*4; //these are x4 because of timeScale
    bool invincibilityTimeUpdated = false;

	public GameObject[] zom;

	public void zombieTimeout (GameObject z)
	{

	}
    
    void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "PowerUp") {
			if (invincibilityTime<=2*4 && !invincibilityTimeUpdated) {
				Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
				invincibilityTime = 2*(int)(Mathf.Sqrt(Mathf.Abs(x.getPowerupLvl())))*4;
				invincibilityTimeUpdated = true;
			}

			Destroy (collision.gameObject);
			
			if (Time.time < invincibilityExpire){ //if you're already invincible
				invincibilityExpire = invincibilityExpire + invincibilityTime;
			}
			else{ 
				invincibilityExpire = Time.time + invincibilityTime;
			}
			audioPowerUp.Play();
			
			recentlyHitExpire = 0;
		}
        
        else if (collision.gameObject.tag == "Ped"){
            Destroy(collision.gameObject);
            GameObject.Find("Main Camera").GetComponent<HUDScript>().runHighFives += 1;
			audioHighFive.Play();
        }

		else if (collision.gameObject.tag == "Untagged") {
			if (Time.time > invincibilityExpire) {
				if (Time.time > recentlyHitExpire) { //if you haven't been hit recently
					Destroy (collision.gameObject);
					recentlyHitExpire = Time.time + recentlyHitTime;

					//spawn zombie animation behind character
					GameObject Zombies = (GameObject) Instantiate (zom[0], new Vector3 (-15, 66, transform.position.z - 15), Quaternion.identity);
					audioZombieGrowl.Play();
					Destroy (Zombies, 20);

				} else { //if this is second hit in short amount of time
					Time.timeScale = 0;
                    Player x = GameObject.Find("PlayerGameObject").GetComponent<PlayerSingleton>().getPlayer();
                    x.addHiFives(GameObject.Find("Main Camera").GetComponent<HUDScript>().runHighFives);
                    x.saveHiFives();
                    x.addScore((int)(GameObject.Find("Main Camera").GetComponent<HUDScript>().playerScore * 100));

					SceneManager.LoadScene ("ZRIV - Main Menu copy");
				}
			} else { //if invincible
				Destroy (collision.gameObject);
			}
		}
	}

	public AudioClip highFive;
 	public AudioClip zombieGrowl;
 	public AudioClip powerUp; 
	//public AudioClip clipWeapon2;
 
 	private AudioSource audioHighFive;
 	private AudioSource audioZombieGrowl;
 	private AudioSource audioPowerUp;
 	//private AudioSource audioWeapon2;
 
 	public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol) 
 		{ 
     	//AudioSource newAudio = gameObject.AddComponent(AudioSource);
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
     	newAudio.clip = clip; 
     	newAudio.loop = loop;
     	newAudio.playOnAwake = playAwake;
     	newAudio.volume = vol; 
     	return newAudio; 
 		}
 
 	public void Awake()
 		{
     	// add the necessary AudioSources:
		audioHighFive = AddAudio(highFive, false, false, 8f);
     	audioZombieGrowl = AddAudio(zombieGrowl , false, false, 8f);
     	audioPowerUp = AddAudio(powerUp, false, false, 8f);
     	//audioWeapon2 = AddAudio(clipWeapon2, false, false, 0.8); 
     	} 
}



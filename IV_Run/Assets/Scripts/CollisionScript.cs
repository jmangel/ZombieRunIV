using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //initialize variables for invincibility powerups
    public int invincibilityTime = 10; //get this from upgrade settings in database
    public float invincibilityExpire = 0;

    public float recentlyHitExpire = 0;
    public int recentlyHitTime = 5;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            invincibilityExpire = Time.time + invincibilityTime;
        }
        
        if (collision.gameObject.tag == "Untagged")
        {
            if (Time.time > invincibilityExpire)
            {
                //do obstacular stuffs
                if (Time.time > recentlyHitExpire) //if you haven't been hit recently
                {
                    Destroy(collision.gameObject);
                    recentlyHitExpire = Time.time + recentlyHitTime;
                }
                else //if this is second hit in short amount of time
                {
                    SceneManager.LoadScene(0);
                }
            }
            else //if invincible
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    //initialize variables for invincibility powerups
    public int invincibilityTime = 10; //get this from upgrade settings in database
    public float invincibilityExpire = 0;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PowerUp")
        {
            invincibilityExpire = Time.time + invincibilityTime;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            if (Time.time > invincibilityExpire)
            {
                //do obstacular stuffs
            }
        }
        if (collision.gameObject.tag == "Untagged")
        {
			SceneManager.LoadScene (2);
        }
    }
}
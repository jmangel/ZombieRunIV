using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HighFiveStoreButton : MonoBehaviour
{

    public void onClick()
    {
        SceneManager.LoadScene("HighFiveStore");
    }
}

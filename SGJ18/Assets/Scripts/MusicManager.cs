using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static GameObject instance = null;

	// Use this for initialization
	void Awake()
    {
        //Debug.Log(instance);
        if (instance != null)
        {
            if (SceneManager.GetActiveScene().name == "Level3")
            {
                instance.gameObject.GetComponent<AudioSource>().enabled = false;
            }
            else
            {
                instance.gameObject.GetComponent<AudioSource>().enabled = true;
            }
        }

        if (instance == null)
        {
            instance = this.gameObject;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}

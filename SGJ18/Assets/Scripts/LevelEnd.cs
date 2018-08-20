using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject endPosition;

    private IEnumerator coroutine;

    public string nextLevel;

	void OnTriggerEnter2D (Collider2D target)
    {
        if (target.tag == "Player")
        {
            GameObject wd = GameObject.FindWithTag("WallOfDoom");
            //Debug.Log(wd);
            if (wd != null)
            {
                GameObject.FindWithTag("WallOfDoom").SetActive(false);
            }
            //Do level end sequence
            //Debug.Log("Level End Sequence");
            target.gameObject.GetComponent<PlayerMovement>().enabled = false;

            //coroutine = EndSequence1(target.gameObject);
            StartCoroutine(EndSequence1(target.gameObject));
        }
    }

    //Makes the dragon travel to a point and perform a celebratory dance
    IEnumerator EndSequence1 (GameObject player)
    {
        Vector3 start = player.transform.position;
        Vector3 finish = endPosition.transform.position;

        Quaternion currRotation = player.transform.rotation;

        float distance = Vector3.Distance(start, finish);
        float i = 0F;

        //Travels to a point and rotates to normal
        while (i < distance)
        {
            yield return new WaitForSeconds(0.0125F);
            float percent = i / distance;
            player.transform.position = Vector3.Lerp(start, finish, percent);// + new Vector3(0, 0, -10);
            player.transform.rotation = Quaternion.Lerp(currRotation, Quaternion.identity, percent);
            i += 0.25F;
        }

        //Hops up and down
        int x = 0;
        while (x < 150)
        {
            yield return new WaitForSeconds(0.0125F);
            if (x % 16 > 7)
            {
                player.transform.position += new Vector3(0, 0.125F, 0);
            }
            else
            {
                player.transform.position += new Vector3(0, -0.125F, 0);
            }
            x++;
        }
        SceneManager.LoadScene(nextLevel);
    }
}

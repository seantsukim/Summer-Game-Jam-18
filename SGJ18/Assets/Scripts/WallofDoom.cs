using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallofDoom : MonoBehaviour
{
    public float wallVelocity;  //speed the wall moves right
    Rigidbody2D rb; //wall's rigidbody2D

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(wallVelocity, 0);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        //Detect if it collided with Player
        if (target.tag == "Player")
        {
            //Debug.Log("Collided");
            //Player "death" scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

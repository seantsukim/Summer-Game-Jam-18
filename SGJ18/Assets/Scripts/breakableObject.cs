using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableObject : MonoBehaviour {
	public Sprite newDisplay; //what to display after this object is interacted with
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//change the sprite display when interact, and turn off collider
		if (Input.GetMouseButtonDown(0))
		{
			this.GetComponent<SpriteRenderer>().sprite = newDisplay;
			this.GetComponent<Collider2D>().enabled = false;
		}
	}
}

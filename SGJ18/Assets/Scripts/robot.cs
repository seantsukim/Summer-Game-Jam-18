using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour {
	//using enum to hold the robot's current state
	public enum robotAction
	{
		sleep,
		idle,
		barrage,
		swing,
		terminated
	}
	//player object is here to pull variables from
	public GameObject player;
	//this gameObjects health
	public int health = 2;
	//hitbox that will turn on and off during fight
	public Collider2D weakspot;
	//keep track of what the robot is currently doing
	private robotAction currentState;

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
		weakspot.enabled = false;
	}

	//points in direction of the player
	void eyesOnPlayer()
	{
		//face left
		if(player.transform.position.x < this.transform.position.x)
		{
			this.transform.localScale = new Vector3(-1, 1, 1);
		}
		//face right
		else
		{
			this.transform.localScale = new Vector3(1, 1, 1);
		}
	}
	
	//preps up barrage of bullets
	void fireBarrage()
	{
		//if robot is facing the left, barrage left
		if (this.transform.localScale.x == -1)
		{
			
		}

		//if the robot is facing right, barrage right
		{

		}
	}

	//prepares to land a huge swing
	void heavySwing()
	{
		weakspot.enabled = true;
	}

	//RIP Robot
	void terminated()
	{
		
	}

	// Update is called once per frame
	void Update () {
		/* 
		switch(currentState)
		{
			case robotAction.idle:
				Debug.Log(1);
				break;
			case robotAction.barrage:
				Debug.Log(2);
				break;
			case robotAction.swing:
				Debug.Log(3);
				break;
			case robotAction.terminated:
				Debug.Log(4);
				break;
		}
		*/
		if (Input.GetKeyDown(KeyCode.Space))
		{
			weakspot.enabled = !weakspot.enabled;
			Debug.Log("State: " + weakspot.enabled);
		}
		eyesOnPlayer();
	}
}

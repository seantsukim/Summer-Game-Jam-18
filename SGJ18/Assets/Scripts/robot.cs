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
	public int health;
	//keep track of what the robot is currently doing
	private robotAction currentState;

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
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

	}

	//prepares to land a huge swing
	void heavySwing()
	{

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

		eyesOnPlayer();
	}
}

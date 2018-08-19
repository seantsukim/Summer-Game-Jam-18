using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour {
	//using enum to hold the robot's current state
	public enum robotAction
	{
		sleep,
		idle,
		missile,
		swing,
		terminated
	}
	//player object is here to pull variables from
	public GameObject player;

	//Robot's barrage points, left and right points
	//public GameObject leftBarrage;
	//public GameObject rightBarrage;

	//the projectile the robot will fire
	public Rigidbody2D missile;

	//this gameObjects health
	public int health = 2;

	//missile speed
	public int missileSpeed = 25;

	//hitbox that will turn on and off during fight
	public Collider2D weakspot;

	//tracks time in between attacks
	public float time;

	//keep track of what the robot is currently doing
	private robotAction currentState;
	//checks if robot is facing left
	private bool isFacingLeft;
	//make sure we dont spam missiles on accident
	private bool isMissileCooldown;

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
		weakspot.enabled = false;
		isFacingLeft = true;
		isMissileCooldown = false;
		time = 0;
	}

	//points in direction of the player when idle
	void eyesOnPlayer()
	{
		//face left
		if(player.transform.position.x < this.transform.position.x)
		{
			this.transform.localScale = new Vector3(-1, 1, 1);
			isFacingLeft = true;
		}
		//face right
		else
		{
			this.transform.localScale = new Vector3(1, 1, 1);
			isFacingLeft = false;
		}
		
		time += Time.deltaTime * 1;
		Debug.Log(time);

		//time to do the swinging animation
		if (time >= 8)
		{
			currentState = robotAction.swing;
		}
		//time to fire a missile
		else if (time >= 5 && !isMissileCooldown)
		{
			currentState = robotAction.missile;
		}
	}
	
	//preps up missile
	void fireMissile()
	{
		if (!isMissileCooldown)
		{
			Rigidbody2D firedMissile;
			firedMissile = Instantiate(missile, this.transform.position, this.transform.rotation) as Rigidbody2D;

			//if robot is facing the left, barrage left
			if (isFacingLeft)
			{
				firedMissile.velocity = transform.TransformDirection(Vector3.left) * missileSpeed;
			}

			else //if the robot is facing right, barrage right
			{
				firedMissile.velocity = transform.TransformDirection(Vector3.right) * missileSpeed;
			}

			isMissileCooldown = true;
		}

		else
		{
			//we've fired a missle already in this rotation
		}

		//reset back to idle state
		currentState = robotAction.idle;
	}

	//prepares to land a huge swing
	void heavySwing()
	{
		weakspot.enabled = true;
		/*
		insert animation code here
		*/

		//reset state back to square one
		weakspot.enabled = false;
		isMissileCooldown = false;
		time = 0;
		currentState = robotAction.idle;

	}

	//RIP Robot
	void terminated()
	{
		
	}

	// Update is called once per frame
	void Update () {
		//finite state machine, tracks state of robot
		switch(currentState)
		{
			case robotAction.idle:
				eyesOnPlayer();
				break;
			case robotAction.missile:
				fireMissile();
				break;
			case robotAction.swing:
				heavySwing();
				break;
			case robotAction.terminated:
				//DIE
				break;
		}

		/*
		if (Input.GetKeyDown(KeyCode.Space))
		{
			fireMissile();
			weakspot.enabled = !weakspot.enabled;
			//Debug.Log("State: " + weakspot.enabled);
			//Debug.Log("Is Left: " + isFacingLeft); // 1 if left, 0 if right
		}
		eyesOnPlayer();
		*/
		
	}
}

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

	//keep track of what the robot is currently doing
	private robotAction currentState;
	private bool isFacingLeft;

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
		weakspot.enabled = false;
		isFacingLeft = true;
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
	}
	
	//preps up missile
	void fireMissile()
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
		//finite state machine, tracks state of robot
		switch(currentState)
		{
			case robotAction.idle:
				Debug.Log(1);
				break;
			case robotAction.missile:
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
			fireMissile();
			weakspot.enabled = !weakspot.enabled;
			//Debug.Log("State: " + weakspot.enabled);
			Debug.Log("Is Left: " + isFacingLeft); // 1 if left, 0 if right
		}
		eyesOnPlayer();
		
	}
}

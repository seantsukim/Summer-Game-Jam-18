using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class robot : MonoBehaviour {
	//using enum to hold the robot's current state
	public enum robotAction
	{
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

	//tracks time in between attacks
	private float time;

	//keep track of what the robot is currently doing
	private robotAction currentState;
	//checks if robot is facing left
	private bool isFacingLeft;
	//make sure we dont spam missiles on accident
	private bool isMissileCooldown;

    private WeakSpot weakSpot;

    private Animator anim;
    int swingHash = Animator.StringToHash("Swing");
    int DamageHash = Animator.StringToHash("Damage");

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
		isFacingLeft = true;
		isMissileCooldown = false;
		time = 0;

        weakSpot = GetComponentInChildren<WeakSpot>();

        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        //finite state machine, tracks state of robot
        switch (currentState)
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
    }

    //points in direction of the player when idle
    void eyesOnPlayer()
	{
		//face left
		if(player.transform.position.x < this.transform.position.x)
		{
            Vector3 scale = transform.localScale;
            if(scale.x >= 0f)
            {
                scale.x *= -1;
            }
            transform.localScale = scale;
			isFacingLeft = true;
		}
		//face right
		else
		{
            Vector3 scale = transform.localScale;
            if (scale.x < 0f)
            {
                scale.x *= -1;
            }
			transform.localScale = scale;
			isFacingLeft = false;
		}
		
		time += Time.deltaTime;

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

		//reset back to idle state
		currentState = robotAction.idle;
	}

	//prepares to land a huge swing
	void heavySwing()
	{
        weakSpot.SetWeakSpotActive(true);
        anim.SetTrigger(swingHash);
	}

    public void EndHeavySwing()
    {
        weakSpot.SetWeakSpotActive(false);
        isMissileCooldown = false;
        time = 0;
        currentState = robotAction.idle;
    }

    public void Damage()
    {
        health -= 1;
        if(health <= 0)
        {
            Die();
        }
        else
        {
            anim.SetTrigger(DamageHash);
            Debug.Log("OW");
        }
    }

    void Die()
    {
        Debug.Log("BLEH");
    }
}

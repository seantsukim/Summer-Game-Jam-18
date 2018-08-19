using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot : MonoBehaviour {
	//using enum to hold the robot's current state
	public enum robotAction
	{
		idle,
		laser,
		swing
	}
	//keep track of what the robot is currently doing
	private robotAction currentState;

	// Use this for initialization
	void Start () {
		currentState = robotAction.idle;
	}
	
	// Update is called once per frame
	void Update () {
		switch(currentState)
		{
			case robotAction.idle:
				Debug.Log(1);
				break;
			case robotAction.laser:
				Debug.Log(2);
				break;
			case robotAction.swing:
				Debug.Log(3);
				break;
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWorldPos : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update()
    {
        transform.up = player.transform.up;
    }
}

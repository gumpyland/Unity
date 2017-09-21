﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		if (hasStarted) { 
		audio.Play();
		}
	}

}

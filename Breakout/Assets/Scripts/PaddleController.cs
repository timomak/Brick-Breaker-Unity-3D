﻿using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{

	public float moveSpeed = 200f;
	public GameObject ball;
	public float ballForceMagnitude;
	public int numBalls;

	//Cache this reference so we don't need to look it up over and over
	private Rigidbody ballBody;
	private Rigidbody ballBody2;
	// Use this for initialization
	void Start ()
	{
		ballBody = ball.GetComponent<Rigidbody> ();
		ballBody2 = ball.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (ballBody.isKinematic) {
			//We can use Sin to oscillate between 1 and -1.
			ball.transform.position = new Vector3 (this.transform.position.x + Mathf.Sin (Time.realtimeSinceStartup), this.transform.position.y + 1f, this.transform.position.z);
		} else {
			ballBody2 = ball.GetComponent<Rigidbody> ();
			ball.transform.position = new Vector3 (this.transform.position.x + Mathf.Sin (Time.realtimeSinceStartup), this.transform.position.y + 1f, this.transform.position.z);

		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			print (this.transform.position.x);
			//if (this.transform.position.x > -4.4) {
			if (this.transform.position.x > (GameBoardGenerator.boardWidth/ -2) - 0.5f) {
				this.transform.position = new Vector3 ((this.transform.position.x - (moveSpeed * Time.deltaTime)), this.transform.position.y, this.transform.position.z);
			}
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			if (this.transform.position.x < (GameBoardGenerator.boardWidth/ 2) + 0.5f) {
				this.transform.position = new Vector3 (this.transform.position.x + (moveSpeed * Time.deltaTime), this.transform.position.y, this.transform.position.z);
			}
		}

		if (Input.GetKey (KeyCode.Space)) {
			if (ballBody.isKinematic) {
				ballBody.isKinematic = false;
				ball.transform.LookAt (this.gameObject.transform);
				ballBody.AddForce (ball.transform.forward.normalized * ballForceMagnitude, ForceMode.VelocityChange);
			}
			if (ballBody.isKinematic == false && ballBody2.isKinematic == true) {
				ballBody2.isKinematic = false;
				ball.transform.LookAt (this.gameObject.transform);
				ballBody2.AddForce (ball.transform.forward.normalized * ballForceMagnitude, ForceMode.VelocityChange);
			}

		}
	}
}
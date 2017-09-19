using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Destroy a block when the ball hits it, and make a nice shiny explosion effect.
	public void OnCollisionEnter(Collision collisionWith)
	{
		if(collisionWith.gameObject.tag == "Ball")
		{
			Rigidbody ballBody = collisionWith.gameObject.GetComponent<Rigidbody>();
			ballBody.isKinematic = true;
		}
	}
}

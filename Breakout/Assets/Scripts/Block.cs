using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public GameObject explosionEffect;

	//Destroy a block when the ball hits it, and make a nice shiny explosion effect.
	public void OnCollisionEnter(Collision collisionWith)
	{
		if(collisionWith.gameObject.tag == "Ball")
		{
			Destroy((GameObject)Instantiate(explosionEffect, collisionWith.gameObject.transform.position, collisionWith.gameObject.transform.rotation), 0.5f);
			Destroy(this.gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class ice_shoot : MonoBehaviour {
	private Transform shoot;
	private GameObject fireBall;
	private BoxCollider2D ballColl;
	private BoxCollider2D shotColl;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "FireBall")
			fireBall = GameObject.FindWithTag("FireBall");
			Destroy(fireBall);
		
	}


	// Use this for initialization
	void Start () {
		shoot = gameObject.GetComponent<Transform>();
		fireBall = GameObject.FindWithTag("FireBall");
	//	ballColl = fireBall.GetComponent<BoxCollider2D>();
		shotColl = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		shoot.Translate(Vector3.right *Time.deltaTime*3f);	

	/*	if(shotColl.IsTouching(ballColl))
		{
			Destroy(fireBall);
			Destroy(gameObject);
		}
	*/

	}
}

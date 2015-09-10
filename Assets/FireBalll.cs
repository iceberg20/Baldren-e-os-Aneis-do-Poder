using UnityEngine;
using System.Collections;

public class FireBalll : MonoBehaviour {
	private Transform t;
	private BoxCollider2D heroColl;
	private GameObject hero;
	private BoxCollider2D fireBall;
	public GameObject fb;


	// Use this for initialization	
	void Start () {
		t = gameObject.GetComponent<Transform>();
		fireBall = gameObject.GetComponent<BoxCollider2D>();
		hero = GameObject.FindGameObjectWithTag("Player");
		heroColl = hero.GetComponent<BoxCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		t.Translate(Vector3.left* (Time.deltaTime*3) );

		if(fireBall.IsTouching(heroColl)){
			Destroy(fb);
		}

		if(t.position.x<11.6f)
			Destroy(fb);

	}
}

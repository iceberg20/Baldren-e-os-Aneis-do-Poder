using UnityEngine;
using System.Collections;

public class ice_shoot : MonoBehaviour {
	private Transform shoot;
	private GameObject fireBall;
	private BoxCollider2D ballColl;
	private BoxCollider2D shotColl;
	public BoxCollider2D dragonColl;
	private Animator ani;
	private GameObject dragon;
	public DragonBoss dragonScript;

	public GameObject h2;
	public GameObject h3;
	public GameObject h4;
	

	private int qtdCoracao = 3;


	/*void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Dragon")
			Destroy(gameObject);
		ani.SetBool("hit",true);
		
	}*/

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Dragon" )	
			Destroy(h2);
			Destroy(gameObject);
	}



	void Start () {
		shoot = gameObject.GetComponent<Transform>();
		shotColl = gameObject.GetComponent<BoxCollider2D>();
		h2 = GameObject.FindWithTag("H2");


	}
	
	// Update is called once per frame
	void Update () {
		shoot.Translate(Vector3.right *Time.deltaTime*4f);	
		
		
	}
}

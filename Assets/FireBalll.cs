using UnityEngine;
using System.Collections;

public class FireBalll : MonoBehaviour {
	private Transform t;
	private BoxCollider2D heroColl;
	private GameObject hero;
	private BoxCollider2D fireBall;
	public GameObject fb;
	private GameObject lifeObject;
	private Transform life_bar;



	// Use this for initialization	
	void Start () {
		t = gameObject.GetComponent<Transform>();
		fireBall = gameObject.GetComponent<BoxCollider2D>();
		hero = GameObject.FindGameObjectWithTag("Player");
		heroColl = hero.GetComponent<BoxCollider2D>();
		lifeObject = GameObject.FindGameObjectWithTag("Life");
		life_bar = lifeObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate(Vector3.left* (Time.deltaTime*3) );

		if(fireBall.IsTouching(heroColl)){
			reduzirVida(0.02f);
			Destroy(fb);
		}

		if(t.position.x<11.6f)
			Destroy(fb);

	}

	void reduzirVida(float  valor)
	{
		//float p = (valor - 100)/-100;
		if(life_bar.localScale.x < 0.2f)
			Application.LoadLevel("gameOver");
		life_bar.localScale = new Vector3(life_bar.localScale.x -valor, life_bar.localScale.y ,life_bar.localScale.z);
		//Vector3 v =  new Vector3(life_bar.transform.position.x, life_bar.transform.position.y, life_bar.transform.position.z);
		//if (life_bar.transform.position.x> -2.9)
			life_bar.transform.Translate(Vector3.left*3.6f);
		
	}
}

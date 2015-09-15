using UnityEngine;
using System.Collections;

public class DragonBoss : MonoBehaviour {
	private float time = 3f;
	public Transform fireBall;
	private Transform boos;
	public Transform hero;
	private bool fire = false;
	private bool follow = false;
	public Animator anime;

	public GameObject h2;
	public GameObject h3;
	public GameObject h4;
	private int qtdCoracao =3;
	private float delay = 5f;
	public Peach p;
	public GameObject prin;



	void OnCollisionEnter2D(Collision2D coll) {			

		if( qtdCoracao == 3 && delay>4f){
				Destroy(h2);
				qtdCoracao-=1;
				delay = 0f;	
		}
		if( qtdCoracao == 2 && delay>4f){
				Destroy(h3);
				qtdCoracao-=1;
				delay = 0f;
		}
		if( qtdCoracao == 1 && delay>4f){
				Destroy(h4);
				qtdCoracao-=1;
				delay = 0f;
		}			
	}


	void Wake(){
		prin =  GameObject.FindGameObjectWithTag("Princesa");
		p = prin.GetComponent<Peach>();
	}
	void Start () {
		boos = gameObject.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

		if(qtdCoracao == 0 && delay>3f){
			p.goDown();
			Destroy(gameObject);
		}

		delay+= Time.deltaTime;

		time+= Time.deltaTime;
		if(time>1f){
			if(fire)
				Instantiate(fireBall,new Vector3(boos.position.x-0.5f, boos.position.y-0.1f,1f),Quaternion.identity);

			time =0;
		}

		if(follow) {
			if(hero.position.y>boos.position.y)
				boos.transform.Translate(Vector3.up*Time.deltaTime);
			else
				boos.transform.Translate(Vector3.down*Time.deltaTime);
		}

	
	}

	public void setAnime()
	{
		anime.SetBool("hit",true);
	}

	public void startFire()	{
		fire = true;
		follow = true;
	}
}

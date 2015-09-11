using UnityEngine;
using System.Collections;

public class EnemyColision : MonoBehaviour {
	public BoxCollider2D inimigo;
	public BoxCollider2D heroi;
	public Transform life_bar;
	private float hit_time_begin;
	private float time;
	private float hit_time_end;
	private bool hited;
	//private AudioSource som;

	// Use this for initialization
	void Start () {
		time = 7.0f;
		//som = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(inimigo.IsTouching(heroi) && time >1.0f) {
			//Debug.Log("Colidiu");	
			time=0.0f;
			reduzirVida(0.02f);
		}
	}

	//O parametro valor e uma porcentagem de 0% a 100%
	void reduzirVida(float  valor)
	{
		//float p = (valor - 100)/-100;
		if(life_bar.localScale.x < 0.01)
			Application.LoadLevel("gameOver");
		life_bar.localScale = new Vector3(life_bar.localScale.x -valor, life_bar.localScale.y ,life_bar.localScale.z);
		//Vector3 v =  new Vector3(life_bar.transform.position.x, life_bar.transform.position.y, life_bar.transform.position.z);
		if (life_bar.transform.position.x> -2.9)
			life_bar.transform.Translate(Vector3.left*0.1f);

	}




}

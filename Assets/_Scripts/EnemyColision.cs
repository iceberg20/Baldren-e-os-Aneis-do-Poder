using UnityEngine;
using System.Collections;

public class EnemyColision : MonoBehaviour {
	public BoxCollider2D inimigo;
	public BoxCollider2D heroi;
	public Transform life_bar;
	private float vida;
	private float hit_time_begin;
	private float time;
	private float hit_time_end;
	private bool hited;

	// Use this for initialization
	void Start () {
		time = 7.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(inimigo.IsTouching(heroi) && time >1.0f) {
			Debug.Log("Colidiu");	
			time=0.0f;
			reduzirVida(20);

		}
	}

	//O parametro valor e uma porcentagem de 0% a 100%
	void reduzirVida(float  valor)
	{
		float p = (valor - 100)/-100;
		if(life_bar.localScale.x < 0.01)
			Application.LoadLevel("gameOver");
		life_bar.localScale = new Vector3(life_bar.localScale.x *p, life_bar.localScale.y ,life_bar.localScale.z);
		//Vector3 v =  new Vector3(life_bar.transform.position.x, life_bar.transform.position.y, life_bar.transform.position.z);
		if (life_bar.transform.position.x> -2.8)
			life_bar.transform.Translate(Vector3.left*0.16f);
			

		Debug.Log(life_bar.transform.localScale.x);

		Debug.Log(p);
	}




}

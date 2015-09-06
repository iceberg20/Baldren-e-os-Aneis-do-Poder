using UnityEngine;
using System.Collections;

public class dragon : MonoBehaviour {
	private Transform t;
	private bool esquerda;
	public BoxCollider2D inimigo;
	public BoxCollider2D heroi;
	private float time;
	private float translation;  
	public Transform life_bar;


	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Transform>();
		esquerda = true;
		time = 7.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(inimigo.IsTouching(heroi) && time >1.0f) {
			time=0.0f;
			reduzirVida(0.2f);
		}

		//Debug.Log(t.position.x);

		if(t.position.x >= 3.67f){
			if(esquerda){
				t.Translate(Vector3.left* Time.deltaTime);
			}
			else{
				if(t.position.x <=5.29f){
					t.Translate(Vector3.right* Time.deltaTime);
					esquerda = false;
				}
				else{
					t.Translate(Vector3.left* Time.deltaTime);
					esquerda = true;
				}
			}
		}
		else{
			t.Translate(Vector3.right* Time.deltaTime);
			esquerda = false;
		}			


		//flip do sprite
		if(esquerda)
			t.transform.localScale = new Vector2(1,1);
		else
			t.transform.localScale = new Vector2(-1,1);

	}

	void reduzirVida(float  valor)
	{
		//float p = (valor - 100)/-100;
		if(life_bar.localScale.x < 0.01)
			Application.LoadLevel("gameOver");
		life_bar.localScale = new Vector3(life_bar.localScale.x -valor, life_bar.localScale.y ,life_bar.localScale.z);
		//Vector3 v =  new Vector3(life_bar.transform.position.x, life_bar.transform.position.y, life_bar.transform.position.z);
		//if (life_bar.transform.position.x> -2.9)
			life_bar.transform.Translate(Vector3.left*25f);
	}
}

using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {
	private float time;
	public BoxCollider2D heroi;
	public BoxCollider2D espinhos;
	public RectTransform life;
	private float lado = 301.7f;

	// Use this for initialization
	void Start () {
		espinhos = gameObject.GetComponent<BoxCollider2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(espinhos.IsTouching(heroi) && time >0.1f) {
			//Debug.Log("Colidiu");	
			time=0.0f;
			reduzirVida(10.0f);
		}
	
	}

	void reduzirVida(float valor){
		if(life.rect.width < 0)
			Application.LoadLevel("gameOver");
		else
		{
			lado-=valor;
			life.sizeDelta = new Vector2(lado,15.2f);
			life.position = new Vector3(life.position.x-(valor/2.0f),life.position.y);
			
		}
	}
}

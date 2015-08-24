using UnityEngine;
using System.Collections;

public class EnemyCollisionHUD : MonoBehaviour {
	public RectTransform life;
	private float lado = 301.7f;
	private float time;
	public BoxCollider2D inimigo;
	public BoxCollider2D heroi;

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
			reduzirVida(10.0f);
		}

		Debug.Log(life.rect.width);

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

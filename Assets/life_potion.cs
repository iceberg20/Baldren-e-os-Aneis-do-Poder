using UnityEngine;
using System.Collections;

public class life_potion : MonoBehaviour {
	public BoxCollider2D potion;
	public BoxCollider2D heroi;
	public RectTransform life_bar;
	private float vida;
	public AudioSource audioPotion;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(heroi.IsTouching(potion)) {
			//Debug.Log("Colidiu");	

			aumentarVida(1f);
		}
	
	}

	void aumentarVida(float  valor)
	{
		//life_bar.localScale = new Vector3(life_bar.localScale.x +valor, life_bar.localScale.y ,life_bar.localScale.z);
		//Vector3 v =  new Vector3(life_bar.transform.position.x, life_bar.transform.position.y, life_bar.transform.position.z);
		life_bar.sizeDelta = new Vector2(301.7f, 15.8f);
		life_bar.anchoredPosition = new Vector2(143.2f,15.8f);  
		audioPotion.Play();
		Destroy(gameObject);
		
		
		//Debug.Log(life_bar.transform.localScale.x);
		
		//Debug.Log(p);
	}
}

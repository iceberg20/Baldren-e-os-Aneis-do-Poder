using UnityEngine;
using System.Collections;

public class mana_potion : MonoBehaviour {
	public BoxCollider2D potion;
	public BoxCollider2D heroi;
	public RectTransform mana_bar;
	public AudioSource audioPotion;
	public GameObject player;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(heroi.IsTouching(potion)) {			
			aumentarMana(1f);
			player.GetComponent<PlayerControll>().fillMana();
		}	
	}

	void aumentarMana(float  valor)
	{
		mana_bar.sizeDelta = new Vector2(301.7f, 15.8f);
		mana_bar.anchoredPosition = new Vector2(170.2f,-9.599998f);  
		audioPotion.Play();
		Destroy(gameObject);
	}
}

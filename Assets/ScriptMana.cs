using UnityEngine;
using System.Collections;

public class ScriptMana : MonoBehaviour {
	private RectTransform mana;
	private float lado = 301.7f;

	// Use this for initialization
	void Start () {
		mana = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.E))
		{
			reduzirMana(5.0f);
		}

	
	}
	void reduzirMana(float valor){
		if(mana.rect.width <= 0)
			Debug.Log("Voce esta sem mana");
		else
		{
			lado-=valor;
			mana.sizeDelta = new Vector2(lado,15.2f);
			mana.position = new Vector3(mana.position.x-(valor/2.0f), mana.position.y);
			
		}
	}

}

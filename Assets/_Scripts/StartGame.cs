using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Renderer rend;
	float width;
	float height;
	//public SpriteRenderer img;
	//img.color = UnityEngine.Color.red;

	// Use this for initialization
	private void Start()
	{
		rend = GetComponent<Renderer>();
		width = rend.bounds.size.x;
		height = rend.bounds.size.y;
		//img =  GetComponent<SpriteRenderer>();
	}

	// Mudar cor do texto quando passar o mouse
	void OnMouseEnter()
	{
		// set the scaling
		Vector3 scale = new Vector3( 1.7f, 1.7f, 1f );
		rend.transform.localScale = scale;
		//img.sprite = Resources.Load("medieval_landscape", typeof(Sprite)) as Sprite;
		//img.color = Color.red;
		//GetComponent<SpriteRenderer>().color = Color.gray;
		//rend.material.color = Color.gray;
	}

	// Mudar cor do texto quando retirar o mouse
	void OnMouseExit()
	{
		Vector3 scale = new Vector3( 1.5f, 1.5f, 1f );
		rend.transform.localScale = scale;
		//img.color = Color.gray;
		//rend.material.color = Color.white;
	}

	// Load do primeiro level ao clicar
	void OnMouseDown ()
	{
		Application.LoadLevel (1);
	}
}

using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	public Renderer rend;
	float width;
	float height;
	
	// Use this for initialization
	private void Start()
	{
		rend = GetComponent<Renderer>();
		width = rend.bounds.size.x;
		height = rend.bounds.size.y;
	}
	
	// Mudar cor do texto quando passar o mouse
	void OnMouseEnter()
	{
		Vector3 scale = new Vector3( 1.7f, 1.7f, 1f );
		rend.transform.localScale = scale;
	}
	
	// Mudar cor do texto quando retirar o mouse
	void OnMouseExit()
	{
		Vector3 scale = new Vector3( 1.5f, 1.5f, 1f );
		rend.transform.localScale = scale;
	}

	// Quitar quando clicar
	void OnMouseDown ()
	{
		Application.Quit();
	}
}

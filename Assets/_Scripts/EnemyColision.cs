using UnityEngine;
using System.Collections;

public class EnemyColision : MonoBehaviour {
	public BoxCollider2D inimigo;
	public BoxCollider2D heroi;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(inimigo.IsTouching(heroi))
		   Debug.Log("Colidiu");	
		   
	}



}

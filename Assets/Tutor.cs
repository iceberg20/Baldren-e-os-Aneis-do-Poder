using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutor : MonoBehaviour {
	public Text text;
	public Transform heroi;
	private bool step1;
	private bool step2;
	public BoxCollider2D step1Coll;

	// Use this for initialization
	void Start () {
		text.text = "";
		step1 = false;
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log(heroi.transform.position.x);
		if(heroi.transform.position.x >=-7.0f && !step1){
			text.text = "Aperte para cima para pular!";
			step1= true;
		}


		if(Input.GetKeyDown(KeyCode.UpArrow) && step1)
			text.text = "";

		if(heroi.transform.position.x >=-4.8f && !step2){
			text.text = "Cuidado com os espinhos!";
			step2= true;		}
		
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && step2)
			text.text = "";
	
	}
}

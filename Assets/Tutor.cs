using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutor : MonoBehaviour {
	public Text text;
	public Transform heroi;
	private bool step1;
	public BoxCollider2D step1Coll;

	// Use this for initialization
	void Start () {
		text.text = "";
		step1 = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(heroi.transform.position.x);
		if(heroi.transform.position.x >=-7.0f && !step1){
			text.text = "Aperte para cima para pular!";
			step1= true;
		}


		if(Input.GetKeyDown(KeyCode.UpArrow) && step1)
			text.text = "";
	
	}
}

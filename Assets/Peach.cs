using UnityEngine;
using System.Collections;

public class Peach : MonoBehaviour {
	private Transform t;
	private bool go = false;
	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Transform>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" )
			Application.LoadLevel("final_feliz");
		
	}

	// Update is called once per frame
	void Update () {
		if(go){
			t.Translate(Vector3.down*Time.deltaTime);
		}

		if(t.position.y <0.94)
			go = false;
	}
	
	public void goDown(){
		go = true;
	}
}

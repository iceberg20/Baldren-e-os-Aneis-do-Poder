using UnityEngine;
using System.Collections;

public class dragon : MonoBehaviour {
	private Transform t;
	private float time;
	private float translation;  


	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Transform>();
		time = 3.0f;
		translation = t.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis("Horizontal")*1;
		time+= Time.deltaTime;
		translation-=0.01f;
		t.Translate (translation, 0 , 0);	
	}
}

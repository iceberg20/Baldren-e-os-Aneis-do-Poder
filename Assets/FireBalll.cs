using UnityEngine;
using System.Collections;

public class FireBalll : MonoBehaviour {
	private Transform t;

	// Use this for initialization
	void Start () {
		t = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate(Vector3.left* Time.deltaTime);
	}
}

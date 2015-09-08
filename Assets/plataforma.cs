using UnityEngine;
using System.Collections;

public class plataforma : MonoBehaviour {
	public Transform camera;
	private Transform plat;
	// Use this for initialization
	void Start () {
		plat = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(plat.position.y);
		if(camera.position.x>=15f){
			if(plat.position.y <1.2)
				plat.transform.Translate(Vector3.up* Time.deltaTime);
		}

	}
}

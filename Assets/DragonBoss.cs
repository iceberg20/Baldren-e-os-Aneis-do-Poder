using UnityEngine;
using System.Collections;

public class DragonBoss : MonoBehaviour {
	private float time = 0f;
	public Transform fireBall;
	private Transform boos;

	// Use this for initialization
	void Start () {
		boos = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		time+= Time.deltaTime;
		if(time>1f){
			Instantiate(fireBall,new Vector3(boos.position.x-0.5f, boos.position.y-0.1f,1f),Quaternion.identity);
			time =0;
		}
	
	}
}

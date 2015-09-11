using UnityEngine;
using System.Collections;

public class DragonBoss : MonoBehaviour {
	private float time = 3f;
	public Transform fireBall;
	private Transform boos;
	public Transform hero;
	private bool fire = false;
	private bool follow = false;


	// Use this for initialization
	void Start () {
		boos = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		time+= Time.deltaTime;
		if(time>0.5f){
			if(fire)
				Instantiate(fireBall,new Vector3(boos.position.x-0.5f, boos.position.y-0.1f,1f),Quaternion.identity);

			time =0;
		}

		if(follow) {
			if(hero.position.y>boos.position.y)
				boos.transform.Translate(Vector3.up*Time.deltaTime);
			else
				boos.transform.Translate(Vector3.down*Time.deltaTime);
		}

	
	}

	public void startFire()	{
		fire = true;
		follow = true;
	}
}

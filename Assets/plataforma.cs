using UnityEngine;
using System.Collections;

public class plataforma : MonoBehaviour {
	public Transform camera;
	private Transform plat;
	public DragonBoss dragonScript;
	public GameObject stone;
	private float qtdStone =0f;
	// Use this for initialization
	void Start () {
		plat = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

		if(camera.position.x>=15f){
			if(plat.position.y <1.2){
				plat.transform.Translate(Vector3.up* Time.deltaTime);
			}
			else{
				dragonScript.startFire();
				if(qtdStone <10) {
					Instantiate(stone,new Vector3(11.2f,qtdStone,0f),Quaternion.identity );
					qtdStone+=1;
				}

			}
		}

	}
}

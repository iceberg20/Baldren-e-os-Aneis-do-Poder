using UnityEngine;
using System.Collections;

public class cajado : MonoBehaviour {
	public GameObject inimigoObj;
	public GameObject inimigoObjDragon;
	private BoxCollider2D cajadoColl;
	public BoxCollider2D inimigoColl;
	public BoxCollider2D inimigoCollDragon;
	public Animator Anime;
	private Vector2 collSizeDefault;
	private float time = 0f;
	private bool aumentar = false;

	// Use this for initialization
	void Start () {
		cajadoColl = gameObject.GetComponent<BoxCollider2D>();	
		collSizeDefault = cajadoColl.size;
	}
	
	// Update is called once per frame 
	void Update () {
		if(cajadoColl.IsTouching(inimigoColl)&& Input.GetKey(KeyCode.Space) ){
			Destroy(inimigoObj, 0.1f);
			cajadoColl.size = new Vector2(cajadoColl.size.x+0.01f, cajadoColl.size.y);
		}

		if(aumentar) time += Time.deltaTime;
		if(aumentar && time<3f){
			cajadoColl.size = new Vector2(cajadoColl.size.x+0.05f, cajadoColl.size.y);

		}
		if(cajadoColl.size.x > (collSizeDefault.x+1.1f)){
			aumentar = false;
			time = 0;	
			cajadoColl.size = collSizeDefault;
		}

		if(cajadoColl.IsTouching(inimigoCollDragon)&& aumentar)
			Destroy(inimigoObjDragon, 0.1f);

		
		
		
		if(Input.GetKey(KeyCode.E)){
			aumentar = true;
			//cajadoColl.size = new Vector2(cajadoColl.size.x+0.1f, cajadoColl.size.y);
			if(cajadoColl.IsTouching(inimigoCollDragon))
				Destroy(inimigoObjDragon, 0.1f);
		}

	}


}
 
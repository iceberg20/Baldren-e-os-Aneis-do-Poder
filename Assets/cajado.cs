using UnityEngine;
using System.Collections;

public class cajado : MonoBehaviour {
	public GameObject inimigoObj;
	private BoxCollider2D cajadoColl;
	public BoxCollider2D inimigoColl;
	public Animator Anime;

	// Use this for initialization
	void Start () {
		cajadoColl = gameObject.GetComponent<BoxCollider2D>();		
	}
	
	// Update is called once per frame 
	void Update () {
		if(cajadoColl.IsTouching(inimigoColl)&& Input.GetKey(KeyCode.Space) ){
			Destroy(inimigoObj, 0.1f);
			cajadoColl.size = new Vector2(cajadoColl.size.x+0.01f, cajadoColl.size.y);
		}
	}
}
 
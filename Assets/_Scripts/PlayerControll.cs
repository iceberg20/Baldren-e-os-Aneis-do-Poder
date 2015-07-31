using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	public GameObject players;

	public float speed;
	public Animator Anime;

	public Rigidbody2D	PlayerRigdbod;
	public int 			Force;
	// Use this for initpublic ialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis("Horizontal")*speed;

		players.transform.Translate (translation, 0 , 0);



		if(Input.GetKeyDown(KeyCode.UpArrow) || (players.transform.position.y <= 0))
		{
			PlayerRigdbod.AddForce(new Vector2(0,Force));
		}

		if(Input.GetKey(KeyCode.RightArrow) ||  Input.GetKey(KeyCode.LeftArrow))
		{
			Anime.SetBool("Walk",true);
			if(Input.GetKey(KeyCode.RightArrow))
				players.transform.localScale = new Vector3(1,1,1);
			else
				players.transform.localScale = new Vector3(-1,1,1);
		}
		else
			Anime.SetBool("Walk",false);

		if(Input.GetKey(KeyCode.Space))
		{
			Anime.SetBool("Attack",true);
			print ("space key was pressed");
		}
		else 
			Anime.SetBool("Attack", false);




	
	}
}	

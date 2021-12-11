using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCtrl : MonoBehaviour {

	private float SPEED = 4.6f;
	private GameObject money;
	public GameObject specEffect;
	[HideInInspector]
	public static Rigidbody2D ball;
	public static Sprite ballSprite;

	void Awake(){
		BallSprite();		
	}

	void Start () {
		specEffect.GetComponent<ParticleSystem>().Stop();	
		ball = GetComponent<Rigidbody2D>();

		//money // shit code
        money = GameObject.FindGameObjectWithTag("money");
		money.GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
		//money // shit code

		StartCoroutine(GoBall());
	}

	IEnumerator GoBall(){
		int dirX = Random.Range(-1,2);
		int dirY = Random.Range(-1,2);
		
		if(dirX == 0){
			dirX = 1; 
		}
		if(dirY == 0){
			dirY = 1; 
		}

		yield return new WaitForSeconds(0.5f);
		ball.AddForce(new Vector2(SPEED * dirX, SPEED * dirY), ForceMode2D.Force);
		
	}
	
	void Update(){
		//ball freeze
		if(ball.transform.position.y > 6.4f || ball.transform.position.y < -6.4f ){
			ball.velocity = Vector3.zero;
		}

		if(RingCtrl.through)
			specEffect.GetComponent<ParticleSystem>().Play();

		//const speed
		ball.velocity = ball.velocity.normalized * SPEED;

	}

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "wall" || col.gameObject.tag == "platform" || col.gameObject.tag == "ring"){
			if(PlayerPrefs.GetString("Sound") == "yes"){
				FindObjectOfType<AudioManager>().Play("bounce");
			}

			if(col.gameObject.tag == "wall" && transform.position.x > 0){
				ball.AddForce(Vector2.left, ForceMode2D.Force);
			}else if(col.gameObject.tag == "wall"  && transform.position.x < 0){
				ball.AddForce(Vector2.right, ForceMode2D.Force);
			}

			if(col.gameObject.tag == "platform" && transform.position.x > 0){
				ball.AddTorque(-5f, ForceMode2D.Force);
			}else if(col.gameObject.tag == "platform"  && transform.position.x < 0){
				ball.AddTorque(5f, ForceMode2D.Force);
			}

		}

			
    }

	void NormalBallSet(){
		SPEED = 5f;
		GetComponent<CircleCollider2D>().radius = 0.285f;
	}

	void FastBallSet(){
		SPEED = 6.5f;
		GetComponent<CircleCollider2D>().radius = 0.285f;
	}

	void BigBallSet(){
		SPEED = 4.2f;
		GetComponent<CircleCollider2D>().radius = 0.455f;
	}

	void SmallBallSet(){
		SPEED = 5.5f;
		GetComponent<CircleCollider2D>().radius = 0.165f;
	}

	//Skins
	void BallSprite(){
		//Acces to another script
		GameObject skinsInGameObj = GameObject.Find("SkinsInGame");
        SkinsInGame skinsInGame = skinsInGameObj.GetComponent<SkinsInGame>();

		switch(PlayerPrefs.GetString("BallInGame")){
			case "default":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("default");
				NormalBallSet();
				break;
			case "red":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("red");
				NormalBallSet();
				break;
			case "blue":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("blue");
				NormalBallSet();
				break;
			case "yellow":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("yellow");
				NormalBallSet();
				break;
			case "green":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("green");
				NormalBallSet();
				break;
			case "darkFast":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("darkFast");
				FastBallSet();
				break;
			case "fast":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("fast");
				FastBallSet();
				break;
			case "big":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("big");
				BigBallSet();
				break;
			case "small":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("small");
				SmallBallSet();
				break;
			case "light":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("light");
				NormalBallSet();
				break;
			case "spinner":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("spinner");
				NormalBallSet();
				break;
		}
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCtrl : MonoBehaviour {

	public Camera cam;
	private Vector3 pos;
	private bool isDraging = false;
	private float SPEED; 

	void Awake(){
		PlatformSprite();
	}

    void Update(){

		if(Input.GetMouseButtonDown(0)){
			isDraging = true;
	        SPEED = 5.8f * Time.deltaTime;
		}else if(Input.GetMouseButtonUp(0)){
			isDraging = false;
			SPEED = 0;
		}

		if(isDraging){
			pos = cam.ScreenToWorldPoint(Input.mousePosition);
		}
		Vector3 scr = cam.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0));

		if(GetComponent<SpriteRenderer>().sprite.name == "bigPlat"){
			if(pos.x > scr.x - 0.8f){
				pos.x =scr.x - 0.8f;
			}else if(pos.x < -scr.x + 0.8f){
				pos.x = -scr.x + 0.8f;
			}
		}else if(GetComponent<SpriteRenderer>().sprite.name == "smallPlat"){
			if(pos.x > scr.x - 0.5f){
				pos.x = scr.x - 0.5f;
			}else if(pos.x < -scr.x + 0.5f){
				pos.x = -scr.x + 0.5f;
			}
		}else{
			if(pos.x > scr.x - 0.6f){
				pos.x = scr.x - 0.6f;
			}else if(pos.x < -scr.x + 0.6f){
				pos.x = -scr.x + 0.6f;
			}
		}
		
		if(GetComponent<SpriteRenderer>().sprite.name == "fastPlat"){
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(pos.x,transform.position.y,transform.position.z), 8f);
		}else{
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(pos.x,transform.position.y,transform.position.z), SPEED);
		}

    }

	void NormalPlatformSet(){
		GetComponent<BoxCollider2D>().offset = new Vector2(-0.004953265f, 0);
		GetComponent<BoxCollider2D>().size = new Vector2(2.036906f, 0.37f);
		GetComponents<CircleCollider2D>()[0].offset = new Vector2(1.0183f, -0.0064f);
		GetComponents<CircleCollider2D>()[1].offset = new Vector2(-1.0183f, -0.0064f);
	}
	
	void BigPlatformSet(){
		GetComponent<BoxCollider2D>().offset = new Vector2(-0.005213082f, 0);
		GetComponent<BoxCollider2D>().size = new Vector2(2.940094f, 0.37f);
		GetComponents<CircleCollider2D>()[0].offset = new Vector2(-1.47f, -0.0064f);
		GetComponents<CircleCollider2D>()[1].offset = new Vector2(1.47f, -0.0064f);
	}

	void SmallPlatSet(){
		GetComponent<BoxCollider2D>().size = new Vector2(1.34f, 0.37f);
		GetComponents<CircleCollider2D>()[0].offset = new Vector2(-0.67f, -0.0064f);
		GetComponents<CircleCollider2D>()[1].offset = new Vector2(0.67f, -0.0064f);
	}

	//Skins
	void PlatformSprite(){
		//Acces to another script
		GameObject skinsInGameObj = GameObject.Find("SkinsInGame");
        SkinsInGame skinsInGame = skinsInGameObj.GetComponent<SkinsInGame>();

		switch(PlayerPrefs.GetString("PlatInGame")){
			case "platform":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("platform");
				NormalPlatformSet();
				break;
			case "redPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("redPlat");
				NormalPlatformSet();
				break;
			case "bluePlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("bluePlat");
				NormalPlatformSet();
				break;
			case "greenPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("greenPlat");
				NormalPlatformSet();
				break;
			case "bigPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("bigPlat");
				BigPlatformSet();
				break;
			case "smallPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("smallPlat");
				SmallPlatSet();
				break;
			case "lightPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("lightPlat");
				NormalPlatformSet();
				break;
			case "fastPlat":
				GetComponent<SpriteRenderer>().sprite = skinsInGame.GetSpriteByName("fastPlat");
				NormalPlatformSet();
				break;
		}
	}

}

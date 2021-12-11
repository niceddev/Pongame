using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class SignInGPGS : MonoBehaviour {

	void Awake(){
		PlayGamesPlatform.Activate();
	}

	void Start(){
		Social.localUser.Authenticate((bool success) => {
			Debug.Log("Здесь можно оставить все пустым?");
		});
	}

}

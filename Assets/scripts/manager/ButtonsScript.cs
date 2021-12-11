using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour {

	public string ANDROID_RATE_URL = "market://details?id=com.niceDev.Pongame";

	public void RateMyApp(){
		Application.OpenURL(ANDROID_RATE_URL);
	}

	public void ShowLeaderBoard(){
		Social.ShowLeaderboardUI();
	}

	public void CustomizeScene(){
		Initiate.Fade("shop", Color.black, 3f);
	}

	public void GameScene(){
		Initiate.Fade("main", Color.black, 3f);
	}

	public void MenuScene(){
		Initiate.Fade("menu", Color.black, 3f);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleShareAds : MonoBehaviour {

	public GameObject ads, share;

	void Start () {
		if(PlayerPrefs.GetString("RemoveAds") != "yes"){
			ads.SetActive(true);
			share.SetActive(false);
		}else{
			share.SetActive(true);
			ads.SetActive(false);
		}
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour {

	public Sprite soundOn, soundOff;
	
	void Start(){
		if(!PlayerPrefs.HasKey("Sound")){
			PlayerPrefs.SetString("Sound","yes");
		}else{
			if(PlayerPrefs.GetString("Sound") == "no"){
				GameObject.Find("soundToggle").GetComponent<Image>().sprite = soundOff;
			}else{
				GameObject.Find("soundToggle").GetComponent<Image>().sprite = soundOn;
			}
		}
	}
	
	public void ToggleSound(){
		if(PlayerPrefs.GetString("Sound") == "no"){
			PlayerPrefs.SetString("Sound","yes");
			GameObject.Find("soundToggle").GetComponent<Image>().sprite = soundOn;
			FindObjectOfType<AudioManager>().Mute(false);
		}else{
			PlayerPrefs.SetString("Sound","no");
			GameObject.Find("soundToggle").GetComponent<Image>().sprite = soundOff;
			FindObjectOfType<AudioManager>().Mute(true);
		}
	}
}

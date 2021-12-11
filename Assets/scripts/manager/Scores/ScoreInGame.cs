using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreInGame : MonoBehaviour {

	public GameObject newRecord;

	void Update(){
		if(RingCtrl.count > PlayerPrefs.GetInt("Score")){
			newRecord.SetActive(true);
		}
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanel : MonoBehaviour {

	public GameObject UI;

	void OnMouseUp(){
		gameObject.SetActive(false);
		GameObject.Find("ball").GetComponent<BallCtrl>().enabled = true;
		GameObject.Find("spawnPos").GetComponent<InstantRing>().enabled = true;
		UI.SetActive(true);
	}

}

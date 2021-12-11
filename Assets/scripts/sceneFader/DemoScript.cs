using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {
	public string scene;
	public Color loadToColor = Color.white;

	void OnMouseUp(){
		Initiate.Fade(scene,loadToColor,3f);	
	}

}


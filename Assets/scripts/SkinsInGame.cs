using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SkinsInGame : MonoBehaviour {

	public Sprite[] sprites;
	private Sprite sprite;

	public Sprite GetSpriteByName(string name){
		foreach (Sprite s in sprites)
		{
			if(s.name == name)
			{
				sprite = s;
				break;
			}
		}


		return sprite;
	}

}

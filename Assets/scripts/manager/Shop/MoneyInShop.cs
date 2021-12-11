using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyInShop : MonoBehaviour {

	public Text money;

	void FixedUpdate () {
		money.text = PlayerPrefs.GetInt("Money").ToString();
	}
	
}

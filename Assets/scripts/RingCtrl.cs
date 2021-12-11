using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingCtrl : MonoBehaviour {

	public BoxCollider2D trigger;
    [HideInInspector]
    public static int count, coin;
    public static bool changePos, through;
    private GameObject score, money;

    void Start(){
        count = 0; coin = PlayerPrefs.GetInt("Money");
        through = false;
        changePos = false;
        score = GameObject.FindGameObjectWithTag("score");
        money = GameObject.FindGameObjectWithTag("money");
    }
    
	void OnTriggerEnter2D(Collider2D col) {		
        changePos = true;
        through = true;

        if(col.gameObject.tag == "ball"){
			if(PlayerPrefs.GetString("Sound") == "yes"){
				FindObjectOfType<AudioManager>().Play("ring");
			}
		}	

    }

	void OnTriggerExit2D(Collider2D col) {
		count++;
        if(PlayerPrefs.GetString("PlatInGame") == "smallPlat"){
            coin = coin + 2;
        }else{
            coin++;
        }
		score.GetComponent<Text>().text = count.ToString(); 
		money.GetComponent<Text>().text = coin.ToString();
        changePos = false;
        through = false;
        PlayerPrefs.SetInt("Money", coin);
    }

}

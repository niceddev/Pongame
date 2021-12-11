using UnityEngine;
using UnityEngine.UI;

public class ScoreInGameOver : MonoBehaviour {
	
	public Text score;

	void Update(){
		GetComponent<Text>().text = score.text;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject gameOver, score;
	private const string leaderBoard = "CgkI6brS478fEAIQAQ";

	void Update () {
		if(BallCtrl.ball.transform.position.y > 6.4f || BallCtrl.ball.transform.position.y < -6.4f){
			gameOver.SetActive(true);
			score.SetActive(false);
			if(PlayerPrefs.GetInt("Score") < RingCtrl.count){
				PlayerPrefs.SetInt("Score", RingCtrl.count);
				Social.ReportScore(RingCtrl.count, leaderBoard, (bool success) => {
					if(success){
						Debug.Log("High Score!");
					}
				});
			}
		}
	}
}

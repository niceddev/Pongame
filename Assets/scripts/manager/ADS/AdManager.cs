// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using AppodealAds.Unity.Api;
// using AppodealAds.Unity.Common;
 
// public class AdManager : MonoBehaviour, IRewardedVideoAdListener {
 
//     static int loadCount = 5;
 
// 	void Start () {
//         string appKey = "5daea5842681fce61e2eb4124344145d1df7ba005de5fb9e";
//         Appodeal.disableLocationPermissionCheck();
//         Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.BANNER | Appodeal.REWARDED_VIDEO); 
//         Appodeal.setRewardedVideoCallbacks(this);

//         if(SceneManager.GetActiveScene().name == "menu"){
//             ShowBanner();
//         }else{
//             HideBanner();
//         }

//         if (loadCount == 0 && SceneManager.GetActiveScene().name == "main"){
//             ShowInterstitial();
//             loadCount = 5;
//         }
//         if(SceneManager.GetActiveScene().name == "main"){
//             loadCount--;    
//         }
        
//     }
 
//     public void ShowBanner(){
//         if (Appodeal.isLoaded(Appodeal.BANNER) && PlayerPrefs.GetString("RemoveAds") != "yes")
//             Appodeal.show(Appodeal.BANNER_BOTTOM);
//     }

//     public void HideBanner(){
//         Appodeal.hide(Appodeal.BANNER);
//     }
 
//     public void ShowInterstitial(){
//         if (Appodeal.isLoaded(Appodeal.INTERSTITIAL) && PlayerPrefs.GetString("RemoveAds") != "yes")
//         {
//             Appodeal.show(Appodeal.INTERSTITIAL);
//         }
//     }
 
//     public void ShowRewarded(){
//         if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
//             Appodeal.show(Appodeal.REWARDED_VIDEO);
//     }
 
//    #region Rewarded Video callback handlers

// 		public void onRewardedVideoLoaded() {  }
// 		public void onRewardedVideoFailedToLoad() {  }
// 		public void onRewardedVideoShown() {  }
// 		public void onRewardedVideoClosed(bool finished) {	}
// 		public void onRewardedVideoFinished(int amount, string name) { 
// 			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 10);

//             if(GameObject.FindGameObjectWithTag("money") != null){
//                 GameObject.FindGameObjectWithTag("money").GetComponent<Text>().text = (int.Parse(GameObject.FindGameObjectWithTag("money").GetComponent<Text>().text) + 10).ToString();
//             }
// 		}

// 	#endregion

// }
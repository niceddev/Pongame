using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour {

	public Transform selectedBall, selectedPlat;
	public RectTransform ballScrollView, platScrollView;
	public GameObject ballButton, platButton;
	public GameObject lockPrefab;
	private GameObject tempBallSelected, tempPlatSelected;
	private	Dictionary<int, string> skins;	
	void Start(){
		DictionatrySkins();

		if(PlayerPrefs.HasKey("SelectedBall") && PlayerPrefs.HasKey("SelectedPlat")){
			tempBallSelected = GameObject.Find(PlayerPrefs.GetString("SelectedBall"));
			tempPlatSelected = GameObject.Find(PlayerPrefs.GetString("SelectedPlat"));
			selectedBall.SetParent(tempBallSelected.transform);
			selectedPlat.SetParent(tempPlatSelected.transform);
		}else if(PlayerPrefs.HasKey("SelectedBall")){
			tempBallSelected = GameObject.Find(PlayerPrefs.GetString("SelectedBall"));
			selectedBall.SetParent(tempBallSelected.transform);
		}else if(PlayerPrefs.HasKey("SelectedPlat")){
			tempPlatSelected = GameObject.Find(PlayerPrefs.GetString("SelectedPlat"));
			selectedPlat.SetParent(tempPlatSelected.transform);
		}
		
		CreateLocks();

	}
	
	void Update(){
		if(Input.GetKey(KeyCode.Escape))
		{
			Initiate.Fade("menu", Color.black, 3f);
		}
	}

	public void SelectBall(){

		//selecting line
		if(!EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)")){
			selectedBall.transform.SetParent(EventSystem.current.currentSelectedGameObject.transform);
			selectedBall.transform.localPosition = new Vector2(0, -60f);
			selectedBall.transform.localScale = new Vector3(1,1,1);

			//prevSelected
			PlayerPrefs.SetString("SelectedBall", EventSystem.current.currentSelectedGameObject.name.ToString());
			
			//saving ball asset's name to use it in the game
			PlayerPrefs.SetString("BallInGame", EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.name.ToString());

		}else{
			if(int.Parse(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").transform.Find("Text").GetComponent<Text>().text) <= PlayerPrefs.GetInt("Money")){

				Destroy(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").gameObject);

				PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - int.Parse(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").transform.Find("Text").GetComponent<Text>().text));

				PlayerPrefs.SetInt(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.name, 1);

			}else{
				Debug.Log("bomz");
			}
		}

	}

	public void SelectPlatform(){

		//selecting line
		if(!EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)")){
			selectedPlat.transform.SetParent(EventSystem.current.currentSelectedGameObject.transform);
			selectedPlat.transform.localPosition = new Vector2(0, -60f);
			selectedPlat.transform.localScale = new Vector3(1,1,1);

			//prevSelected
			PlayerPrefs.SetString("SelectedPlat", EventSystem.current.currentSelectedGameObject.name.ToString());

			//saving plat asset's name to use it in the game
			PlayerPrefs.SetString("PlatInGame", EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.name.ToString());
		}else{
			if(int.Parse(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").transform.Find("Text").GetComponent<Text>().text) <= PlayerPrefs.GetInt("Money")){

				Destroy(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").gameObject);

				PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - int.Parse(EventSystem.current.currentSelectedGameObject.transform.Find("locked(Clone)").transform.Find("Text").GetComponent<Text>().text));

				PlayerPrefs.SetInt(EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.name, 1);

			}else{
				Debug.Log("bomz");
			}
		}

	}

	public void BallContent(){
		ballScrollView.position = new Vector3(ballScrollView.position.x,ballScrollView.position.y, 0); 
		platScrollView.position = new Vector3(platScrollView.position.x,platScrollView.position.y, -15f); 

		ballButton.GetComponent<Image>().color = new Color32(252,112,0,255);
		platButton.GetComponent<Image>().color = Color.black;
	}

	public void PlatContent(){		
		platScrollView.position = new Vector3(platScrollView.position.x,platScrollView.position.y, 0); 
		ballScrollView.position = new Vector3(ballScrollView.position.x,ballScrollView.position.y, -15f); 

		platButton.GetComponent<Image>().color = new Color32(252,112,0,255);
		ballButton.GetComponent<Image>().color = Color.black;
	}

	void CreateLocks(){
		foreach (GameObject item in GameObject.FindGameObjectsWithTag("button")){
			GameObject lockPrefabObj = Instantiate(lockPrefab, item.transform.position, Quaternion.identity);
			lockPrefabObj.transform.SetParent(item.transform);
			lockPrefabObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,0,0);
			lockPrefabObj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

			// PRICES
			//ball's
			if(item.transform.Find("big") || item.transform.Find("small")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 30.ToString();
			}
			if(item.transform.Find("light")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 50.ToString();
			}
			if(item.transform.Find("spinner")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 65.ToString();
			}
			if(item.transform.Find("fast")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 80.ToString();
			}
			if(item.transform.Find("darkFast")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 100.ToString();
			}
			//plat's
			if(item.transform.Find("smallPlat")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 30.ToString();
			}
			if(item.transform.Find("lightPlat")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 50.ToString();
			}
			if(item.transform.Find("bigPlat")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 100.ToString();
			}
			if(item.transform.Find("fastPlat")){
				lockPrefabObj.transform.Find("Text").GetComponent<Text>().text = 150.ToString();
			}
			// UNLOCKED ITEMS

			for(int i = 1; i <= skins.Count; i++){
				if(PlayerPrefs.HasKey(skins[i]) && lockPrefabObj.transform.parent.transform.Find(skins[i])){
					Destroy(lockPrefabObj);
				}
				Debug.Log(skins[i]);
			}
		}
	}

	void DictionatrySkins(){

		skins = new Dictionary<int, string>();

		skins.Add(1,"red");
		skins.Add(2,"green");
		skins.Add(3,"blue");
		skins.Add(4,"yellow");
		skins.Add(5,"big");
		skins.Add(6,"small");
		skins.Add(7,"light");
		skins.Add(8,"fast");
		skins.Add(9,"darkFast");
		skins.Add(10,"spinner");
		skins.Add(11,"redPlat");
		skins.Add(12,"bluePlat");
		skins.Add(13,"greenPlat");
		skins.Add(14,"smallPlat");
		skins.Add(15,"lightPlat");
		skins.Add(16,"bigPlat");
		skins.Add(17,"fastPlat");

	}
	
}

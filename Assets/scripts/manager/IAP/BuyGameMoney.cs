using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class BuyGameMoney : MonoBehaviour {

	public Text money;

    private void Start () {
        PurchaseManager.OnPurchaseConsumable += PurchaseManager_OnPurchaseConsumable;
        PurchaseManager.OnPurchaseNonConsumable += PurchaseManager_OnPurchaseNonConsumable;
	}

	private void PurchaseManager_OnPurchaseConsumable(PurchaseEventArgs args){
		if(args.purchasedProduct.definition.id == "money30_add"){
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 30);
		}else if(args.purchasedProduct.definition.id == "money60_add"){
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 60);
		}else if(args.purchasedProduct.definition.id == "money150_add"){
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 150);
		}
	}
	
	private void PurchaseManager_OnPurchaseNonConsumable(PurchaseEventArgs args){

		if(args.purchasedProduct.definition.id == "remove_ads"){
			PlayerPrefs.SetString("RemoveAds", "yes");
		}

	}
	
}

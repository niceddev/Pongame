using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantRing : MonoBehaviour {

	
	public Transform[] spawnPos;
	public GameObject objPrefab;
	int index, index2;
	Transform pos, pos2;
	GameObject obj;

	void Start(){
		index = Random.Range(0,spawnPos.Length);
		pos = spawnPos[index];
		
	    StartCoroutine(RingGo());
	}
	
	IEnumerator RingGo(){
		yield return new WaitForSeconds(0.85f);
		obj = Instantiate(objPrefab,pos.position, Quaternion.Euler(-102.389f,0,0)) as GameObject;
        obj.transform.SetParent(pos.transform);
		pos.transform.Rotate(0, 0, Random.Range(0f, 360f));
	}

    void FixedUpdate(){
        index2 = Random.Range(0,spawnPos.Length);
		pos2 = spawnPos[index2];

        if(RingCtrl.changePos){

			obj.transform.SetParent(pos2.transform);
			obj.transform.position = pos2.transform.position;
			foreach (Transform item in spawnPos)
			{
				item.Rotate(0, 0, Random.Range(0f, 360f));
			}

		}

		
    }
}

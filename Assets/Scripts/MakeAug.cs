using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeAug : MonoBehaviour {
	public GameObject spawn;

	public void InstantiateAug(string type){
		if(GameObject.Find("GameState").GetComponent<State>().Money>=15){
			GameObject.Find("GameState").GetComponent<State>().Money-=15;
			GameObject.Find("Money").GetComponent<Text>().text="Currency: "+GameObject.Find("GameState").GetComponent<State>().Money;
			GameObject newAug= Instantiate(spawn,new Vector3(10,1,10),Quaternion.identity) as GameObject;
			newAug.GetComponent<Aug> ().type = type;
			if(type=="damage"){
				newAug.renderer.material.color=Color.black;
			}
			if(type=="fire"){
				newAug.renderer.material.color=Color.red;
			}
		}

	}
}

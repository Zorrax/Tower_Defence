using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Aug : MonoBehaviour {
	public Text tooltip;
	public int level = 1;
	public int augID=0;
	public string type;
	public float specialchance=0;


	public void Updatetooltip(){
		tooltip.text = "Type: "+type+"\nLevel: " + level+"\nSpecial: "+specialchance;
	}
	public void LevelUp(){
		if(GameObject.Find("GameState").GetComponent<State>().Money>=15){
			GameObject.Find("GameState").GetComponent<State>().Money-=15;
			GameObject.Find("Money").GetComponent<Text>().text="Currency: "+GameObject.Find("GameState").GetComponent<State>().Money;
			level++;
		}
			Updatetooltip ();
	}

}

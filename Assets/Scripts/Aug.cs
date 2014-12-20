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
		tooltip.text = "Level: " + level;
	}

}

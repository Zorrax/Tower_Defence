using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updatebarphys : MonoBehaviour {

	public GameObject mob;
	
	// Update is called once per frame
	void Update () {
		if(mob!=null){ 
			gameObject.GetComponent<Image> ().fillAmount = mob.GetComponent<Healthbar> ().me.PhysicalResistance/100f;
		}
	}
}
